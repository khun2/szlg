using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz {
    public partial class Form1 : Form {
        /* Függvények */
        void Fra(int order, double size) {
            if (order <= 1) {Előre(size); return; } 
            Fra(order-1, size/2);
            Jobbra(72);
            Fra(order-1, size/2);
            Jobbra(-144);
            Fra(order-1, size/2);
            using (new Átmenetileg(Jobbra, -72)) {
                Fra(order - 1, size / 2);
            }
            Fra(order - 1, size / 2);
            Jobbra(72);
            Fra(order - 1, size / 2);
        }
        void Fra5(int order, double size) {
            for (int i = 0; i < 5; i++) {
                Fra(order, size);
                Jobbra(72);
            }
        }
        /* Függvények vége */
        void FELADAT() {
            /* Ezt indítja a START gomb! */
            using (new Frissítés(false)) {
                Teleport(közép.X / 1, közép.Y, észak);
                Fra5(5, 50);
            }
        }
    }
}
