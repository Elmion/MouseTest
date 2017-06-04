﻿using System;
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
        public Form1()
        {
            InitializeComponent();
            Core c =  new Core();
            c.Run(new cmdGenerateField("020000300" + "020000300" + "020000000"));
            c.Run(new cmdDeletePair(1, 10));
            DrawConsoleReport(c);
            c.Undo();
            DrawConsoleReport(c);
        }
        public void DrawConsoleReport(Core c)
        {
            List<string> s = c.GetConsoleReport();
            for (int i = 0; i < s.Count; i++)
            {
                Console.WriteLine(s[i]);
            }
        }
    }
}
