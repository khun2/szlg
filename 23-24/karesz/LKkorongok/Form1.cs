using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
        /* Függvények */
        void Tölt(double size, Color color) {
            using(new Rajzol(false)) {
                Előre(size);
                Tölt(color);
                Előre(-size);
            }
        }
        void Rectangle(double a, double b) {
            for (int i = 0; i < 2; i++)
            {
                Előre(a);
                Jobbra(90);
                Előre(b);
                Jobbra(90);
            }
        }
        void Rectangle(double a, double b, Color color) {
            Rectangle(a, b);
            double root = Math.Min(Math.Sqrt(2 * a), Math.Sqrt(2 * b));
            Jobbra(45);
            Tölt(root, color);
            Jobbra(-45);
        }
        void Triangle(double size) {
            Jobbra(30);
            for (int i = 0;i < 3;i++) {
                Előre(size);
                Jobbra(-120);
            }
            Jobbra(-30);
        }
        void Triangle(double size, Color color) {
            Triangle(size);
            Tölt(size, color);
        }
        void Hexagon(double size) {
            for (int i = 0; i < 6; i++){
                Előre(size);
                Jobbra(60);
            }
        }
        void Hexagon(double size, Color color) {
            Hexagon(size);
            Jobbra(60);
            Tölt(size, color);
            Jobbra(-60);
        }
        void Oldalaz(double a) {
            using(new Rajzol(false)) {
                Jobbra(90);
                Előre(a);
                Jobbra(-90);
            }
        }
        void Base(double size) {
            Hexagon(size);
            Jobbra(-90);
            for (int i = 0; i < 6; i++) {
                Rectangle(size * 2, size);
                Jobbra(-30);
                Triangle(size*2);
                Jobbra(-30);
                Oldalaz(-size);
            }
            Jobbra(90);
        }
        void SwapRow(double size) {
            using(new Rajzol(false)) {
                Jobbra(120);
                Előre(size);
                Jobbra(-60);
                Előre(size);
                Jobbra(-60);
                Oldalaz(size * 2);
            }
        }
        void Row(double size, int row) {
            for (int i = 0; i < row; i++) {
                Base(size);
                SwapRow(size);
            }
            for (int i = 0; i < row; i++) {
                SwapRow(-size);
            }
        }
        void SwapLine(double size) {
            using (new Rajzol(false)) {
                Előre(size);
                Jobbra(60);
                Előre(size);
                Jobbra(-30);
                Előre(2 * size);
                Jobbra(-30);
            }
        }

        void Halo(double size, int row, int pillar) {
            for(int i = 0;i < pillar;i++) {
                Row(size, row);
                SwapLine(size);
            }
            for(int i = 0;i<pillar ; i++) {
                SwapLine(-size);
            }
            // a színezést azért írom külön mert ugyanazt nem lehet kétszer ugyanúgy beszinezni
        }
        Color Szinvaltas(Color color, Color color1, Color color2) {
            return (color = color == color1 ? color2 : color1);
        }
        void Colouring1(double size,int row,Color color1, Color color2) {
            double root = Math.Sqrt(2 * size);
            Jobbra(-45);
            Tölt(root, color2);
            Jobbra(45);
            for(int i = 0; i<row ; i++) {
                Color color = color2;
                color = Szinvaltas(color, color1, color2);
                Jobbra(60);
                Tölt(size, color);
                Jobbra(-60);
                SwapRow(size);
                Jobbra(-45);
                color = Szinvaltas(color, color1, color2);
                Tölt(root, color);
                Jobbra(45);
                
            }
            for (int i = 0; i < row; i++) {
                SwapRow(-size);
            }
            //ez beszínezi elvileg a középső két sort és nagyon csúnya, emellet sajog a fejem ennek a megírásától
        }
        void Mozaik(double size, int row, int pillar, Color color1, Color color2) {
            Halo(size, row, pillar);
            for (int i = 0;i < pillar ; i++) {
                Colouring1(size, row,color1,color2);
                SwapLine(size);
            }
            for(int i = 0;i<pillar ; i++) {
                SwapLine(-size);
            }
        }
        /* Függvények vége */
        void FELADAT()
		{
            /* Ezt indítja a START gomb! */
            Teleport(közép.X/2, közép.Y*1.8, észak);
            Mozaik(10, 1, 5, Color.Blue, Color.Red);
		}
	}
}
