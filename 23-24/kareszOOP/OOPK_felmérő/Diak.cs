using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Karesz {
    public partial class Form1 : Form {
        //custom OOPK build, normál karesez commandokkal nem fog működni!
        void Kavics(int c = 2) {
            if (!Van_e_itt_Kavics()) {
                Tegyél_le_egy_kavicsot(c);
            }
        }
        void bástya(int s) {
            Kavics();
            ElőreRakj(s - 1);
            Jobbra();
            ElőreRakj(2);
            Jobbra();
            ElőreRakj(s - 1);
        }
        void várfal(int count, int s) {
            for (int i = 0; i < count; i++) {
                bástya(s);
                if (i % 2 == 0) { s -= 2; }
                else { s += 2; }
                Balra();
                Előre();
                Balra();
            }
        }
        void BalLe() {
            for (int i = 0; i < 2; i++) {
                Balra(1);
                while (!Van_e_előttem_fal() && !Kilépek_e_a_pályáról()) {
                    Előre();
                }
            }
            Jobbra(2);
        }
        void BalLeFalK() {
            //ez teknikailag kell a feladatleírás miatt
            for (int i = 0; i < 2; i++) {
                Balra(1);
                while (!Van_e_előttem_fal() && !Kilépek_e_a_pályáról()) {
                    if (i == 1) {
                        int rand1 = random_generator.Next(2, 7);
                        Kavics(rand1);
                    }
                    Előre();
                }
            }
        }
        bool checkWall() {
            Balra();
            if (!Van_e_előttem_fal()) {
                return true;
            }
            Jobbra();
            return false;
        }
        Random random_generator = new Random();
        void Falkövetés() {
            BalLeFalK();
            int rand1 = random_generator.Next(2, 7);
            Kavics(rand1);
            if (Kilépek_e_a_pályáról()) {
                return;
            }
            Jobbra(2);
            while (true) {
                if (checkWall()) {
                    break;
                }
                rand1 = random_generator.Next(2, 7);
                Kavics(rand1);
                Előre();
                if (Van_e_előttem_fal()) {
                    if (checkWall()) {
                        rand1 = random_generator.Next(2, 7);
                        Kavics(rand1);

                        break;
                    }
                    Jobbra();
                }
            }
            rand1 = random_generator.Next(2, 7);
            Kavics(rand1);
            Előre();
            rand1 = random_generator.Next(2, 7);
            Kavics(rand1);
        }
        void KFordulj(int x) {
            if (x == 1) {
                Jobbra();
            }
            else {
                Balra();
            }
        }
        int pkő = 0, fkő = 0;
        void Virág() {
            for (int i = 0; i < 4; i++) {
                Előre();
                Tegyél_le_egy_kavicsot(6);
                Előre(-1);
                Jobbra();
            }
        }
        void Végigmegy() {
            Végtelenkő();
            int sign = 1;
            while (true) {
                if (Kilépek_e_a_pályáról()) {
                    KFordulj(sign);
                    if (Kilépek_e_a_pályáról()) {
                        break;
                    }
                    else {
                        if (Mi_van_alattam() == 3) {
                            Vegyél_fel_egy_kavicsot();
                            pkő++;
                        }
                        else if (Mi_van_alattam() == 2) {
                            Vegyél_fel_egy_kavicsot();
                            fkő++;
                        }
                        else if (Mi_van_alattam() == 5) {

                        }
                        Előre();
                        KFordulj(sign);
                        sign *= -1;
                    }
                }
                else {
                    if (Mi_van_alattam() == 3) {
                        Vegyél_fel_egy_kavicsot();
                        pkő++;
                    }
                    else if (Mi_van_alattam() == 2) {
                        Vegyél_fel_egy_kavicsot();
                        fkő++;
                    }
                    else if (Mi_van_alattam() == 5) {
                        //valamit csinálj
                        Virág();
                    }
                    Előre();
                }
            }
            KFordulj(-1);
        }
        void _29() {
            BalLe();
            Végigmegy();
            BalLe();
        }
        void DIÁK_ROBOTJAI() {
            Robot karesz = Robot.Get("Karesz");

            karesz.Feladat = delegate () {
                //code goes here brrrrr 
                //bástya(4);
                //várfal(6, 4);
                //Falkövetés();
                _29();
            };
        }
    }
}
