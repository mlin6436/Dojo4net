using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.Tests
{
    [TestFixture]
    public class RomanNumeralGeneratorTest
    {
        [Test]
        public void RomanNumeralGeneratorShouldInstanciateANewObject()
        {
            var generator = new RomanNumeralGenerator();
            Assert.That(generator, Is.Not.Null);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(4000)]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Value must be between 0 - 3,999.")]
        public void GenerateShouldThrowExceptionIfTheNumberIsLessThanZeroOrGreaterThan3999(int number)
        {
            var generator = new RomanNumeralGenerator();
            var result = generator.Generate(number);
        }

        [Test]
        public void GenerateShouldReturnNIfTheNumberIsZero()
        {
            var number = 0;
            var generator = new RomanNumeralGenerator();
            var result = generator.Generate(number);
            Assert.That(result, Is.EqualTo("N"));
        }

        [Test]
        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(20, "XX")]
        [TestCase(3999, "MMMCMXCIX")]

        public void GenerateShouldReturnAResult(int number, string expected)
        {
            var generator = new RomanNumeralGenerator();
            var result = generator.Generate(number);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
