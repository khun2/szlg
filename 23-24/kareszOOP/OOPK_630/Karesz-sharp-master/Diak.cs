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
        void DIÁK_ROBOTJAI()
        {
            Robot karesz = Robot.Get("Karesz");

                void _06_30() {
                    Jobbra(2);
                    while (!Van_e_előttem_fal()) {
                        Előre();
                    }
                    Jobbra();
                    while (!Van_e_előttem_fal()) {
                        Előre();
                    }
                    Jobbra();
                    while (true) {
                        if (Kilépek_e_a_pályáról()) {
                            break;
                        }
                        if (!Van_e_előttem_fal()) {
                            Előre();
                        }
                        Jobbra();
                        if (!Van_e_előttem_fal()) {
                            Előre();
                        }
                        else {
                            Balra();
                        }
                        if (Van_e_előttem_fal()) {
                            Balra();
                        }
                    }
                }
            karesz.Feladat = delegate ()
            {
                //code goes here brrrrr 
                _06_30();
            };
        }
    }
}
