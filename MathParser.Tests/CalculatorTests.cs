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
        [TestCase("1a1", "2")]
        [TestCase("1b1", "0")]
        [TestCase("3c4", "12")]
        [TestCase("4d2", "2")]
        public void GetBinaryOperationResult_ShouldReturnCalculationResult(string input, string expected)
        {
            var calculator = new Calculator();
            var result = calculator.GetBinaryOperationResult(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("3a2c4", "20")]
        [TestCase("32a2d2", "17")]
        [TestCase("500a10b66c32", "14208")]        
        public void GetMultipleOperationResult_ShouldReturnCalculationResult(string input, string expected)
        {
            var calculator = new Calculator();
            var result = calculator.GetMultipleOperationResult(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("3ae4c66fb32", "235")]
        [TestCase("3c4d2aee2a4c41fc4f", "990")]
        public void GetBracketOperationResult_ShouldReturnCalculationResult(string input, string expected)
        {
            var calculator = new Calculator();
            var result = calculator.GetMultipleOperationResult(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
