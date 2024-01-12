using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form {
        /* Függvények */
        void Oldalaz(double size, double angle) {
            using (new Rajzol(false)) {
                Jobbra(angle);
                Előre(size);
                Jobbra(-angle);
            }
        }
        void Tölt(double size, double angle, Color color) {
            using (new Rajzol(false)) {
                Jobbra(angle);
                Előre(size);
                Tölt(color,false);
                //ez lehet hogy csalás de nagyon leesgyszerűsíti a feladatot
                Előre(-size);
                Jobbra(-angle);
            }
        }
        void Rombusz(double size, double angle, Color color) {
            Jobbra(angle / 2);
            for (int i = 0; i < 2; i++)
            {
                Előre(size);
                Jobbra(-angle);
                Előre(size);
                Jobbra(-(180 - angle));
            }
            Tölt(size / 2, -angle / 2, color);
            Jobbra(-angle / 2);
        }
        void Base(double size, Color color, Color color1, Color color2) {
            for (int i = 0; i < 2; i++) {
                Jobbra(60);
                Előre(size * 2);
                Jobbra(-120);
                Előre(size);
                Rombusz(size, 120, color);
                Jobbra(120);
                Rombusz(size, 120, color1);
                Előre(-size);
                Jobbra(-120);
                Előre(size * 2);
                Jobbra(-120);
            }
            Tölt(size / 2,0, color2);
        }
        void TripleBase(double size, Color color, Color color1, Color color2) {
            Base(size, color, color1, color2);
            Jobbra(120);
            Base(size, color1, color2, color);
            Jobbra(120);
            Base(size,color2, color, color1);
            Jobbra(120);
        }
        void Row(double size, int row,  Color color, Color color1, Color color2) {
            for(int i = 0;i < row;i++) {
                TripleBase(size, color, color1, color2);
                Oldalaz(size * 4, 60);
                Oldalaz(size, 0);
            }
            Oldalaz(-size * 4 * row, 60);
            Oldalaz(-size * row, 0);
        }
        void Terep(double size, int row,int length, Color color, Color color1, Color color2) {
            for (int i = 0; i < length; i++) {
                Row(size, row, color, color1, color2);
                Oldalaz(size * 5, 120);
                Oldalaz(size, 0);
            }
            Oldalaz(size * 5 * length, -60);
            Oldalaz(-size * length, 0);
        }
        // Függvények vége 
        void FELADAT()
		{
            /* Ezt indítja a START gomb! */
            Teleport(közép.X/2, közép.Y*1.2, észak);
            Terep(5,1,7, Color.DarkSlateBlue, Color.LightSteelBlue, Color.SteelBlue);
            
		}
	}
}
