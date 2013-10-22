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
        [TestCase("-1", "-1")]
        [TestCase("0", "0")]
        [TestCase("1", "1")]
        [TestCase("11", "11")]
        public void GetResult_ShouldReturnCalculationResult(string input, string expected)
        {
            var calculator = new Calculator();
            var result = calculator.GetResult(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
