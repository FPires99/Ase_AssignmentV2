using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    public partial class Form1 : Form
    {
        public int dotSize = 20;
        public int centerX = 10;
        public int centerY = 10;
        public Color dotColor = Color.Red;
        private Brush dotBrush;

        public Form1()
        {
            InitializeComponent();
            panel1.Invalidate();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                // Draw the dot on the panel using class-level fields
                dotBrush = new SolidBrush(dotColor);

                // Draw the dot on the panel at the current position
                g.FillEllipse(dotBrush, centerX - dotSize / 2, centerY - dotSize / 2, dotSize, dotSize);

            }
        }
    }
}
