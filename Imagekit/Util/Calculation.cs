using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Imagekit.Util
{
    public class Calculation
    {
        private static readonly int DEFAULT_TIME_DIFF = 60 * 30;
       


        public static int getHammingDistance(string firstHex, string secondHex)
        {
            if (!(isValidHex(firstHex) && isValidHex(secondHex)))
            {
                throw new Exception("Both argument should be hexadecimal.");
            }
            if (firstHex.Length != secondHex.Length) throw new Exception("Both argument are not equal in length.");
            BigInteger b1 = BigInteger.Parse(firstHex, NumberStyles.HexNumber);
            BigInteger b2 = BigInteger.Parse(secondHex, NumberStyles.HexNumber);
            BigInteger xor = b1 ^ b2;
             
            int count = 0;
            for (int i = 0; i < xor.ToString().Length; i++)
            {
                if (xor.ToString()[i] == '1')
                {
                    count += 1;
                }
            }
            return count;
        }

        static bool isValidHex(string hex)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(hex, @"^[0-9a-fA-F]+$");
            
        }

    }
}
