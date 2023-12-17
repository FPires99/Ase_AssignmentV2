using System.Drawing;

namespace Graphical_Programming_Language
{
    public class Triangle : Shape
    {
        public int sideLength;
        protected bool fillEnabled;

        /// <summary>
        /// Initializes a new instance of the triangle class with the parameters.
        /// </summary>
        /// <param name="colour">Color of the triangle.</param>
        /// <param name="x">X coordinate of the triangle.</param>
        /// <param name="y">Y coordinate of the triangle.</param>
        /// <param name="sideLength">Side length of the triangle.</param>
        /// <param name="fillEnabled">Indicates if the triangle is filled or not.</param>
        public Triangle(Color colour, int x, int y, int sideLength, bool fillEnabled) : base(colour, x, y)
        {
            this.sideLength = sideLength;
            this.fillEnabled = fillEnabled;
        }

        /// <summary>
        /// Draws the triangle on the specified place we will be using  a panel.
        /// </summary>
        /// <param name="g">.</param>
        public override void draw(Graphics g)
        {
            using (Pen p = new Pen(Color.Red, 2))
            using (SolidBrush b = new SolidBrush(colour))
            {
                Point point1 = new Point(x, y + sideLength);
                Point point2 = new Point(x + sideLength, y + sideLength);
                Point point3 = new Point(x + sideLength / 2, y);

                Point[] trianglePoints = { point1, point2, point3 };

                if (fillEnabled)
                {
                    g.FillPolygon(b, trianglePoints);
                }

                g.DrawPolygon(p, trianglePoints);
                base.draw(g);
            }
        }
    }
}