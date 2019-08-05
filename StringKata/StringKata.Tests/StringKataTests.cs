using System;
using NUnit.Framework;

namespace StringKata.Tests
{
    [TestFixture]
    public class StringKataTests
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturnZero()
        {
            var input = "";
            var expectedResult = 0;

            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_GivenOneInput_ShouldReturnSameNumber()
        {
            var input = "2";
            var expectedResult = 2;

            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_GivenTwoInputs_ShouldReturnSum()
        {
            var input = "2,3";
            var expectedResult = 5;

            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("2,3,4", 9)]
        [TestCase("1,2,3,4,5,6,7,8,9,10", 55)]
        public void Add_GivenMultipleInputs_ShouldReturnSum(string input, int expectedResult)
        {
            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Test]
        public void Add_UsingNewLineDelimiter_ShouldReturnSum()
        {
            var input = "2,3\n4";
            var expectedResult = 9;

            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_UsingCustomDelimiter_ShouldReturnSum()
        {
            var input = "//;\n2;3;4";
            var expectedResult = 9;

            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowError()
        {
            var input = "2,3,-4";

            Assert.Throws<Exception>(() => StringKata().Add(input), "Negatives are not allowed: -4");
        }

        [Test]
        public void Add_GivenNegativeNumbers_ShouldThrowError()
        {
            var input = "2,3,-4,-5";

            Assert.Throws<Exception>(() => StringKata().Add(input), "Negatives are not allowed: -4, -5");
        }

        [Test]
        public void Add_GivenNumbersGreaterThanOneThousand_ShouldIgnoreNumbersGreaterThanOneThousandAndReturnSum()
        {
            var input = "2,3,1001";
            var expectedResult = 5;

            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_CustomDelimiterCanBeAStringOfAnyLength_ShouldReturnSum()
        {
            var input = "//[***]\n1***2***3";
            var expectedResult = 6;

            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        private static StringKata StringKata()
        {
            return new StringKata();
        }
    }
}
