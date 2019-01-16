using System;

namespace CryptoChallenges.Helpers
{
    public class Pkcs7
    {
        /// <summary>
        /// Pad any block to a specific block length, by appending the number of bytes of padding to the end of the block.
        /// </summary>
        public static byte[] Pad(byte[] block, int blockLength, byte paddingByte = 4)
        {
            if (block.Length > blockLength)
            {
                throw new ArgumentException("blockLength should be greater than block.Length", "blockLength");
            }

            var newBlock = new byte[blockLength];

            Array.Copy(block, newBlock, block.Length);

            for (int i = block.Length; i < blockLength; i++)
            {
                newBlock[i] = paddingByte;
            }

            return newBlock;
        }
    }
}
