using System;
using System.Diagnostics.Eventing.Reader;
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
        void sor(double a, int b, Color color1, Color color2) {
            for (int i = 0; i < b; i++) {
                if (i % 2 == 0) {
                    Négyzet(a, color1);
                    Jobbra(90);
                    Előre(a);
                    Jobbra(-90);
                }
                else {
                    Négyzet(a, color2);
                    Jobbra(90);
                    Előre(a);
                    Jobbra(-90);
                //tudom hogy nem jó a nested code de nincs jobb ötletem most
                }
            }
                Jobbra(-90);
                Előre(b * a);
                Jobbra(90);
		}
        void sakktabla(double a, int sorszam, int oszlop, Color color1, Color color2) {
            Tollat(fel);
            Előre(-a);
            Tollat(le);
        for(int i = 0; i<oszlop; i++) {
            if (i % 2 == 0) {
                    Tollat(fel);
                    Előre(a);
                    Tollat(le);
                    sor(a, sorszam, color1, color2);
                }
            else {
                    Előre(a);
                    sor(a, sorszam, color2, color1);
                }
            }
            Előre(-a * (oszlop - 1));
            //ismét nestelt kód
            /*
            Google en passant
            Holy Hell
            New response just dropped
            */
        }
        /* Függvények vége */
        void FELADAT()
		{
            /* Ezt indítja a START gomb! */
            // Teleport(közép.X, közép.Y+150, észak);
            sakktabla(30, 8,8, Color.White, Color.Black);
		}
	}
}
