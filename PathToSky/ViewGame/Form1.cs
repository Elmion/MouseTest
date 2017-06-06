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
        private Core c;
        PaintInfo pInfo;
        GameViewManager iManager;
        public Form1()
        {
            InitializeComponent();
            c =  new Core();
            pInfo = new PaintInfo();
            iManager = new GameViewManager(panel1, GetField , GetPairs);
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
        //Две дергалки свойств дабы не отдавать Core  во вью
        #region Дергалки
        private string GetField()
        {
            return c.Field;
        }
        private List<Pair> GetPairs()
        {
            return c.CurrentPairs;
        } 
        #endregion
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
        private FieldPosition SelectedFrameStringPosition;//позиция рамки в string координатах
        private Point SelectedFrameDrawingPosition;

        private Func<string> GetField;
        private Func<List<Pair>> GetPairs;
        public GameViewManager(Panel p,Func<string> GetterField,Func<List<Pair>> GetterPairs)
        {
            gamePanel = p;
            gamePanel.MouseClick += MouseClick;
            gamePanel.Paint += GamePanel_Paint;
            SelectedFrameStringPosition = null;
            GetField = GetterField;
            GetPairs = GetterPairs;
        }
        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = gamePanel.CreateGraphics();
            string DrawingField = GetField();
            for (int i = 0; i < GetField().Length; i++)
            {
                g.DrawImage(ResourceManager.GetBitMap(DrawingField[i]), new Rectangle((i % 9) * SIZE_TILE, (int)((i / 9) * SIZE_TILE * 1.4f), SIZE_TILE, (int)(SIZE_TILE * 1.4f)));
            }
            if (SelectedFrameStringPosition != null)
            {
                g.DrawRectangle(new Pen(Brushes.Black, 3), new Rectangle(pInfo.PositionFrame.X * SIZE_TILE, (int)(pInfo.PositionFrame.Y * SIZE_TILE * 1.4f), SIZE_TILE, (int)(SIZE_TILE * 1.4f)));
            }
        }

        void MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectedFrameStringPosition == null)
            {
                SelectedFrameStringPosition = new FieldPosition(PositionConvertor.MouseXYToStringX(e.X,e.Y), '0');
                SelectedFrameDrawingPosition = new Point(PositionConvertor.SnapToGridX(e.X), PositionConvertor.SnapToGridY(e.Y));

                gamePanel.Invalidate(new Rectangle(SelectedFrameDrawingPosition (e.X / SIZE_TILE) * SIZE_TILE,(int)(e.Y / (SIZE_TILE * 1.4f) * SIZE_TILE * 1.4f), SIZE_TILE, (int)(SIZE_TILE * 1.4f)));
            }
            else
            {
                PairReady(SelectedFrameStringPosition.Position, PositionConvertor.MouseXYToStringX(e.X,e.Y)); //отправляем запрос в Ядро
                SelectedFrameStringPosition = null;
                gamePanel.Invalidate(new Rectangle(SelectedFrameDrawingPosition, new Size(SIZE_TILE + 4, (int)(SIZE_TILE * 1.4f + 4))));
            }
        }
    }
    public class PositionConvertor
    {
        const int SIZE_TILE = 25;
        public static int SnapToGridX(int mouseCoordinate)
        {
            return (mouseCoordinate / SIZE_TILE) * SIZE_TILE;
        }
        public static int SnapToGridY(int mouseCoordinate)
        {
            int buff = (int)Math.Floor(SIZE_TILE * 1.4f);
            return (mouseCoordinate / buff) * buff;
        }
        public static int MouseXYToStringX(int x,int y)
        {
            return (x / SIZE_TILE) + (int)((y / (SIZE_TILE * 1.4f))) * 9; //9 размер поля
        }
    }
}
