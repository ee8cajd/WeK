#region Using Statements

using System;

using Madcow.Network.Management;

using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Madcow.UnitTest.Network.Management
{
    /// <summary>
    /// UnitTests for Madcow.Network.Management.PhysicalAddress.
    /// </summary>
    [TestClass]
    public class PhysicalAddressTest
    {
        #region Constructors

        public PhysicalAddressTest()
        {

        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void Equals()
        {
            PhysicalAddress Control = new PhysicalAddress(new byte[] { 0xea, 0x30, 0xcd, 0x3b, 0x21, 0xdf });
            PhysicalAddress TestEqual = new PhysicalAddress(new byte[] { 0xEA, 0x30, 0xCD, 0x3B, 0x21, 0xDF });
            PhysicalAddress TestDifferent1 = new PhysicalAddress(new byte[] { 0xeb, 0x30, 0xcd, 0x3b, 0x21, 0xdf });
            PhysicalAddress TestDifferent2 = new PhysicalAddress(new byte[] { 0xea, 0x30, 0xcd, 0x3b, 0x21, 0xde });
            PhysicalAddress TestDifferent3 = new PhysicalAddress(new byte[] { 0xea, 0x30, 0xce, 0x3b, 0x21, 0xdf });
            PhysicalAddress TestDifferent4 = PhysicalAddress.None;

            Assert.AreEqual(Control, TestEqual, "Madcow.Network.Management.PhysicalAddress.Equals failed; Equal PhysicalAddresses have been reported as unequal.");
            Assert.IsTrue(Control == TestEqual, "Madcow.Network.Management.PhysicalAddress.Equals failed; Equal PhysicalAddresses have been reported as unequal (==).");
            Assert.AreNotEqual(Control, TestDifferent1, "Madcow.Network.Management.PhysicalAddress.Equals failed; Unequal (first byte) PhysicalAddresses have been reported as equal.");
            Assert.AreNotEqual(Control, TestDifferent2, "Madcow.Network.Management.PhysicalAddress.Equals failed; Unequal (last byte) PhysicalAddresses have been reported as equal.");
            Assert.AreNotEqual(Control, TestDifferent3, "Madcow.Network.Management.PhysicalAddress.Equals failed; Unequal (third byte) PhysicalAddresses have been reported as equal.");
            Assert.AreNotEqual(Control, TestDifferent4, "Madcow.Network.Management.PhysicalAddress.Equals failed; Unequal (compared with 'None') PhysicalAddresses have been reported as equal.");
        }

        [TestMethod]
        public void ToStringColonSeparatedUppercase()
        {
            PhysicalAddress TestAddress = new PhysicalAddress(new byte[] { 0xea, 0x30, 0xcd, 0x3b, 0x21, 0xdf });

            string Result = TestAddress.ToString("C", null);

            Assert.IsNotNull(Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format 'C' did not return a string representation.");
            Assert.AreEqual<string>(@"EA:30:CD:3B:21:DF", Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format 'C' did not return the expected result.");
        }

        [TestMethod]
        public void ToStringColonSeparatedLowercase()
        {
            PhysicalAddress TestAddress = new PhysicalAddress(new byte[] { 0xea, 0x30, 0xcd, 0x3b, 0x21, 0xdf });

            string Result = TestAddress.ToString("c", null);

            Assert.IsNotNull(Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format 'c' did not return a string representation.");
            Assert.AreEqual<string>(@"ea:30:cd:3b:21:df", Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format 'c' did not return the expected result.");
        }

        [TestMethod]
        public void ToStringDashSeparatedUppercase()
        {
            PhysicalAddress TestAddress = new PhysicalAddress(new byte[] { 0xea, 0x30, 0xcd, 0x3b, 0x21, 0xdf });

            string Result = TestAddress.ToString("D", null);

            Assert.IsNotNull(Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format 'D' did not return a string representation.");
            Assert.AreEqual<string>(@"EA-30-CD-3B-21-DF", Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format 'D' did not return the expected result.");
        }

        [TestMethod]
        public void ToStringDashSeparatedLowercase()
        {
            PhysicalAddress TestAddress = new PhysicalAddress(new byte[] { 0xea, 0x30, 0xcd, 0x3b, 0x21, 0xdf });

            string Result = TestAddress.ToString("d", null);

            Assert.IsNotNull(Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format 'd' did not return a string representation.");
            Assert.AreEqual<string>(@"ea-30-cd-3b-21-df", Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format 'd' did not return the expected result.");
        }

        [TestMethod]
        public void ToStringGeneralUppercase()
        {
            PhysicalAddress TestAddress = new PhysicalAddress(new byte[] { 0xea, 0x30, 0xcd, 0x3b, 0x21, 0xdf });

            string Result = TestAddress.ToString("G", null);

            Assert.IsNotNull(Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format 'G' did not return a string representation.");
            Assert.AreEqual<string>(@"EA30CD3B21DF", Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format 'G' did not return the expected result.");
        }

        [TestMethod]
        public void ToStringGeneralLowercase()
        {
            PhysicalAddress TestAddress = new PhysicalAddress(new byte[] { 0xea, 0x30, 0xcd, 0x3b, 0x21, 0xdf });

            string Result = TestAddress.ToString("g", null);

            Assert.IsNotNull(Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format 'g' did not return a string representation.");
            Assert.AreEqual<string>(@"ea30cd3b21df", Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format 'g' did not return the expected result.");
        }

        [TestMethod]
        public void ToStringNullAndEmpty()
        {
            PhysicalAddress TestAddress = new PhysicalAddress(new byte[] { 0xea, 0x30, 0xcd, 0x3b, 0x21, 0xdf });

            string Result = TestAddress.ToString();

            Assert.IsNotNull(Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format <null> did not return a string representation.");
            Assert.AreEqual<string>(@"EA30CD3B21DF", Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format <null> did not return the expected result.");

            Result = TestAddress.ToString(String.Empty, null);

            Assert.IsNotNull(Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format \"\" did not return a string representation.");
            Assert.AreEqual<string>(@"EA30CD3B21DF", Result, "Madcow.Network.Management.PhysicalAddress.ToString failed; Format \"\" did not return the expected result.");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToStringInvalidFormat()
        {
            PhysicalAddress TestAddress = new PhysicalAddress(new byte[] { 0xea, 0x30, 0xcd, 0x3b, 0x21, 0xdf });

            string Result = TestAddress.ToString("Q", null);
        }

        [TestMethod]
        public void TryParseTest()
        {
            PhysicalAddress ValidMac1 = new PhysicalAddress(new byte[] { 0xEA, 0x36, 0xC4, 0x77, 0xFD, 0x29 });
            PhysicalAddress ValidMac2 = new PhysicalAddress(new byte[] { 0x29, 0xFD, 0x77, 0xC4, 0x36, 0xEA });
            PhysicalAddress ValidMac3 = new PhysicalAddress(new byte[] { 0x77, 0x29, 0x36, 0xFD, 0xEA, 0xC4 });

            string[] BadMacs = new string[] {
                "GG:36:C4:77:FD:29",
                "EA-36-C4-77-FD-GG",
                "ea-36-c4;77-fd-29",
                "ea36c477fdgg",
                "ea36c466f22984"
            };

            PhysicalAddress Result;
            Assert.IsTrue(PhysicalAddress.TryParse(ValidMac1.ToString("C", null), out Result), "Madcow.Network.Management.PhysicalAddress.TryParse failed; Method returned failure (C).");
            Assert.AreEqual<string>(ValidMac1.ToString("C", null), Result.ToString("C", null), "Madcow.Network.Management.PhysicalAddress.TryParse failed; 'C' Parse operation produced incorrect results.");

            Assert.IsTrue(PhysicalAddress.TryParse(ValidMac2.ToString("D", null), out Result), "Madcow.Network.Management.PhysicalAddress.TryParse failed; Method returned failure (D).");
            Assert.AreEqual<string>(ValidMac2.ToString("D", null), Result.ToString("D", null), "Madcow.Network.Management.PhysicalAddress.TryParse failed; 'D' Parse operation produced incorrect results.");

            Assert.IsTrue(PhysicalAddress.TryParse(ValidMac3.ToString("G", null), out Result), "Madcow.Network.Management.PhysicalAddress.TryParse failed; Method returned failure (G).");
            Assert.AreEqual<string>(ValidMac3.ToString("G", null), Result.ToString("G", null), "Madcow.Network.Management.PhysicalAddress.TryParse failed; 'G' Parse operation produced incorrect results.");

            Assert.IsTrue(PhysicalAddress.TryParse(null, out Result), "Madcow.Network.Management.PhysicalAddress.TryParse failed; Method returned failure.");
            Assert.AreEqual(PhysicalAddress.None, Result, "Madcow.Network.Management.PhysicalAddress.TryParse failed; Method did not return 'None' on null entry.");

            for (int i = 0; i < BadMacs.Length; i++)
            {
                Assert.IsFalse(PhysicalAddress.TryParse(BadMacs[i], out Result), String.Format("Madcow.Network.Management.PhysicalAddress.TryParse failed; Method did not detect bad MAC address {0}.", i));
            }

            Assert.IsTrue(PhysicalAddress.TryParse("EA-36-C4:77-FD-29", out Result), "Madcow.Network.Management.PhysicalAddress.TryParse failed; Method returned failure (mixed delimiters).");
        }

        #endregion
    }
}
