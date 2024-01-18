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
        void Pálya_6(bool n = true) {
            while (!Van_e_előttem_fal()) {
                Előre();
            }
            Balra();
            Előre();
            Balra();
            while (!Van_e_előttem_fal()) {
                Előre();
            }
            Jobbra();
            Előre();
            Jobbra();
            Pálya_6();
        }
        void DIÁK_ROBOTJAI() {
            Robot karesz = Robot.Get("Karesz");

            karesz.Feladat = delegate () {
                //code goes here brrrrr
                Jobbra();
                Pálya_6();
            };
        }
    }
}
