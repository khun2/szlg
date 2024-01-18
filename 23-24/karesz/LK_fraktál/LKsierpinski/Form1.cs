using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz {
    public partial class Form1 : Form {
        /* Függvények */
        void Oldalaz(double size, double angle) {
            using (new Rajzol(false))
            using (new Átmenetileg(Jobbra, angle)) {
                Előre(size);
}
        }
        void Nyíl(int num, double size) {
            if (num == 1) { Jobbra(90); Előre(size); Jobbra(-90); return; }
            Jobbra(30);
            Oldalaz(size, 0);
            using(new Átmenetileg(Jobbra, 90)) {
                Nyíl(num-1, size/2);
            }
            Oldalaz(size, 0);
        }
        /* Függvények vége */
        void FELADAT() {
            /* Ezt indítja a START gomb! */
            using (new Frissítés(false)) {
                Teleport(közép.X / 1, közép.Y, észak);
                Nyíl(2, 100);
            }
        }
    }
}
