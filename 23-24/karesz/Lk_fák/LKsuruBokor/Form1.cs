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
			if (yrs == 0) { return; }
			Fa(yrs-1, size/2);
			using (new Átmenetileg(Előre, size)) { 
				Fa(yrs-1, size/2);
				using(new Átmenetileg(Jobbra,30)) {
					Fa(yrs-1, size/2);
				}
			}
			using (new Átmenetileg(Előre, size/2)) {
				Fa(yrs-1, size/2);
				using (new Átmenetileg(Jobbra, -30)) {
					Fa(yrs-1, size/2);
				}
			}
		}

		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			// Teleport(közép.X, közép.Y+150, észak);
			
			using(new Frissítés(false)) {
                Fa(8, 100);
            }
		}
	}
}
