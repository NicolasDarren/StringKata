﻿using System;
using NUnit.Framework;

namespace StringKata.Tests
{
    [TestFixture]
    public class StringKataTests
    {
        [Test]
        public void Add_EmptyStringPassed_ReturnsZero()
        {
            var input = "";
            var expectedResult = 0;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_OneNumberPassed_ReturnsSameNumber()
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
            var input = "1,2,3,4,5";
            var expectedResult = 15;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_NewLineDelimiter_ReturnsSum()
        {
            var input = "1,2\n3";
            var expectedResult = 6;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_CustomDelimiter_ReturnsSum()
        {
            var input = "//;\n1;2;3";
            var expectedResult = 6;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_NegativeNumberPassed_ThrowsError()
        {
            var input = "1,2,-3,-4";
            var expectedMessage = "Negatives are not allowed: -3,-4";

            var exception = Assert.Throws<Exception>(() => GetStringKata().Add(input));

            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void Add_NumberGreaterThanThousandPassed_NumberGreaterThanThousandIgnoredAndReturnsSum()
        {
            var input = "1,2,3,4000";
            var expectedResult = 6;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_CustomDelimiterVaryingLength_ReturnsSum()
        {
            var input = "//***\n1***2***3";
            var expectedResult = 6;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_MultipleCustomDelimitersVaryingLength_ReturnsSum()
        {
            var input = "//[***][||]\n1||2***3";
            var expectedResult = 6;

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        private StringKata GetStringKata()
        {
            return new StringKata();
        }
    }
}
