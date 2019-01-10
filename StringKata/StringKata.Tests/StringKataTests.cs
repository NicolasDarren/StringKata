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
            var expectedResult = 0;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenOneValue_ReturnsSameValue()
        {
            var input = "1";
            var expectedResult = 1;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenTwoValues_ReturnsSum()
        {
            var input = "1,2";
            var expectedResult = 3;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenMultipleValues_ReturnsSum()
        {
            var input = "1,2,3,4,5";
            var expectedResult = 15;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenNewLineDelimiter_ReturnsSum()
        {
            var input = "1,2\n3";
            var expectedResult = 6;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenCustomDelimiter_ReturnsSum()
        {
            var input = "//[*]\n1*2*3";
            var expectedResult = 6;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenNegativeValue_ThrowsException()
        {
            var input = "1,2,-3,-4";

            var exception = Assert.Throws<Exception>(() => GetStringKata().Add(input));

            Assert.AreEqual(exception.Message, "Negatives not allowed. (-3,-4)");
        }

        [Test]
        public void Add_WhenValueGreaterThanAThousand_IgnoresValuesGreaterThanAThousandAndReturnsSum()
        {
            var input = "1,2,3000";
            var expectedResult = 3;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenCustomDelimiterVaryingLength_ReturnsSum()
        {
            var input = "//[**]\n1**2**3";
            var expectedResult = 6;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenMultipleCustomDelimiterVaryingLength_ReturnsSum()
        {
            var input = "//[**][||]\n1||2**3";
            var expectedResult = 6;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
