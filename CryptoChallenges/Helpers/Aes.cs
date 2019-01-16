using System.Security.Cryptography;

namespace CryptoChallenges.Helpers
{
    public class Aes
    {
        public static byte[] DecryptEcb(byte[] input, byte[] key)
        {
            var aes = new AesManaged
            {
                KeySize = 128,
                Key = key,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.Zeros,
                IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            return decryptor.TransformFinalBlock(input, 0, input.Length);
        }

        public static byte[] EncryptEcb(byte[] input, byte[] key)
        {
            var aes = new AesManaged
            {
                KeySize = 128,
                Key = key,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.Zeros,
                IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            return encryptor.TransformFinalBlock(input, 0, input.Length);
        }
    }
}
