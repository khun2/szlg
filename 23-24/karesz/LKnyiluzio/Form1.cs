using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
        /* Függvények */
        void Rectangle(double a, double b) {
            for (int i = 0; i < 2; i++) {
                Előre(a);
                Jobbra(90);
                Előre(b);
                Jobbra(90);
            }
        }
        void Rectangle(double a, double b, Color color){
            Tollszín(color);
            Rectangle(a, b);
            double root = Math.Min(Math.Sqrt(2 * a), Math.Sqrt(2 * b));
            Jobbra(45);
            using(new Rajzol(false)) {            
                Előre(root);
                Tölt(color);
                Előre(-root);
                Jobbra(-45);
            }
            Tollszín(Color.Black);
        }
        void Oldalaz(double a) {
            using(new Rajzol(false)) {
                Jobbra(90);
                Előre(a);
                Jobbra(-90);
            }
        }
        void Alap(double a, Color color) {
            Jobbra(90);
            Rectangle(a*2.5,a,color);
            Oldalaz(2.5 * a);
            Jobbra(-90);
            Rectangle(a * 2.5, a, color);
            Előre(2.5 * a);
        }
        /* Függvények vége */
        void FELADAT()
		{
            /* Ezt indítja a START gomb! */
            // Teleport(közép.X, közép.Y+150, észak);
            Alap(10, Color.Black);
			
		}
	}
}
