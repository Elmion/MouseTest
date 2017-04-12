using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTowerConcept
{
    public partial class ucCristalCollector : UserControl
    {
        public int CristalCount { get; set; }
        public ucCristalCollector()
        {
            InitializeComponent();
            pictureBox1.MouseDown += lCriCount_MouseDown;
            lCriCount.MouseDown += lCriCount_MouseDown;
        }
        public void Update()
        {
            lCriCount.Text = CristalCount.ToString();
        }
        private void lCriCount_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop( this , DragDropEffects.Copy);
        }
        

    }
}
