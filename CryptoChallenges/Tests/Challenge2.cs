using CryptoChallenges.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoChallenges.Tests
{
    /// <summary>
    /// http://cryptopals.com/sets/1/challenges/2
    /// </summary>
    [TestClass]
    public class Challenge2
    {
        const string _hexStringInput1 = "1c0111001f010100061a024b53535009181c";
        const string _hexStringInput2 = "686974207468652062756c6c277320657965";
        const string _expectedHexOutput = "746865206b696420646f6e277420706c6179";

        [TestMethod]
        public void Challenge2_Solution()
        {
            var input1ByteArray = Converter.FromHexStringToByteArray(_hexStringInput1);
            var input2ByteArray = Converter.FromHexStringToByteArray(_hexStringInput2);

            var xorResult = Xor.Apply(input1ByteArray, input2ByteArray);

            var hexOutput = Converter.FromByteArrayToHexString(xorResult);

            Assert.AreEqual(_expectedHexOutput, hexOutput, true);
        }
    }
}
