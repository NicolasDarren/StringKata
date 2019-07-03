using System;
using System.Linq;

namespace StringKata
{
    public class StringKata
    {
        public int Add(string numbersString)
        {
            if (string.IsNullOrWhiteSpace(numbersString))
            {
                return 0;
            }
            var delimiters = new [] { ',', '\n' };
            if (numbersString.StartsWith("//"))
            {
                delimiters = numbersString.ToCharArray(2,1);
                var firstNewLine = numbersString.IndexOf('\n');
                numbersString = numbersString.Substring(firstNewLine + 1);
            }

            var numberList = numbersString.Split(delimiters).Select(int.Parse);

            var result = numberList.Sum();

            return result;
        }
    }
}
