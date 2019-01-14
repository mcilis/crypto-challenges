using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CryptoChallenges.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoChallenges.Tests
{
    /// <summary>
    /// http://cryptopals.com/sets/1/challenges/4
    /// </summary>
    [TestClass]
    public class Challenge4
    {
        [TestMethod]
        public void Challenge4_Solution()
        {
            var inputFile = new StreamReader("Assets/inputForChallenge4.txt");

            var results = new Dictionary<string, double>();

            while (!inputFile.EndOfStream)
            {
                var encryptedLine = Converter.FromHexStringToByteArray(inputFile.ReadLine().Trim());

                var key = SingleByteXorCipher.FindSingleByteKey(encryptedLine);

                var decryptedText = SingleByteXorCipher.Decrypt(encryptedLine, key);

                var score = SingleByteXorCipher.ScoreAccordingToEnglishLetterFrequency(Encoding.Default.GetBytes(decryptedText));

                results.Add(decryptedText, score);
            }

            var hiddenMessage = results.OrderByDescending(x => x.Value).First();

            Assert.AreEqual("Now that the party is jumping\n", hiddenMessage.Key);

            Console.WriteLine($"Score:{hiddenMessage.Value}");
        }
    }
}
