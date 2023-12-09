using System;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Téglalap (double a, double b){
			for (int i = 0; i < 2; i++) {
				Előre(a);
				Jobbra(90);
				Előre(b);
				Jobbra(90);
			}
		}
		void Téglalap (double a, double b, Color color)
		{
			Téglalap(a, b);
			double root = Math.Min(Math.Sqrt(2*a),Math.Sqrt(2*b));
            Jobbra(45);
            Tollat(fel);
            Előre(root);
            Tölt(color);
            Előre(-root);
			Jobbra(-45);
			Tollat(le);
        }
		void black_key(double a){
            double b = a * 5;
            double c = a * 3 / 4;
            double d = a * 3;
            Jobbra(90);
            Előre(a);
            Jobbra(-90);
            Előre(b - d);
            //MessageBox.Show("asdd");
            Téglalap(d, c / 2, Color.Black);
            Jobbra(-90);
            Előre(c / 2);
            Jobbra(90);
            Téglalap(d, c / 2, Color.Black);
			Jobbra(90);
			Előre(c / 2);
			Jobbra(-90);
			Előre(-(b - d));
        }
		void oktáv(double a){
			double b = a * 5;
			double c = a * 3 / 4;
			double d = a * 3;
			for (int i = 0;i < 7;i++) {
				Téglalap(b,a);
				Jobbra(90);
				Előre(a);
				Jobbra(-90);
			}
            Jobbra(-90);
            Előre(7 * a);
            Jobbra(90);
			black_key(a);
			black_key(a);
			Jobbra(90);
			Előre(a);
			Jobbra(-90);
			for (int i = 0; i < 3;i++) {
				black_key(a);
			}
			Jobbra(90);
			Előre(a);
			Jobbra(-90);
		}
		void zongora(double a, int b){
			for (int i = 0; i < b; i++) {
				oktáv(a);
			}
			Jobbra(-90);
			Előre(a * b * 7);
			Jobbra(90);
		}
		

		/* Függvények vége */
		void FELADAT()
		{
			
			/* Ezt indítja a START gomb! */
			 Teleport(közép.X-200, közép.Y, észak);
			zongora(10, 5);



		
		}
	}
}
