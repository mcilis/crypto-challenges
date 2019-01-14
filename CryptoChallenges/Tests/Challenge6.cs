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
    /// http://cryptopals.com/sets/1/challenges/6
    /// </summary>
    [TestClass]
    public class Challenge6
    {
        [TestMethod]
        public void Challenge6_Solution()
        {
            var inputFile = new StreamReader("Assets/inputForChallenge6.txt").ReadToEnd();

            var inputByteArray = Convert.FromBase64String(inputFile);


            // Find key size

            var keySizeEditDistanceList = new Dictionary<byte, double>();

            for (byte candidateKeySize = 2; candidateKeySize < 41; candidateKeySize++)
            {
                var distanceList = new List<int>();
                for (int currentIndex = 0; currentIndex < inputByteArray.Length; currentIndex = currentIndex + candidateKeySize)
                {
                    var first = inputByteArray.Skip(currentIndex).Take(candidateKeySize).ToArray();
                    var second = inputByteArray.Skip(currentIndex + candidateKeySize).Take(candidateKeySize).ToArray();
                    var distance = HammingDistance.Calculate(first, second);
                    distanceList.Add(distance);
                }
                var avgDistance = distanceList.Average();

                keySizeEditDistanceList.Add(candidateKeySize, avgDistance / candidateKeySize);
            }

            var keySize = keySizeEditDistanceList.OrderBy(x => x.Value).First().Key;

            Assert.AreEqual(29, keySize);


            // Transpose byte array according to the key size

            var blockList = new List<byte[]>();

            for (int i = 0; i < inputByteArray.Length; i = i + keySize)
            {
                blockList.Add(inputByteArray.Skip(i).Take(keySize).ToArray());
            }

            var lastBlock = blockList.Last();
            if (lastBlock.Length < keySize)
            {
                var expandedLast = new byte[keySize];

                for (int i = 0; i < lastBlock.Length; i++)
                {
                    expandedLast[i] = lastBlock[i];
                }

                blockList.RemoveAt(blockList.Count - 1);
                blockList.Add(expandedLast);
            }

            var transposedBlockList = new List<byte[]>();

            for (int i = 0; i < keySize; i++)
            {
                var transposedBlockArray = new byte[blockList.Count];

                for (int j = 0; j < blockList.Count; j++)
                {
                    transposedBlockArray[j] = blockList[j][i];
                }

                transposedBlockList.Add(transposedBlockArray);
            }


            // Use single byte xor cipher solution for each block to find the repeating key

            var keyList = new List<byte>();
            foreach (var block in transposedBlockList)
            {
                var minScore = 0d;
                byte selectedByteCode = 32;
                for (byte byteCode = 32; byteCode < 127; byteCode++) // <-- Brute force search for the correct character
                {
                    var output = Xor.Apply(block, byteCode);
                    var score = SingleByteXorCipher.ScoreAccordingToEnglishLetterFrequency(output);
                    if (score > minScore)
                    {
                        minScore = score;
                        selectedByteCode = byteCode;
                    }
                }

                //Console.WriteLine($"minScore: {minScore} selectedByteCode:{Convert.ToChar(selectedByteCode)}");

                keyList.Add(selectedByteCode);
            }


            var keyByteArray = keyList.ToArray();

            Assert.AreEqual("Terminator X: Bring the noise", Encoding.Default.GetString(keyByteArray));



            // Decrypt text

            var decryptedByteArray = new byte[inputByteArray.Length];

            for (int i = 0; i < inputByteArray.Length; i++)
            {
                decryptedByteArray[i] = (byte)(inputByteArray[i] ^ keyByteArray[i % keySize]);
            }

            var decryptedText = Encoding.UTF8.GetString(decryptedByteArray);

            Console.WriteLine(decryptedText);
        }
    }
}
