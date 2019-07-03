using NUnit.Framework;

namespace StringKata.Tests
{
    [TestFixture]
    public class StringKataTests
    {
        [Test]
        public void Add_NoInput_ShouldReturnZero()
        {
            var input = "";
            var expectedResult = 0;

            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("5", 5)]
        [TestCase("10", 10)]
        public void Add_OneNumberPassed_ShouldReturnOriginalNumber(string input, int expectedResult)
        {
            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_TwoInputsPassed_ShouldReturnSum()
        {
            var input = "1,2";
            var expectedResult = 3;

            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("1,2,3", 6)]
        [TestCase("4,5,6,7", 22)]
        public void Add_MultipleInputsPassed_ShouldReturnSum(string input, int expectedResult)
        {
            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_AllowNewLineDelimiters_ShouldReturnSum()
        {
            var input = "1\n2,3";
            var expectedResult = 6;

            var actualResult = StringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_AllowCustomDelimiters_ShouldReturnSum()
        {
            var input = "//;\n1;2;3";
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
