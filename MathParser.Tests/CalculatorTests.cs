﻿using NUnit.Framework;
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
        public void GetResult_ShouldReturnCalculationResult(string input, string expected)
        {
            var calculator = new Calculator();
            var result = calculator.GetResult(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
