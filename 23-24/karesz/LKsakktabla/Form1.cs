using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Négyzet(double a) {
			for (int i = 0; i < 4; i++){
				Előre(a);
				Jobbra(90);
			}
		}
        void Négyzet(double a, Color color){
			Négyzet(a);
            double root =Math.Sqrt(2 * a);
            Jobbra(45);
            Tollat(fel);
            Előre(root);
            Tölt(color);
            Előre(-root);
            Jobbra(-45);
            Tollat(le);
        }
        void sorWhite(double a, int b) {
			for (int i = 0; i < b; i++) {
				Négyzet(a);
				Jobbra(90);
				Előre(a);
				Jobbra(-90);
				Négyzet(a, Color.Black);
                Jobbra(90);
                Előre(a);
                Jobbra(-90);
            }
		}
		void sorBlack(double a, int b)
        {
            for (int i = 0; i < b/2; i++)
            {
                Négyzet(a, Color.Black);
                Jobbra(90);
                Előre(a);
                Jobbra(-90);
                Négyzet(a);
                Jobbra(90);
                Előre(a);
                Jobbra(-90);
            }
        }
        void sakktábla(double a, int b, int c) {

        }
        /* Függvények vége */
        void FELADAT()
		{
            /* Ezt indítja a START gomb! */
            // Teleport(közép.X, közép.Y+150, észak);
            
		}
	}
}
