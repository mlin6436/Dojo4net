using Roman.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    public class RomanNumeralGenerator : IRomanNumeralGenerator
    {
        public const string Zero = "N";
        public const string One = "I";
        public const string Four = "IV";
        public const string Five = "V";
        public const string Nine = "IX";
        public const string Ten = "X";
        public const string Forty = "XL";
        public const string Fifty = "L";
        public const string Ninety = "XC";
        public const string OneHundred = "C";
        public const string FourHundred = "CD";
        public const string FiveHundred = "D";
        public const string NineHundred = "CM";
        public const string OneThousand = "M";

        public string Generate(int number)
        {
            var romanNumeral = String.Empty;

            if (number < 0 || number > 3999)
            {
                throw new Exception("Value must be between 0 - 3,999.");
            }

            if (number == 0)
            {
                romanNumeral = Zero;
            }

            var m = number / 1000;
            var c = number % 1000 / 100;
            var x = number % 1000 % 100 / 10;
            var i = number % 1000 % 100 % 10 / 1;

            for (int integer = 0; integer < m; integer++ )
            {
                romanNumeral += OneThousand;
            }

            romanNumeral += GetRomanNumeral(c, OneHundred, FourHundred, FiveHundred, NineHundred);
            romanNumeral += GetRomanNumeral(x, Ten, Forty, Fifty, Ninety);
            romanNumeral += GetRomanNumeral(i, One, Four, Five, Nine);

            return romanNumeral;
        }

        private string GetRomanNumeral(int number, string first, string forth, string fifth, string ninth)
        {
            var romanNumeral = string.Empty;

            if (number == 9)
            {
                romanNumeral += ninth;
            }
            else if (number > 5 && number < 9)
            {
                romanNumeral += fifth;
                for (int integer = 0; integer < number - 5; integer++)
                {
                    romanNumeral += first;
                }
            }
            else if (number == 5)
            {
                romanNumeral += fifth;
            }
            else if (number == 4)
            {
                romanNumeral += forth;
            }
            else
            {
                for (int integer = 0; integer < number; integer++)
                {
                    romanNumeral += first;
                }
            }

            return romanNumeral;
        }
    }
}
