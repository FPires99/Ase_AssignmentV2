using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Graphical_Programming_Language;

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
    }
}
