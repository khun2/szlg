using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
        /* Függvények */
        void Tölt(double size, Color color) {
            using (new Rajzol(false)) {
                Előre(size);
                Tölt(color);
                Előre(-size);
            }
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
        void Triangle(double size) {
            double root = 2*(Math.Sqrt(2 * size));
            //Wolfram Alpha nem hazudik (ha helyesen írtam be az egyenletet)
        }
        void ArrowHead(double size) {
            double root = 2*(Math.Sqrt(2 * size));
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
        }
        void Alap(double size) {
            double root = Math.Sqrt(2*size);
            Jobbra(-45);
            Rectangle(size * 3,root);
            Előre(size * 3);
            Jobbra(45);
            ArrowHead(size);
        }
        /* Függvények vége */
        void FELADAT() {
            /* Ezt indítja a START gomb! */
            // Teleport(közép.X, közép.Y+150, észak);
            //Alap(20);
            Triangle(10);
            
		}
	}
}
