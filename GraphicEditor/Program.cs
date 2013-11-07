using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GraphicEditor
{
    class Program
    {
        private static bool _cancel = false;
        private static readonly Canvas Canvas = new Canvas();

        static void Main(string[] args)
        {
            Console.WriteLine("Application has started. Ctrl-C to end");

            var thread = new Thread(Worker);
            thread.Start();

            var autoResetEvent = new AutoResetEvent(false);
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                eventArgs.Cancel = true;
                autoResetEvent.Set();
            };

            autoResetEvent.WaitOne();
            _cancel = true;
            Console.WriteLine("Now shutting down");
        }

        private static void Worker()
        {
            while (!_cancel)
            {
                Console.Write(">");

                var command = Console.ReadLine();

                if (command == null)
                {
                    continue;
                }

                var commandElements = command.Split(' ');

                int m, n, t1, t2;
                switch (commandElements[0])
                {
                    case "I":
                        if (int.TryParse(commandElements[1], out m)
                            && int.TryParse(commandElements[2], out n))
                        {
                            Canvas.Initialise(m, n);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;
                    case "C":
                        Canvas.Clear();
                        break;
                    case "L":
                        if (int.TryParse(commandElements[1], out m)
                            && int.TryParse(commandElements[2], out n)
                            && commandElements.Length == 4)
                        {
                            Canvas.SetColourToAPixel(m, n, commandElements[3]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;
                    case "V":
                        if (int.TryParse(commandElements[1], out m)
                            && int.TryParse(commandElements[2], out t1)
                            && int.TryParse(commandElements[3], out t2)
                            && commandElements.Length == 5)
                        {
                            Canvas.SetColourToAVerticalSegment(m, t1, t2, commandElements[4]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;
                    case "H":
                        if (int.TryParse(commandElements[1], out t1)
                            && int.TryParse(commandElements[2], out t2)
                            && int.TryParse(commandElements[3], out n)
                            && commandElements.Length == 5)
                        {
                            Canvas.SetColourToAHorizontalSegment(t1, t2, n, commandElements[4]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;
                    case "F":
                        if (int.TryParse(commandElements[1], out m)
                            && int.TryParse(commandElements[2], out n)
                            && commandElements.Length == 4)
                        {
                            Canvas.SetColourToARegion(m, n, commandElements[3]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;
                    case "S":
                        Canvas.Show();
                        break;
                    case "X":
                        Console.WriteLine("Application has stopped.");
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
