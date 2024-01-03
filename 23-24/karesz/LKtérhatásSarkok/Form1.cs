using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Oldalaz(double size, double angle) {
			using(new Rajzol(false)) {
                Jobbra(angle);
                Előre(size);
                Jobbra(-angle);
            }
		}
		void Harmad(double size) {
			Jobbra(60);
			Előre(size);
			Jobbra(-120);
			Előre(size / 2);
			Jobbra(-60);
			Előre(size / 2);
			Jobbra(120);
			Oldalaz(-size / 2, 0);
			//mivel szimetrikus az egészet megismétlem a másik irányba
            Jobbra(-60);
            Előre(size);
            Jobbra(120);
            Előre(size / 2);
            Jobbra(60);
            Előre(size / 2);
            Jobbra(-120);
			Oldalaz(-size / 2, 0);
        }
		void Base(double size) {
			for (int i = 0; i < 3; i++) {
				Harmad(size);
				Jobbra(120);
			}
		}
		void Row(double size,int row) {
			for(int i = 0;i < row;i++) {
				Base(size);
				Oldalaz(size * 1.5, 60);
			}
			Oldalaz(-size*row*1.5,60);
		}
		void Mozaik(double size, int row, int length) {
			for (int i = 0; i < length; i++){
				Row(size, row);
				Oldalaz(size * 1.5, 0);
			}
			Oldalaz(-size*length*1.5,0);
		}
		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			// Teleport(közép.X, közép.Y+150, észak);
			Mozaik(20, 5,6);
			
		}
	}
}
