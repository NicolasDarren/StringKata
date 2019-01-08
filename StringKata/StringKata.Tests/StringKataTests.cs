using System;
using NUnit.Framework;

namespace StringKata.Tests
{
    [TestFixture]
    public class StringKataTests
    {
        private static StringKata CreateStringKata()
        {
            return new StringKata();
        }

        [Test]
        public void Add_WhenEmptyString_ReturnsZero()
        {
            var input = "";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(0, actualResult);
        }

        [Test]
        public void Add_WhenOne_ReturnsOne()
        {
            var input = "1";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(1, actualResult);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        [TestCase("4", 4)]
        [TestCase("5", 5)]
        public void Add_WhenOneDigit_ReturnsInput(string input, int expectedResult)
        {
            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenOneAndTwo_ReturnsThree()
        {
            var input = "1, 2";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(3, actualResult);
        }

        [TestCase("1, 2", 3)]
        [TestCase("8,6", 14)]
        [TestCase("1,2,3,4,5", 15)]
        [TestCase("1,2,3,4,5,1,2,3,5", 26)]
        public void Add_WhenTwoDigits_ReturnsSum(string input, int expectedResult)
        {
            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenNewLineDelimiter_ReturnsSum()
        {
            var input = "1\n2";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(3, actualResult);
        }

        [Test]
        public void Add_WhenNewLineDelimiterAndComma_ReturnsSum()
        {
            var input = "1\n2,3";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenCustomDelimiter_ReturnsSum()
        {
            var input = "//[*]\n1*2*3";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenCustomDelimiterWithVaryingLength_ReturnsSum()
        {
            var input = "//[*|]\n1*|2*|3";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }
    }
}
