//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
//using System.Threading;

namespace Karesz {
    public partial class Form1 : Form {
        void DIÁK_ROBOTJAI() {
            Robot karesz = Robot.Get("Karesz");
            void Keres(bool i = true) {
                if (i) {
                    Jobbra();
                }
                else {
                    Balra();
                }
                if (!Van_e_előttem_fal() && !Kilépek_e_a_pályáról()) {
                    Előre();
                    if (!Van_e_itt_Kavics()) {
                        Jobbra(2);
                        Előre();
                        Balra(1);
                        Keres(!i);
                    }
                    else { return; }
                }
                else {
                    if (i) {
                        Balra();
                    }
                    else {
                        Jobbra();
                    }
                    Keres(!i);
                }
            }
            void _21() {
                for (int i = 0; i < 26; i++) {
                    while (!Van_e_előttem_fal() && !Kilépek_e_a_pályáról()) {
                        Előre();
                        if (!Van_e_itt_Kavics()) {
                            Jobbra(2);
                            Előre();
                            Jobbra(2);
                            break;
                        }
                    }
                    Keres();
                }
                Előre(4);
                Keres();
                Előre(2);
            }
            void BalLe() {
                for (int i = 0; i < 2; i++) {
                    Balra(1);
                    while (!Kilépek_e_a_pályáról() && !Van_e_előttem_fal()) {
                        Előre();
                    }
                }
                Jobbra(2);
                Végtelenkő();
            }
            void KFordulj(int x) {
                if (x == 1) {
                    Jobbra();
                }
                else {
                    Balra();
                }
            }
            int kavicsok = 0;
            void Végigmegy() {
                int sign = -1;
                while (true) {
                    if (Kilépek_e_a_pályáról()) {
                        KFordulj(sign);
                        if (Kilépek_e_a_pályáról()) {
                            if (Van_e_itt_Kavics()) {
                                kavicsok++;
                                Vegyél_fel_egy_kavicsot();
                            }
                            break;
                        }
                        else {
                            if (Van_e_itt_Kavics()) {
                                kavicsok++;
                                Vegyél_fel_egy_kavicsot();
                            }
                            Előre();
                            KFordulj(sign);
                            sign *= -1;
                        }
                    }
                    else {
                        if (Van_e_itt_Kavics()) {
                            Vegyél_fel_egy_kavicsot();
                            kavicsok++;
                        }
                        Előre();
                    }
                }
                KFordulj(-1);
            }
            void Végirak() {
                int sign = -1;
                while (kavicsok > 0) {
                    if (Kilépek_e_a_pályáról()) {
                        KFordulj(sign);
                        if (Kilépek_e_a_pályáról()) {
                            Tegyél_le_egy_kavicsot();
                            kavicsok--;
                            break;
                        }
                        else {
                            Tegyél_le_egy_kavicsot();
                            kavicsok--;
                            Előre();
                            KFordulj(sign);
                            sign *= -1;
                        }
                    }
                    else {
                        Tegyél_le_egy_kavicsot();
                        kavicsok--;
                        Előre();
                    }
                }
                KFordulj(1);
            }
            void Porszívó() {
                BalLe();
                Jobbra();
                Végigmegy();
                BalLe();
                while (!Kilépek_e_a_pályáról()) { Előre(); }
                Jobbra(2);
                Végirak();
                BalLe();
            }

            void Rajz() {

            }
            karesz.Feladat = delegate () {
                Rajz();
            };
        }
    }
}
