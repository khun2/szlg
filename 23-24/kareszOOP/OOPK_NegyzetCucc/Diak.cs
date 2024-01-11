using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Karesz
{
    public partial class Form1 : Form
    {
        void L(int length) {
            Tegyél_le_egy_kavicsot();
            ElőreRakj(length * 2);
            Előre(-length * 2);
            Jobbra();
            ElőreRakj(length);
            Előre(-length);
            Balra();
        }
        void Alap(int length) {
            for (int i = 0; i < 2; i++) {
                L(length);
                Előre(length * 4);
                Jobbra();
            }
            L(length);
            Előre(length*2);
        }
        void DIÁK_ROBOTJAI()
        {
            Robot karesz = Robot.Get("Karesz");

            karesz.Feladat = delegate ()
            {
                //code goes here brrrrr
                Alap(1);
            };
        }
    }
}
