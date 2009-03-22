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
    /// 
    /// </summary>
    public class WakeOnLan
    {
        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="machineAddress"></param>
        /// <returns></returns>
        public static bool WakeMachine(PhysicalAddress machineAddress)
        {
            return WakeMachine(machineAddress, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="machineAddress"></param>
        /// <param name="secureOnPassword"></param>
        /// <returns></returns>
        public static bool WakeMachine(PhysicalAddress machineAddress, PhysicalAddress secureOnPassword)
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

            for (int i = 6; i <= PayloadEnd ; i += 6)
            {
                Array.Copy(PayloadMac, 0, WolFrame, i, 6);
            }

            try
            {
                // Send the frame out on the network.
                using (UdpClient WolNetwork = new UdpClient())
                {
                    WolNetwork.Connect(IPAddress.Broadcast, 0);
                    WolNetwork.Send(WolFrame, WolFrame.Length);
                }
            }
            catch (SocketException SockEx)
            {
                PacketSent = false;
            }

            return PacketSent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="machineAddress"></param>
        public static void WakeMachineAsync(PhysicalAddress machineAddress)
        {

        }

        #endregion

        #region Private Methods

#if DEBUG

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="filename"></param>
        private void DumpWolFrameToFile(byte[] frame, string filename)
        {
            System.Text.StringBuilder FrameData = new System.Text.StringBuilder();
            
            for (int i = 0; i < frame.Length; i++)
            {
                if ((i + 1) % 6 != 0)
                {
                    FrameData.Append(frame[i].ToString("X2"));
                }
                else
                {
                    FrameData.AppendLine(frame[i].ToString("X2"));
                }
            }

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
            {
                sw.Write(FrameData.ToString());
            }
        }

#endif

        #endregion
    }
}
