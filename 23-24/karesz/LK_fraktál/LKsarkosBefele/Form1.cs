using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Sokszög(double size, int sides) {
			for (int i = 0; i < sides; i++) {
				Előre(size);
				Jobbra(360 / sides);
			}
		}
		void Ábra(int sides, double size) {
			if(sides <=2) {return; }
			Sokszög(size, sides);
			for (int i = 0;i < sides; i++) {
				Előre(size);
				Jobbra(360 / sides);
				using (new Átmenetileg(Jobbra,((360 / (sides - 1))-(360 / sides))/2)) {
					//absolutely rancid maths but it works
					Ábra(sides - 1, (size / 2));
				}
			}
        }
		/* Függvények vége */
		void FELADAT() {
			/* Ezt indítja a START gomb! */
			using (new Frissítés(false)) {
				Teleport(közép.X / 1, közép.Y, észak);
				Ábra(7, 100);
				//több mint hetet nem tud megrajzolni nekem ismeretlen okok miatt
			}
		}
	}
}
