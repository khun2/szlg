using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		
		void Bokor(int yrs, double size) {
			if (yrs == 0) { return; }
            using(new Átmenetileg(Előre, size/3)) {
                Bokor(yrs - 1, size / 3);
                using (new Átmenetileg(Jobbra, 60)) {
                    Bokor(yrs - 1, size / 3);
                }
            }
            using (new Átmenetileg(Előre, size / 3*2)) {
				Előre(size / 3);
				Előre(-size / 3);
				//ez bloatnak néz ki de nem az trust me
                Bokor(yrs - 1, size / 3);
				using (new Átmenetileg(Jobbra, -60)) {
					Bokor(yrs - 1, size / 3);
				}
            }
            Bokor(yrs - 1, size / 3);
        }

		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			// Teleport(közép.X, közép.Y+150, észak);
			using(new Frissítés(false)) {
                Bokor(4, 200);
            }
		}
	}
}
