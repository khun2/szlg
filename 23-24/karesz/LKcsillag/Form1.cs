﻿using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
        /* Függvények */
        void Tölt(double size, Color color)
        {
            using (new Rajzol(false))
            {
                Előre(size);
                Tölt(color);
                Előre(-size);
            }
        }
        void Rombusz(double size, double angle,Color color) {
            Jobbra(angle);
            for (int i = 0; i < 2; i++){
                Előre(size);
                Jobbra(-angle);
                Előre(size);
                Jobbra(-(180-angle));
            }
            Jobbra(-angle/2);
            Tölt(size/3*4, color);
            Jobbra(-angle/2);
        }
        void Change(double size, double angle) {
            using (new Rajzol(false)) {
                Jobbra(angle);
                Előre(size);
                Jobbra(-angle);
            }
        }
        void Row(double size,double angle, int length, Color[] colors) {
            
            for (int i = 0; i < length; i++) {
                Rombusz(size,angle, colors[i]);
                //ezt a Color[] color dolgot Petitől loptam(engedélyével ofc) mert teljesen el voltam akadva
                Change(size,angle);
            }
            Change(-length*size,angle);
        }
        void Mozaik(double size, double angle, int length, Color[] colors) {
            for (int i = 0; i < length; i++) {
                Color[] colors1 = colors.Skip(i).Take(length).ToArray();
                Row(size,angle,length,colors1);
                Előre(size);
            }
            Előre(-size * length);
        }
        void Fmozaik(double size, double angle, int length, Color[] colors) {
            if ((360 % angle != 0)) { MessageBox.Show("Az angle nem oztható 360-nal, Kérlek adj meg egy másik számot");}
            else {
                for (int i = 0; i < 360 / angle; i++)
                {
                    Mozaik(size, angle, length, colors);
                    Jobbra(angle);
                }
            }
        }
        /* Függvények vége */
        void FELADAT()
		{
            /* Ezt indítja a START gomb! */
            Teleport(közép.X, közép.Y, észak);

            Color[] colors = { Color.Aquamarine, Color.Green, Color.Blue, Color.Black, Color.White,Color.Yellow, Color.Pink, Color.DarkOrchid, Color.Indigo,Color.Lavender};
            Fmozaik(20, 30, 5, colors);
			
		}
	}
}
