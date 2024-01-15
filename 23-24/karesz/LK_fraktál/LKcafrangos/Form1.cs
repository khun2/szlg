using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Fraktál(int yrs, double size, int sign=1) {
			if (yrs <= 1) { Előre(size); return; }
			Fraktál(yrs-1, size/3,sign);
			using (new Átmenetileg(Jobbra, 60*sign))
			{
				Fraktál(yrs - 1, size / 3,sign);
				using (new Átmenetileg(Jobbra, -120*sign))
				{
					Fraktál(yrs - 1, size / 3 ,sign);
					Fraktál(yrs - 1, size / 3 , sign);
				}
				Fraktál(yrs-1, size/3, sign);
			}   
		}
		void Szigetj(int szögszám, int yrs, double size) {
			for (int i = 0; i < szögszám; i++) {
				Fraktál(yrs, size);
				Jobbra(360 / szögszám);
			}
		}
        void Szigete(int szögszám, int yrs, double size) {
            for (int i = 0; i < szögszám; i++) {
				Fraktál(yrs, size,-1);
                Jobbra(360 / szögszám);
            }
        }
        /* Függvények vége */
        void FELADAT() {
			/* Ezt indítja a START gomb! */
			using (new Frissítés(false)) {
				Teleport(közép.X / 2, közép.Y, észak);
				using (new Átmenetileg(Jobbra, 30)) {
					Szigete(5,2,100);
				}

			}
		}
	}
}
