using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Fog(double a, Color color) {
			Előre(a);
			Jobbra(30);
			for (int i = 0; i < 2; i++) {
				Előre(a);
				Jobbra(120);
			}
			Jobbra(-90);
			for (int i = 0; i < 2; i++){
				Előre(a);
				Jobbra(90);
			}
			Tolt(color, a);
		}
		void Tolt(Color color, double a) {
			using(new Rajzol(false)) {
				Jobbra(45);
				Előre(a);
				Tölt(color);
				Előre(-a);
				Jobbra(-45);
			}
		}
		Color Szinvaltas(Color color, Color color1, Color color2) {
			color = color == color1 ? color2 : color1;
			return color;
		}
		void Oldalaz(double a) {
			using (new Rajzol(false)) {
				Jobbra(90);
				Előre(a);
				Jobbra(-90);
			}
		}
		void Sor(double size, int amount, Color color1, Color color2) {
			Color color = Color.Aquamarine;
			for (int i = 0; i < amount; i++){
				Fog(size, Szinvaltas(color,color1, color2));
				Oldalaz(size);
			}
		}
		
        /* Függvények vége */
        void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			// Teleport(közép.X, közép.Y+150, észak);
			Sor(10,5, Color.Black, Color.White);
		}
	}
}
