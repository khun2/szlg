using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Fraktál(int yrs, double size) {
			if (yrs == 0) { return; }
			if (yrs == 1) { Előre(size); return; }
			Fraktál(yrs-1, size/3);
			using (new Átmenetileg(Jobbra, -60))
			{
				Fraktál(yrs - 1, size / 3);
				using (new Átmenetileg(Jobbra, 120))
				{
					Fraktál(yrs - 1, size / 3 * 2);
				}
				Fraktál(yrs-1, size/3);
			}
            Fraktál(yrs-1, size/3);
		}
		/* Függvények vége */
		void FELADAT() {
			/* Ezt indítja a START gomb! */
			using (new Frissítés(false)) {
				Teleport(közép.X / 2, közép.Y, észak);
				using (new Átmenetileg(Jobbra, 90)) {
					Fraktál(3, 200);
				}
			}
		}
	}
}
