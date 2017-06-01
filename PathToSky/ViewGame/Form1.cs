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
            c.Run(new cmdGenerateField("0"));
            DrawConsoleReport(c);
            c.Run(new cmdDeletePair(6, 15));
            DrawConsoleReport(c);
            c.Run(new cmdDeleteLine());
            DrawConsoleReport(c);
        }
        public void DrawConsoleReport(Core c)
        {
            List<string> s = c.GetReport();
            for (int i = 0; i < s.Count; i++)
            {
                Console.WriteLine(s[i]);
            }
        }
    }
}
