using CryptoChallenges.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CryptoChallenges.Tests
{
    /// <summary>
    /// http://cryptopals.com/sets/1/challenges/8
    /// </summary>
    [TestClass]
    public class Challenge8
    {
        [TestMethod]
        public void Challenge8_Solution()
        {
            var inputFile = new StreamReader("Assets/inputForChallenge8.txt");

            var results = new Dictionary<string, double>();

            var lines = new Dictionary<byte[], int>();

            while (!inputFile.EndOfStream)
            {
                var encryptedLine = Converter.FromHexStringToByteArray(inputFile.ReadLine().Trim());

                var chunks = new Dictionary<string, int>();

                for (int i = 0; i < encryptedLine.Length; i = i + 16)
                {
                    var chunkKey = Convert.ToBase64String(encryptedLine.Skip(i).Take(16).ToArray());

                    if (chunks.ContainsKey(chunkKey))
                    {
                        chunks[chunkKey]++;
                    }
                    else
                    {
                        chunks.Add(chunkKey, 1);
                    }
                }

                lines.Add(encryptedLine, chunks.OrderByDescending(x => x.Value).First().Value);
            }

            var selectedLine = lines.OrderByDescending(x => x.Value).First();

            Assert.AreEqual("D880619740A8A19B7840A8A31C810A3D08649AF70DC06F4FD5D2D69C744CD283E2DD052F6B641DBF9D11B0348542BB5708649AF70DC06F4FD5D2D69C744CD2839475C9DFDBC1D46597949D9C7E82BF5A08649AF70DC06F4FD5D2D69C744CD28397A93EAB8D6AECD566489154789A6B0308649AF70DC06F4FD5D2D69C744CD283D403180C98C8F6DB1F2A3F9C4040DEB0AB51B29933F2C123C58386B06FBA186A", Converter.FromByteArrayToHexString(selectedLine.Key), true);
        }
    }
}
