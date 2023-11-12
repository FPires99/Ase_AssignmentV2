using Graphical_Programming_Language;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace Graphical_Programming_Language
{
    public class Circle : Shape
    {
        public int radius;
        protected bool fillEnabled;

        /// <summary>
        /// Initializes a new instance of the circle class with the parameters.
        /// </summary>
        /// <param name="colour">Th color of the circle.</param>
        /// <param name="x">x coordinate of the circle center.</param>
        /// <param name="y">y coordinate of the circle center.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="fillEnabled">Indicates if the circle is filled.</param>
        public Circle(Color colour, int x, int y, int radius, bool fillEnabled) : base(colour, x, y)
        {
            this.radius = radius;
            this.fillEnabled = fillEnabled;
        }

        /// <summary>
        /// Draws the circle on the specified place we will be using  a panel.
        /// </summary>
        /// <param name="g">.</param>
        public override void draw(Graphics g)
        {
            using (Pen p = new Pen(Color.Red, 2))
            using (SolidBrush b = new SolidBrush(colour))
            {
                if (fillEnabled)
                {
                    g.FillEllipse(b, x - radius, y - radius, radius * 2, radius * 2);
                }

                g.DrawEllipse(p, x - radius, y - radius, radius * 2, radius * 2);
                base.draw(g);
            }
        }
    }
}