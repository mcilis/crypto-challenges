using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace CryptoChallenges.Helpers
{
    public class Converter
    {
        public static byte[] FromHexStringToByteArrayManual(string hexString)
        {
            int numberOfChars = hexString.Length;
            byte[] bytes = new byte[numberOfChars / 2];
            for (int i = 0; i < numberOfChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16); // <-- using substring in here makes it slower!!!
            return bytes;
        }

        public static byte[] FromHexStringToByteArray(string hexString)
        {
            return SoapHexBinary.Parse(hexString).Value;
        }

        public static string FromByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);

            for (int i = 0; i < ba.Length; i++)       // <-- use for loop is faster than foreach   
                hex.Append(ba[i].ToString("X2"));   // <-- ToString is faster than AppendFormat   

            return hex.ToString();
        }
    }
}
