using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace TestTowerConcept
{
    public partial class Form1 : Form
    {
        List<Monster> monsters;
        Timer t;
        GameCore core;
        public Form1()
        {
            InitializeComponent();
            core = new GameCore();
            ucFieldView1.Init(core);
            t = new Timer();
            t.Interval = 10;
            t.Tick += T_Tick;t.Start();
        }
        private void T_Tick(object sender, EventArgs e)
        {
            core.Update();
            ucFieldView1.Invalidate();
        }
    }
}
