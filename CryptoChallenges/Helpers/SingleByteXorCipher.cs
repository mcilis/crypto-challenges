using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoChallenges.Helpers
{
    public class SingleByteXorCipher
    {
        public static byte FindSingleByteKey(byte[] inputByteArray)
        {
            var minScore = 0d;
            byte selectedByteCode = 32;
            byte[] output = null;
            for (byte byteCode = 32; byteCode < 127; byteCode++) // <-- Brute force search for the correct character
            {
                output = Xor.Apply(inputByteArray, byteCode);
                var score = ScoreAccordingToEnglishLetterFrequency(output);
                if (score > minScore)
                {
                    minScore = score;
                    selectedByteCode = byteCode;
                    //Console.WriteLine($"Decrypted Text:{Encoding.Default.GetString(output)} - Key: {Convert.ToChar(selectedByteCode)} - Score:{minScore}");
                }
            }
            return selectedByteCode;
        }

        public static string Decrypt(byte[] inputByteArray, byte key)
        {
            var decryptedByteArray = Xor.Apply(inputByteArray, key);
            var decryptedText = Encoding.Default.GetString(decryptedByteArray);
            return decryptedText;
        }

        public static double ScoreAccordingToEnglishLetterFrequency(byte[] arr)
        {
            var score = 0d;
            for (int i = 0; i < arr.Length; i++)
            {
                var character = Convert.ToChar(arr[i]);

                if (EnglishLetterFrequency.ContainsKey(character))
                {
                    score += (EnglishLetterFrequency[character] / 100.0) + 0.1;

                }
            }
            return score;
        }

        private static readonly Dictionary<char, double> EnglishLetterFrequency =
            new Dictionary<char, double>
            {
                {'e', 12.7},
                {'t', 9.06},
                {'a', 8.17},
                {'o', 7.51},
                {'i', 6.97},
                {'n', 6.75},
                {'s', 6.33},
                {'h', 6.09},
                {'r', 5.99},
                {'d', 4.25},
                {'l', 4.03},
                {'c', 2.78},
                {'u', 2.76},
                {'m', 2.41},
                {'w', 2.36},
                {'f', 2.23},
                {'g', 2.02},
                {'y', 1.97},
                {'p', 1.93},
                {'b', 1.29},
                {'v', 0.98},
                {'k', 0.77},
                {'j', 0.15},
                {'x', 0.15},
                {'q', 0.10},
                {'z', 0.07},
                {' ', 0.001},
                {'.', 0.001},
                {',', 0.001},
                {':', 0.001},
                {';', 0.001},
                {'!', 0.001},
                {'?', 0.001},
                {'(', 0.001},
                {')', 0.001},
                {'[', 0.001},
                {']', 0.001},
                {'{', 0.001},
                {'}', 0.001},
                {'#', 0.001},
                {'$', 0.001},
                {'*', 0.001},
                {'\\', 0.001},
                {'\'', 0.001}
            };
    }
}
