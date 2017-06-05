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
        Core c;
        public Form1()
        {
            InitializeComponent();
            c =  new Core();
            c.Run(new cmdGenerateField("123456789" + "123456789"));
        }
        public void DrawConsoleReport(Core c)
        {
            List<string> s = c.GetConsoleReport();
            for (int i = 0; i < s.Count; i++)
            {
                Console.WriteLine(s[i]);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            for (int i = 0; i < c.Field.Length; i++)
            {           
                    g.DrawImage(ResourceManager.GetBitMap(c.Field[i]), new Rectangle( (i%9) * 20, (i / 9) * 20, 20, 20));
            }
        }
    }
}
