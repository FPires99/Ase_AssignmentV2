using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    public class Commands
    {
        /// <summary>
        /// This method is responsible to load a txt file.
        /// </summary>
        /// <param name="textBox2">This is where the text is going to appear after the load.</param>
        /// <param name="filePath">The path to be loaded.</param>
        public void LoadTextToFile(TextBox textBox2, string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string fileContents = File.ReadAllText(filePath);
                    textBox2.Text = fileContents;
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading file: " + ex.Message);
            }
        }

        /// <summary>
        /// This method saves the text entered into textbox2 to the downloads folder.
        /// </summary>
        /// <param name="text">Text to be saved</param>
        /// <returns></returns>
        public bool SaveTextToFile(string text)
        {
            try
            {
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                int fileNumber = 1;
                string filePath;

                do
                {
                    filePath = Path.Combine(downloadsPath, $"output{fileNumber}.txt");
                    fileNumber++;
                }
                while (File.Exists(filePath));

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(text);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// This method sets the pen colour on the colour specified at color string.
        /// </summary>
        /// <param name="colorString">The color string specifying the desired pen colour</param>
        /// <returns></returns>
        public Color SetPenColor(string colorString)
        {
            Color newColor;

            switch (colorString.ToLower())
            {
                case "blue":
                    newColor = Color.Blue;
                    MessageBox.Show("Pen color set to blue.");
                    break;
                case "red":
                    newColor = Color.Red;
                    MessageBox.Show("Pen color set to red.");
                    break;
                case "green":
                    newColor = Color.Green;
                    MessageBox.Show("Pen color set to green.");
                    break;
                default:
                    MessageBox.Show($"Invalid color '{colorString}' for the 'pen' command. Supported colors are 'blue', 'red', and 'green'.");
                    newColor = Color.Red; // Default to red in case of an error
                    break;
            }

            return newColor;
        }



    }
}
