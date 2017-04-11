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
        public bool InReload;
        public ucCard()
        {
            InitializeComponent();
        }
        public new void Update()
        {
            if (card == null) pbPic.BackgroundImage = null;
            if (card is Mage) pbPic.BackgroundImage = Properties.Resources.Mage;
            if (card is Ogr) pbPic.BackgroundImage = Properties.Resources.Sleep_Troll;

            //если речардж есть
            if (Recharge > 0) lInfo.Text = Recharge.ToString();
            if (Recharge == 0) lInfo.Text = "Заряжено";
            if (InReload) lInfo.Text = "Перегрузка";
        }

        private void ucCard_Click(object sender, EventArgs e)
        {
            Form1 f = this.Parent as Form1;
            f.PutCard(this);
        }
    }
}
