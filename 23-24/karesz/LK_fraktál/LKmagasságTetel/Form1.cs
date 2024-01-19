using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz {
    public partial class Form1 : Form {
        /* Függvények */
        static double kisebbik_hegyesszög = 180 * Math.Atan2(1, 2) / Math.PI;
        static double nagyobbik_hegyesszög = 90 - kisebbik_hegyesszög;
        static double gyököt = Math.Sqrt(5);
        static double pergyököt = 1 / Math.Sqrt(5);

        void Oldalaz(double size, double angle) {
            using (new Átmenetileg(Jobbra, angle))
            using (new Rajzol(false)) {
                Előre(size);
            }
        }
        void MagasságtételBefogo(double size, int sign=1) {
            Előre(size);
            Jobbra(180 - nagyobbik_hegyesszög*sign);
            Előre(size * gyököt);
            Jobbra(180 - kisebbik_hegyesszög*sign);
            Előre(size * 2);
            Jobbra(90*sign);
        }
        void MagasságtétalFraktál(int rec, double size,int sign=1) {
            if (rec <= 1) {
                MagasságtételBefogo(size,sign);
                return; 
            }
            Jobbra(kisebbik_hegyesszög*sign);
            Oldalaz(size * pergyököt, 0);
            Jobbra(180);
            MagasságtétalFraktál(rec-1, size*pergyököt,-1*sign);
            Oldalaz(-size * pergyököt, 0);
            using(new Átmenetileg(Jobbra, 90 * sign)) {
                MagasságtétalFraktál(rec-1,size * gyököt / 5,-1 * sign);
            }
            Oldalaz(size * gyököt / 5*2, -90 * sign);
            MagasságtétalFraktál(rec-1,size * gyököt / 5 ,1 * sign);
            MagasságtétalFraktál(rec-1,size * gyököt / 5,-1 * sign);
            Oldalaz(size * gyököt / 5*2, 90 * sign);
            Oldalaz(2*size * pergyököt, 0);
            Jobbra(180-kisebbik_hegyesszög*sign);

        }
        /* Függvények vége */
        void FELADAT() {
            /* Ezt indítja a START gomb! */
            using (new Frissítés(false)) {
                Teleport(közép.X / 2, közép.Y + 150, észak);
                MagasságtétalFraktál(6, 200);
            }
        }
    }
}
