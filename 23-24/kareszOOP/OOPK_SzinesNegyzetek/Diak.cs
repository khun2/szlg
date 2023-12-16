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
        void ElőreRakjRandom(int lenght) {
            for (int i = 0; i < lenght; i++) {
                Random random_generator = new Random();
                int rand1 = random_generator.Next(2, 7);
                Előre(1);
                Tegyél_le_egy_kavicsot(rand1);
            }
        }
        void RandNégyzet(int lenght) {
            Előre(-lenght / 2);
            Jobbra(); ;
            Előre(-lenght / 2);
            Balra();
            for (int i = 0;i < 4;i++) {
                ElőreRakjRandom(lenght);
                Jobbra();
            }
            Jobbra(); ;
            Előre(lenght / 2);
            Balra();
            Előre(lenght / 2);
        }
        void SzinesNegyzetek(int amount, int smallest) {
            for(int i = 0; i < amount; i++) {
                RandNégyzet(smallest);
                smallest += 4;
            }
        }
        void DIÁK_ROBOTJAI()
        {
            Robot karesz = Robot.Get("Karesz");

            karesz.Feladat = delegate ()
            {
                //code goes here brrrrr
                SzinesNegyzetek(5, 4);
            };
        }
    }
}
