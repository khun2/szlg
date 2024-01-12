using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Alap(double size) {
			Ív(90, size);
			Jobbra(-90);
			Ív(-180, size);
			Jobbra(-90);
			Ív(90,size);
			Jobbra(180);
		}
		void Athelyezkedes(double size) {
			using (new Rajzol(false)) {
				Ív(90, size);
				Jobbra(-90);
				Ív(-90, size);
				Jobbra(180);
			}
        }
		void Szem(double size) {
			for(int i = 0; i < 4; i++) {
                Alap(size);
                Athelyezkedes(size);
            }
        }
		void Athelyezkedes2(double size) {
			using(new Rajzol(false)) { 
				Ív(90, size);
                Ív(-90, size);  
            }
		}
		void Sor(int length, double size) {
			for (int i = 0; i < length; i++) {
				Szem(size);
				Athelyezkedes2(size);
			}
            for (int i = 0; i < length; i++){
                Athelyezkedes2(-size);
            }
        }
		void Halo(int length, int width, double size) {
			for (int i = 0; i < width; i++){
				Sor(length, size);
				Jobbra(90);
				Athelyezkedes2(-size);
				Jobbra(-90);
			}
			for(int i=0; i<width; i++) {
				Jobbra(90);
				Athelyezkedes2(size);
				Jobbra(-90);
			}
		}
		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			//Teleport(közép.X, közép.Y*1.8, észak);
			Halo(4, 3, 30);
		}
	}
}
