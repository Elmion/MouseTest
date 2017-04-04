using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTowerConcept
{
    public partial class Form1 : Form
    {
        List<Monster> monsters;
        Timer t;
        public Form1()
        {
            InitializeComponent();
            monsters = new List<Monster>();
            monsters.Add(new Monster(ucFieldView1.Width, 1));
            monsters.Add(new Monster(0, 0));
            foreach (var item in monsters)
            {
                ucFieldView1.DrawsObject.Add(item);
            }
            t = new Timer();
            t.Interval = 10;
            t.Tick += T_Tick;t.Start();
        }
        private void T_Tick(object sender, EventArgs e)
        {
            Update();
            
            ucFieldView1.Invalidate();
        }
        void Update()
        {
            foreach (var item in monsters)
            {
                item.Move(2);
            }
            CollideObject();
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].DeathFlag)
                {
                    RemoveMonster(monsters[i]);
                }
            }
        }
        void CollideObject()
        {
            foreach (var item in monsters)
            {
                foreach (var item2 in monsters)
                {
                    if (item != item2)
                        if (item.Collide(item2))
                            item.AttackTo(item2);
                }

            }
        }
        void RemoveMonster(Monster m)
        {
            monsters.Remove(m);
            ucFieldView1.DrawsObject.Remove(m);
        }
    }
}
