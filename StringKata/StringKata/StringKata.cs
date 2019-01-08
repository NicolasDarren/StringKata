using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringKata
{
    public class StringKata
    {
        public static int Add(string input)
        {
            int result = 0;

            if (string.IsNullOrEmpty(input))
                return result;

            List<int> inputArray = new List<int>();

            if (input.StartsWith("//"))
            {
                var firstNewLine = input.IndexOf("\n", StringComparison.Ordinal);

                var delimiterStringLength = firstNewLine - 2;
                var delimiterString = input.Substring(2, delimiterStringLength);
                delimiterString = delimiterString.Replace("[", "");
                var delimiters = Regex.Split(delimiterString, "]");
                delimiters = delimiters.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                if (delimiters.Length == 1)
                {
                    var delimiter = input[2];

                    if (input[2] == '[' && input[3] != '\n')
                    {
                        delimiter = input[3];
                    }

                    var numberString = input.Substring(firstNewLine + 1);

                    inputArray = numberString.Split(delimiter).Select(int.Parse).ToList();
                }
                else
                {
                    var numberString = input.Substring(firstNewLine + 1);

                    foreach (var delimiter in delimiters)
                        numberString.Replace(delimiter, ",");

                    inputArray = Regex.Split(numberString, ",").Select(int.Parse).ToList();
                }
            }
            else
            {
                inputArray = input.Split(',', '\n').Select(int.Parse).ToList();
            }

            foreach (var number in inputArray)
            {
                List<int> negativeNumbers = new List<int>();
                if (number < 0)
                {
                    negativeNumbers.Add(number);
                }
                else
                {
                    if(number < 1000)
                        result += number;
                }

                if(negativeNumbers.Count > 0)
                    throw new Exception($"Negative values are not allowed. The following negative values were included: {negativeNumbers.ToString()}");
            }

            return result;
        }
    }
}
