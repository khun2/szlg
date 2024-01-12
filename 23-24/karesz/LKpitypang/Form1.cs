using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Pitypang(int yrs, double size)
		{
			if (yrs == 0) { return; }
			using (new Átmenetileg(Előre, size)) { 
				Jobbra(-60);
				for (int i = 0; i < yrs - 1; i++) {
					Pitypang(yrs - 1, size / 2);
					Jobbra(120 / (yrs - 1));
					Pitypang(yrs - 1, size / 2);
				}
				if (yrs == 1) {
					Jobbra(120);
				}
				Jobbra(-60);
			}
		}

		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			// Teleport(közép.X, közép.Y+150, észak);
			
			using(new Frissítés(false)) {
                Pitypang(7, 100);
            }
		}
	}
}
