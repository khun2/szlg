using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Karesz {
    public partial class Form1 : Form {
        void DIÁK_ROBOTJAI() {
            Robot karesz = Robot.Get("Karesz");
            void Keres(int count = 0, bool i = true) {
                while (!Kilépek_e_a_pályáról()) {
                if (count >= 7) { break; }
                    Console.WriteLine(count);
                    count++;
                    if (!Van_e_előttem_fal()) {
                        if (Van_e_itt_Kavics()) {
                            count = 0;
                            Vegyél_fel_egy_kavicsot();
                        }
                        else { Jobbra(); }
                        if (!Van_e_előttem_fal()) {
                            Előre();
                        }
                    }
                    else { Jobbra(); }
                    if (!Van_e_itt_Kavics()) {
                        if (i) {
                            Jobbra();
                            Keres(count, false);
                        }
                        else {
                            Jobbra(2);
                            Keres(count);
                        }
                    }
                    Keres(count);
                }
            }

            void _16() {

            }
            karesz.Feladat = delegate () {
                //code goes here brrrrr 
                Keres();

            };
        }
    }
}
