using System;

namespace CryptoChallenges.Helpers
{
    public class Xor
    {
        public static byte[] Apply(byte[] arrA, byte[] arrB)
        {
            if (arrA.Length != arrB.Length)
                throw new ArgumentException("Input arrays should have same length!");

            var resultArr = new byte[arrA.Length];

            for (int i = 0; i < arrA.Length; i++)
            {
                resultArr[i] = (byte)(arrA[i] ^ arrB[i]);
            }

            return resultArr;
        }

        public static byte[] Apply(byte[] arr, byte byteCode)
        {
            var resultArr = new byte[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                resultArr[i] = (byte)(arr[i] ^ byteCode);
            }

            return resultArr;
        }
    }
}
