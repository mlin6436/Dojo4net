using Roman.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Roman
{
    class Program
    {
        // To run the program, open command line and type: Roman.exe /v 3999
        static void Main(string[] args)
        {
            var command = Args.Configuration.Configure<Command>().CreateAndBind(args);
            var value = command.Value;

            if (String.IsNullOrEmpty(value))
            {
                Console.WriteLine("Please enter a value to convert.");
                return;
            }

            var regex = new Regex(@"[\d]");
            if (!regex.IsMatch(value))
            {
                Console.WriteLine("Please enter a number to convert");
                return;
            }

            IRomanNumeralGenerator generator = new RomanNumeralGenerator();
            Console.WriteLine("Result is: {0}", generator.Generate(Int32.Parse(value)));
        }
    }
}
