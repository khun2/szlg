using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Négyzet(double a, Color color) {
			for (int i = 0; i < 4; i++) {
				Előre(a);
				Jobbra(90);
			}
			Jobbra(45);
			Tollat(fel);
			Előre(a);
			Tölt(color);
			Előre(-a);
			Jobbra(-45);
			Tollat(le);
		}
		void Teglalap (double a, double b, Color color) {
			for (int i = 0;i < 2;i++) {
				Előre(a);
				Jobbra(90);
				Előre(b);
				Jobbra(90);
			}
			if (a < b)
			{
			double root = Math.Sqrt(2 * a);
                Jobbra(45);
                Tollat(fel);
                Előre(root);
                Tölt(color);
                Előre(-root);
            }
            else
			{
			double root = Math.Sqrt(2 * b);
                Jobbra(45);
                Tollat(fel);
                Előre(root);
                Tölt(color);
                Előre(-root);
            }
			//ez nem értem miért nem működik ha külön van

			/*Jobbra(45);
            Tollat(fel);
            Előre(root);
            Tölt(color);
            Előre(-root);*/
            Jobbra(-45);
            Tollat(le);
        }
		void hrcircle (double a, Color color)
		{
			Előre(a);
			Jobbra(90);
			Ív(180, a/2);
			Jobbra(-90);
            Előre(-a);
			Jobbra(90);
            double root = Math.Sqrt(2 * a);
            Jobbra(45);
            Tollat(fel);
            Előre(-root);
            Tölt(color);
            Előre(root);
            Jobbra(-45);
            Tollat(le);
			Jobbra(90);
			Előre(-a);
        }
        void hlcircle(double a, Color color)
        {
            Jobbra(-90);
            Ív(180, a / 2);
            Jobbra(-90);
            Előre(-a);
            Jobbra(90);
            double root = Math.Sqrt(2 * a);
            Jobbra(45);
            Tollat(fel);
            Előre(-root);
            Tölt(color);
            Előre(root);
            Jobbra(-45);
            Tollat(le);
			Jobbra(-90);
        }
		void labjobb(double a)
		{
			Teglalap(a, a, Color.Black);
			Jobbra(90);
			Előre(a);
			Jobbra(-90);
			hrcircle(a, Color.Black);
			Jobbra(-90);
			Előre(a);
			Jobbra(90);
		}
		void labbal(double a)
		{
            Teglalap(a, a/4, Color.Black);
			//MessageBox.Show("a");
			hlcircle(a, Color.Black);
			//MessageBox.Show("s");
			
			/*
			Jobbra(90);
			Előre(a/4);
			Jobbra(-90);
			*/
			//^^^^^ez volt a problema egész végig nem tudom hogy nem vettem eszre hamarabb
        }
		void lab(double a)
		{
			labbal(a);
			//MessageBox.Show("a");
			Tollat(fel);
			Jobbra(90);
			Előre(a / 4*3);
			Jobbra(-90);
			Tollat(le);
			labjobb(a);
			Tollat(fel);
			Jobbra(-90);
			Előre(a / 4*3);
			Jobbra(90);
			Tollat(le);
		}
		void _2nyom(double a)
		{
			a = a / 5;
			double x = a * 4 / 3;
            Jobbra(-35);
			lab(a);
			Jobbra(35);
			
			Jobbra(90);
			Tollat(fel);
			Előre(x);
			Jobbra(-90);

            Előre(-a);
			Tollat(le);
			Jobbra(35);
			lab(a);
			Tollat(fel);
			Jobbra(-35);
			Előre(a);
			Jobbra(90);
			Előre(-x);
			Jobbra(-90);
			Tollat(le);
        }
		void nyomok(int b, double a)
		{
			for (int i = 0; i < b; i++)
			{
				_2nyom(a);
                a = a / 5;
                Tollat(fel);
				Jobbra(90);
				Előre(3*a);
				Tollat(le);
				Jobbra(-90);
				a *= 5;
			}
			Tollat(fel);
			Jobbra(-90);
			Előre(a / 5 * 3 * b);
			Jobbra(90);
			Tollat(le);
		}
        /* Függvények vége */
        void FELADAT()
		{
			/* Ezt indítja a START gomb! */
			Teleport(közép.X-200, közép.Y, észak);
			MessageBox.Show("itt vagyok");

			nyomok(5, 150);
			//_2nyom(250);
            //Teglalap(1, 1, Color.Black);		
        }
	}
}
