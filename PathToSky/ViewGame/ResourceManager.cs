using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ViewGame
{
    public class ResourceManager
    {
        public static Bitmap GetBitMap(char c)
        {
            switch (c)
            {
                case '0':
                    return ViewGame.Properties.Resources.Num_00;
                case '1':
                    return ViewGame.Properties.Resources.Num_01;
                case '2':
                    return ViewGame.Properties.Resources.Num_02;
                case '3':
                    return ViewGame.Properties.Resources.Num_03;
                case '4':
                    return ViewGame.Properties.Resources.Num_04;
                case '5':
                    return ViewGame.Properties.Resources.Num_05;
                case '6':
                    return ViewGame.Properties.Resources.Num_06;
                case '7':
                    return ViewGame.Properties.Resources.Num_07;
                case '8':
                    return ViewGame.Properties.Resources.Num_08;
                case '9':
                    return ViewGame.Properties.Resources.Num_09;
                case 'f':
                    return ViewGame.Properties.Resources.Frame;
            }
            return null;
        }
    }


}
