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
		void _3Négyzet(double a){
			Jobbra(-45);
			Négyzet(a);
			Előre(a);
			Négyzetbal(a);
			Előre(-a);
			Jobbra(90);
			Előre(a);
			Négyzet(a);
            Előre(-a);
			Jobbra(-45);

		}
		void alapminta(double a)
		{
			Tollszín(Color.Red);
			Jobbra(135);
			Előre(a);
			Jobbra(-90);
			Előre(a);
			Jobbra(-45);
			_3Négyzet(a / 2);
			Jobbra(135);
			Előre(a);
			Jobbra(-90);
            Előre(a);
            Jobbra(-45);
        }
		void sormintaA(int b, double a) {
		for(int i = 0;i < b;i++) {
				alapminta(a);
			}
		}
		void sormintaB(int b, double a){
			sormintaA(b, a);
			Jobbra(-135);
			Előre(a);
			Jobbra(-90);
			Előre(a) ;
			Jobbra(45);
			sormintaA(b,a);
            Jobbra(-135);
            Előre(a);
            Jobbra(-90);
            Előre(a);
            Jobbra(45);
        }



            /* Függvények vége */
            void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			 Teleport(közép.X-200, közép.Y, észak);
			Tollvastagság(2);
			//alapminta(50);
			//sormintaA(3, 50);
			sormintaB(3, 40);

		
		}
	}
}
