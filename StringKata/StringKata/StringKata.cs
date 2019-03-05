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
            var delimiters = GetDelimiters(input);
            var numberString = GetNumberString(input);
            
            var numberList = GetNumberList(numberString, delimiters);

            return numberList.Sum();
        }

        private static List<int> GetNumberList(string numberString, string[] delimiters)
        {
            var numberList = numberString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            numberList = numberList.Where(number => number < 1000).ToList();

            var negativeNumbers = numberList.Where(number => number < 0).ToList();

            if (negativeNumbers.Any())
                throw new Exception("Negatives not allowed: " + string.Join(", ", negativeNumbers));

            return numberList;
        }

        private static string GetNumberString(string input)
        {
            return input.StartsWith("//") ? input.Split('\n')[1] : input;
        }

        private string[] GetDelimiters(string input)
        {
            return input.StartsWith("//") ? 
                GetCustomDelimiters(input) : 
                new[] { ",", "\n" };
        }

        private static string[] GetCustomDelimiters(string input)
        {
            var delimiterSection = input.Substring(2).Split('\n')[0].Replace("[", "").Replace(']', ',');
            return delimiterSection.Split(',');
        }
    }
}
