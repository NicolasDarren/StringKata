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
            char[] defaultDelimiter = {',', '\n'};
            var negativeNumbers = new List<int>();
            var numberList = new List<int>();

            // Custom delimiter 
            if (input.StartsWith("//"))
            {
                var endOfDelimiterSectionPosition = input.IndexOf('\n');
                var delimiterSectionLength = endOfDelimiterSectionPosition - 2;
                var delimiterSection = input.Substring(2, delimiterSectionLength);
                delimiterSection = delimiterSection.Replace("[", "").Replace(']', ',');
                var delimiters = delimiterSection.Split(defaultDelimiter, StringSplitOptions.RemoveEmptyEntries);

                var numberString = input.Substring(endOfDelimiterSectionPosition + 1);
                var numberStringList = numberString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                numberList = numberStringList.Select(x => Convert.ToInt32(x)).ToList();
            }
            else
            {
                numberList = input.Split(defaultDelimiter).Select(x => Convert.ToInt32(x)).ToList();
            }

            numberList = numberList.Where(x => x < 1000).ToList();

            ThrowErrorIfNegativeNumbersInList(numberList, negativeNumbers);

            sum = numberList.Sum();

            return sum;
        }

        private static void ThrowErrorIfNegativeNumbersInList(List<int> numberList, List<int> negativeNumbers)
        {
            foreach (var number in numberList)
            {
                if (number < 0)
                    negativeNumbers.Add(number);
            }

            if (negativeNumbers.Count > 0)
                throw new Exception($"Negatives are not allowed. The following negative numbers were in the list: {string.Join("; ", negativeNumbers)}");
        }
    }
}
