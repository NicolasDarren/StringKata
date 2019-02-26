using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata
{
    public class StringKata
    {
        public int Add(string numberString)
        {
            if (string.IsNullOrWhiteSpace(numberString))
                return 0;
            
            var delimiters = GetDelimiters(numberString);

            numberString = GetNumberString(numberString);

            var numberList = GetNumberList(numberString, delimiters);

            HandleNegativeNumbers(numberList);

            return numberList.Sum();
        }

        private static List<int> GetNumberList(string numberString, string[] delimiters)
        {
            var numberList = numberString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            numberList = numberList.Where(x => x < 1000).ToList();

            return numberList;
        }

        private void HandleNegativeNumbers(List<int> numberList)
        {
            var negativeNumbers = numberList.Where(x => x < 0).ToList();

            if(negativeNumbers.Any())
                throw new Exception($"Negatives not allowed: {string.Join(",", negativeNumbers)}");
        }

        private static string GetNumberString(string numberString)
        {
            if (numberString.StartsWith("//"))
                return numberString.Split('\n')[1];

            return numberString;
        }

        private string[] GetDelimiters(string numberString)
        {
            var defaultDelimiters = new[] { ",", "\n" };
            var delimiters = defaultDelimiters;

            if (numberString.StartsWith("//"))
            {
                var delimiterSection = numberString.Substring(2).Split('\n')[0];
                delimiterSection = delimiterSection.Replace("[", "");
                delimiters = delimiterSection.Split(']');
            }

            return delimiters;
        }
    }
}
