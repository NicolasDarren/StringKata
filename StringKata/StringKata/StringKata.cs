using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace StringKata
{
    public class StringKata
    {
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            var delimiters = new char[] {',', '\n'};

            if (input.StartsWith("//"))
                delimiters = GetCustomDelimiter(input);

            var numberString = input.Split(delimiters);

            var numberList = numberString.Select(int.Parse).ToList();

            return numberList.Sum();
        }

        private char[] GetCustomDelimiter(string input)
        {
            var delimiterSection = input.Split('\n')[0].Substring(2);

            return delimiterSection.ToArray();
        }
    }
}
