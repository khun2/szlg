using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Deltoid(double size, double size1) {
			for (int i = 0; i<2; i++) {
				Előre(size1);
				Jobbra(60);
				Előre(size);
				Jobbra(120);
			}
		}
		void Brick(double size,double size1) {
			Deltoid(size, size1);
			Jobbra(-60);
			Deltoid(size1, size);
			Jobbra(60);
            Előre(size1);
            Jobbra(-60);
            Előre(size);
			Jobbra(120);
			Deltoid(size, size);
			Jobbra(-120);
            Előre(-size);
            Jobbra(60);
            Előre(-size1);		
		}
		void RowSwap(double size) {
			using(new Rajzol(false)) {
                for (int i = 0; i < 2; i++) {
                    Jobbra(60);
                    Előre(size);
					
                }
                Jobbra(-120);
            }
        }
		void Row(double size, double size1,int length) {
			for (int i = 0;i < length;i++) {
				Brick(size, size1);
				RowSwap(size);
			}
			for (int i = 0; i < length; i++) {
				RowSwap(-size);
			}
        }
		void PillarSwap(double size, double size1) {
			Előre(size1);
			Jobbra(60);
			Előre(size);
			Jobbra(-60);
		}
		void Piramis(double size, double size1, int length) {
			for (int i = 0; i < length; i++) {
				Row(size, size1, length - i);
				PillarSwap(size, size1);
			}
			for (int i = 0; i < length; i++){
				PillarSwap(-size, -size1);
			}
		}
		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			// Teleport(közép.X, közép.Y+150, észak);
			Piramis(20, 32,6);
			
		}
	}
}
