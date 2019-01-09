using System;
using NUnit.Framework;

namespace StringKata.Tests
{
    [TestFixture]
    public class StringKataTests
    {
        private StringKata CreateStringKata()
        {
            return new StringKata();
        }

        [Test]
        public void Add_WhenBlank_ReturnsZero()
        {
            var input = " ";

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
        [TestCase("10", 10)]
        [TestCase("55", 55)]
        public void Add_WhenOneValue_ReturnsValue(string input, int expectedResult)
        {
            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenTwoValues_ReturnsSum()
        {
            var input = "1,2";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(3, actualResult);
        }

        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4,5", 15)]
        [TestCase("1,2,3,4,5,6,7,8,9", 45)]
        public void Add_WhenVaryingNumberOfValues_ReturnsSum(string input, int expectedResult)
        {
            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenNewLineDelimiter_ReturnsSum()
        {
            var input = "1,2\n3";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenCustomDelimiter_ReturnsSum()
        {
            var input = "//[*]\n3*1*2";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenNegativeValue_ThrowException()
        {
            var input = "//[*]\n3*-1*-2";

            var exception = Assert.Throws<Exception>(() => CreateStringKata().Add(input));

            Assert.AreEqual(exception.Message, "Negative numbers are not allowed. Please alter the following value(s): -1; -2");
        }

        [Test]
        public void Add_WhenValueGreaterThanOneThousand_IgnoreValueGreaterThanOneThousandAndReturnsSum()
        {
            var input = "1, 2, 3000";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(3, actualResult);
        }

        [Test]
        public void Add_WhenCustomDelimiterVaryingLength_ReturnsSum()
        {
            var input = "//[***]\n3***1***2";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenMultipleCustomDelimiterVaryingLength_ReturnsSum()
        {
            var input = "//[***][||]\n3***1||2";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }
    }
}
