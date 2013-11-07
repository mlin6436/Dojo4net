using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicEditor.Tests
{
    [TestFixture]
    public class CanvasTests
    {
        [Test]
        [TestCase(5, 6, 30)]
        public void Initialise_ShouldInstanciateAListOfPixel(int x, int y, int count)
        {
            var canvas = new Canvas();
            canvas.Initialise(x, y);
            Assert.That(canvas.Pixels.Count, Is.EqualTo(count));
        }

        [Test]
        [TestCase(5, 6, 2, 3, "A")]
        public void SetColourToAPixel_ShouldSetColourToAnApointedPixel(int x, int y, int row, int column, string colour)
        {
            var canvas = new Canvas();
            canvas.Initialise(x, y);
            Assert.That(canvas.Pixels.First(p => p.X == column && p.Y == row).Colour, Is.Not.EqualTo(colour));
            canvas.SetColourToAPixel(row, column, colour);
            Assert.That(canvas.Pixels.First(p => p.X == column && p.Y == row).Colour, Is.EqualTo(colour));
        }

        [Test]
        [TestCase(5, 6, 2, 3, 4, "W")]
        public void SetColourToAVerticalSegment_ShouldSetColourToAVerticalSegmentOfPixels(int x, int y, int row, int begin, int end, string colour)
        {
            var canvas = new Canvas();
            canvas.Initialise(x, y);
            foreach (var pixel in canvas.Pixels.Where(p => p.Y == row && p.X >= begin && p.X <= end))
            {
                Assert.That(pixel.Colour, Is.Not.EqualTo(colour));
            }
            canvas.SetColourToAVerticalSegment(row, begin, end, colour);
            foreach (var pixel in canvas.Pixels.Where(p => p.Y == row && p.X >= begin && p.X <= end))
            {
                Assert.That(pixel.Colour, Is.EqualTo(colour));
            }
        }

        [Test]
        [TestCase(5, 6, 3, 4, 2, "Z")]
        public void SetColourToAHorizontalSegment_ShouldSetColourToAHorizontalSegmentOfPixels(int x, int y, int begin, int end, int row, string colour)
        {
            var canvas = new Canvas();
            canvas.Initialise(x, y);
            foreach (var pixel in canvas.Pixels.Where(p => p.X == row && p.Y >= begin && p.Y <= end))
            {
                Assert.That(pixel.Colour, Is.Not.EqualTo(colour));
            }
            canvas.SetColourToAHorizontalSegment(begin, end, row, colour);
            foreach (var pixel in canvas.Pixels.Where(p => p.X == row && p.Y >= begin && p.Y <= end))
            {
                Assert.That(pixel.Colour, Is.EqualTo(colour));
            }
        }

        [Test]
        [TestCase(3, 3, 2, 2, 2, 3, 3, 3, "A", "Z")]
        public void SetColourToARegion_ShoudSetColourToARegionOfPixels(int x, int y, int row1, int column1, int row2, int column2, int row3, int column3, string tempColour, string targetColour)
        {
            var canvas = new Canvas();
            canvas.Initialise(x, y);
            canvas.SetColourToAPixel(row1, column1, tempColour);
            canvas.SetColourToAPixel(row2, column2, tempColour);
            canvas.SetColourToAPixel(row3, column3, tempColour);
            canvas.SetColourToARegion(row3, column3, targetColour);
            Assert.That(canvas.Pixels.First(p => p.X == column1 && p.Y == row1).Colour, Is.EqualTo(targetColour));
            Assert.That(canvas.Pixels.First(p => p.X == column2 && p.Y == row2).Colour, Is.EqualTo(targetColour));
            Assert.That(canvas.Pixels.First(p => p.X == column3 && p.Y == row3).Colour, Is.EqualTo(targetColour));
        }

        [Test]
        [TestCase(5, 6, 1, 1, "W", "O")]
        public void Clear_ShouldResetAllPixelColourToWhite(int x, int y, int row, int column, string colour, string expectedColour)
        {
            var canvas = new Canvas();
            canvas.Initialise(x, y);
            canvas.SetColourToARegion(column, row, colour);
            canvas.Clear();
            foreach (var pixel in canvas.Pixels)
            {
                Assert.That(pixel.Colour, Is.EqualTo(expectedColour));
            }
        }
    }
}
