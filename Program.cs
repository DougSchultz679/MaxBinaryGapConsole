using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BinaryGapFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ***** Binary Gap Finder ***** ");
            Console.WriteLine(" Enter the integer to assess ");
            int computeVal = Int32.Parse(Console.ReadLine());
            

            Console.WriteLine("The number you have selected is: {0}", computeVal);

            Console.WriteLine("The binary version of the number you selected is: {0}", computeVal.GetBin());

            Console.WriteLine("The max binary gap of your number is: {0}", Solution(computeVal));

            Console.ReadLine();
        }

        public static int Solution(int n)
        {
            string binNum = n.GetBin();
            string RegexPattern = @"10+(?=1)";
            if (!Regex.IsMatch(binNum, RegexPattern)) return 0;

            var Matches = Regex.Matches(binNum, RegexPattern);

            int MaxGap = 0;

            foreach (Match m in Matches)
            {
                MaxGap = Math.Max(m.GetBinGapSizeInBinRegexMatch(), MaxGap);
            }
            return MaxGap;
        }       
    }

    public static class Extensions
    {
        public static string GetBin(this int n)
        {
            List<string> Result = new List<string>();

            for (int i = n; i >= 1; i /= 2)
            {
                Result.Add((i % 2).ToString());
            }
            Result.Reverse();
            return String.Join("", Result);
        }

        public static int GetBinGapSizeInBinRegexMatch(this Match m)
        {
            int ctr = 1;

            for (int i = 2; i < m.ToString().Length; i++)
            {
                if (m.ToString()[i] == '0') ctr++;
            }
            return ctr;
        }
    }
}
