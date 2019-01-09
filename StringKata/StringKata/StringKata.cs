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
            if (string.IsNullOrWhiteSpace(input))
                return sum;

            input = input.Trim();

            string[] defaultDelimiters = {",", "\n"};
            var delimiters = defaultDelimiters;
            string numberString = input;

            if (input.StartsWith("//"))
            {
                delimiters = GetDelimiter(input, defaultDelimiters, out numberString);

            }

            var numberList = numberString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToList();

            var negativeNumbers = numberList.Where(x => x < 0).ToList();
            if (negativeNumbers.Count > 0)
                throw new Exception($"Negative numbers are not allowed. Please alter the following value(s): {string.Join("; ", negativeNumbers)}");

            numberList = numberList.Where(x => x < 1000).ToList();

            sum = numberList.Sum();

            return sum;
        }

        private string[] GetDelimiter(string input, string[] defaultDelimiters, out string numberString)
        {
            var endOfDelimiterSectionPosition = input.IndexOf('\n');
            var delimiterSectionLength = endOfDelimiterSectionPosition - 2;
            var delimiterSection = input.Substring(2, delimiterSectionLength)
                .Replace("[", "")
                .Replace(']',',');

            var delimiters = delimiterSection.Split(defaultDelimiters, StringSplitOptions.RemoveEmptyEntries);

            numberString = input.Substring(endOfDelimiterSectionPosition + 1);

            return delimiters;
        }
    }
}
