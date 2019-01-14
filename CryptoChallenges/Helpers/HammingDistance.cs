using System;
using System.Text;

namespace CryptoChallenges.Helpers
{
    // The Hamming distance (edit distance) is just the number of differing bits
    public class HammingDistance
    {
        public static int Calculate(string input1, string input2)
        {
            if (input1.Length != input2.Length)
                return -1;

            var input1Bits = GetBitString(input1);
            var input2Bits = GetBitString(input2);

            var distance = CountDifferingBits(input1Bits, input2Bits);

            return distance;
        }

        public static int Calculate(byte[] input1, byte[] input2)
        {
            if (input1.Length != input2.Length)
                return -1;

            var input1Bits = GetBitString(input1);
            var input2Bits = GetBitString(input2);

            var distance = CountDifferingBits(input1Bits, input2Bits);

            return distance;
        }

        private static int CountDifferingBits(string input1Bits, string input2Bits)
        {
            if (input1Bits.Length != input2Bits.Length)
                return -2;

            var input1BitsCharArr = input1Bits.ToCharArray();
            var input2BitsCharArr = input2Bits.ToCharArray();

            var numberOfDifferingBits = 0;

            for (int i = 0; i < input1Bits.Length; i++)
            {
                if (input1BitsCharArr[i] != input2BitsCharArr[i])
                {
                    numberOfDifferingBits++;
                }
            }

            return numberOfDifferingBits;
        }

        private static string GetBitString(string input)
        {
            var inputByteArray = Encoding.UTF8.GetBytes(input);

            return GetBitString(inputByteArray);
        }

        private static string GetBitString(byte[] input)
        {
            var bitString = new StringBuilder();

            foreach (var inputByte in input)
            {
                var binaryString = Convert.ToString(inputByte, 2);
                var binaryStringAsEightDigits = binaryString.PadLeft(8, '0');

                bitString.Append(binaryStringAsEightDigits);
            }

            return bitString.ToString();
        }
    }
}
