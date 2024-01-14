using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Weirdo(int yrs, double size) {
            if (yrs == 0) { return; }
            if (yrs == 1) { Előre(size); return; }
			using (new Átmenetileg(Jobbra, -30))
			{
				Weirdo(yrs - 1, size / 3);
				using (new Átmenetileg(Jobbra, 60))
				{
					Weirdo(yrs - 1, size / 3);
				}
				Weirdo(yrs - 1, size / 3);
			}
        }
		void Ábra(int yrs, double size) {
			for (int i = 0; i < 3; i++) {
				Weirdo(yrs, size);
				Jobbra(120);
            }
        }
		/* Függvények vége */
		void FELADAT() {
			/* Ezt indítja a START gomb! */
			using (new Frissítés(false)) {
				Teleport(közép.X / 1, közép.Y, észak);
				using(new Átmenetileg(Jobbra, 90)) {
					Ábra(6, 200);
				}
			}
		}
	}
}
