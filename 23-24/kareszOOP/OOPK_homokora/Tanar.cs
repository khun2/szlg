﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace Karesz
{
    public partial class Form1 : Form
    {
        private const string V = "palya04.txt";
        string betöltendő_pálya = V;

        void TANÁR_ROBOTJAI()
        {
            new Robot("Karesz", 10000, 10000, 10000, 10000, 0, 5, 28, 0);


            Robot janesz = new Robot("Janesz", Robot.képkészlet_lilesz, 0, 0, 0, 0, 0, 14, 1, 2);

            janesz.Feladat = delegate ()
            {
                /*while (true)
                {
                    janesz.Lépj();
                }*/
            };

            Robot fanesz = new Robot("Fanesz", Robot.képkészlet_lilesz, 0, 0, 0, 0, 0, 16, 1, 2);

            fanesz.Feladat = delegate ()
            {
                /*while (true)
                {
                    fanesz.Lépj();
                }*/
            };


        }
    }
}