using System;
using System.Drawing;

namespace Graphical_Programming_Language
{
    public class Circle : Shape
    {
        public int radius;
        protected bool fillEnabled;
        public string VariableName { get; set; } 

        public Circle(Color colour, int x, int y, int radius, bool fillEnabled) : base(colour, x, y)
        {
            this.radius = radius;
            this.fillEnabled = fillEnabled;

            Console.WriteLine($"Circle created with radius: {radius}");
        }

        public void SetRadius(int value)
        {
            radius = value;
        }

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