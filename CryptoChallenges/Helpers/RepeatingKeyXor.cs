using System.Text;

namespace CryptoChallenges.Helpers
{
    public class RepeatingKeyXor
    {
        public static string Apply(string input, string key)
        {
            var inputByteArray = Encoding.Default.GetBytes(input);
            var keyLength = key.Length;
            var keyByteArray = Encoding.Default.GetBytes(key);

            var encryptedByteArray = new byte[inputByteArray.Length];

            for (int i = 0; i < inputByteArray.Length; i++)
            {
                encryptedByteArray[i] = (byte)(inputByteArray[i] ^ keyByteArray[i % keyLength]);
            }

            return Converter.FromByteArrayToHexString(encryptedByteArray);
        }
    }
}
