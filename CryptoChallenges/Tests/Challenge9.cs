using CryptoChallenges.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace CryptoChallenges.Tests
{
    /// <summary>
    /// http://cryptopals.com/sets/1/challenges/9
    /// </summary>
    [TestClass]
    public class Challenge9
    {
        const string _input = "YELLOW SUBMARINE";
        const string _expectedOutput = "YELLOW SUBMARINE\x04\x04\x04\x04";

        [TestMethod]
        public void Challenge9_Solution()
        {
            var padded = Pkcs7.Pad(Encoding.UTF8.GetBytes(_input), 20);

            Assert.AreEqual(_expectedOutput, Encoding.UTF8.GetString(padded));
        }
    }
}
