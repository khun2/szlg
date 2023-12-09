using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Négyzet(double a)
		{
			for (int i = 0; i < 4; i++)
			{
				Előre(a);
				Jobbra(90);
			}
		}
		void Négyzetbal(double a) {
			for (int i = 0; i < 4; i++)
			{
				Előre(a);
				Jobbra(-90);
			}
		}
		void alapminta(double a)
		{
			Tollvastagság(3);
			//Tollszín(Color.Red);
			Jobbra(135);
			Előre(a);
			Jobbra(-90);
			Előre(a);
			Jobbra(-90);
			Négyzet(a / 2);
			Előre(a / 2);
			//Négyzetbal(a / 2);
		}
		

		

		/* Függvények vége */
		void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			 Teleport(közép.X, közép.Y, észak);
			alapminta(50);

		
		}
	}
}
