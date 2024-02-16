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
            void Keres(bool jobbra = true) {
                if (jobbra) {
                    Jobbra();
                }
                else {
                    Balra();
                }
                if (!Van_e_előttem_fal()) {
                    Előre();
                    if (!Van_e_itt_Kavics()) {
                        Jobbra(2);
                        Előre();
                        Balra(1);
                        Keres(!jobbra);
                    }
                    else { return; }
                }
                else {
                    if (jobbra) {
                        Balra();
                    }
                    else {
                        Jobbra();
                    }
                    Keres(!jobbra);
                }
            }
            void _16() {
                while (!Kilépek_e_a_pályáról()) {
                    while (!Van_e_előttem_fal()) {   
                        Előre();
                        if (!Van_e_itt_Kavics()) {
                            Előre(-1);
                            break;
                        }
                    }
                    Keres();
                }
            }
            karesz.Feladat = delegate () {
                _16();
                //Keres();
            };
        }
    }
}
