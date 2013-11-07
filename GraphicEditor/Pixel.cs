using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicEditor
{
    public class Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Colour { get; set; }
        public bool Marked { get; set; }

        public Pixel(int x, int y)
        {
            X = x;
            Y = y;
            Colour = "O";
            Marked = false;
        }
    }
}
