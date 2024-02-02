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
            void Keres(bool i = true) {
                if (!Van_e_előttem_fal()) {
                    if (Van_e_itt_Kavics()) {
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
                        Keres(false);
                    }
                    else {
                        Jobbra(2);
                        Keres();
                    }
                }
            }

            void _16() {
                while (!Kilépek_e_a_pályáról()) {
                    Keres();
                }
            }
            karesz.Feladat = delegate () {
                //code goes here brrrrr 
                _16();

            };
        }
    }
}
