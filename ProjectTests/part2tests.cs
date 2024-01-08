using Graphical_Programming_Language;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectTests
{
    [TestClass]
    public class part2tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            
        }

        /// <summary>
        /// Tests the variable assignment functionality using multi-line commands.
        /// </summary>
        [TestMethod]
        public void TestVariableAssignment()
        {
            // Arrange
            Form1 form = new Form1();

            // Act
            form.ExecuteMultiLineCommands("x = 100");

            // Assert
            // Add assertions based on the expected state after the commands are executed
            Assert.IsTrue(form.variableCircleMap.ContainsKey("x"));
            Assert.AreEqual(100, form.variableValues[0]); 

            // Example: Check if no circle was created
            Assert.AreEqual(0, form.circles.Count);
        }
    }
}
