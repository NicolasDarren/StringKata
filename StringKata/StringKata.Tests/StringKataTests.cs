using System;
using NUnit.Framework;

namespace StringKata.Tests
{
    [TestFixture]
    public class StringKataTests
    {
        private StringKata GetStringKata()
        {
            return new StringKata();
        }

        [Test]
        public void Add_WhenBlank_ReturnsZero()
        {
            var input = "";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(0, actualResult);
        }

        [Test]
        public void Add_WhenOne_ReturnsOne()
        {
            var input = "1";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(1, actualResult);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("10", 10)]
        public void Add_WhenOneValue_ReturnsValue(string input, int expectedResult)
        {
            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenTwoValues_ReturnsSum()
        {
            var input = "1,2";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(3, actualResult);
        }

        [TestCase("1,2,3", 6)]
        [TestCase("5,15,3,7,19", 49)]
        public void Add_WhenVaryingValues_ReturnsSum(string input, int expectedResult)
        {
            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenNewLineDelimiter_ReturnsSum()
        {
            var input = "1,2\n3";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenCustomDelimiter_ReturnsSum()
        {
            var input = "//[*]\n1*2*3";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenNegativeValues_ThrowsException()
        {
            var input = "1,-2,-3,4";

            var exception = Assert.Throws<Exception>(() => GetStringKata().Add(input));

            Assert.AreEqual(exception.Message, "Negative values are not allowed. Please change the following values: -2; -3");
        }

        [Test]
        public void Add_WhenValueMoreThanOneThousand_IgnoreValueAndReturnSum()
        {
            var input = "1,2,3,10000";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenCustomDelimiterVaryingLength_ReturnsSum()
        {
            var input = "//[***]\n1***2***3";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenMultipleCustomDelimiterVaryingLength_ReturnsSum()
        {
            var input = "//[***][||]\n1||2***3";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }
    }
}
