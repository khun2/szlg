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
        void BalLe() {
            for (int i = 0; i < 2; i++) {
                Balra(1);
                while (!Van_e_előttem_fal()) {
                    Előre();
                }
            }
            Jobbra(2);
        }
        bool checkWall() {
            Balra();
            if (!Van_e_előttem_fal()) {
                return true;
            }
            Jobbra();
            return false;
        }
        Random random_generator = new Random();
        void Falkövetés() {
            BalLe();
            int asd = 1;
            while (true) {
                if (checkWall()) {
                    break;
                }
                if (asd==1) {
                    int rand1 = random_generator.Next(2, 7);
                    Tegyél_le_egy_kavicsot(rand1);
                }
                Előre();
                asd *= -1;
                if (Van_e_előttem_fal()) {
                    if (checkWall()) {
                        if (asd == 1) {
                            int rand1 = random_generator.Next(2, 7);
                            Tegyél_le_egy_kavicsot(rand1);
                        }
                        break;
                    }
                    Jobbra();
                }
            }
                        Előre();
        }
        void DIÁK_ROBOTJAI()
        {
            Robot karesz = Robot.Get("Karesz");

            karesz.Feladat = delegate ()
            {
                //code goes here brrrrr 
                Falkövetés();
            };
        }
    }
}
