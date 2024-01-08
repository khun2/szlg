using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
        /* Függvények */
        void Tölt(double s, Color c) {
  		using (new Rajzol(false))
 		using (new Előre(s))
    		Tölt(c);
	}
        void Rectangle(double a, double b) {
            for (int i = 0; i < 2; i++) {
                Előre(a);
                Jobbra(90);
                Előre(b);
                Jobbra(90);
            }
            double root = Math.Min(Math.Sqrt(2 * a), Math.Sqrt(2 * b));
            using (new Rajzol(false)) {
                Jobbra(45);
                Tölt(root, Color.Black);
                Jobbra(-45);
            }
        }
        void Oldalaz(double a) {
            using(new Rajzol(false)) {
                Jobbra(90);
                Előre(a);
                Jobbra(-90);
            }
        }
        void ArrowHead(double size) {
            double root = Math.Sqrt(2*size*size);
            Jobbra(90);
            Oldalaz(-size * 2);
            Rectangle(size * 2, size);
            Oldalaz(size * 2);
            Jobbra(-90);
            Előre(-size);
            Oldalaz(-size);
            Rectangle(size * 3, size);
            Oldalaz(size);
            Előre(size);
            Jobbra(22);
            Tölt(root / 2,Color.Black);
            Jobbra(-22);
        }
        void Alap(double size) {
            double root = Math.Sqrt(2*size*size);
            Jobbra(-45);
            Rectangle(size * 3,root);
            Előre(size * 3);
            Jobbra(45);
            ArrowHead(size);
            Jobbra(-45);
            Előre(-size * 3);
            Jobbra(45);
        }
        void Nyílnégyzet(double size) {
            double root = Math.Sqrt(2*size*size);
            for (int i = 0; i < 4; i++) {
                Alap(size);
                Jobbra(45);
                Előre(root);
                Jobbra(45);
            }
            Jobbra(90);
            Tölt(size/2,Color.Black);
            Jobbra(-90);
        }
        void Swap(double size) {
            using(new Rajzol(false)) {
                double root = Math.Sqrt(2 * size * size);
                Jobbra(45);
                Előre(root + size * 3);
                Oldalaz(root);
                Jobbra(-45);
                Oldalaz(2 * size);
                Jobbra(45);
                Oldalaz(size * 3);
                Jobbra(-45);
            }
        }
        void SwapFel(double size) {
            double root = Math.Sqrt(2*size*size);
            using (new Rajzol(false)) {
                Jobbra(-135);
                Oldalaz(-root);
                Jobbra(45);
                Swap(size);
                Jobbra(45);
                Előre(root);
                Jobbra(45);
            }
        }
        void Nyílsor(double size, int row) {
            for (int i = 0; i < row; i++) {
                Nyílnégyzet(size);
                Swap(size);
            }
            Jobbra(180);
            for (int i = 0;i < row; i++) {
                Swap(size);
            }
            Jobbra(180);
        }
        void Nyílminta(double size, int row, int pillar) {
            for(int i = 0;i<pillar ; i++){
                Nyílsor(size, row);
                SwapFel(size);
            }
            Jobbra(180);
            for (int i = 0; i < pillar; i++) {
                SwapFel(size);
            }
            Jobbra(180);
        }
        /* Függvények vége */
        void FELADAT() {
            /* Ezt indítja a START gomb! */
            Teleport(közép.X/4, közép.Y*1.8, észak);
            Nyílminta(10, 4, 3);
		}
	}
}
