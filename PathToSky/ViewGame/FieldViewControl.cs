using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewGame
{
    public partial class FieldViewControl : UserControl
    {
        private List<Panel> FieldPanels;
        public FieldViewControl()
        {
            InitializeComponent();
            BuildField();
        }
        public void BuildField()
        {
            FieldPanels = new List<Panel>();
            int width = 9;
            int height = 12;
            int ImageSizeW = pView.Width / width;
            int ImageSizeH = pView.Height / height;
            for (int i = 0; i < width * height; i++)
            {
                Panel p = new Panel();
                p.Parent = pView;
                p.Location = new Point(i % width * ImageSizeW, i / width * ImageSizeH);
                p.BorderStyle = BorderStyle.FixedSingle;
                p.Size = new Size(ImageSizeW, ImageSizeH);
                //p.BackgroundImage = ResourceManager.GetBitMap('0');
                p.Tag = '0';
                p.BackgroundImageLayout = ImageLayout.Stretch;
                FieldPanels.Add(p);
            }
        }
        public  void LoadField(string INString)
        {
            for (int i = 0; i < INString.Length; i++)
            {
                FieldPanels[i].CreateGraphics().Clear(SystemColors.Control);
                if (INString[i] == '0')
                {
                    FieldPanels[i].CreateGraphics().Clear(Color.Blue);
                }
                else
                {
                    FieldPanels[i].CreateGraphics().DrawString(INString[i].ToString(), new Font("Arial", 12), Brushes.Blue, new Point(0, 0));
                }
              
            }
        }
    }
}
