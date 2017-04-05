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
        Core.GameCore Game; 
        public ucFieldView()
        {
            InitializeComponent();
            DrawsObject = new List<IDraw>();
            g = CreateGraphics();
        }
        public void Init(Core.GameCore game)
        {
            Game = game;
        }
        private void ucFieldView_Paint(object sender, PaintEventArgs e)
        {
            Game.Draw(g);     
        }
    }
}
