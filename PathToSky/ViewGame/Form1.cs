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
            string s = c.GenerateRandomField();
            Console.WriteLine(s.Substring(0, 9));
            Console.WriteLine(s.Substring(9, 9));
            Console.WriteLine(s.Substring(18, 9));
            List<Pair> cuples =  c.GetCuples(s, 9);
            Console.WriteLine("--------------------------");

            foreach (var item in cuples)
            {
                Console.WriteLine(item.ToString());

            }
        }
    }
}
