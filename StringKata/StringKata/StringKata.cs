using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringKata
{
    public class StringKata
    {
        private string[] delimiter;

        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            delimiter = new[]{",", "\n"};
            var numberString = input;

            if (input.StartsWith("//"))
            {
                delimiter = GetDelimiter(input);

                numberString = GetNumberString(input);
            }

            var numberList = GetNumberList(numberString, delimiter);
            var sum = numberList.Sum();

            return sum;
        }

        private string GetNumberString(string input)
        {
            var newLinePosition = input.IndexOf('\n');

            // Next line will be start of number string
            return input.Substring(newLinePosition + 1);
        }

        private string[] GetDelimiter(string input)
        {
            var newLinePosition = input.IndexOf('\n');
            var lengthOfFirstTwoCharacters = 2;
            var delimiterSectionLength = newLinePosition - lengthOfFirstTwoCharacters;
            
            // Create comma separated delimiter section string
            var delimiterSection = input.Substring(lengthOfFirstTwoCharacters, delimiterSectionLength)
                .Replace("[", "")
                .Replace(']', ',');

            var delimiters = delimiterSection.Split(new []{','}, StringSplitOptions.RemoveEmptyEntries);

            return delimiters;
        }

        private static List<int> GetNumberList(string input, string[] delimiters)
        {
            var numberList = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            CheckForNegativeNumbers(numberList);

            numberList = IgnoreNumbersGreaterThanOneThousand(numberList);

            return numberList;
        }

        private static List<int> IgnoreNumbersGreaterThanOneThousand(List<int> numberList)
        {
            return numberList.Where(x => x < 1000).ToList();
        }

        private static void CheckForNegativeNumbers(List<int> input)
        {
            var negativeNumbers = input.Where(n => n < 0).ToList();
            if(negativeNumbers.Count > 0)
                throw new Exception($"Negative numbers NOT allowed ({string.Join("; ", negativeNumbers)})");
        }
    }
}
