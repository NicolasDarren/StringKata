using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace StringKata
{
    public class StringKata
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            var delimiters = new[] { ",", "\n"};
            var numberString = input;

            if (input.StartsWith("//"))
            {
                delimiters = GetCustomDelimiter(input, delimiters);
                numberString = GetNumberString(input);
            }

            var numberList = GetNumberList(numberString, delimiters);

            numberList = RemoveValuesGreaterThanOneThousand(numberList);

            CheckForNegatives(numberList);

            return numberList.Sum();
        }

        private static List<int> RemoveValuesGreaterThanOneThousand(List<int> numberList)
        {
            numberList = numberList.Where(x => x < 1000).ToList();
            return numberList;
        }

        private static void CheckForNegatives(List<int> numberList)
        {
            var negatives = numberList.Where(x => x < 0).ToList();

            if (negatives.Any())
                throw new Exception("Negatives are not allowed: " + string.Join(", ", negatives));
        }

        private static List<int> GetNumberList(string numberString, string[] delimiters)
        {
            return numberString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        }

        private static string GetNumberString(string input)
        {
            var newLineIndex = input.IndexOf('\n');
            var numberString = input.Substring(newLineIndex + 1);
            return numberString;
        }

        private static string[] GetCustomDelimiter(string input, string[] delimiters)
        {
            var newLineIndex = input.IndexOf('\n');
            var delimiterString = input.Substring(2, newLineIndex - 2);

            if (delimiterString.Contains('['))
            {
                var startIndex = delimiterString.IndexOf('[');
                if (startIndex > -1)
                    delimiterString = delimiterString.Remove(startIndex, 1);

                var endIndex = delimiterString.IndexOf(']');
                if(endIndex > -1)
                    delimiterString = delimiterString.Remove(endIndex,1);

                return new[] { delimiterString };
            }

            var del = input.Substring(2, 1);
            delimiters = delimiters.Append(del).ToArray();
            return delimiters;
        }
    }
}
