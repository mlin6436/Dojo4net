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
        private const string OperatorPattern = @"[a-d]";
        private const string BinaryOperationPattern = @"[0-9]+[a-d]+[0-9]+";
        private const string BracketOperationPattern = @"[e][0-9a-d]*[f]";

        private const string OperatorAddition = "a";
        private const string OperatorSubtraction = "b";
        private const string OperatorMultiplication = "c";
        private const string OperatorDivision = "d";
        private const string OperatorOpeningBracket = "e";
        private const string OperatorClosingBracket = "f";

        public string GetBinaryOperationResult(string input)
        {
            var regex = Regex.Match(input, OperatorPattern);

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
             
            return input;
        }

        public string GetMultipleOperationResult(string input)
        {
            var result = input;
            var regex = Regex.Match(input, BinaryOperationPattern);

            if (regex.Success)
            {
                result = GetBinaryOperationResult(regex.Value) + input.Substring(regex.Length);
                return GetMultipleOperationResult(result);
            }

            return result;
        }

        public string GetBracketOperationResult(string input)
        {
            var result = input;
            var regex = Regex.Match(input, BracketOperationPattern);

            if (regex.Success)
            {
                result = input.Substring(0, regex.Index) + GetMultipleOperationResult(regex.Value.Replace(OperatorOpeningBracket, string.Empty).Replace(OperatorClosingBracket, string.Empty)) + input.Substring(regex.Index + regex.Length);
                return GetBracketOperationResult(result);
            }
             
            return GetMultipleOperationResult(input);
        }
    }
}
