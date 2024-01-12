using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Fa(int yrs, double size) {
			if (yrs == 0) {return;}
			using (new Átmenetileg(Előre, size)) {
				using (new Átmenetileg(Jobbra, -60)) {
					Fa(yrs - 1, size / 3 * 2);
                }
				Fa(yrs - 1, size / 3*2);
                using (new Átmenetileg(Jobbra, 60)) {
					Fa(yrs-1, size / 3*2);
				}
			}
		}

		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			// Teleport(közép.X, közép.Y+150, észak);

			using(new Frissítés(false)) {
                Fa(6, 100);
            }
		}
	}
}
