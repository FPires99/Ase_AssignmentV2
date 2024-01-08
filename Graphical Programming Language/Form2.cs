using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    public partial class Form2 : Form
    {

        public int dotSize = 20;
        public int centerX = 10;
        public int centerY = 10;
        public Color dotColor = Color.Red;
        public Brush dotBrush;
        private Commands commands;
        public GraphicsPath path = new GraphicsPath();
        private bool fillEnabled = false;
        public List<Rectangle> rectangles = new List<Rectangle>();
        public List<Circle> circles = new List<Circle>();
        private List<Triangle> triangles = new List<Triangle>();
        public string[] variableNames = new string[100];
        public int[] variableValues = new int[100];
        public int variableCounter = 0;
        public Dictionary<string, Circle> variableCircleMap = new Dictionary<string, Circle>();
        public bool isInsideLoop = false;
        public List<string> outputMessages = new List<string>();


        public Form2()
        {
            InitializeComponent();
            panel1.Invalidate();
            commands = new Commands();
        }

        public void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                // Draw the dot on the panel using class-level fields
                dotBrush = new SolidBrush(dotColor);

                // Draw the dot on the panel at the current position
                g.FillEllipse(dotBrush, centerX - dotSize / 2, centerY - dotSize / 2, dotSize, dotSize);

                // Draw the path on the graphics object
                using (Pen linePen = new Pen(Color.Black, 2))
                {
                    g.DrawPath(linePen, path);
                }

                foreach (Rectangle rectangle in rectangles)
                {
                    rectangle.draw(g);
                }
                foreach (Circle circle in circles)
                {
                    circle.draw(g);
                }
                foreach (Triangle triangle in triangles)
                {
                    triangle.draw(g);
                }
            }
        }
        /// <summary>
        /// This method is going to be responsible to execute all the commands in the program.
        /// </summary>
        /// <param name="parser">Processes the commands and the parameters</param>
        public void ExecuteCommand(CommandParser parser)
        {
            MessageBox.Show($"Executing command: {parser.CommandName}");

            {
                switch (parser.CommandName)
                {
                    case "while":
                        ExecuteWhileLoop(parser);
                        break;

                    case "messagebox":

                        if (!isInsideLoop)
                        {
                            MessageBox.Show("Executing command messagebox");

                            ExecuteSingleLine("messagebox " + string.Join(" ", parser.Parameters));
                        }
                        break;

                    case "moveto":
                        MoveToCommand(parser);
                        break;

                    case "run":
                        ExecuteMultiLineCommands(textBox2.Text);
                        textBox2.Clear();
                        break;

                    case "drawto":
                        DrawTo(parser);
                        break;

                    case "clear":
                        clearCommand();
                        break;

                    case "reset":
                        ResetPen();
                        break;

                    case "rectangle":
                        if (parser.Parameters.Count == 2 &&
                        int.TryParse(parser.Parameters[0], out int width) &&
                        int.TryParse(parser.Parameters[1], out int height))
                        {
                            Rectangle rectangle = new Rectangle(dotColor, centerX, centerY, width, height, fillEnabled);
                            rectangles.Add(rectangle);
                            rectangle.draw(panel1.CreateGraphics());
                            textBox1.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Invalid 'rectangle' command format. Please use 'rectangle width height'.");
                        }
                        break;

                    case "circle":
                        if (parser.Parameters.Count == 1)
                        {
                            string parameter = parser.Parameters[0];

                            // Check if it's a variable
                            if (IsVariable(parameter, out int variableValue))
                            {
                                // Create a new Circle with the specified radius from the variable
                                Circle circle = new Circle(dotColor, centerX, centerY, variableValue, fillEnabled);
                                circles.Add(circle);
                                circle.draw(panel1.CreateGraphics());
                                textBox1.Clear();
                            }
                            else
                            {
                                MessageBox.Show($"Variable '{parameter}' not found or does not have a numeric value.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid 'circle' command format. Please use 'circle radiusOrVariable'.");
                        }
                        break;


                    case "triangle":
                        if (parser.Parameters.Count == 1 && int.TryParse(parser.Parameters[0], out int sideLength))
                        {
                            Triangle triangle = new Triangle(dotColor, centerX, centerY, sideLength, fillEnabled);
                            triangles.Add(triangle);
                            triangle.draw(panel1.CreateGraphics());
                            textBox1.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Invalid 'triangle' command format. Please use 'triangle sideLength'.");
                        }
                        break;

                    case "pen":
                        if (parser.Parameters.Count == 1)
                        {
                            string colorString = parser.Parameters[0];
                            dotColor = commands.SetPenColor(colorString);
                        }
                        else
                        {
                            MessageBox.Show("Invalid 'pen' command format. Please use 'pen color', where color is the desired pen color.");
                        }
                        break;

                    case "fill":
                        if (parser.Parameters.Count == 1 && int.TryParse(parser.Parameters[0], out int fillOption))
                        {
                            switch (fillOption)
                            {
                                case 1:
                                    fillEnabled = true;
                                    break;
                                case 2:
                                    fillEnabled = false;
                                    break;
                                default:
                                    MessageBox.Show("Invalid 'fill' command option. Please use 'fill 1' for fill on or 'fill 2' for fill off.");
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid 'fill' command format. Please use 'fill 1' for fill on or 'fill 2' for fill off.");
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// Executes a while loop based on the provided command parser.
        /// </summary>
        /// <param name="parser">The command parser for the while loop parameters.</param>
        /// This method checks if the while loop parameters are in the correct format (while variable < count).
        /// If the condition is met, it executes the loops commands. The variable should be a valid numeric variable.
        public void ExecuteWhileLoop(CommandParser parser)
        {
            if (parser.Parameters.Count == 3 &&
                int.TryParse(parser.Parameters[2], out int loopCount))
            {
                string loopVariable = parser.Parameters[0];

                // Check if the loop variable is a valid variable
                if (IsVariable(loopVariable, out int variableValue))
                {
                    while (variableValue < loopCount)
                    {
                        // Output the message to the console
                        string message = $"Executing command: messagebox \"Hello world\"";
                        Console.WriteLine(message);

                        // Store the message in the outputMessages list
                        outputMessages.Add(message);

                        // Update the loop variable value
                        variableValue++;

                        // Optionally, you can add a delay between iterations to visualize the loop
                        System.Threading.Thread.Sleep(500);
                    }
                }
                else
                {
                    MessageBox.Show($"Variable '{loopVariable}' not found or does not have a numeric value.");
                }
            }
            else
            {
                MessageBox.Show("Invalid 'while' command format. Please use 'while variable < count'.");
            }
        }
        /// <summary>
        /// Checks if the specified parameter is a variable.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="variableValue">If the parameter is a variable, contains its value; otherwise, set to 0.</param>
        /// <returns>True if the parameter is a variable, false otherwise.</returns>
        public bool IsVariable(string parameter, out int variableValue)
        {
            // Check if the parameter is a variable by looking it up in the variableNames array
            int index = Array.IndexOf(variableNames, parameter);

            if (index != -1 && variableValues[index] != 0)
            {
                // If the variable exists and has a non-zero value, get its value from the variableValues array
                variableValue = variableValues[index];
                return true;
            }

            variableValue = 0; // Default value 
            return false;
        }

        /// <summary>
        /// Handles the assignment of a value to a variable.
        /// </summary>
        /// <param name="command">The command representing the variable assignment.</param>
        public void HandleVariableAssignment(string command)
        {
            // Split the command into variable name and value
            string[] parts = command.Split('=');

            if (parts.Length == 2)
            {
                string variableName = parts[0].Trim();
                string variableValueString = parts[1].Trim();

                // Check if the variable value is numeric
                if (int.TryParse(variableValueString, out int variableValue))
                {
                    // Assign the variable value to the variableName
                    AssignVariable(variableName, variableValue);
                }
                else
                {
                    MessageBox.Show("Invalid variable assignment. Variable value must be a numeric value.");
                }
            }
            else
            {
                MessageBox.Show("Invalid variable assignment format. Please use 'variableName = value'.");
            }
        }

        /// <summary>
        /// Assigns a value to a variable and updates the associated Circle.
        /// </summary>
        /// <param name="variableName">The name of the variable.</param>
        /// <param name="variableValue">The value to assign to the variable.</param>
        public void AssignVariable(string variableName, int variableValue)
        {
            int index = Array.IndexOf(variableNames, variableName);

            if (index != -1)
            {
                Circle existingCircle = variableCircleMap[variableName];
                existingCircle.SetRadius(variableValue);

                // Update the variableValues array with the correct value
                variableValues[index] = variableValue;

                panel1.Invalidate();
                MessageBox.Show($"Variable '{variableName}' updated. Radius set to: {variableValue}");
            }
            else
            {
                // Add the variable to the dictionary
                Circle newCircle = new Circle(dotColor, centerX, centerY, variableValue, fillEnabled);
                variableCircleMap.Add(variableName, newCircle);

                // Resize the variableValues array to accommodate the new variable
                Array.Resize(ref variableNames, variableCounter + 1);
                Array.Resize(ref variableValues, variableCounter + 1);

                // Update the variableValues array with the correct value
                variableNames[variableCounter] = variableName;
                variableValues[variableCounter] = variableValue;

                variableCounter++;

                MessageBox.Show($"Variable '{variableName}' created with value: {variableValue}");
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
                    panel1.Invalidate();

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
                    // Trim leading and trailing whitespaces
                    string trimmedCommand = commandLine.Trim();

                    // Skip empty lines
                    if (string.IsNullOrEmpty(trimmedCommand))
                    {
                        continue;
                    }

                    try
                    {
                        // Check if the command contains an equal sign (=), indicating a variable assignment
                        if (trimmedCommand.Contains("="))
                        {
                            HandleVariableAssignment(trimmedCommand);
                        }
                        else
                        {
                            // If not a variable assignment, proceed with regular command execution
                            CommandParser parser = new CommandParser(trimmedCommand);
                            ExecuteCommand(parser);
                            panel1.Invalidate();
                        }
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
        /// <summary>
        /// This command allows the user to draw a line from the current position to a specific point
        /// </summary>
        /// <param name="parser">This method is using parser class to process the command  and do the checks.</param>
        public void DrawTo(CommandParser parser)
        {
            if (parser.Parameters.Count == 2 &&
                int.TryParse(parser.Parameters[0], out int xValue) &&
                int.TryParse(parser.Parameters[1], out int yValue))
            {
                // Add a line segment to the path
                path.AddLine(centerX, centerY, xValue, yValue);

                // Update the current position
                centerX = xValue;
                centerY = yValue;

                // Redraw the panel to reflect the drawing
                panel1.Invalidate();
            }
            else
            {
                MessageBox.Show("Invalid 'drawto' command format. Please use 'drawto x y'.");
            }
        }

        /// <summary>
        /// This command clears the drawing.
        /// </summary>
        public void clearCommand()
        {
            path.Reset();
            panel1.Invalidate();
        }

        /// <summary>
        /// This command resets pen to initial position.
        /// </summary>
        public void ResetPen()
        {
            centerX = 10;
            centerY = 10;
            panel1.Invalidate();
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

 
