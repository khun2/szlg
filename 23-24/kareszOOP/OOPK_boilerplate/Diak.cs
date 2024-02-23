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
        #region Koordináta rendszer

        int x = 0;
        int y = 0;
        int karesz_irany = 0;
        // 0, 1, 2, 3
        List<int[]> Kövek = new List<int[]>();

        void KElore() {
            Előre();
            switch (karesz_irany) {
                case 0:
                    y++;
                    break;
                case 1:
                    x++;
                    break;
                case 2:
                    y--;
                    break;
                case 3:
                    x--;
                    break;
            }
        }

        void KFordulj(int n) {
            if (n != 1 && n != -1) { return; }
            if (n == 1) {
                Jobbra();
                if (karesz_irany == 3) {
                    karesz_irany = 0;
                }
                else {
                    karesz_irany++;
                }
            }
            else {
                Balra();
                if (karesz_irany == 0) {
                    karesz_irany = 3;
                }
                else {
                    karesz_irany--;
                }
            }
        }

        void AddData() {
            int[] xyc = new int[3];
            xyc[0] = x;
            xyc[1] = y;
            xyc[2] = Mi_van_alattam();
            Kövek.Add(xyc);
        }
        void Visszamegy() {
            KFordulj(jobbra);
        }
        #endregion
        void DIÁK_ROBOTJAI() {
            Robot karesz = Robot.Get("Karesz");

            karesz.Feladat = delegate () {
                //code goes here brrrrr
            };
        }
    }
}
