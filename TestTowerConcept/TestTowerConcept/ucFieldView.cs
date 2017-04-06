using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonElement;

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
          List<SceneItemInfo> listDrawElement = Game.GetDrawInfo();
            foreach (SceneItemInfo itemInfo in listDrawElement)
            {
                if(itemInfo.NameCommonObject == "Mage")
                {
                    g.DrawRectangle(new Pen(Brushes.Red), new Rectangle((int)(itemInfo.PositionX - itemInfo.Bounds.Width / 2), (int)(itemInfo.PositionY - itemInfo.Bounds.Height / 2 + 50), (int)itemInfo.Bounds.Width, (int)itemInfo.Bounds.Height));
                }
                if (itemInfo.NameCommonObject == "Ogr")
                    {
                    g.DrawRectangle(new Pen(Brushes.Peru), new Rectangle((int)(itemInfo.PositionX - itemInfo.Bounds.Width / 2), (int)(itemInfo.PositionY - itemInfo.Bounds.Height / 2 + 50), (int)itemInfo.Bounds.Width, (int)itemInfo.Bounds.Height));
                }
                if (itemInfo.NameCommonObject == "Portal")
                {
                    g.DrawRectangle(new Pen(Brushes.Black), new Rectangle((int)(itemInfo.PositionX - itemInfo.Bounds.Width / 2), (int)(itemInfo.PositionY - itemInfo.Bounds.Height / 2 + 50), (int)itemInfo.Bounds.Width, (int)itemInfo.Bounds.Height));
                }
            }        
        }
    }
}
