using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Cgörbe(int yrs, double size) {
			if (yrs == 0) { return; }
			if (yrs == 1) { Jobbra(90); Előre(size/2);Jobbra(-90); return; }
			using(new Átmenetileg(Jobbra, 90)) {
                Cgörbe(yrs-1, size/2);
            }
            for (int i = 0; i < 2; i++) {
                Cgörbe(yrs-1, size / 2);
			}
            using (new Átmenetileg(Jobbra, -90)) {
                Cgörbe(yrs - 1, size / 2);
            }
        }
		/* Függvények vége */
		void FELADAT() {
			/* Ezt indítja a START gomb! */
			using (new Frissítés(false)) {
				Teleport(közép.X / 1, közép.Y, észak);
				//Jobbra(90);
				Cgörbe(7, 200);
			}
		}
	}
}
