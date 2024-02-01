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
            void Elomozog(bool i=true) {
                if (!Van_e_előttem_fal()) {
                    Előre();
                    return;
                }
                else if (i) {
                    Jobbra();
                    Elomozog(false);
                }
                else {
                    Jobbra(2);
                    Elomozog(true);
                }
            }
            void _31() {
                if (Van_e_itt_Kavics()) {
                    Vegyél_fel_egy_kavicsot();
                }
                Tegyél_le_egy_kavicsot(piros);
                Elomozog();
                while (true) {
                    while (!Van_e_előttem_fal()) {
                        Előre();
                        if (Van_e_itt_Kavics()) {
                            Vegyél_fel_egy_kavicsot();
                        }
                    }
                    Jobbra();
                }
            }
            karesz.Feladat = delegate () {
                //code goes here brrrrr 
                _31();
            };
        }
    }
}
