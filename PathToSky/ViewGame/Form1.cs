using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathCore;

namespace ViewGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Core c =  new Core();
            c.GeneratePrepareField("106600231" + "100000245" + "600000485");
            DrawConsoleReport(c);
            c.DeletePair(c.GetPairAtPosition(2, 3));
            DrawConsoleReport(c);

        }
        public void DrawConsoleReport(Core c)
        {
            Console.WriteLine("+++++++++");
            Console.WriteLine(c.GameField.ToString().Substring(0, 9));
            Console.WriteLine(c.GameField.ToString().Substring(9, 9));
            Console.WriteLine(c.GameField.ToString().Substring(18, 9));
            List<Pair> cuples = c.GetCuples();
            Console.WriteLine("---------");

            foreach (var item in cuples)
            {
                Console.WriteLine(item.ToString());

            }
        }
    }
}
