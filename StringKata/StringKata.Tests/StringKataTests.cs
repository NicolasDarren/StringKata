using System;
using NUnit.Framework;

namespace StringKata.Tests
{
    [TestFixture]
    public class StringKataTests
    {
        [Test]
        public void Add_EmptyStringPassed_ReturnsZero()
        {
            var numberString = "";
            var expectedResult = 0;

            var actualResult = GetStringKata().Add(numberString);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_OneNumberPassed_ReturnsInput()
        {
            var numberString = "1";
            var expectedResult = 1;

            var actualResult = GetStringKata().Add(numberString);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_NumbersPassed_ReturnsSum()
        {
            var numberString = "1,2";
            var expectedResult = 3;

            var actualResult = GetStringKata().Add(numberString);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_NewLineDelimiter_ReturnsSum()
        {
            var numberString = "1,2\n3";
            var expectedResult = 6;

            var actualResult = GetStringKata().Add(numberString);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_CustomDelimitersUsed_ReturnsSum()
        {
            var numberString = "//;\n1;2";
            var expectedResult = 3;

            var actualResult = GetStringKata().Add(numberString);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_NegativeNumberPassed_ThrowsException()
        {
            var input = "1,2,-3";

            var exception = Assert.Throws<Exception>(() => GetStringKata().Add(input));

            Assert.AreEqual("Negatives not allowed: -3", exception.Message);
        }

        [Test]
        public void Add_NumbersGreaterThanThousandPassed_NumbersGreaterThanThousandIgnoredAndReturnsSum()
        {
            var numberString = "1,2,3000";
            var expectedResult = 3;

            var actualResult = GetStringKata().Add(numberString);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_CustomDelimitersVaryingLength_ReturnsSum()
        {
            var numberString = "//[***]\n1***2***3";
            var expectedResult = 6;

            var actualResult = GetStringKata().Add(numberString);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_MultipleCustomDelimitersVaryingLength_ReturnsSum()
        {
            var numberString = "//[***][||]\n1***2||3";
            var expectedResult = 6;

            var actualResult = GetStringKata().Add(numberString);

            Assert.AreEqual(expectedResult, actualResult);
        }

        private StringKata GetStringKata()
        {
            return new StringKata();
        }
    }
}
