using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz {
	public partial class Form1 : Form {
		/* Függvények */
		void Fa(int yrs, double size) {
			using (new Vastagság(2)) {
				if (yrs == 0) { return; }
				using (new Szín(Color.Brown)) {
					using (new Átmenetileg(Előre, size)) {
						using (new Átmenetileg(Balra, 60)) {
							if (yrs == 1) { Tollszín(Color.LightGreen); }
							Fa(yrs - 1, size / 3 * 2);
						}
						using (new Átmenetileg(Jobbra, 60)) {
							Fa(yrs - 1, size / 3 * 2);
						}
					}
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
