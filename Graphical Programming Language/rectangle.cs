using Graphical_Programming_Language;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
    public class Rectangle : Shape
    {
        public int width, height;
        protected bool fillEnabled;

        /// <summary>
        /// Initializes an instance of rectangle with specific parameters.
        /// </summary>
        /// <param name="colour">Color of the rectangle</param>
        /// <param name="x">Coordinate of X</param>
        /// <param name="y">Coordinate of X</param>
        /// <param name="width">Width of the rectangle</param>
        /// <param name="height">height of the rectangle</param>
        /// <param name="fillEnabled">Indicates if the rectangle is filled.</param>
        public Rectangle(Color colour, int x, int y, int width, int height, bool fillEnabled) : base(colour, x, y)
        {
            this.width = width;
            this.height = height;
            this.fillEnabled = fillEnabled;
        }

        /// <summary>
        ///  Draws the rectangle on the specified graphics place.
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            using (Pen p = new Pen(Color.Red, 2))
            using (SolidBrush b = new SolidBrush(colour))
            {
                if (fillEnabled)
                {
                    g.FillRectangle(b, x - width / 2, y - height / 2, width, height);
                }

                g.DrawRectangle(p, x - width / 2, y - height / 2, width, height);
                base.draw(g);
            }
        }
    }
}