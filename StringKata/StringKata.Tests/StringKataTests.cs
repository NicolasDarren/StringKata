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

        [TestCase("0", 0)]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("10", 10)]
        [TestCase("100", 100)]
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
        [TestCase("5,10,15", 30)]
        [TestCase("1,2,3,4,5,6,7,8,9", 45)]
        public void Add_WhenUnknownNumberOfValues_ReturnsSum(string input, int expectedResult)
        {
            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_WhenUsingNewLineDelimiter_ReturnsSum()
        {
            var input = "1,2\n3,4";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(10, actualResult);
        }

        [Test]
        public void Add_WhenCustomDelimiter_ReturnsSum()
        {
            var input = "//[*]\n1*2*3";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenNegativeNumbers_ThrowsError()
        {
            var input = "1,-2,3,-1";

            Assert.Throws<Exception>(() => CreateStringKata().Add(input));
        }

        [Test]
        public void Add_WhenCustomDelimiterAndNegativeNumbers_ReturnsSum()
        {
            var input = "//[*]\n1*-2*3*-4";
            
            var exception = Assert.Throws<Exception>(() => CreateStringKata().Add(input));

            Assert.AreEqual(exception.Message, "Negatives are not allowed. The following negative numbers were in the list: -2; -4");
        }

        [Test]
        public void Add_WhenNumberGreaterThanOneThousand_IgnoresGreaterThanOneThousandAndReturnsSum()
        {
            var input = "//[*]\n1*2000*3";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(4, actualResult);
        }

        [Test]
        public void Add_WhenCustomDelimiterAnyLength_ReturnsSum()
        {
            var input = "//[***]\n1***2***3";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenMultipleCustomDelimiterAnyLength_ReturnsSum()
        {
            var input = "//[***][||]\n1***2||3";

            var actualResult = CreateStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }



    }
}
