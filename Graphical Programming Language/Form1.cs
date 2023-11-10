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
        private Commands commands;

        public Form1()
        {
            InitializeComponent();
            panel1.Invalidate();
            commands = new Commands();


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
        /// <summary>
        /// This method is going to be responsible to execute all the commands in the program.
        /// </summary>
        /// <param name="parser">Processes the commands and the parameters</param>
        public void ExecuteCommand(CommandParser parser)
        {
            switch (parser.CommandName)
            {
                case "moveto":
                    MoveToCommand(parser);
                    break;
            }
        }
        /// <summary>
        /// Thi method executes single lines at textbox1
        /// </summary>
        /// <param name="command"></param>
        public void ExecuteSingleLine(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                MessageBox.Show("You need to insert a command.");
            }
            else
            {
                try
                {
                    CommandParser parser = new CommandParser(command);
                    ExecuteCommand(parser);
                    textBox1.Clear();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        /// <summary>
        /// This code is responsible for the moveto command by updative the coordinates.
        /// </summary>
        /// <param name="parser">This will process the command splitting from the parameters and checking.</param>
        private void MoveToCommand(CommandParser parser)
        {
            if (parser.Parameters.Count == 2 &&
                int.TryParse(parser.Parameters[0], out int x) &&
                int.TryParse(parser.Parameters[1], out int y))
            {
                
                centerX = x;
                centerY = y;

                panel1.Invalidate();

                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Invalid 'moveto' command format. Please use 'moveto x y'.");
            }
        }

        private void RunButton2_Click(object sender, EventArgs e)
        {
            ExecuteSingleLine(textBox1.Text.Trim());
        }
    }
}
