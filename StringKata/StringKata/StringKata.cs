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
            int result = 0;

            if (string.IsNullOrEmpty(input))
                return result;

            List<int> inputArray = new List<int>();

            if (input.StartsWith("//"))
            {
                // Find the end of the delimiter section
                var firstNewLine = input.IndexOf("\n", StringComparison.Ordinal);

                // Starting just after "//" up to the end of the delimiter section "\n" will be the delimiter string length
                var delimiterStringLength = firstNewLine - 2;

                // After isolating that part of the string, ensure that the known, fixed format is manipulated such that we can split the numbers correctly
                var delimiterString = input.Substring(2, delimiterStringLength);

                // Remove unnecessary separator
                delimiterString = delimiterString.Replace("[", "");

                // Split delimiter string using remaining separator
                var delimiters = Regex.Split(delimiterString, "]");

                // Ensure there are no empty values in the delimiters array
                delimiters = delimiters.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                // If only one delimiter
                if (delimiters.Length == 1 && delimiters[0].Length == 1)
                {
                    // If the initial format is used
                    var delimiter = input[2];

                    // If the new format is used and the old format is not used with the delimiter being "["
                    if (input[2] == '[' && input[3] != '\n')
                        delimiter = input[3];

                    // Isolate the number section of the string
                    var numberString = input.Substring(firstNewLine + 1);

                    inputArray = numberString.Split(delimiter).Select(int.Parse).ToList();
                }
                else
                {
                    var numberString = input.Substring(firstNewLine + 1);

                    foreach (var delimiter in delimiters)
                        numberString = numberString.Replace(delimiter, ",");

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
