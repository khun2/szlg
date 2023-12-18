using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		/* Függvények */
		void Fog(double a, Color color) {
			Előre(a);
			Jobbra(30);
			for (int i = 0; i < 2; i++) {
				Előre(a);
				Jobbra(120);
			}
			Jobbra(-90);
			for (int i = 0; i < 2; i++){
				Előre(a);
				Jobbra(90);
			}
			Tolt(color, a);
		}
		void Tolt(Color color, double a) {
			using(new Rajzol(false)) {
				Jobbra(45);
				Előre(a);
				Tölt(color);
				Előre(-a);
				Jobbra(-45);
			}
		}
		Color Szinvaltas(Color color, Color color1, Color color2) {
			return(color = color == color1 ? color2 : color1);
		}
		void Oldalaz(double a) {
			using (new Rajzol(false)) {
				Jobbra(90);
				Előre(a);
				Jobbra(-90);
			}
		}
		void Sor(double size, int amount, Color color1, Color color2) {
			Color color = color2;
			for (int i = 0; i < amount; i++){
				color=Szinvaltas(color, color1, color2);
				Fog(size, color);
				Oldalaz(size);
			}
			Oldalaz(-amount * size);
		}
		void Sor2(double size, int amount, Color color1, Color color2) {
            Oldalaz(amount * size);
			Jobbra(180);
			Sor(size, amount, color1, color2);
            Jobbra(180);
            Oldalaz(-amount * size);
        }
		void Dupla(double size, int amount, Color color1, Color color2, Color color3, Color color4) {
            Sor(size, amount, color1, color2);
			using (new Rajzol(false)) {
				Előre(size);
				Jobbra(30);
				Előre(size);
				Jobbra(-30);
				Előre(size);
			}
			Sor2(size, amount, color3, color4);
			using (new Rajzol(false)) {
				Előre(-size);
				Jobbra(30);
				Előre(-size);
				Jobbra(-30);
				Előre(-size);
			}
        }
		void Fal(double size, int amount,int height, Color color1, Color color2, Color color3, Color color4) {
			for(int i = 0; i < height; i++) {
				Dupla(size, amount, color1, color2, color3, color4);
				using (new Rajzol(false)) {
					Előre(size);
					Jobbra(30);
					Előre(size);
					Jobbra(-30);
					Előre(size);
				}
			
            }
            using (new Rajzol(false)) {
                for (int i = 0; i < height; i++) {
                    Előre(-size);
                    Jobbra(30);
                    Előre(-size);
                    Jobbra(-30);
                    Előre(-size);
                }
            }

        }
        /* Függvények vége */
        void FELADAT() { using (new Frissítés(false))
        /* Ezt indítja a START gomb! */
		// Teleport(közép.X, közép.Y+150, észak);
        Fal(10, 10,4, Color.Red, Color.Blue, Color.Green, Color.Purple);
		}
	}
}
