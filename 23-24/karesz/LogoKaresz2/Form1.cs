using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void hatszög(double a)
		{
            for(int i = 0; i < 6; i++)
			{
                Előre(a);
                Jobbra(300);
            }
        }
		void vonalak(double a, double b)
		{
            Tollat(fel);
            Előre(200);
            Tollat(le);
			Jobbra(30);
			Előre(b);
			for (int i = 0; i < 6; i++)
			{
				Előre(-(b * a + b));
				Előre(a * 2*b + b*2);
                Előre(-(b * a + b));
				Jobbra(60);
            }
			Előre(-b);
			Jobbra(150+180);
			Tollat(fel);
			Előre(-200);
			Tollat(le);
        }
		void pókháló (double a, double b)
		{
            Tollat(fel);
            Előre(200);
            Tollat(le);
            Jobbra(90);
            for(int i = 0;i < a;i++)
			{
				hatszög((i + 1) * b);
                Jobbra(120);
				Előre(b);
				Jobbra(240);	
			}
            Tollat(fel);
			Jobbra(300);
			Előre(b*a);
			Jobbra(330);
			Előre(-200);
			Tollat(le);
            vonalak(a, b);

			/*Jobbra(300);
			Előre (a*50+50);*/
        }

		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			// Teleport(közép.X, közép.Y+150, észak);

			pókháló(5, 25);
            //vonalak(10, 15);
            //elvileg minden számmal működik ami nem megy ki a pályáról


        }
	}
}
