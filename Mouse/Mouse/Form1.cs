using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mouse
{
    public partial class Form1 : Form
    {
        Graphics g;
        Timer t;
        float Tik = 0;
        float speed = 0;
        MathCore.Mouse mouse;
        MathCore.Wheel wheel;
        MathCore.EnergyBlock block;
        public Form1()
        {
            InitializeComponent();
            Wheel.Width = 200;
            Wheel.Height = 200;
            t = new Timer();
            t.Tick += T_Tick;
            t.Start();
            mouse = new MathCore.Mouse(100);
            wheel = new MathCore.Wheel(20, 1);
            block = new MathCore.EnergyBlock();
            wheel.PutMouse(mouse);
            wheel.ConnectBlock(block);
        }
        private void T_Tick(object sender, EventArgs e)
        {
            mouse.Update();
            wheel.Update();
            lPulse.Text = mouse.HeartTik.ToString();
            lhangry.Text = mouse.Hangry.ToString();
            lPowerOUT.Text = wheel.AngleSpeed.ToString();
            lBlock.Text = block.EnablePower.ToString();
            lMousePowerOutput.Text = mouse.PowerOUTBUFFERED.ToString();
            //if (Accelerate)
            //{
            //    speed += 0.9f;
            //    if (speed > 80) speed = 80;
            //}
            //else
            //{
            //    speed -= 0.4f;
            //    if (speed < 0) speed = 0;
            //}
            //Tik += speed;
            //if (Tik > 360) Tik -= 360;
            //Wheel.Invalidate();

        }

        //private void Wheel_Paint(object sender, PaintEventArgs e)
        //{
        //    Matrix m = new Matrix();
        //    m.RotateAt(Tik, new PointF(Wheel.Width / 2, Wheel.Height / 2));
            
        //    Pen p = new Pen(Brushes.Black,1);
        //    Pen r = new Pen(Brushes.Green, 2);
        //    r.DashStyle = DashStyle.Dash;
        //    g.Transform = m;
        //    g.DrawLine(p, new PointF(((float)Wheel.Width) / 4.0f, ((float)Wheel.Height) / 2.0f), new PointF(((float)Wheel.Width) * 3.0f / 4.0f, ((float)Wheel.Height) / 2.0f));
        //    g.DrawLine(p, new PointF(((float)Wheel.Width) / 2.0f, ((float)Wheel.Height) / 4.0f), new PointF(((float)Wheel.Width)  / 2.0f, ((float)Wheel.Height) * 3.0f/ 4.0f));
        //    g.DrawEllipse(r,new RectangleF(((float)Wheel.Width) / 4.0f, ((float)Wheel.Height) / 4.0f, ((float)Wheel.Width) / 2.0f, ((float)Wheel.Height) / 2.0f));
        //    lPulse.Text = speed.ToString();
        //}

        private void Wheel_MouseDown(object sender, MouseEventArgs e)
        {
            //Accelerate = true;
        }

        private void Wheel_MouseUp(object sender, MouseEventArgs e)
        {
            wheel.GetAcceletate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void bEatCheese_Click(object sender, EventArgs e)
        {
            mouse.MouseEat(new MathCore.Cheese());
        }
        private void bEquipHead_Click(object sender, EventArgs e)
        {
            mouse.Equip(new MathCore.MouseCap());
        }
    }
}
