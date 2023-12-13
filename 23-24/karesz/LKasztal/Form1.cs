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
				Előre(a / 4);
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
			Előre(a * sorszam * 3 + sorszam * a / 4);
			Jobbra(90);
			Tollat(fel);
		}
		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			// Teleport(közép.X, közép.Y+150, észak);
			
			sor(20, 4, Color.Brown);
		}
	}
}
