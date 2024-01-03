using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Tölt(double size, double angle, Color color) {
			using(new Rajzol(false)) {
				Jobbra(angle);
				Előre(size);
				Tölt(color);
				Előre(-size);
				Jobbra(-angle);
			}
		}
		void Rombusz(double size, double angle, Color color)
        {
			Jobbra(angle / 2);
            for (int i = 0; i < 2; i++)
            {
                Előre(size);
                Jobbra(-angle);
                Előre(size);
                Jobbra(-(180 - angle));
            }
            Tölt(size / 2,-angle/2, color);
			Jobbra(-angle / 2);
        }
		void Swap1(double size) {
			using(new Rajzol(false)) {
                Jobbra(30);
                Előre(size);
                Jobbra(90);
				Előre(size);
				Jobbra(-120);
            }
		}
		void Swap2(double size) {
			using(new Rajzol(false)) {
				Jobbra(60);
				Előre(size);
				Jobbra(90);
				Előre(size);
				Jobbra(-150);
			}
		}
		void Mirror(double size,double angle) {
			//nem jutott eszembe jobb név
            using(new Rajzol(false)) {
                Jobbra(-angle/2);
                Előre(size);
                Jobbra(angle);
                Előre(size);
                Jobbra(180-angle/2);
            }
        }
        void Row(double size,int row, Color color1, Color color2) {
			for (int i = 0; i < row; i++) {
				Rombusz(size,60, color1);
				Swap1(size);
				Rombusz(size,120,color2);
				Swap2(size);
				//ez nagyon lustának néz ki de a feladat ezt kéri ezért ezt teszem
			}
            Mirror(size,60);
            for (int i = 0; i < row; i++) {
                Swap2(size);
                Swap1(size); 
            }
            Mirror(size,60);
        }
		void Row2(double size, int row, Color color1, Color color2) {
            for (int i = 0; i < row; i++) {
                Rombusz(size, 120, color2);
                Swap2(size);
                Rombusz(size, 60, color1);
                Swap1(size);
            }
			Mirror(size,120);
            for (int i = 0; i < row; i++) {
                Swap1(size);
                Swap2(size);
            }
			Mirror(size,120);
        }
        void DoubleRow(double size,int row, Color color1, Color color2) {
				Row(size, row, color1, color2);
				Mirror(size,60);
				Jobbra(180);
				Row2(size,row,color1, color2);
				Jobbra(180);
				Mirror(size,60);
        }
		void Mozaik(double size, int row,int length, Color color1, Color color2) {
			for (int i = 0; i < length; i++) {
				DoubleRow(size, row, color1, color2);
                Mirror(size, 60);
                Jobbra(180);
				Mirror(size, 120);
                Jobbra(180);
            }
			for (int i = 0;i < length;i++) {
				Jobbra(180);
				Mirror(size, 120);
				Jobbra(180);
                Mirror(size, 60);
			}
		}
        /* Függvények vége */
        void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			Teleport(közép.X/3, közép.Y*1.8, észak);
			Mozaik(40, 5,3, Color.Red, Color.Blue);
			//Rombusz(40, 120, Color.Red);
			//Mirror2(40);
		}
	}
}
