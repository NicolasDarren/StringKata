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
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            var delimiters = GetDelimiter(input);

            var numberList = GetNumberList(input, delimiters);
                
            var sum = numberList.Sum();

            return sum;
        }

        private List<int> GetNumberList(string input, string[] delimiters)
        {
            var numberString = input;

            if (HasCustomDelimiter(input))
                numberString = input.Split('\n')[1];

            var numberList = numberString
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            ThrowErrorIfAnyNegativeValues(numberList);

            numberList = RemoveValuesGreaterThanThousand(numberList);

            return numberList;
        }

        private List<int> RemoveValuesGreaterThanThousand(List<int> numberList)
        {
            return numberList.Where(x => x < 1000).ToList();
        }

        private void ThrowErrorIfAnyNegativeValues(List<int> numberList)
        {
            var negativeValues = numberList.Where(x => x < 0).ToList();

            if (negativeValues.Count > 0)
                throw new Exception($"Negative values not allowed. ({string.Join(",", negativeValues)})");
        }

        private string[] GetDelimiter(string input)
        {
            var delimiters = new[] {",", "\n"};
            if (HasCustomDelimiter(input))
                delimiters = GetCustomDelimiters(input);

            return delimiters;
        }

        private string[] GetCustomDelimiters(string input)
        {
            var delimiterString = input.Split('\n').FirstOrDefault();
            var customDelimiterIndicatorLength = 2;
            var commaSeparatedDelimiters = delimiterString.Substring(customDelimiterIndicatorLength)
                .Replace("[", "");

            return commaSeparatedDelimiters.Split(']');
        }

        private bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }
    }
}
