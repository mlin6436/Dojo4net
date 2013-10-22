using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MathParser
{
    public class Calculator
    {
        private const string BinaryOperationPattern = @"[a-zA-Z]";

        private const string OperatorAddition = "a";
        private const string OperatorSubtraction = "b";
        private const string OperatorMultiplication = "c";
        private const string OperatorDivision = "d";

        public string GetResult(string input)
        {
            var regex = Regex.Match(input, BinaryOperationPattern);

            if (regex.Success)
            {
                var operandA = Int32.Parse(input.Substring(0, regex.Index));
                var operandB = Int32.Parse(input.Substring(regex.Index + 1));

                switch (regex.Value)
                {
                    case OperatorAddition: return (operandA + operandB).ToString();
                    case OperatorSubtraction: return (operandA - operandB).ToString();
                    case OperatorMultiplication: return (operandA * operandB).ToString();
                    case OperatorDivision: return (operandA / operandB).ToString();
                    default: return "0";
                }
            }
            else
            {
                return input;
            }
        }
    }
}
