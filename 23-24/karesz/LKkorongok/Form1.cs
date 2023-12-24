using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
        /* Függvények */
        void Teglalap(double a, double b) {
            for (int i = 0; i < 2; i++)
            {
                Előre(a);
                Jobbra(90);
                Előre(b);
                Jobbra(90);
            }
        }
        void Teglalap(double a, double b, Color color) {
            Teglalap(a, b);
            double root = Math.Min(Math.Sqrt(2 * a), Math.Sqrt(2 * b));
            Jobbra(45);
            Tollat(fel);
            Előre(root);
            Tölt(color);
            Előre(-root);
            Jobbra(-45);
            Tollat(le);
        }
        void Triangle(double size, Color color) {
            Jobbra(30);
            for (int i = 0;i < 3;i++) {
                Előre(size);
                Jobbra(-120);
            }
            Jobbra(-30);
            using(new Rajzol(false)) {
                Előre(size/2);
                Tölt(color);
                Előre(-size/2);
            }
        }
        void Hexagon(double size, Color color) {
            for (int i = 0; i < 6; i++){
                Előre(size);
                Jobbra(60);
            }
            using(new Rajzol(false)) {
                Jobbra(60);
                Előre(size);
                Tölt(color);
                Előre(-size);
                Jobbra(-60);
            }
        }
        void Base(double size, Color color) {
        
        }
        /* Függvények vége */
        void FELADAT()
		{
            /* Ezt indítja a START gomb! */
            // Teleport(közép.X, közép.Y+150, észak);
            Hexagon(30, Color.Red);
			
		}
	}
}
