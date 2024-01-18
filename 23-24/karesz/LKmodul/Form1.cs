using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz {
    public partial class Form1 : Form {
        /* Függvények */
        //actions
        void Tölt(double s, double a, Color c) {
            using (new Rajzol(false))
            using (new Átmenetileg(Jobbra, a))
            using (new Átmenetileg(Előre, s)) {
                Tölt(c);
            }
        }
        Color Szinvaltas(Color color, Color color1, Color color2) {
            return (color = color == color1 ? color2 : color1);
        }
        void Oldalaz(double s, double a) {
            using (new Rajzol(false))
            using (new Átmenetileg(Jobbra, a)) {
                Előre(s);
            }
        }
        //Shapes
        void Rectangle(double a, double b) {
            for (int i = 0; i < 2; i++) {
                Előre(a);
                Jobbra(90);
                Előre(b);
                Jobbra(90);
            }
        }
        void Rectangle(double a, double b, Color color) {
            double root = Math.Min(Math.Sqrt(2 * a), Math.Sqrt(2 * b));
            Tölt(root, 45, color);
        }
        void Rombusz(double size, double angle, Color color) {
            Jobbra(angle / 2);
            for (int i = 0; i < 2; i++) {
                Előre(size);
                Jobbra(-angle);
                Előre(size);
                Jobbra(-(180 - angle));
            }
            Tölt(size / 2, -angle / 2, color);
            Jobbra(-angle / 2);
        }
        void Triangle(double size) {
            for (int i = 0; i < 3; i++) {
                Előre(size);
                Jobbra(120);
            }
        }
        void Triangle(double size, Color color) {
            Triangle(size);
            Tölt(size / 2, 30, color);
        }
        void Hexagon(double size) {
            for (int i = 0; i < 6; i++) {
                Előre(size);
                Jobbra(60);
            }
        }
        void Hexagon(double size, Color color) {
            Hexagon(size);
            Tölt(size,60, color);
        }
        /* Függvények vége */
        void FELADAT() {
            /* Ezt indítja a START gomb! */
            // Teleport(közép.X, közép.Y+150, észak);
            Rombusz(30, 45, Color.Red);

        }


    }
}