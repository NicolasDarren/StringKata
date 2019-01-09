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

            string[] defaultDelimiters = {",", "\n"};
            string[] delimiters = defaultDelimiters;
            string numberString = input;

            if (input.StartsWith("//"))
                delimiters = GetDelimiters(input, defaultDelimiters, out numberString);

            var numberStringList = numberString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var numberList = numberStringList.Select(x => Convert.ToInt32(x)).ToList();

            var negativeNumbers = numberList.Where(x => x < 0).ToList();
            if (negativeNumbers.Count > 0)
                throw new Exception($"Negative values are NOT allowed. Please remove the following value(s): {string.Join("; ", negativeNumbers)}");

            numberList = numberList.Where(x => x < 1000).ToList();

            sum = numberList.Sum();

            return sum;
        }

        private string[] GetDelimiters(string input, string[] defaultDelimiters, out string numberString)
        {
            var newLinePosition = input.IndexOf('\n');
            numberString = input.Substring(newLinePosition + 1);

            var delimiterSectionLength = newLinePosition - 2;
            var delimiterSection = input.Substring(2, delimiterSectionLength)
                .Replace("[", "")
                .Replace(']', ',');

            var delimiters = delimiterSection.Split(defaultDelimiters, StringSplitOptions.RemoveEmptyEntries);

            return delimiters;
        }
    }
}
