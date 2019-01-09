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
        public void Add_WhenOneValue_ReturnsValue()
        {
            var input = "1";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(1, actualResult);
        }

        [Test]
        public void Add_WhenTwoValues_ReturnsSum()
        {
            var input = "1,2";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(3, actualResult);
        }

        [Test]
        public void Add_WhenNewLineDelimiter_ReturnsSum()
        {
            var input = "1\n2";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(3, actualResult);
        }

        [Test]
        public void Add_WhenNegativeNumbers_ReturnsSum()
        {
            var input = "1,-2";

            var exception = Assert.Throws<Exception>(() => GetStringKata().Add(input));

            Assert.AreEqual(exception.Message, "Negative numbers NOT allowed (-2)");
        }

        [Test]
        public void Add_WhenCustomDelimiter_ReturnsSum()
        {
            var input = "//[*]\n1*2*3";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenValueGreaterThanOneThousand_IgnoreValueAndReturnsSum()
        {
            var input = "1,2,3000";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(3, actualResult);
        }

        [Test]
        public void Add_WhenCustomDelimiterVaryingLength_ReturnsSum()
        {
            var input = "//[**]\n1**2**3";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }

        [Test]
        public void Add_WhenMultipleCustomDelimiterVaryingLength_ReturnsSum()
        {
            var input = "//[**]\n1**2**3";

            var actualResult = GetStringKata().Add(input);

            Assert.AreEqual(6, actualResult);
        }
    }
}
