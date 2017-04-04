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
    public partial class ucFieldView : UserControl
    {
        internal List<IDraw> DrawsObject;
        Graphics g; 
        public ucFieldView()
        {
            InitializeComponent();
            DrawsObject = new List<IDraw>();
            g = CreateGraphics();
        }
        private void ucFieldView_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Brushes.Brown, 4);
            g.DrawLine(p, 0, Height * 2 / 3, Width, Height * 2 / 3);
            foreach (var item in DrawsObject)
            {
                item.Draw(g, item.PositionX, Height * 2 / 3 - item.Bounds.Height/2 );
            }   
        }
    }
}
