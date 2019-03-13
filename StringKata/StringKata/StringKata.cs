using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace StringKata
{
    public class StringKata
    {
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            var delimiters = new[] {','.ToString(), '\n'.ToString()};
            var numberString = input;

            if (input.StartsWith("//"))
            {
                delimiters = GetCustomDelimiter(input);
                numberString = input.Split('\n')[1];
            }

            var numberList = GetNumberList(numberString, delimiters);

            return numberList.Sum();
        }

        private static List<int> GetNumberList(string numberString, string[] delimiters)
        {
            var numberList = numberString
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(number => number < 1000)
                .ToList();
            var negativeNumbers = numberList.Where(number => number < 0).ToList();

            if(negativeNumbers.Any())
                throw new Exception("Negatives are not allowed: " + string.Join(",", negativeNumbers));

            return numberList;
        }

        private string[] GetCustomDelimiter(string input)
        {
            var delimiterSection = input.Split('\n')[0].Substring(2);
            var delimiterArray = delimiterSection
                .Replace("[", "")
                .Replace(']', ',')
                .Split(',');
            return delimiterArray;
        }
    }
}
