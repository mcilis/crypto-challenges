using CryptoChallenges.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoChallenges.Tests
{
    /// <summary>
    /// http://cryptopals.com/sets/1/challenges/5
    /// </summary>
    [TestClass]
    public class Challenge5
    {
        const string _input = "Burning 'em, if you ain't quick and nimble\nI go crazy when I hear a cymbal";
        const string _key = "ICE";
        const string _expectedHexOutput = "0b3637272a2b2e63622c2e69692a23693a2a3c6324202d623d63343c2a26226324272765272a282b2f20430a652e2c652a3124333a653e2b2027630c692b20283165286326302e27282f";

        [TestMethod]
        public void Challenge5_Solution()
        {
            var encrypted = RepeatingKeyXor.Apply(_input, _key);

            Assert.AreEqual(_expectedHexOutput, encrypted, true);
        }
    }
}
