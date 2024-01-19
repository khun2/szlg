using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz {
    public partial class Form1 : Form {
        /* Függvények */
        void Nyíl(double size, int rec) {
            if (rec <= 1) { Jobbra(90); Előre(size);Jobbra(-90); return; }
            using (new Rajzol(false)) {
                Jobbra(-60);
                Nyíl(size / 2, rec - 1);
                Jobbra(-180);
            }
            Nyíl(size / 2, rec - 1);
            using (new Rajzol(false)) {
                Jobbra(180);
                Nyíl(size / 2, rec - 1);
                Jobbra(60);
            }
            Nyíl(size / 2, rec - 1);
            using (new Rajzol(false)) {
                Jobbra(60);
                Nyíl(size / 2, rec - 1);
                Jobbra(-180);
            }
            Nyíl(size / 2, rec - 1);
            using (new Rajzol(false)) {
                Jobbra(180);
                Nyíl(size / 2, rec - 1);
                Jobbra(-60);
            }
        }
        /* Függvények vége */
        void FELADAT() {
            /* Ezt indítja a START gomb! */
            using (new Frissítés(false)) {
                Teleport(közép.X / 2, közép.Y+150, észak);
                //ez a megoldás nagyon ineficcient és lassú de működik
                Nyíl(300, 7);
            }
        }
    }
}
