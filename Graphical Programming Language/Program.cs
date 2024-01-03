using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Form1 c = new Form1();
            c.ShowDialog();
            Console.ReadLine();
        }
    }
}
