using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void ívonal(double a) {
		
				Jobbra(90);
				Előre(a);
				Jobbra(- 90);
				Ív(90, a);
				Jobbra(180);
		}
		void alap(double a, Color color) {
		for (int i = 0; i < 4; i++) {
				ívonal(a);
			}
			Tollat(fel);
			Előre(a);
			Tölt(color);
			Előre(-a);
			Tollat(le);
		}
		void athelyezkedes(double a) {
				Tollat(fel);
				ívonal(a);
				Jobbra(90);
				Előre(a);
				Jobbra(90);
				Előre(a / 3);
				ívonal(a);
				Tollat(le);
		}
		void sor(double a, int sorszam, Color color) {
		for(int i = 0;i < sorszam;i++) {
				alap(a, color);
				athelyezkedes(a);
			}
			Tollat(fel);
			Jobbra(-90);
			Előre(a * sorszam * 3 + sorszam * a / 3);
			Jobbra(90);
			Tollat(fel);
		}
        void Téglalap(double a, double b)
        {
            for (int i = 0; i < 2; i++)
            {
                Előre(a);
                Jobbra(90);
                Előre(b);
                Jobbra(90);
            }
        }
        void Téglalap(double a, double b, Color color)
        {
            Téglalap(a, b);
            double root = Math.Min(Math.Sqrt(2 * a), Math.Sqrt(2 * b));
            Jobbra(45);
            Tollat(fel);
            Előre(root);
            Tölt(color);
            Előre(-root);
            Jobbra(-45);
            Tollat(le);
        }
		void asztal(double a, int oszlop, int sorszam, Color color1, Color color2) {
			Tollszín(color1);
			double téglalap1 = a * 3 * oszlop + (oszlop + 1) * a / 3;
			double téglalap2 = a * 3 * sorszam + (sorszam + 1) * a / 3;
			Téglalap(téglalap1, téglalap2, color2);
			//ez nagyon ronda matek de én szeretem a nagyon ronda matekot mivel így lesz a legpontosabb
			Tollat(fel);
			Jobbra(90);
			Előre(a + a / 3);
			Jobbra(-90);
			Előre(a / 3);
			Tollat(le);
			for (int i = 0; i < oszlop; i++) { 
			sor(a, sorszam, color1);
				Tollat(fel);
			Előre(3*a+a/3);
				Tollat(le);
			}
			Tollat(fel);
			Előre(-téglalap1);
			Jobbra(-90);
			Előre(a + a / 3);
			Jobbra(90);
			Tollat(le);
        }
        /* Függvények vége */
        void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			Teleport(közép.X/5, közép.Y*1.8, észak);

			asztal(15, 4, 6,Color.Black, Color.White);
		}
	}
}
