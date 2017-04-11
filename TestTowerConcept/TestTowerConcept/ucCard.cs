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
        public Card card;
        public int Recharge;

        public ucCard()
        {
            InitializeComponent();
        }
        public new void Update()
        {
            if (card == null) pbPic.BackgroundImage = null;
            if (card is Mage) pbPic.BackgroundImage = Properties.Resources.Mage;
            if (card is Ogr) pbPic.BackgroundImage = Properties.Resources.Sleep_Troll;
            if (card is OloloSolder) pbPic.BackgroundImage = Properties.Resources.japonka;
            if (card is Knight) pbPic.BackgroundImage = Properties.Resources.Iojik;
            if (card is Bee) pbPic.BackgroundImage = Properties.Resources.Bee;
            if (card is RedCat) pbPic.BackgroundImage = Properties.Resources.Fox;
            if (card is WildDimon) pbPic.BackgroundImage = Properties.Resources.Rainbow_Hand;
            if (card is Orc) pbPic.BackgroundImage = Properties.Resources.Run_Boy;
            if (card is Kamicadze) pbPic.BackgroundImage = Properties.Resources.Lenin;
            if (card is Academic) pbPic.BackgroundImage = Properties.Resources.Smile;
            //если речардж есть
            if (Recharge > 0) lInfo.Text = Recharge.ToString();
            if (Recharge == 0) lInfo.Text = "Заряжено";
            if (Recharge < 0) lInfo.Text = "Перегрузка";
        }

        private void ucCard_Click(object sender, EventArgs e)
        {
            

        }

        private void ucCard_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Recharge < 0) return;                   
                Form1 f = this.Parent as Form1;
                f.PutCard(this);
            }
            if (e.Button == MouseButtons.Right)
            {
                Form1 f = this.Parent as Form1;
                f.ReloadCard(this);
            }
        }
    }
}
