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
        AnalyseForm f;
        public Form1()
        {
            InitializeComponent();
            f = new AnalyseForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {

            };
        }
    }

}
