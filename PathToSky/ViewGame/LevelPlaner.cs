using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewGame
{
    public partial class LevelPlaner : Form
    {
        List<Panel> PalletePanels;
        List<Panel> FieldPanels;
        Panel PalleteSelectedPanel = null;
        public string FieldString { get; set; }
        public LevelPlaner()
        {
            InitializeComponent();
            this.bSave.Click += Save_Click;
            PalletePanels = new List<Panel>();
            FieldPanels = new List<Panel>();
            BuildPallete();
            BuildField();
        }
        public LevelPlaner(string InString)
        {
            InitializeComponent();
            this.bSave.Click += Save_Click;

            PalletePanels = new List<Panel>();
            FieldPanels = new List<Panel>();
            BuildPallete();
            BuildField();
            Load(InString);
        }
        private void Save_Click(object o, EventArgs e)
        {
            FieldString = Save();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        public void BuildPallete()
        {
            int width = 9;
            int ImageSizeW = pPallete.Width / 3;
            string Line = "0123456789";
            const  int ImageSize = 50;
            for (int i = 0; i < Line.Length; i++)
            {
                Panel p = new Panel();
                p.Parent = pPallete;
                p.Location = new Point(i % 3 * ImageSizeW, i / 3 * ImageSizeW);
                p.BorderStyle = BorderStyle.FixedSingle;
                p.Size = new Size(ImageSizeW, ImageSizeW);
                p.BackgroundImage = ResourceManager.GetBitMap(Line[i]);
                p.BackgroundImageLayout = ImageLayout.Stretch;
                p.Tag = Line[i];
                p.Click += (o, e) =>
                {
                    PalleteSelectedPanel.BackColor = SystemColors.Control;
                    PalleteSelectedPanel = p;
                    PalleteSelectedPanel.BackColor = Color.Red;
                    p.Tag = (char)PalleteSelectedPanel.Tag;
                };
                PalletePanels.Add(p);
            }
            PalleteSelectedPanel = PalletePanels[0];
        }
        public void BuildField()
        {
            int width = 9;
            int height = 12;
            int ImageSizeW = pView.Width/ width;
            int ImageSizeH = pView.Height / height;
            for (int i = 0; i < width* height; i++)
            {
                Panel p = new Panel();
                p.Parent = pView;
                p.Location = new Point(i % width * ImageSizeW, i / width * ImageSizeH);
                p.BorderStyle = BorderStyle.FixedSingle;
                p.Size = new Size(ImageSizeW, ImageSizeH);
                p.BackgroundImage = ResourceManager.GetBitMap('0');
                p.Tag = '0';
                p.BackgroundImageLayout = ImageLayout.Stretch;
                p.Click += (o, e) =>
                {
                     p.BackgroundImage = ResourceManager.GetBitMap((char)PalleteSelectedPanel.Tag);
                     p.Tag = (char)PalleteSelectedPanel.Tag;
                };
                FieldPanels.Add(p);
            }
        }
        public void Load(string INString)
        {
            for (int i = 0; i < INString.Length; i++)
            {
                FieldPanels[i] = PalletePanels.Find(x => (char)x.Tag == INString[i]);
            }
        }
        public string Save()
        {
            string OUT = "";
            foreach (var item in FieldPanels)
            {
                OUT += (char)item.Tag;   
            }
            OUT = OUT.TrimEnd('0');
            return OUT;
        }
    }
}
