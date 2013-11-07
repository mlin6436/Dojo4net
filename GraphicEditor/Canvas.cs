using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicEditor
{
    public class Canvas
    {
        private int _x;
        private int _y;
        public List<Pixel> Pixels { get; private set; }

        public Canvas()
        {
            Pixels = new List<Pixel>();
        }

        public void Initialise(int x, int y)
        {
            _x = x;
            _y = y;

            for (var i = 1; i <= y; i++)
            {
                for (var j = 1; j <= x; j++)
                {
                    Pixels.Add(new Pixel(i, j));
                }
            }
        }

        public void Show()
        {
            Console.WriteLine("==>");

            for (var i = 1; i <= _y; i++)
            {
                for (var j = 1; j <= _x; j++)
                {
                    Console.Write(Pixels.First(p => p.X == i && p.Y == j).Colour);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void SetColourToAPixel(int row, int column, string colour)
        {
            Pixels.First(p => p.X == column && p.Y == row).Colour = colour;
        }

        public void SetColourToAVerticalSegment(int row, int begin, int end, string colour)
        {
            foreach (var pixel in Pixels.Where(p => p.Y == row && p.X >= begin && p.X <= end))
            {
                pixel.Colour = colour;
            }
        }

        public void SetColourToAHorizontalSegment(int begin, int end, int row, string colour)
        {
            foreach (var pixel in Pixels.Where(p => p.Y >= begin && p.Y <= end && p.X == row))
            {
                pixel.Colour = colour;
            }
        }

        public void SetColourToARegion(int x, int y, string colour)
        {
            var originColour = Pixels.First(p => p.X == x && p.Y == y).Colour;

            if (originColour == colour)
            {
                return;
            }

            Pixels.First(p => p.X == x && p.Y == y).Marked = true;

            while (Pixels.Any(p => p.Marked == true))
            {
                var currentPixel = Pixels.First(p => p.Marked == true);
                currentPixel.Colour = colour;
                currentPixel.Marked = false;

                if (Pixels.Exists(p => p.X == (currentPixel.X - 1) && p.Y == currentPixel.Y && p.Colour == originColour))
                {
                    Pixels.First(p => p.X == (currentPixel.X - 1) && p.Y == currentPixel.Y).Marked = true;
                }

                if (Pixels.Exists(p => p.X == currentPixel.X && p.Y == (currentPixel.Y + 1) && p.Colour == originColour))
                {
                    Pixels.First(p => p.X == currentPixel.X && p.Y == (currentPixel.Y + 1)).Marked = true;
                }

                if (Pixels.Exists(p => p.X == (currentPixel.X + 1) && p.Y == currentPixel.Y && p.Colour == originColour))
                {
                    Pixels.First(p => p.X == (currentPixel.X + 1) && p.Y == currentPixel.Y).Marked = true;
                }

                if (Pixels.Exists(p => p.X == currentPixel.X && p.Y == (currentPixel.Y - 1) && p.Colour == originColour))
                {
                    Pixels.First(p => p.X == currentPixel.X && p.Y == (currentPixel.Y - 1)).Marked = true;
                }
            }
        }

        public void Clear()
        {
            foreach (var pixel in Pixels)
            {
                pixel.Colour = "O";
            }
        }
    }
}
