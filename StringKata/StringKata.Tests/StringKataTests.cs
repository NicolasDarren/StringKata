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

            var result = CreateStringKata().Add(input);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_WhenOne_ReturnsOne()
        {
            var input = "1";

            var result = CreateStringKata().Add(input);

            Assert.AreEqual(1, result);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        [TestCase("4", 4)]
        [TestCase("5", 5)]
        public void Add_WhenOneDigit_ReturnsInput(string input, int expectedResult)
        {
            var result = CreateStringKata().Add(input);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Add_WhenOneAndTwo_ReturnsThree()
        {
            var input = "1,2";

            var result = CreateStringKata().Add(input);

            Assert.AreEqual(3, result);
        }

        [TestCase("1,2",3)]
        [TestCase("5,2",7)]
        public void Add_WhenTwoDigits_ReturnsSum(string input, int expectedResult)
        {
            var result = CreateStringKata().Add(input);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Add_WhenNewLineDelimiter_ReturnsSum()
        {
            var input = "1\n2";

            var result = CreateStringKata().Add(input);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_WhenNewLineAndCommaDelimiters_ReturnsSum()
        {
            var input = "1\n2,3";

            var result = CreateStringKata().Add(input);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_WhenCustomDelimiterPrecedesNumbers_ReturnsSum()
        {
            var input = "//;\n1;2";

            var result = CreateStringKata().Add(input);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_WhenOnlyNegativeValuePassed_ThrowsException()
        {
            var input = "-1";
            
            Assert.Throws<Exception>(() => CreateStringKata().Add(input), "Negatives are not allowed.");
        }

        [Test]
        public void Add_WhenNegativeValueInListPassed_ThrowsException()
        {
            var input = "3,-1,2";
            
            Assert.Throws<Exception>(() => CreateStringKata().Add(input), "Negatives are not allowed.");
        }

        // todo: Add multiple negative number test

        [Test]
        public void Add_WhenNumbersExceedOneThousand_IgnoresGreaterThanOneThousandAndReturnsSum()
        {
            var input = "3,1,1002";

            var result = CreateStringKata().Add(input);

            Assert.AreEqual(4, result);
        }

        [Test]
        public void Add_WhenDelimiterCanHaveVaryingLength_ReturnsSum()
        {
            var input = "//[**]\n3**1**2";

            var result = CreateStringKata().Add(input);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_WhenMultipleDelimitersCanHaveVaryingLength_ReturnsSum()
        {
            var input = "//[**][||]\n3**1||2";

            var result = CreateStringKata().Add(input);

            Assert.AreEqual(6, result);
        }
    }
}
