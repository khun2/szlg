using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
        /* Függvények */
        void Tölt(double size, Color color)
        {
            using (new Rajzol(false))
            {
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
        }
        void Rectangle(double a, double b, Color color){
            Tollszín(color);
            Rectangle(a, b);
            double root = Math.Min(Math.Sqrt(2 * a), Math.Sqrt(2 * b));
            Jobbra(45);
            using(new Rajzol(false)) {
                Tölt(root,color);
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
        void Triangle(double size, Color color) {
            Tollszín(color);
            double a = Math.Sqrt(6 * size);
            Oldalaz(-size);
            Jobbra(45);
            Előre(a);
            Jobbra(90);
            Előre(a);
            Jobbra(90);
            Előre(3*size);
            Jobbra(90);
            Oldalaz(size);
            Jobbra(45);
            Tölt(a / 2, color);
            Jobbra(-45);
            Tollszín(Color.Black);
        }
        void Alap(double size,Color color) {
            Jobbra(90);
            Oldalaz(-size / 2);
            Előre(-size / 2);
            Rectangle(size,size,color);
            Előre(size);
            Rectangle(size * 2, size,color);
        }
        /* Függvények vége */
        void FELADAT()
		{
            /* Ezt indítja a START gomb! */
            // Teleport(közép.X, közép.Y+150, észak);
            Alap(10, Color.Black);
            Triangle(10,Color.Black);
			
		}
	}
}
