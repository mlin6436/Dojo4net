using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        [TestCase("3a2c4", "20")]
        public void GetResult_ShouldReturnCalculationResult(string input, string expected)
        {
            var calculator = new Calculator();
            var result = calculator.GetResult(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
