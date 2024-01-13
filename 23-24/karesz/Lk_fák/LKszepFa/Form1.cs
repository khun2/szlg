using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		Color getColor(int yrs) {
			if (yrs == 1) {  return Color.LightGreen; }
			else if (yrs == 2) {  return Color.Green; }
			else { return Color.Brown; }
		}
		int getVastagsag(int yrs) {
			if (yrs%2==1) {yrs++; }
			return yrs/2;
		}
		void Fa(int yrs, double size) {
			if (yrs == 0) {return;}
			Color color = getColor(yrs);
			int vastagsag = getVastagsag(yrs);
			using(new Szín(color)) {
                using(new Vastagság(vastagsag)) {
                    using (new Átmenetileg(Előre, size)) {
                        using (new Átmenetileg(Jobbra, -30)) {
                            Fa(yrs - 1, size / 2);
                        }
                        Fa(yrs - 1, size / 3 * 2);
                        using (new Átmenetileg(Jobbra, 30)) {
                            Fa(yrs - 1, size / 2);
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
                Fa(5, 100);
            }
		}
	}
}
