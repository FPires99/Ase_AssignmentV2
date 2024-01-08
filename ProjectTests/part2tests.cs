using Graphical_Programming_Language;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;

namespace ProjectTests
{
    [TestClass]
    public class part2tests
    {
        /// <summary>
        /// Tests the variable assignment functionality using multi-line commands.
        /// </summary>
        /// <remarks>
        /// This test ensures that the ExecuteMultiLineCommands method correctly processes a variable assignment
        /// followed by the "circle" command and checks the expected state of the form and associated objects.
        [TestMethod]
        public void TestVariableAssignment()
        {
            Form1 form = new Form1();
            form.ExecuteMultiLineCommands("x = 100\n circle x");

            // Assert
            // Add assertions based on the expected state after the commands are executed
            Assert.IsTrue(form.variableCircleMap.ContainsKey("x"));
            Assert.AreEqual(100, form.variableValues[0]);

            //Check if one circle was created
            Assert.AreEqual(1, form.circles.Count);

            // Example: Check if the circle has the correct properties using fields directly
            Circle createdCircle = form.circles[0];
            Assert.AreEqual(100, createdCircle.radius);
        }

        /// <summary>
        ///  This test ensures that the ExecuteWhileLoop method executes the loop when given valid parameters and checks the output.
        /// </summary>
        [TestMethod]
        public void ExecuteWhileLoop_ValidParameters()
        {
           
            Form1 form = new Form1();
            CommandParser validParser = new CommandParser("while x < 5");

            // Set up a variable with a numeric value
            form.variableNames[0] = "x";
            form.variableValues[0] = 3;

            // Act
            form.ExecuteWhileLoop(validParser);

            Assert.IsTrue(form.outputMessages.Contains("Executing command: messagebox \"Hello world\""));
        }
    
    }
}
