using System;
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
        string betöltendő_pálya = "palya04.txt";

        void TANÁR_ROBOTJAI()
        {
            new Robot("Karesz", 10, 10, 10, 10, 0, 5, 28, 0);


            Robot janesz = new Robot("Janesz", Robot.képkészlet_lilesz, 0, 0, 0, 0, 0, 14, 1, 2);

            janesz.Feladat = delegate ()
            {
                while (true)
                {
                    janesz.Lépj();
                }
            };

            Robot fanesz = new Robot("Fanesz", Robot.képkészlet_lilesz, 0, 0, 0, 0, 0, 16, 1, 2);

            fanesz.Feladat = delegate ()
            {
                while (true)
                {
                    fanesz.Lépj();
                }
            };


        }
    }
}