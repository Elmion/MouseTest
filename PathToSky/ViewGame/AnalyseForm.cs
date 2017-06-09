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
    public partial class AnalyseForm : Form
    {
        string AnalyseString = "";
        Core core;
        private int counter = 0;
        private List<string> FinalFields;


        private List<Panel> FieldPanels;


        public AnalyseForm()
        {
            InitializeComponent();
            core = new Core();
            BuildField();
        }

        private void bLoadTest_Click(object sender, EventArgs e)
        {
            AnalyseString = "010101011" +
                            "010101011" +
                            "010101011";
        }
        private void bRandom_Click(object sender, EventArgs e)
        {
            core.Run(new cmdGenerateField());
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
        public void Load(string INString)
        {
            for (int i = 0; i < INString.Length; i++)
            {
                FieldPanels[i].Text = INString[i].ToString();
            }
        }
        private void bPairCalc_Click(object sender, EventArgs e)
        {
            TreeNode root = new TreeNode("root");
            treeView.Nodes.Add(root);
            List <Pair> pairs = core.CurrentPairs;
            counter = 0;
            FinalFields = new List<string>();
            for (int i = 0; i < pairs.Count; i++)
            {
                TreeNode r = new TreeNode(pairs[i].ToString());
                core.Run(new cmdDeletePair(pairs[i].NumFirst.Position, pairs[i].NumSecond.Position));
                r.Tag = core.Field;
                root.Nodes.Add(r);
                core.Undo();
                Console.WriteLine(++counter);
            }
            if (pairs.Count == 0 && !FinalFields.Contains(core.Field))
                                                 FinalFields.Add(core.Field);
            Console.WriteLine("Уникальных окончаний" +FinalFields.Count);
        }
        private void RecurscePairTree(TreeNode InputBranch)
        {
            Core LocalCore = new Core();
            LocalCore.Run(new cmdGenerateField((string)InputBranch.Tag));
            List<Pair> pairs = LocalCore.CurrentPairs;
            for (int i = 0; i < pairs.Count; i++)
            {

                TreeNode r = new TreeNode(pairs[i].ToString());
                core.Run(new cmdDeletePair(pairs[i].NumFirst.Position, pairs[i].NumSecond.Position));
                r.Tag = core.Field;
                RecurscePairTree(r);
                InputBranch.Nodes.Add(r);
                core.Undo();
                Console.WriteLine(++counter);
            }
            if (pairs.Count == 0 && !FinalFields.Contains(core.Field))
                                                 FinalFields.Add(core.Field);
        }
    }
    public class PairLinks
    {
    }
}
