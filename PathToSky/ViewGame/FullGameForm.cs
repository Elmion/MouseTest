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
    public partial class FullGameForm : Form
    {
        const int SIZE_TILE = 25;
        private Core c;
        GameViewManager GameView;
        public FullGameForm()
        {
            InitializeComponent();
            cbDeletesLine.Checked = true;//По умолчанию удаляем линии
            c = new Core();
            GameView = new GameViewManager(panel1, GetField, GetPairs);
            GameView.PairReady += IManager_PairReady;
            cbDeletesLine.CheckedChanged += ChangeDeleteLine;
            bRestart.Click += BRestart_Click;
            bRewrite.Click += bRewrite_Click;
            moveCancel.Click += moveCancel_Click;
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
        private object IManager_PairReady(int arg1, int arg2)
        {
            return c.Run(new cmdDeletePair(arg1, arg2));
        }

        public void DrawConsoleReport(Core c)
        {
            List<string> s = c.GetConsoleReport();
            for (int i = 0; i < s.Count; i++)
            {
                Console.WriteLine(s[i]);
            }
        }
        public void CheckLines()
        {
            if (c.haveLineToDelete)
            {
                c.Run(new cmdDeleteLine());
                panel1.Invalidate();
                CheckFinish();
            }
        }
        private void bRewrite_Click(object sender, EventArgs e)
        {
            c.Run(new cmdRewrite());
            panel1.Invalidate();
            CheckFinish();

        }

        private void moveCancel_Click(object sender, EventArgs e)
        {
            c.Undo();
            panel1.Invalidate();
            CheckFinish();
        }
        private void ChangeDeleteLine(object sender, EventArgs e)
        {
            GameView.LinesDeletes = cbDeletesLine.Checked;

            if (cbDeletesLine.Checked)
            {
                CheckLines();
            }
        }
        private void CheckFinish()
        {
            switch (c.GameState)
            {
                case GameStates.Processed:
                    bRewrite.BackColor = SystemColors.Control;
                    bRewrite.Text = "Переписываем";
                    bRewrite.Enabled = true;
                    break;
                case GameStates.GameOver:
                    bRewrite.BackColor = Color.Salmon;
                    bRewrite.Text = "Пройгрыш";
                    bRewrite.Enabled = false;
                    break;
                case GameStates.GameWin:
                    bRewrite.BackColor = Color.LawnGreen;
                    bRewrite.Text = "Победа";
                    bRewrite.Enabled = false;
                    break;
            }
        }
        private void BRestart_Click(object sender, EventArgs e)
        {
            c.Run(new cmdRestartGame());
            c.Run(new cmdGenerateField("123456789" +
                           "123456789" +
                           "123456789" +
                           "123456789"));
            panel1.Invalidate();
            CheckFinish();
        }

        private void bRestart_Click_1(object sender, EventArgs e)
        {

        }
    }
    public class GameViewManager
    {
        const int SIZE_TILE = 25;
        public event Func<int, int, object> PairReady;
        public bool LinesDeletes = true;
        private Panel gamePanel;
        private FieldPosition SelectedFrameStringPosition;//позиция рамки в string координатах
        private Point SelectedFrameDrawingPosition;

        private Func<string> GetField;
        private Func<List<Pair>> GetPairs;
        public GameViewManager(Panel p, Func<string> GetterField, Func<List<Pair>> GetterPairs)
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
                g.DrawImage(ResourceManager.GetBitMap(DrawingField[i]), new Rectangle(PositionConvertor.StringXToSnapGridXY(i), PositionConvertor.GetTileSize()));
            }
            if (SelectedFrameStringPosition != null)
            {
                g.DrawRectangle(new Pen(Brushes.Black, 3), new Rectangle(SelectedFrameDrawingPosition, PositionConvertor.GetTileSize()));
            }
        }

        void MouseClick(object sender, MouseEventArgs e)
        {
            const int AREA = 3;
            if (SelectedFrameStringPosition == null)
            {
                SelectedFrameStringPosition = new FieldPosition(PositionConvertor.MouseXYToStringX(e.X, e.Y), '0');
                SelectedFrameDrawingPosition = new Point(PositionConvertor.SnapToGridX(e.X), PositionConvertor.SnapToGridY(e.Y));
                gamePanel.Invalidate(new Rectangle(new Point(SelectedFrameDrawingPosition.X - AREA, SelectedFrameDrawingPosition.Y - AREA), PositionConvertor.GetTileSize() + new Size(2 * AREA, 2 * AREA)));
            }
            else
            {
                object CoreAnswer = PairReady(SelectedFrameStringPosition.Position, PositionConvertor.MouseXYToStringX(e.X, e.Y));//отправляем запрос в Ядро

                gamePanel.Invalidate(new Rectangle(new Point(PositionConvertor.SnapToGridX(e.X) - AREA, PositionConvertor.SnapToGridY(e.Y) - AREA), PositionConvertor.GetTileSize() + new Size(2 * AREA, 2 * AREA)));
                SelectedFrameStringPosition = null;
                gamePanel.Invalidate(new Rectangle(new Point(SelectedFrameDrawingPosition.X - AREA, SelectedFrameDrawingPosition.Y - AREA), PositionConvertor.GetTileSize() + new Size(2 * AREA, 2 * AREA)));
                if (LinesDeletes) ((FullGameForm)gamePanel.Parent).CheckLines();
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
            int buff = (int)Math.Ceiling(SIZE_TILE * 1.4f);
            return (mouseCoordinate / buff) * buff;
        }
        public static int MouseXYToStringX(int x, int y)
        {
            return (x / SIZE_TILE) + (int)((y / (SIZE_TILE * 1.4f))) * 9; //9 размер поля
        }
        public static Size GetTileSize()
        {
            return new Size(SIZE_TILE + 4, (int)(SIZE_TILE * 1.4f + 4));
        }
        public static Point StringXToSnapGridXY(int x)
        {
            return new Point((x % 9) * SIZE_TILE, (int)((x / 9) * SIZE_TILE * 1.4f));
        }
    }
}
