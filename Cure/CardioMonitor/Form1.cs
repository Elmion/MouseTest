using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Health;

namespace CardioMonitor
{
    public partial class Form1 : Form
    {
        Timer t;
        Heart heart;
        DateTime timePreverios;
        float animationHeart = 0.9f;
        private const float ANIMATION_SPEED = 0.2f;

        public Form1()
        {
            InitializeComponent();
            heart = new Heart();
            heart.Tuk += ResetAnimationHeart;
            t = new Timer();
            t.Tick += T_Tick;
            timePreverios = DateTime.Now;
            t.Start();
        }
        private void ResetAnimationHeart()
        {
            animationHeart = 0.7f;
        }
        private void TukGraficks()
        {
            if(animationHeart < 1.00f) animationHeart += ANIMATION_SPEED; 
            pPicHeart.Size = new Size((int) (pHeart.Size.Width * animationHeart), (int) (pHeart.Size.Height * animationHeart));
            pPicHeart.Location = new Point((int)(pHeart.Width / 2 - pHeart.Size.Width * animationHeart / 2), (int)(pHeart.Height / 2 - pHeart.Size.Height * animationHeart / 2));
        }

        private void T_Tick(object sender, EventArgs e)
        {
            DateTime bufTime = DateTime.Now;
            heart.Update(bufTime.Ticks - timePreverios.Ticks);
            timePreverios = bufTime;
            TukGraficks();
            tBPM.Text = heart.CurrentBPM.ToString();
            tPblood.Text = heart.CurrentPressure.ToString();
        }

        private void bAcceleration_Click(object sender, EventArgs e)
        {
            heart.Acceleration(Power.Medium);
        }

        private void bDeceleration_Click(object sender, EventArgs e)
        {
            heart.Deceleration(Power.Medium);
        }
    }
}
