using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Graphical_Programming_Language
{
    public abstract class Shape
    {

        protected Color colour; 
        public int x, y; 
        public Shape(Color colour, int x, int y)
        {

            this.colour = colour; 
            this.x = x; 
            this.y = y; 
            
        }

        public virtual void draw(Graphics g)
        {
            
          
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.NoClip;
            
        }

       

    }
}


