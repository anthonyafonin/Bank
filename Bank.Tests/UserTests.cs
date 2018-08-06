using System;
using Bank.AppNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void PasswordGetsHashed()
        {
            var plaintext = "TestPassword!";
            var hashedPass = Crypto.GetHashSalt(plaintext);
            Assert.AreNotEqual(plaintext, hashedPass);
        }
    }
}
