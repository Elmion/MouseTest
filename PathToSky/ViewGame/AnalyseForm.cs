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
        private FieldIndex FinalFields;
        //  private List<string> IntermediateFields;
        private FieldIndex Index;
        System.Diagnostics.Stopwatch s;
        public AnalyseForm()
        {
            InitializeComponent();
            core = new Core();
            treeView.AfterSelect += (o, e) =>
            {
                fieldView.LoadField((string)e.Node.Tag);
            };
            s = new  System.Diagnostics.Stopwatch();
        }
        #region FieldView

        private void bLoadTest_Click(object sender, EventArgs e)
        {
            AnalyseString = "010101011" +
                            "010101011" +
                            "010101011";
            fieldView.LoadField(AnalyseString);
        }
        private void bRandom_Click(object sender, EventArgs e)
        {
            core.Run(new cmdGenerateField());
            AnalyseString = core.Field;
            fieldView.LoadField(AnalyseString);
        }
        private void bViewOrgin_Click(object sender, EventArgs e)
        {
            fieldView.LoadField(AnalyseString);
        }

        #endregion
        #region Базовый алгоритм

        private void bPairCalc_Click(object sender, EventArgs e)
        {
            //long start = DateTime.Now.Ticks;
            //Core LocalCore = new Core();
            //LocalCore.Run(new cmdGenerateField(AnalyseString));
            //TreeNode root = new TreeNode("root");
            //treeView.Nodes.Add(root);
            //List<Pair> pairs = LocalCore.CurrentPairs;
            //counter = 0;
            //FinalFields = new List<string>();
            //for (int i = 0; i < pairs.Count; i++)
            //{
            //    TreeNode r = new TreeNode(pairs[i].ToString());
            //    LocalCore.Run(new cmdDeletePair(pairs[i].NumFirst.Position, pairs[i].NumSecond.Position));
            //    r.Tag = LocalCore.Field;
            //    RecurscePairTree(r);
            //    root.Nodes.Add(r);
            //    LocalCore.Undo();
            //}
            //if (pairs.Count == 0 && !FinalFields.Contains(LocalCore.Field))
            //    FinalFields.Add(LocalCore.Field);

            //Console.WriteLine("Уникальных окончаний " + FinalFields.Count);
            //Console.WriteLine("Время " + new DateTime(DateTime.Now.Ticks - start).Millisecond);
        }
        private void RecurscePairTree(TreeNode InputBranch)
        {
            //Core LocalCore = new Core();
            //LocalCore.Run(new cmdGenerateField((string)InputBranch.Tag));
            //List<Pair> pairs = LocalCore.CurrentPairs;
            //for (int i = 0; i < pairs.Count; i++)
            //{

            //    TreeNode r = new TreeNode(pairs[i].ToString());
            //    LocalCore.Run(new cmdDeletePair(pairs[i].NumFirst.Position, pairs[i].NumSecond.Position));
            //    r.Tag = LocalCore.Field;
            //    RecurscePairTree(r);
            //    InputBranch.Nodes.Add(r);
            //    LocalCore.Undo();
            //}
            //if (pairs.Count == 0 && !FinalFields.Contains(LocalCore.Field))
            //    FinalFields.Add(LocalCore.Field);
        }

        #endregion
        private void bCalcNewAlgoritm_Click(object sender, EventArgs e)
        {
           
            long start = DateTime.Now.Ticks;
            FinalFields = new FieldIndex();
            Index = new FieldIndex();
            // IntermediateFields = new List<string>();
            
            TreeNode root = new TreeNode("root");
            root.Tag = AnalyseString;
            treeView.Nodes.Add(root);

            RecurceNewAlgoritm(root,0);

            //Console.WriteLine("Новым алгоритмом: " + FinalFields.Count);
            Console.WriteLine("Время " + new DateTime(DateTime.Now.Ticks - start).Millisecond);
        }
        private void RecurceNewAlgoritm(TreeNode InputNode,int deep)
        {
                if (deep > 4) return;
                Core LocalCore = new Core();
                LocalCore.Run(new cmdGenerateField((string)InputNode.Tag));
                List<Pair> toCicle;
                List<Pair> pairs = GetVarPair(LocalCore.CurrentPairs, out toCicle);
                foreach (var item in pairs)
                {
                    LocalCore.Run(new cmdDeletePair(item.NumFirst.Position, item.NumSecond.Position));
                }
                for (int i = 0; i < toCicle.Count; i++)
                {
                    TreeNode r = new TreeNode(toCicle[i].ToString());
                    LocalCore.Run(new cmdDeletePair(toCicle[i].NumFirst.Position, toCicle[i].NumSecond.Position));
                    bool b =  Index.Contain(LocalCore.Field,0,Index.root,true);
                    if (!b)
                    {
                        InputNode.Nodes.Add(r);   
                        r.Tag = LocalCore.Field;
                       deep++;
                        RecurceNewAlgoritm(r,deep);
                    }
                    LocalCore.Undo();
                }
                if(toCicle.Count == 0)
                {
                    Index.Contain(LocalCore.Field, 0, FinalFields.root, true);
                }
        }
        private List<Pair> GetVarPair(List<Pair> pair, out List<Pair> toCicle)
        {
            List<Pair> toField = new List<Pair>();
            toCicle = new List<Pair>();
            for (int i = 0; i < pair.Count; i++)
            {
                bool AddPAirToCicle = false;
                for (int j = 0; j < pair.Count; j++)
                {
                    if (pair[i].NumFirst.Position == pair[j].NumFirst.Position || pair[i].NumSecond.Position == pair[j].NumFirst.Position ||
                       pair[i].NumFirst.Position == pair[j].NumSecond.Position || pair[i].NumSecond.Position == pair[j].NumSecond.Position)
                    {
                        if (!pair[i].Equals(pair[j]))
                        {
                            toCicle.Add(pair[i]);
                            AddPAirToCicle = true;
                            break;
                        }

                    }
                }
                if(!AddPAirToCicle)
                {
                    toField.Add(pair[i]);
                }
            }
            return toField;
        }

        private void ViewPairMap()
        {

            //long start = DateTime.Now.Ticks;
            //FinalFields = new FieldIndex();
            //Index = new FieldIndex();
            //// IntermediateFields = new List<string>();

            //TreeNode root = new TreeNode("root");
            //root.Tag = ;
            //treeView.Nodes.Add(root);

            //RecurceNewAlgoritm(root);

            ////Console.WriteLine("Новым алгоритмом: " + FinalFields.Count);
            //Console.WriteLine("Время " + new DateTime(DateTime.Now.Ticks - start).Millisecond);
        }
        private void RecurcePairViewMap()
        {

        }
    }
    public class FieldIndex
    {
        public FieldIndexItem root;
        public FieldIndex()
        {
            root = new FieldIndexItem();
        }
        public bool Contain(string s,int index, FieldIndexItem Item,bool add)
        {
            if (s.Length == index) return true;
            if (Item.Child1 != null && Item.Child1.Value  == s[index])
            {
               return Contain(s, ++index, Item.Child1, add);
            }
            if (Item.Child2 != null && Item.Child2.Value == s[index])
            {
               return Contain(s, ++index, Item.Child2, add);
            }
            if(add)
            {
                if (Item.Child1 == null)
                {
                    Item.Child1 = new FieldIndexItem(s[index]);
                    Contain(s, ++index, Item.Child1, add);
                }
                else
                {
                    Item.Child2 = new FieldIndexItem(s[index]);
                    Contain(s, ++index, Item.Child2, add);
                }
            }
            return false;
        }
    }
    public class FieldIndexItem
    {
        public FieldIndexItem parent;
        public char Value;
        public FieldIndexItem Child1;
        public FieldIndexItem Child2;
        public FieldIndexItem(char c)
        {
            Child1 = null;
            Child2 = null;
            Value = c;
        }
        public FieldIndexItem()
        {
            Child1 = null;
            Child2 = null;
        }

    }
}
