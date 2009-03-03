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
using System.Collections.Generic;
using System.Text;

#endregion

namespace Madcow.Network.Management
{
    /// <summary>
    /// 
    /// </summary>
    public class PhysicalAddress : IFormattable
    {
        #region Private Members

        private byte[] _physicalAddress;

        #endregion

        #region Public Members

        /// <summary>
        /// 
        /// </summary>
        public static readonly PhysicalAddress None;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        static PhysicalAddress()
        {
            None = new PhysicalAddress(new byte[0]);
        }

        /// <summary>
        /// Initializes a new instance of the System.Net.NetworkInformation.PhysicalAddress class.
        /// </summary>
        /// <param name="address">A System.Byte array containing the address.</param>
        public PhysicalAddress(byte[] address)
        {
            this._physicalAddress = address;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a deep copy of this Physical Address object.
        /// </summary>
        /// <returns>The new, deep-copied Physical Address object.</returns>
        public PhysicalAddress Clone()
        {
            // Use GetAddressBytes() which performs a deep copy.
            return new PhysicalAddress(this.GetAddressBytes());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparand"></param>
        /// <returns></returns>
        public override bool Equals(object comparand)
        {
            return Equals(comparand as PhysicalAddress);
        }

        /// <summary>
        /// Compares two Physical Address objects for equality of their values.
        /// </summary>
        /// <param name="comparand">The Physical Address object with which this Physical Address is compared.</param>
        /// <returns>True if the two Physical Address objects have the same value.</returns>
        public bool Equals(PhysicalAddress comparand)
        {
            bool AreEqual = comparand != null && _physicalAddress.Length == comparand._physicalAddress.Length;

            for (int i = 0; (i < _physicalAddress.Length) && AreEqual; i++)
            {
                AreEqual = (_physicalAddress[i] == comparand._physicalAddress[i]);
            }

            return AreEqual;
        }

        /// <summary>
        /// Retrieves the value represented by this Physical Address object.
        /// </summary>
        /// <returns>Byte array containing the Physical Address value.</returns>
        public byte[] GetAddressBytes()
        {
            byte[] AddressCopy = new byte[this._physicalAddress.Length];
            Buffer.BlockCopy(this._physicalAddress, 0, AddressCopy, 0, this._physicalAddress.Length);

            return AddressCopy;
        }

        /// <summary>
        /// Converts the value of the current PhysicalAddress object to its equivalent, default string representation.
        /// </summary>
        /// <returns>The string representation of the current PhysicalAddress object.</returns>
        public override string ToString()
        {
            return ToString(null, null);
        }

        /// <summary>
        /// Converts the value of the current PhysicalAddress object to its equivalent string representation using the specified format.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the current PhysicalAddress object, formatted as specified by the format parameter.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            string Address;

            switch (format)
            {
                case "c":
                case "C":
                    Address = String.Join(":", Array.ConvertAll<byte, string>(_physicalAddress, ConvertByteToHexString(Char.IsUpper(format, 0))));
                    break;

                case "d":
                case "D":
                    Address = String.Join("-", Array.ConvertAll<byte, string>(_physicalAddress, ConvertByteToHexString(Char.IsUpper(format, 0))));
                    break;

                case "g":
                case "G":
                case "":
                case null:
                    if (String.IsNullOrEmpty(format))
                    {
                        Address = String.Join(String.Empty, Array.ConvertAll<byte, string>(_physicalAddress, ConvertByteToHexString(true)));
                    }
                    else
                    {
                        Address = String.Join(String.Empty, Array.ConvertAll<byte, string>(_physicalAddress, ConvertByteToHexString(Char.IsUpper(format, 0))));
                    }
                    break;

                default:
                    throw new FormatException(String.Format("Invalid format string: '{0}'.", format));
            }

            return Address;
        }

        /// <summary>
        /// Attempts to convert a string representation of a Physical Address to a Physical Address object.
        /// </summary>
        /// <param name="address">The string representation of the Physcial Address.</param>
        /// <param name="result">A Physical Address object set to the value of the converted string representation.</param>
        /// <returns>True if the conversion was successful and <paramref name="result">result</paramref> is valid.</returns>
        public static bool TryParse(string address, out PhysicalAddress result)
        {
            bool Success = true;
            result = null;

            // If no address has been provided, return PhysicalAddress.None.
            if (String.IsNullOrEmpty(address))
            {
                result = None;
            }
            else
            {
                try
                {
                    byte[] MacBytes = new byte[6];
                    string[] MacComponents = address.Split(new char[] { '-', ':' });

                    // This method will only support 48-bit MAC addresses with consistent separators. If there
                    // are no separators, the MAC address must be 12 hex digits.
                    if (MacComponents.Length == 6)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            MacBytes[i] = Convert.ToByte(MacComponents[i], 16);
                        }
                    }
                    else if (MacComponents.Length == 1 && MacComponents[0].Length == 12)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            MacBytes[i] = Convert.ToByte(MacComponents[0].Substring(i * 2, 2), 16);
                        }
                    }
                    else
                    {
                        Success = false;
                    }

                    result = new PhysicalAddress(MacBytes);
                }
                catch (FormatException)
                {
                    Success = false;
                    result = null;
                }
            }

            return Success;
        }

        #endregion

        #region Operator Overrides

        /// <summary>
        /// Implements the equality operator for testing the values of two Physical Address objects.
        /// </summary>
        /// <param name="physicalAddress1"></param>
        /// <param name="physicalAddress2"></param>
        /// <returns>True if the two Physcial Address objects have the same value.</returns>
        public static bool operator==(PhysicalAddress physicalAddress1, PhysicalAddress physicalAddress2)
        {
            bool AreEqual = true;

            if (Object.ReferenceEquals(physicalAddress1, null))
            {
                AreEqual = Object.ReferenceEquals(physicalAddress2, null);
            }
            else
            {
                AreEqual = physicalAddress1.Equals(physicalAddress2);
            }

            return AreEqual;
        }

        /// <summary>
        /// Implements the inequality operator for testing the values of two Physical Address objects.
        /// </summary>
        /// <param name="physicalAddress1"></param>
        /// <param name="physicalAddress2"></param>
        /// <returns>True if the two Physcial Address objects do not have the same value.</returns>
        public static bool operator !=(PhysicalAddress physicalAddress1, PhysicalAddress physicalAddress2)
        {
            return (physicalAddress1 == physicalAddress2) == false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Return a Converter delegate that converts a System.Byte object to a two digit 
        /// hex equivalent string of the given byte value.
        /// </summary>
        /// <param name="hexUpper">Flag indicating whether the delegate should return an uppercase hex equivalent.</param>
        /// <returns>Converter delegate to convert a byte into an equivalent string.</returns>
        private Converter<byte, string> ConvertByteToHexString(bool hexUpper)
        {
            return delegate(byte source) { return source.ToString(hexUpper ? "X2" : "x2"); };
        }

        #endregion
    }
}
