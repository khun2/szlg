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
        void DIÁK_ROBOTJAI() {

            Robot karesz = Robot.Get("Karesz");
            void Kavics(int c) {
                if (!Van_e_itt_Kavics()) {
                    Tegyél_le_egy_kavicsot(c);
                }
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
            int pkő = 0, skő = 0;
            void Végigmegy() {
                int sign = 1;
                while (true) {
                    if (Kilépek_e_a_pályáról()) {
                        KFordulj(sign);
                        if (Kilépek_e_a_pályáról()) {
                            break;
                        }
                        else {
                            if (Mi_van_alattam()==3) {
                                Vegyél_fel_egy_kavicsot();
                                Tegyél_le_egy_kavicsot();
                                pkő++;
                            }
                            else if(Mi_van_alattam() == 5) {
                                Vegyél_fel_egy_kavicsot();
                                Tegyél_le_egy_kavicsot();
                                skő++;
                            }
                            Előre();
                            KFordulj(sign);
                            sign *= -1;
                        }
                    }
                    else {
                        if (Mi_van_alattam() == 3) {
                            Vegyél_fel_egy_kavicsot();
                            Tegyél_le_egy_kavicsot();
                            pkő++;
                        }
                        else if (Mi_van_alattam() == 5) {
                            Vegyél_fel_egy_kavicsot();
                            Tegyél_le_egy_kavicsot();
                            skő++;
                        }
                        Előre();
                    }
                }
                KFordulj(-1);
            }
            void _28() {
                BalLe();
                Végigmegy();
                MessageBox.Show($"{pkő}\n{skő}");
                BalLe();
            }


            karesz.Feladat = delegate () {
                //Körberak(2);
                _28();
            };
        }
    }
}