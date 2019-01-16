using System;
using System.IO;
using System.Text;
using CryptoChallenges.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoChallenges.Tests
{
    /// <summary>
    /// http://cryptopals.com/sets/1/challenges/7
    /// </summary>
    [TestClass]
    public class Challenge7
    {
        [TestMethod]
        public void Challenge7_Solution()
        {
            var inputFile = new StreamReader("Assets/inputForChallenge7.txt").ReadToEnd();

            var key = "YELLOW SUBMARINE";

            var decryptedText = Aes.DecryptEcb(Convert.FromBase64String(inputFile), Encoding.UTF8.GetBytes(key));

            Console.WriteLine(Encoding.UTF8.GetString(decryptedText));
        }
    }
}
