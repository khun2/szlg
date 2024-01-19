using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz {
    public partial class Form1 : Form {
        /* Függvények */
        /*void Oldalaz(double size, double angle) {
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
        }*/
        void Fra(double size, int rec) {
            if (rec <= 1) { Előre(size); return; }
            using (new Rajzol(false))
                Balra(-30);
            Fra(size / 2, rec - 1);
            for (int i = 0; i < 2; i++) {
                Jobbra(180);
                Fra(size / 2, rec - 1);
            }
            Jobbra(60);
            Fra(size / 2, rec - 1);
            using (new Rajzol(false))
                Jobbra(60);
            Fra(size / 2, rec - 1);
            Jobbra(210);
        }
        /* Függvények vége */
        void FELADAT() {
            /* Ezt indítja a START gomb! */
            using (new Frissítés(true)) {
                Teleport(közép.X / 1, közép.Y, észak);
                Fra(40, 3);
            }
        }
    }
}
