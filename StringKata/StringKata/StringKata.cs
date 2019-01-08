using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringKata
{
    public class StringKata
    {
        public int Add(string input)
        {
            var sum = 0;

            if (string.IsNullOrEmpty(input))
                return sum;

            char[] defaultDelimiter = {',', '\n'};
            input = input.Trim();
            List<int> numberList = new List<int>();

            if (input.StartsWith("//"))
            {
                var endOfDelimiterSectionPosition = input.IndexOf('\n');
                // Exclude the starting "//"
                var delimiterSectionLength = endOfDelimiterSectionPosition - 2;
                var delimiterSection = input.Substring(2, delimiterSectionLength).Replace("[", "").Replace(']',',');
                var delimiters = delimiterSection.Split(defaultDelimiter, StringSplitOptions.RemoveEmptyEntries);

                var numberString = input.Substring(endOfDelimiterSectionPosition + 1);
                numberList = numberString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Convert.ToInt32(x)).ToList();
            }
            else
            {
                numberList = input.Split(defaultDelimiter, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Convert.ToInt32(x)).ToList();
            }
            
            foreach (var number in numberList)
                sum += number;

            return sum;
        }
    }
}
