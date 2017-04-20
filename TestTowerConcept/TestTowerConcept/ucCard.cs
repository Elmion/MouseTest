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
    public partial class ucCard : UserControl
    {
        public string card;
        public int Recharge;
        public int Cristall;
        public List<string> Effects;

        private bool TryDragCristal = false;
        public CristallRecycle cr;
        Rectangle dragBoxFromMouseDown;

        public ucCard()
        {
            InitializeComponent();
            pbPic.MouseClick += ucCard_MouseClick;
            //pbPic.DragDrop += ucCard_DragDrop;
            lInfo.MouseClick += ucCard_MouseClick;
            Cristall = 0;
           
        }
        public new void Update()
        {
            if (card == null) pbPic.BackgroundImage = null;
            if (card == "Mage") pbPic.BackgroundImage = Properties.Resources.Mage;
            if (card == "Ogr") pbPic.BackgroundImage = Properties.Resources.Sleep_Troll;
            if (card == "OloloSolder") pbPic.BackgroundImage = Properties.Resources.japonka;
            if (card == "Knight") pbPic.BackgroundImage = Properties.Resources.Iojik;
            if (card == "Bee") pbPic.BackgroundImage = Properties.Resources.Bee;
            if (card == "RedCat") pbPic.BackgroundImage = Properties.Resources.Fox;
            if (card == "WildDimon") pbPic.BackgroundImage = Properties.Resources.Rainbow_Hand;
            if (card == "Orc") pbPic.BackgroundImage = Properties.Resources.Run_Boy;
            if (card == "Kamicadze") pbPic.BackgroundImage = Properties.Resources.Lenin;
            if (card == "Academic") pbPic.BackgroundImage = Properties.Resources.Smile;
            //если речардж есть
            if (Recharge > 0) lInfo.Text = Recharge.ToString();
            if (Recharge == 0) lInfo.Text = "Заряжено";
            if (Recharge < 0) lInfo.Text = "Перегрузка";
            lCri.Text = Cristall.ToString();
        }

        private void ucCard_MouseClick(object sender, MouseEventArgs e)
        {

        }
        public void ucCard_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ucCristalCollector)))
            {
                ucCristalCollector c = e.Data.GetData(typeof(ucCristalCollector)) as ucCristalCollector;
                c.CristalCount--;
                Cristall++;
                Form1 f = this.Parent as Form1;
                f.AddCristall(this);
            }
            if (e.Data.GetDataPresent(typeof(ucCard)))
            {
                ucCard c = e.Data.GetData(typeof(ucCard)) as ucCard;
                if(c != this)
                {
                    Cristall++;
                    c.Cristall--;
                    Form1 f = this.Parent as Form1;
                    f.ReplaceCristall(c,this);
                }
                if (c.cr != null) c.cr.Dispose();//удаляем карзинку образовавшуюся при перетаскивании на первоночальном слоте
            }
        }
        private void ucCard_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void ucCard_MouseDown_1(object sender, MouseEventArgs e)
        {
             dragBoxFromMouseDown = new Rectangle(e.X - 5, e.Y - 5, 10,10 );
        }
 

        private void ucCard_MouseUp(object sender, MouseEventArgs e)
        {
            dragBoxFromMouseDown = Rectangle.Empty;
            if (e.Button == MouseButtons.Left)
            {
                if (Recharge < 0) return;
                Form1 f = this.Parent as Form1;
                f.PutCard(this);
            }
            if (e.Button == MouseButtons.Right)
            {
                if (Recharge < 0) return;
                Form1 f = this.Parent as Form1;
                f.ReloadCard(this);
            }

        }

        private void ucCard_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.Location))
            {
                cr = new CristallRecycle();
                cr.Parent = this.Parent;
                cr.AllowDrop = true;
                cr.Location = new Point(this.Location.X, this.Location.Y - 71);
                cr.BringToFront();
                cr.Show();
                dragBoxFromMouseDown = Rectangle.Empty;
                DoDragDrop(this, DragDropEffects.Copy);
            }
        }

        private void ucCard_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("-----------------+");
            Console.WriteLine(card);
            Console.WriteLine("-----------------+");
            for (int i = 0; i < Effects.Count; i++)
            {
                Console.WriteLine(Effects[i]);
            }
            Console.WriteLine("-----------------+");
        }
    }
}
