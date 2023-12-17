using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Négyzet(double a) {
		for (int i = 0; i < 4; i++) {
				Előre(a);
				Jobbra(90);
			}
        }
        void Athelyezkedes(double size)
        {
            Jobbra(90);
            Előre(size);
            Jobbra(-90);
        }
        void CsempeDarab(double size) {
			Előre(2 * size);
			for (int i = 0; i < 2; i++){
				Jobbra(90);
				Előre(size);
			}
			Jobbra(-90);
            for (int i = 0; i < 2; i++)
            {
                Előre(size);
                Jobbra(90);
            }
			Előre(2 * size);
			Jobbra(90);
        }
		void CsempeBelső(double size) {
			for(int i = 0; i < 4; i++) {
				CsempeDarab(size);
				using(new Rajzol(false)) {
					Előre(size * 5);
					Jobbra(90);
				}
			}
		}
		void Csempe(double size) {
			Négyzet(size);
			using (new Rajzol(false)){
				Jobbra(90);
				Előre(size / 7);
				Jobbra(-90);
                Előre(size / 7);
            }
			CsempeBelső(size / 7);
			using(new Rajzol(false)){
                Előre(-size / 7);
                Jobbra(-90);
                Előre(size / 7);
                Jobbra(90);
            }
        }
		void Hfal(int height, double size) {
			for(int i = 0; i < height; i++) {
				Csempe(size);
				Előre(size);
            }
			Előre(-height * size);
		}
		void Nfal(int height, double size) {
			for (int i = 0; i < height; i++) {
				Hfal(height, size);
				Athelyezkedes(size);
			}
			Athelyezkedes(-size*height);
		}
		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			Teleport(közép.X-200, közép.Y+150, észak);
			Nfal(5,35);
			
		}
	}
}
