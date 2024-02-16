using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz {
    public partial class Form1 : Form {
        /* Függvények */
        Color GetColor(int yrs) {
            if (yrs == 1) { return Color.Green; }
            else { return Color.Black; }
        }
        void Fa(int yrs, double size) {
            if (yrs == 0) { return; }
            Color color = GetColor(yrs);
            using (new Szín(color)) {
                using (new Vastagság(yrs)) {
                    using (new Átmenetileg(Előre, size)) {
                        using (new Átmenetileg(Jobbra, -45)) {
                            Fa(yrs - 1, size / 3 * 2);
                        }
                        using (new Átmenetileg(Jobbra, 45)) {
                            Fa(yrs - 1, size / 3 * 2);
                        }
                    }
                    if (yrs > 3) {
                        using (new Átmenetileg(Előre, size / 3))
                        using (new Átmenetileg(Jobbra, 45)) {
                            Fa(yrs - 3, size / 3 * 2);
                        }
                    }
                }
            }
        }
        void Fraktál(int yrs, double size, int sign,bool voltMár=false) {
            if (yrs == 1) { Előre(size); return; }
            if(!voltMár) { Jobbra(90);voltMár = true;}
            Fraktál(yrs - 1, size / 2, sign * -1,true);
            using (new Átmenetileg(Jobbra, -90*sign)) {
                Fraktál(yrs - 1, size / 2, sign * -1,true);
                Hátra(size / 2);
                Fraktál(yrs - 1, size / 2, sign * 1,true);
                Hátra(size / 2);
            }
            Fraktál(yrs - 1, size / 2, sign * -1, true);
        }
        void NégyzetFraktál(int yrs, double size, int sign) {
            for (int i = 0; i < 4; i++) {
                Fraktál(yrs, size, sign);
            }
        }
        /* Függvények vége */
        void FELADAT() {
            /* Ezt indítja a START gomb! */
            Teleport(közép.X, közép.Y, észak);
            using (new Frissítés(false)) {
                //Fa(8, 85);
                //Fraktál(2, 100, 1);
                NégyzetFraktál(5, 100, 1);
            }

        }
    }
}
