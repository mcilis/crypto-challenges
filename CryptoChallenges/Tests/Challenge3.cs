using System;
using CryptoChallenges.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoChallenges.Tests
{
    /// <summary>
    /// http://cryptopals.com/sets/1/challenges/3
    /// </summary>
    [TestClass]
    public class Challenge3
    {
        const string _hexStringInput = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";

        [TestMethod]
        public void Challenge3_Solution()
        {
            var inputByteArray = Converter.FromHexStringToByteArray(_hexStringInput);

            var key = SingleByteXorCipher.FindSingleByteKey(inputByteArray);

            Assert.AreEqual('X', Convert.ToChar(key));

            var decryptedText = SingleByteXorCipher.Decrypt(inputByteArray, key);

            Assert.AreEqual("Cooking MC's like a pound of bacon", decryptedText);
        }
    }
}
