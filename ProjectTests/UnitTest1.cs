using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Graphical_Programming_Language;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;



namespace ProjectTests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// This Unit Test is adding some parameters and then calling the method to finally check for the position of X AND Y.
        /// </summary>
        [TestMethod]
        public void MoveToCommandTest()
        {
            CommandParser parser = new CommandParser("moveto");
            parser.Parameters.Add("10");
            parser.Parameters.Add("20");

            Form1 instance = new Form1();

            instance.MoveToCommand(parser);

            Assert.AreEqual(10, instance.centerX);
            Assert.AreEqual(20, instance.centerY);
            
        }

        /// <summary>
        /// Tests the drawto method. It check if method updates coordinates x and Y.
        /// </summary>
        [TestMethod]
        public void DrawTo()
        {
            string validCommand = "drawto 100 200";
            CommandParser parser = new CommandParser(validCommand);
            Form1 form = new Form1();

            // Remember the initial values
            int initialCenterX = form.centerX;
            int initialCenterY = form.centerY;
            GraphicsPath initialPath = form.path;

            form.DrawTo(parser);

            // Verify that centerX and centerY were updated correctly
            Assert.AreEqual(100, form.centerX);
            Assert.AreEqual(200, form.centerY);
        }

        /// <summary>
        /// This test writes a line inside a empty form so we could use clearCommand to check if it clears.
        /// </summary>
        [TestMethod]
        public void TestClearCommand()
        {
            Form1 form = new Form1();

            form.path.AddLine(new Point(10, 10), new Point(20, 20));
            form.clearCommand();


            // Verify that the GraphicsPath is empty after using clear command.
            Assert.AreEqual(0, form.path.PointCount);


        }

        /// <summary>
        /// This test uses the command moveto to move the red dot to another position then resets the position and checks for current position
        /// </summary>
        [TestMethod]
        public void TestResetPen()
        {
            Form1 form = new Form1();
            form.ExecuteCommand(new CommandParser("moveto 100 100"));

            form.ResetPen();

            Assert.AreEqual(10, form.centerX);
            Assert.AreEqual(10, form.centerY);

        }
        /// <summary>
        /// Tests the size of a rectangle drawn.
        /// </summary>
        [TestMethod]
        public void RectangleSize()
        {
            
            int x = 100;
            int y = 100;
            int expectedWidth = 50;
            int expectedHeight = 30;

            Graphical_Programming_Language.Rectangle rectangle = new Graphical_Programming_Language.Rectangle(Color.Blue, x, y, expectedWidth, expectedHeight, fillEnabled: true);

          
            using (Bitmap bmp = new Bitmap(200, 200))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                rectangle.draw(g);

                // Assert: Check the size of the drawn rectangle
                Assert.AreEqual(expectedWidth, rectangle.width);
                Assert.AreEqual(expectedHeight, rectangle.height);
            }
        }
        /// <summary>
        /// This tests draws a circle then checks for his radius.
        /// </summary>
        [TestMethod]
        public void Draw_Circle()
        {
            int x = 100;
            int y = 100;
            int radius = 30;

            Circle circle = new Circle(Color.Blue, x, y, radius, fillEnabled: true);

            using (Bitmap bmp = new Bitmap(200, 200))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                circle.draw(g);

                // Assert: Check the size of the drawn circle
                Assert.AreEqual(radius * 2, circle.radius * 2);
                Assert.AreEqual(radius * 2, circle.radius * 2);

               
            }
        }
        /// <summary>
        /// This test draws a triangle then checks for side lenght.
        /// </summary>
        [TestMethod]
        public void Draw_Triangle()
        {
            int x = 100;
            int y = 100;
            int sideLength = 50;

            Triangle triangle = new Triangle(Color.Green, x, y, sideLength, fillEnabled: true);

            using (Bitmap bmp = new Bitmap(200, 200))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                triangle.draw(g);

                //Checks the size of the drawn triangle
                Assert.AreEqual(sideLength, triangle.sideLength);
                Assert.AreEqual(sideLength, triangle.sideLength);

            }
        }


        /// <summary>
        /// Tests execute single line by using a valid command and then checking position of the coordinates.
        /// </summary>
        [TestMethod]
        public void SingleLineCommands()
        {

            Form1 instance = new Form1();
            int initialX = instance.centerX;
            int initialY = instance.centerY;
            string validCommand = "moveto 50 50";

            instance.ExecuteSingleLine(validCommand);

            Assert.AreEqual(50, instance.centerX);
            Assert.AreEqual(50, instance.centerY);
            Assert.AreNotEqual(initialX, instance.centerX);
            Assert.AreNotEqual(initialY, instance.centerY);

        }

        /// <summary>
        /// This method tests the multi line commands method by using moveto commands and cheking their position in the end.
        /// </summary>
        [TestMethod]
        public void MultiLineCommands()
        {

            Form1 instance = new Form1();
            string validCommands = "moveto 50 50\nmoveto 100 100\nclear";
            instance.ExecuteMultiLineCommands(validCommands);

            Assert.AreEqual(100, instance.centerX);
            Assert.AreEqual(100, instance.centerY);

            Assert.AreNotEqual(50, instance.centerX);
            Assert.AreNotEqual(50, instance.centerY);

        }

        /// <summary>
        /// This test created a temporary file with some text then checks the text inside the file.
        /// </summary>
        [TestMethod]
        public void LoadTextToFile()
        {
            var textBox = new TextBox();
            var command = new Commands();

            // Create a temporary text file for testing
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, "Test Text");


            command.LoadTextToFile(textBox, tempFilePath);


            string loadedText = textBox.Text;
            Assert.AreEqual("Test Text", loadedText);


            File.Delete(tempFilePath);
        }

        /// <summary>
        /// This unit test is saving text into a file and return if it saved.
        /// </summary>
        [TestMethod]
        public void SaveTextToFile()
        {

            var commands = new Commands();
            string textToSave = "Test text to save.";


            bool result = commands.SaveTextToFile(textToSave);

            Assert.IsTrue(result);
        }
        /// <summary>
        /// This Unit Test test the Parser Input with a valid command with valid parameters
        /// </summary>
        [TestMethod]
        public void ParseInput()
        {
            string input = "moveto 100 100";
            CommandParser instance = new CommandParser(input);

            Assert.AreEqual("moveto", instance.CommandName);

            System.Diagnostics.Debug.WriteLine($"Actual Parameters Count: {instance.Parameters.Count}");

            CollectionAssert.AreEquivalent(new[] { "100", "100" }, instance.Parameters);
        }
        /// <summary>
        /// This unit tests checks if the command is valid.
        /// </summary>
        [TestMethod]
        public void ValidCommands()
        {

            var parser = new CommandParser("moveto 100 100");
            Assert.IsTrue(parser.IsValidCommand("moveto"));
            Assert.IsFalse(parser.IsValidCommand("hello"));
        }
        /// <summary>
        /// This Unit Test checks if the parameters are valid
        /// </summary>
        [TestMethod]
        public void IsValidParameter()
        {
            var parser = new CommandParser("moveto 100 100");


            Assert.IsTrue(parser.IsValidParameter("123"));
            Assert.IsTrue(parser.IsValidParameter("0"));
            Assert.IsFalse(parser.IsValidParameter("aaa"));
            Assert.IsTrue(parser.IsValidParameter("blue"));
        }


    }
}
