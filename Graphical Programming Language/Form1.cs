﻿using System;
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

                case "run":
                    ExecuteMultiLineCommands(textBox2.Text);
                    textBox2.Clear();
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
        /// This methods reads muiltiple commands.
        /// </summary>
        /// <param name="inputCommands">This is the string that contains the command</param>
        ///<remarks>
        ///This method separates the command and the parameters stored in  the string 
        ///inputCommands then executes parsed command 
        ///to process the command including a while loop to go 
        ///over all the commands inputted.
        ///<remarks>
        public void ExecuteMultiLineCommands(string inputCommands)
        {
            if (string.IsNullOrWhiteSpace(inputCommands))
            {
                MessageBox.Show("You need to insert commands.");
            }
            else
            {
                string[] commandLines = inputCommands.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string commandLine in commandLines)
                {
                    try
                    {
                        CommandParser parser = new CommandParser(commandLine.Trim());
                        ExecuteCommand(parser);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
                textBox2.Clear();
            }
        }
        /// <summary>
        /// This code is responsible for the moveto command by updative the coordinates.
        /// </summary>
        /// <param name="parser">This will process the command splitting from the parameters and checking.</param>
        public void MoveToCommand(CommandParser parser)
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

        private void RunButton1_Click(object sender, EventArgs e)
        {
            ExecuteMultiLineCommands(textBox2.Text.Trim());
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string selectedFilePath = openFileDialog.FileName;

                    commands.LoadTextToFile(textBox2, selectedFilePath);
                }
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string textToSave = textBox2.Text;

            if (commands.SaveTextToFile(textToSave))
            {
                MessageBox.Show("Text saved to file successfully!");
            }
            else
            {
                MessageBox.Show("Failed to save text to the file.");
            }
        }
    }
}
