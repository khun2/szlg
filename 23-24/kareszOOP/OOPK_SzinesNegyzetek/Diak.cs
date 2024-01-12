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
        
        void Négyzet(int lenght, int color) {
            Előre(-lenght / 2);
            Jobbra(); ;
            Előre(-lenght / 2);
            Balra();
            for (int i = 0;i < 4;i++) {
                ElőreRakj(lenght,color);
                Jobbra();
            }
            Jobbra(); ;
            Előre(lenght / 2);
            Balra();
            Előre(lenght / 2);
        }
        void SzinesNegyzetek(int amount, int smallest) {
            for(int i = 0; i < amount; i++) {
                Random random_generator = new Random();
                int rand1 = random_generator.Next(2, 7);
                Négyzet(smallest, rand1);
                smallest += 4;
            }
        }
        void DIÁK_ROBOTJAI()
        {
            Robot karesz = Robot.Get("Karesz");

            karesz.Feladat = delegate ()
            {
                //code goes here brrrrr
                Végtelenkő(true);
                SzinesNegyzetek(5, 4);
            };
        }
    }
}
