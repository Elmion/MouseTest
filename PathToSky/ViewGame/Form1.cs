using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathCore;

namespace ViewGame
{

    public partial class Form1 : Form
    {
        const int SIZE_TILE = 25;
        Core c;
        PaintInfo pInfo;
        InputManager iManager;
        public Form1()
        {
            InitializeComponent();
            c =  new Core();
            pInfo = new PaintInfo();
            iManager = new InputManager(panel1);
            iManager.PairReady += IManager_PairReady;
            c.Run(new cmdGenerateField("123456789" +
                                       "123456789" +
                                       "123456789" +
                                       "123456789" +
                                       "123456789" +
                                       "123456789" +
                                       "123456789" +
                                       "123456789" +
                                       "123456789" +
                                       "123456789" +
                                       "123456789" +
                                       "123456789" ));
            
        }

        private void IManager_PairReady(int arg1, int arg2)
        {
            c.Run(new cmdDeletePair(arg1, arg2));
            panel1.Invalidate();
        }

        public void DrawConsoleReport(Core c)
        {
            List<string> s = c.GetConsoleReport();
            for (int i = 0; i < s.Count; i++)
            {
                Console.WriteLine(s[i]);
            }
        }  
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
    public class GameViewManager
    {
        const int SIZE_TILE = 25;
        public event Action<int,int> PairReady;
        private Panel gamePanel;
        private FieldPosition OnePosition;
        private FieldPosition TwoPosition;
        public GameViewManager(Panel p)
        {
            gamePanel = p;
            gamePanel.MouseClick += MouseClick;
            gamePanel.Paint += GamePanel_Paint;
            OnePosition = null;
            TwoPosition = null;
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            for (int i = 0; i < c.Field.Length; i++)
            {
                g.DrawImage(ResourceManager.GetBitMap(c.Field[i]), new Rectangle((i % 9) * SIZE_TILE, (int)((i / 9) * SIZE_TILE * 1.4f), SIZE_TILE, (int)(SIZE_TILE * 1.4f)));
            }
            if (pInfo.SelectFrameVisible)
            {
                g.DrawRectangle(new Pen(Brushes.Black, 3), new Rectangle(pInfo.PositionFrame.X * SIZE_TILE, (int)(pInfo.PositionFrame.Y * SIZE_TILE * 1.4f), SIZE_TILE, (int)(SIZE_TILE * 1.4f)));
            }
        }

        void MouseClick(object sender, MouseEventArgs e)
        {
            if (OnePosition == null)
            { 
                OnePosition = new FieldPosition((e.X/ SIZE_TILE) + (int)((e.Y/ (SIZE_TILE * 1.4f) )) * 9, '0');
                pInfo.SetFramAt((int)e.X / SIZE_TILE, (int)(e.Y / (SIZE_TILE * 1.4f)));
                gamePanel.Invalidate(new Rectangle((e.X / SIZE_TILE) * SIZE_TILE,(int)(e.Y / (SIZE_TILE * 1.4f) * SIZE_TILE * 1.4f), SIZE_TILE, (int)(SIZE_TILE * 1.4f)));
            }
            else
            {
                TwoPosition = new FieldPosition((e.X / SIZE_TILE) + (int)((e.Y / (SIZE_TILE * 1.4f))) * 9, '0');
                PairReady(OnePosition.Position, TwoPosition.Position);
                OnePosition = null;
                TwoPosition = null;
                gamePanel.Invalidate(new Rectangle(pInfo.PositionFrame.X * SIZE_TILE - 2, (int)(pInfo.PositionFrame.Y * SIZE_TILE * 1.4f) - 2, SIZE_TILE + 4, (int)(SIZE_TILE * 1.4f + 4)));
            }
        }
        
    }
    public class PaintInfo
    {
        public bool SelectFrameVisible = false;
        public Point PositionFrame;
        public PaintInfo()
        {
            PositionFrame = new Point();
        }
        public void SetFramAt(int x, int y)
        {
            SelectFrameVisible = !SelectFrameVisible;
            PositionFrame = new Point(x, y);
        }
    }
}
