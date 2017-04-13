using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTowerConcept
{
    public partial class CristallRecycle : UserControl
    {
        public CristallRecycle()
        {
            InitializeComponent();
        }

        private void CristallRecycle_DragEnter(object sender, DragEventArgs e)
        {
           if(e.Data.GetDataPresent(typeof(ucCard)) )
            e.Effect = DragDropEffects.Copy;
        }
        private void CristallRecycle_DragDrop(object sender, DragEventArgs e)
        {
            ucCard c = e.Data.GetData(typeof(ucCard)) as ucCard;
            c.Cristall--;
            Form1 f = this.Parent as Form1;
            f.RemoveCristall(c);
            Dispose();
        }
    }
}
