using System;
using System.Text;
using CryptoChallenges.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoChallenges.Tests
{
    /// <summary>
    /// http://cryptopals.com/sets/1/challenges/10
    /// </summary>
    [TestClass]
    public class Challenge10
    {
        [TestMethod]
        public void Challenge10_Solution()
        {
        }

        [TestMethod]
        public void Challenge10_InternalTest1()
        {
            var plainText = "abcdefghijklmnop";
            var key = Encoding.UTF8.GetBytes("YELLOW SUBMARINE");

            var encryptedText = Aes.EncryptEcb(Encoding.UTF8.GetBytes(plainText), key);

            Console.WriteLine($"encryptedText={Convert.ToBase64String(encryptedText)}");

            var decryptedText = Aes.DecryptEcb(encryptedText, key);

            Assert.AreEqual(plainText, Encoding.UTF8.GetString(decryptedText));
        }
    }
}
