using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Ívonal(double a) {
			Jobbra(90);
			Előre(a);
			Jobbra(- 90);
			Ív(90, a);
			Jobbra(180);
		}
		void Alap(double a, Color color) {
			for (int i = 0; i < 4; i++) {
				Ívonal(a);
			}
			using (new Rajzol(false)) {
				Előre(a);
				Tölt(color);
				Előre(-a);
			}
			
		}
		void Athelyezkedes(double a) {
			using (new Rajzol(false)){
				Jobbra(90);
				Előre(3 * a + a / 3);
				Jobbra(-90);
			}
		}
		void Sor(double a, int sorszam, Color color) {
			for (int i = 0;i < sorszam;i++) {
				Alap(a, color);
				Athelyezkedes(a);
			}
			using (new Rajzol(false)) {
				Jobbra(-90);
				Előre(a * sorszam * 3 + sorszam * a / 3);
				Jobbra(90);
			}
		}
        void Téglalap(double a, double b) {
            for (int i = 0; i < 2; i++) {
                Előre(a);
                Jobbra(90);
                Előre(b);
                Jobbra(90);
            }
        }
        void Téglalap(double a, double b, Color color) {
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
		void Asztal(double a, int oszlop, int sorszam, Color color1, Color color2) {
			Tollszín(color1);
			double téglalap1 = a * 3 * oszlop + (oszlop + 1) * a / 3;
			double téglalap2 = a * 3 * sorszam + (sorszam + 1) * a / 3;
			Téglalap(téglalap1, téglalap2, color2);
			//ez nagyon ronda matek de én szeretem a nagyon ronda matekot mivel így lesz a legpontosabb
			using (new Rajzol(false)) { 
				Jobbra(90);
				Előre(a + a / 3);
				Jobbra(-90);
				Előre(a / 3);
			}
			for (int i = 0; i < oszlop; i++) { 
				Sor(a, sorszam, color1);
				Tollat(fel);
				Előre(3*a+a/3);
				Tollat(le);
			}
			using (new Rajzol(false)) {
				Előre(-téglalap1);
				Jobbra(-90);
				Előre(a + a / 3);
				Jobbra(90);
			}
        }
        /* Függvények vége */
        void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			Teleport(közép.X/5, közép.Y*1.8, észak);
			Asztal(15, 4, 6,Color.Black, Color.White);
		}
	}
}
