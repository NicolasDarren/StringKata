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

            var delimiters = GetDelimiters(input);

            var numberList = GetNumberList(input, delimiters);

            var sum = numberList.Sum();

            return sum;
        }

        private string[] GetDelimiters(string input)
        {
            var delimiters = new[] { ",", "\n" };

            if (input.StartsWith("//"))
                delimiters = GetCustomDelimiters(input);

            return delimiters;
        }

        private string[] GetCustomDelimiters(string input)
        {
            var newLinePosition = input.IndexOf('\n');
            var customDelimiterIndicatorLength = 2;
            var customDelimiterStringLength = newLinePosition - customDelimiterIndicatorLength;
            var delimiterSection = input.Substring(customDelimiterIndicatorLength, customDelimiterStringLength);
            var delimiters = GetDelimitersList(delimiterSection);

            return delimiters;
        }

        private string[] GetDelimitersList(string delimiterSection)
        {
            var commaSeparatedDelimitersString = delimiterSection.Replace("[", "")
                .Replace(']', ',');

            var delimiters = commaSeparatedDelimitersString.Split(',');

            return delimiters;
        }

        private List<int> GetNumberList(string input, string[] delimiters)
        {
            var numberStringArray = GetNumberStringArray(input, delimiters);

            var numberList = numberStringArray.Select(int.Parse).ToList();

            ThrowErrorIfAnyNegativeNumbers(numberList);

            numberList = numberList.Where(x => x < 1000).ToList();

            return numberList;
        }

        private void ThrowErrorIfAnyNegativeNumbers(List<int> numberList)
        {
            var negativeNumbers = numberList.Where(x => x < 0).ToList();

            if (negativeNumbers.Count > 0)
                throw new Exception($"Negative values NOT allowed. ({string.Join(",", negativeNumbers)})");
        }

        private static string[] GetNumberStringArray(string input, string[] delimiters)
        {
            var numberString = input;
            if (input.StartsWith("//"))
            {
                var newLinePosition = input.IndexOf('\n');
                // Begins after New Line character
                numberString = input.Substring(newLinePosition + 1);
            }

            var numberStringArray = numberString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return numberStringArray;
        }
    }
}
