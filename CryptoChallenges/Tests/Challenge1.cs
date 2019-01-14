using System;
using System.Diagnostics;
using CryptoChallenges.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoChallenges.Tests
{
    /// <summary>
    /// http://cryptopals.com/sets/1/challenges/1
    /// </summary>
    [TestClass]
    public class Challenge1
    {
        const string _hexString = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
        const string _base64String = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t";

        [TestMethod]
        public void Challenge1_Solution()
        {
            var inputByteArray = Converter.FromHexStringToByteArrayManual(_hexString);

            var base64Output = Convert.ToBase64String(inputByteArray);

            Assert.AreEqual(_base64String, base64Output);
        }
        
        [TestMethod]
        public void Challenge1_InternalTest1()
        {
            // Comparing performances

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var inputByteArrayManual = Converter.FromHexStringToByteArrayManual(_hexString);

            var base64Output = Convert.ToBase64String(inputByteArrayManual);
            
            Assert.AreEqual(_base64String, base64Output);

            stopwatch.Stop();

            var elapsedTimeManual = stopwatch.ElapsedTicks;

            stopwatch = new Stopwatch();

            stopwatch.Start();

            var inputByteArray = Converter.FromHexStringToByteArray(_hexString);

            Assert.AreEqual(_base64String, Convert.ToBase64String(inputByteArray));

            stopwatch.Stop();

            var elapsedTimeSoapHexBinary = stopwatch.ElapsedTicks;

            Console.WriteLine($"Elapsed time Manual: {elapsedTimeManual} ticks | Elapsed time SoapHexBinary: {elapsedTimeSoapHexBinary} ticks");
        }

        [TestMethod]
        public void Challenge1_InternalTest2()
        {
            // From ByteArray To HexString

            var inputByteArray = Convert.FromBase64String(_base64String);

            var outputHexString = Converter.FromByteArrayToHexString(inputByteArray);

            Assert.AreEqual(_hexString, outputHexString, true);
        }
    }
}
