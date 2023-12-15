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
        void Lepcso(int height, int color=2) {
        for(int i = 0; i < height; i++) {
                ElőreRakj(1, color);
                Jobbra();
                Előre();
                Balra();

            }
        }
        void Falak(int color=2) {
            for (int i = 0; i < 2; i++){
                ElőreRakj(10, color);
                Jobbra();
                ElőreRakj(20,color);
                Jobbra();
            }
        }
        void Teto(int color=2) {
            Előre(10);
            Lepcso(11,color);
            Jobbra();
            Előre(-1);
            Vegyél_fel_egy_kavicsot();
            Előre(-1);
            Lepcso(11,color);
            Előre(-20);
            Balra();
            Előre(-10);
        }
        void Ajto(int color=2) {
            Jobbra();
            Előre(4);
            Balra();
            ElőreRakj(5, color);
            Jobbra();
            ElőreRakj(4,color);
            Jobbra();
            ElőreRakj(4,color);
            Előre(1);
            Jobbra();
            Előre(9);
            Jobbra();
        }
        void Ablak(int color) {
            Jobbra();
            Előre(13);
            Balra();
            Előre(5);
            for(int i = 0; i < 4; i++) {
                ElőreRakj(3, color);
                Jobbra() ;
            }
            Előre(-5);
            Balra();
            Előre(12);
            Jobbra();
        }
        void Keritsdarab(int color=2) {
            Jobbra();
            ElőreRakj(1);
            Előre(1);
            Jobbra();
            ElőreRakj(1);
            Balra();
            Balra();
            ElőreRakj(7);
            Előre(-2);
            Balra();
            ElőreRakj(1);
            Előre(-1);
            Jobbra();
            Előre(-4);
        }
        void Kerites(int kerites, int color=2) {
            for (int i = 0; i < kerites; i++){
                Keritsdarab(color);
            }
            Balra();
            Előre(kerites * 2);
            Jobbra();
        }

        void Haz(int kerites,int color=2) {
            Falak(color);
            Teto(color);
            Ajto(color);
            Ablak(color);
            Jobbra();
            Előre(20);
            Balra();
            Előre();
            Kerites(kerites, color);
            Előre(-1);
            Balra();
            Előre(20);
            Jobbra();
        }
        void DIÁK_ROBOTJAI()
        {
            Robot karesz = Robot.Get("Karesz");

            karesz.Feladat = delegate ()
            {
                //code goes here brrrrr
                Végtelenkő(true);
                Haz(5);
                
                
            };
            
        }
    }
}
