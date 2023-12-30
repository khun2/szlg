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
            for (int i = 0;i < 3;i++) {
                Előre(size);
                Jobbra(120);
            }
        }
        void Triangle(double size, Color color) {
            Triangle(size);
            Jobbra(30);
            Tölt(size/2, color);
            Jobbra(-30);
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
        Color Szinvaltas(Color color, Color color1, Color color2) {
            return (color = color == color1 ? color2 : color1);
        }
        
        void SwapRow(double size)
        {
            using (new Rajzol(false))
            {
                Jobbra(120);
                Előre(size);
                Jobbra(-60);
                Előre(size);
                Jobbra(-60);
                Oldalaz(size * 2);
            }
        }
        void Row1(double size, int row, Color color1,Color color2) {
            Jobbra(-90);
            Rectangle(2 * size, size, color2);
            Jobbra(90);
            for (int i = 0; i < row; i++) {
                Hexagon(size, color1);
                SwapRow(size);
                Jobbra(-90);
                Rectangle(2 * size, size, color2);
                Jobbra(90);
            }
            for (int i = 0;i < row; i++) {
                SwapRow(-size);
            }
        }
        void TrianglePlusRectangle(double size, Color color1, Color color2) {
            Oldalaz(-size);
            Rectangle(2 * size, size, color2);
            Jobbra(-60);
            
            Triangle(size * 2, color1);
        }
        void Row2(double size,int row, Color color1,Color color2,Color color3,bool state) {
            Color color = color1;
            if (state) {
                Jobbra(-150);
                Triangle(size * 2, color);
                Jobbra(150);
            }
            else {
                for (int i = 0;i<row ; i++) {
                    SwapRow(size);
                }
                Oldalaz(-size*2);
                Tollat(fel);
                Előre(size);
                Tollat(le);
                Jobbra(30);
                color = color2;
                Triangle(size * 2, color);
                Jobbra(150);
            }
            for (int i = 0; i < row; i++) {
                Jobbra(-150);
                color = Szinvaltas(color, color1, color2);
                TrianglePlusRectangle(size, color, color3);
                color = Szinvaltas(color, color1, color2);
                TrianglePlusRectangle(size, color, color3);
                Jobbra(-90);
                Oldalaz(size*2);
            }
            for (int i=0;i<row;i++) {
                SwapRow(-size);
            }
            if (state==false) {
                for (int i=0;i<row; i++) {
                    SwapRow(size);
                }
                Jobbra(180);
                Oldalaz(size*2);
                Előre(-size);
            }
        }
        bool StateChange(bool state) {
            if (state) {
                return (false);
            }
            return(true);
        }
        void PillarSwap(double size, bool state) {
            using(new Rajzol(false)) {
                Előre(size);
                Jobbra(60);
                Előre(size);
                Jobbra(-30);
                Előre(size * 2);
                Jobbra(-30);
                if (state) {
                    SwapRow(-size);
                }
            }
        }
        Color Test(double size) {
            using(new Rajzol(false))
            {
                Jobbra(45);
                Color test = new Color();
                Előre(size);
                test = Milyen_szín_van_itt();
                Előre(-size);
                Jobbra(-45);
                return (test);
            }
        }
        void Mozaik(double size, int row, int pillar, Color color1, Color color2, Color color3, Color color4) {
            Color asd = Milyen_szín_van_itt();
            Color teszt = Milyen_szín_van_itt();
            //ez megadja a háttér színét amit később használok
            Row2(size, row, color1, color2, color3, true);
            bool state = true;
            MessageBox.Show($"{state}");
            for (int i = 0; i < pillar; i++) {
                PillarSwap(size, state);
                if (i==0) {
                    PillarSwap(-size, state);
                }
                if (state) {
                    Jobbra(-150);
                    teszt = Test(size / 4);
                    if (teszt == asd) {
                        Triangle(size * 2, color1);
                    }
                    //ha nincs beszinezve már beszínezi ha igen nem csinál semmit (peti ötlete de az én (szar) implementációm)
                    Oldalaz(-size);
                    teszt = Test(size / 4);
                    if (teszt == asd) {
                        Rectangle(size * 2, size, color3);
                    }
                    Oldalaz(size);
                    Jobbra(150);
                }
                else {
                    for (int i2 = 0; i2 < row; i2++) {
                        SwapRow(size);
                    }
                    Oldalaz(-size * 2);
                    Jobbra(90);
                    teszt = Test(size / 4);
                    if (teszt == asd) {
                        Triangle(size * 2, color1);
                    }
                    Jobbra(60);
                    teszt = Test(size / 4);
                    if (teszt==asd) {
                        Rectangle(size * 2, size, color3);
                    }
                    Jobbra(-150);
                    Oldalaz(size * 2);
                    for (int i2 = 0; i2 < row; i2++) {
                        SwapRow(-size);
                    }
                }
                Row1(size, row, color4, color3);
                Row2(size,row,color1,color2, color3, false);
                state=StateChange(state);
            }
            Back(size, pillar,row, state);
            MessageBox.Show($"{state}");
        }
        void Back(double size, int pillar,int row, bool state) {
            using(new Rajzol(false)) {
                
            }
        }
        /* Függvények vége */
        void FELADAT()
		{
            /* Ezt indítja a START gomb! */
            Teleport(közép.X/2, közép.Y*1.5, észak);
            Mozaik(15, 2, 5, Color.Blue, Color.Red, Color.Yellow, Color.LightGreen);
            
        }
	}
}
