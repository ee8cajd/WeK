/*

WeK - A magic packet Wake On LAN Utility for Microsoft Windows.
Copyright © 2009 Chris Dickson

WeK is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as 
published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

WeK is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

*/

#region Using Statements

using System;
using System.Net;
using System.Net.Sockets;

#endregion

namespace Madcow.Network.Management
{
    /// <summary>
    /// Class providing a high level interface to Wake On LAN host control functionality.
    /// </summary>
    public class WakeOnLan
    {
        #region Public Methods

        /// <summary>
        /// Send a Wake On LAN request to a machine.
        /// </summary>
        /// <param name="machineAddress">The MAC Address of the machine to be woken.</param>
        /// <returns></returns>
        public static bool WakeMachine(PhysicalAddress machineAddress)
        {
            return WakeMachine(machineAddress, null, null, null);
        }

        /// <summary>
        /// Send a Wake On LAN request to a machine.
        /// </summary>
        /// <param name="machineAddress">The MAC Address of the machine to be woken.</param>
        /// <param name="remoteHost">The remote host address and port of the machine to be woken.</param>
        /// <param name="hostSubnetMask">The subnet mask for the network on which the machine to be woken resides.</param>
        /// <returns></returns>
        public static bool WakeMachine(PhysicalAddress machineAddress,
                                       IPEndPoint remoteHostToWake,
                                       IPAddress remoteHostSubnetMask)
        {
            return WakeMachine(machineAddress, null, remoteHostToWake, remoteHostSubnetMask);
        }

        /// <summary>
        /// Send a Wake On LAN request to a machine.
        /// </summary>
        /// <param name="machineAddress">The MAC Address of the machine to be woken.</param>
        /// <param name="secureOnPassword">The password required by the machine to be woken.</param>
        /// <returns></returns>
        public static bool WakeMachine(PhysicalAddress machineAddress, PhysicalAddress secureOnPassword)
        {
            return WakeMachine(machineAddress, secureOnPassword, null, null);
        }

        /// <summary>
        /// Send a Wake On LAN request to a machine.
        /// </summary>
        /// <param name="machineAddress">The MAC Address of the machine to be woken.</param>
        /// <param name="secureOnPassword">The password required by the machine to be woken.</param>
        /// <param name="remoteHost">The remote host address and port of the machine to be woken.</param>
        /// <param name="hostSubnetMask">The subnet mask for the network on which the machine to be woken resides.</param>
        /// <returns></returns>
        public static bool WakeMachine(PhysicalAddress machineAddress,
                                       PhysicalAddress secureOnPassword,
                                       IPEndPoint remoteHostToWake,
                                       IPAddress remoteHostSubnetMask)
        {
            bool PacketSent = true;

            int FrameSize = 6 * 17;
            bool SecureOnPasswordRequired = (secureOnPassword != null && secureOnPassword != PhysicalAddress.None);

            if (SecureOnPasswordRequired)
            {
                FrameSize += 6;
            }

            byte[] WolFrame = new byte[FrameSize];

            // Set the synchronization sequence.
            Array.Copy(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, 0, WolFrame, 0, 6);

            // Set the SecureOn password, if specified.
            if (SecureOnPasswordRequired)
            {
                Array.Copy(secureOnPassword.GetAddressBytes(), 0, WolFrame, FrameSize - 6, 6);
            }

            // Set the main payload of the frame.
            byte[] PayloadMac = machineAddress.GetAddressBytes();
            int PayloadEnd = FrameSize - (SecureOnPasswordRequired ? 12 : 6);

            for (int i = 6; i <= PayloadEnd; i += 6)
            {
                Array.Copy(PayloadMac, 0, WolFrame, i, 6);
            }

            try
            {
                // Send the frame out on the network.
                using (UdpClient WolNetwork = new UdpClient())
                {
                    IPEndPoint WakeEndpoint;

                    if (remoteHostToWake == null || remoteHostSubnetMask == null)
                    {
                        WakeEndpoint = new IPEndPoint(IPAddress.Broadcast, 0);
                    }
                    else
                    {
                        WakeEndpoint = CalculateSubnetBroadcastAddress(remoteHostToWake, remoteHostSubnetMask);
                    }

                    WolNetwork.Connect(WakeEndpoint);
                    WolNetwork.Send(WolFrame, WolFrame.Length);
                }
            }
            catch (SocketException)
            {
                PacketSent = false;
            }

            return PacketSent;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Calculates the broadcast address for a given IP address and subnet mask.
        /// </summary>
        /// <param name="remoteHost">The remote host IP address.</param>
        /// <param name="hostSubnetMask">The subnet mask defining the network in which the given IP address operates.</param>
        /// <returns>A new IPEndpoint object initialised to the broadcast address for the remoteHost supplied.</returns>
        private static IPEndPoint CalculateSubnetBroadcastAddress(IPEndPoint remoteHost, IPAddress hostSubnetMask)
        {
            IPEndPoint WakeEndpoint;

            // Calculate the broadcast address required for IP Directed Broadcast.
            byte[] BroadcastAddressBytes = remoteHost.Address.GetAddressBytes();
            byte[] HostSubnetMaskBytes = hostSubnetMask.GetAddressBytes();

            if (BroadcastAddressBytes.Length == HostSubnetMaskBytes.Length)
            {
                for (int i = 0; i < BroadcastAddressBytes.Length; i++)
                {
                    BroadcastAddressBytes[i] |= (byte)~HostSubnetMaskBytes[i];
                }

                WakeEndpoint = new IPEndPoint(new IPAddress(BroadcastAddressBytes), remoteHost.Port);
            }
            else
            {
                throw new InvalidOperationException("Unable to convert host address to directed broadcast subnet address.");
            }

            return WakeEndpoint;
        }

        #endregion
    }
}
