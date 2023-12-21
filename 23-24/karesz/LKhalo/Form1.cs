using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void alap(double size) {
			Ív(90, size);
			Jobbra(-90);
			Ív(-180, size);
			Jobbra(-90);
			Ív(90,size);
			Jobbra(180);
		}
		void athelyezkedes(double size) {
            Ív(90, size);
            Jobbra(-90);
            Ív(-90, size);
            Jobbra(180);
        }
		void szem(double size) {
			for(int i = 0; i < 4; i++) {
                alap(20);
                athelyezkedes(20);
            }

        }
		void athelyezkedes2(double size) {
		using(new Rajzol(false)) { 
				Ív(90, size);
                Ív(-90, size);  
            }
		}
		void sor(int length, double size) {
			for (int i = 0; i < length; i++) {
				szem(size);
				athelyezkedes2(size);
			}
            for (int i = 0; i < length; i++){
                athelyezkedes2(-size);
            }
        }
		void halo(int length, int width, double size) {
			for (int i = 0; i < width; i++){
				sor(length, size);
				Jobbra(90);
				athelyezkedes(-size);
				Jobbra(-90);
			}
			for (int i = 0; i < width; i++)
			{
				using(new Rajzol(false)) {
					Jobbra(90);
					athelyezkedes2(-size);
					Jobbra(-90);
				}
			}
		}
		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			Teleport(közép.X, közép.Y*1.8, észak);
			halo(4, 3, 20);
		}
	}
}
