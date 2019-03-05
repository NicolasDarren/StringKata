using System;
using NUnit.Framework;

namespace StringKata.Tests
{
    [TestFixture]
    public class StringKataTests
    {
        [Test]
        public void Add_NoStringPassed_ReturnsZero()
        {
            var input = "";
            var expectedResult = 0;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_OneNumberPassed_ReturnsNumber()
        {
            var input = "1";
            var expectedResult = 1;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_TwoNumbersPassed_ReturnsSum()
        {
            var input = "1,2";
            var expectedResult = 3;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_MultipleNumbersPassed_ReturnsSum()
        {
            var input = "1,2,5,12";
            var expectedResult = 20;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_NewLineDelimiterUsed_ReturnsSum()
        {
            var input = "1\n2,5";
            var expectedResult = 8;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_CustomDelimiterUsed_ReturnsSum()
        {
            var input = "//;\n1;2;5";
            var expectedResult = 8;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_NegativeNumbersPassed_ThrowsException()
        {
            var input = "1,2,-3";

            var exception = Assert.Throws<Exception>(() => GetStringKata().Add(input));

            Assert.AreEqual("Negatives not allowed: -3", exception.Message);
        }

        [Test]
        public void Add_CustomDelimiterVaryingLengthUsed_ReturnsSum()
        {
            var input = "//**\n1**2**5";
            var expectedResult = 8;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_MultipleCustomDelimiterVaryingLengthUsed_ReturnsSum()
        {
            var input = "//[**][|||]\n1|||2**5";
            var expectedResult = 8;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        private StringKata GetStringKata()
        {
            return new StringKata();
        }
    }
}
