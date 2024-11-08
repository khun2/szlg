#include <bits/stdc++.h>
using namespace std;

int main() {
    int n, k, m, c, count = 0;
    cin >> n >> k >> m >> c;
<<<<<<< HEAD
    vector<int> v(c), finishdates(0);
    for (int i = 0; i < c; i++) { cin >> v[i]; }
    int result = 0, current = 1;
    for (int i = 0; current < c; i++) {
        while (n > 0) {
            current = v[i];
            finishdates.push_back(v[i] + m - 1);
            n--;
            result++;
            i++;
            while (finishdates.size() > 0 &&
                   nextFinish < finishdates.size() &&
                   finishdates[nextFinish] < current) {
                n++;
                nextFinish++;
            }
        }
        while (finishdates.size() > 0 &&
               nextFinish < finishdates.size() &&
               finishdates[nextFinish] < current) {
            n++;
            nextFinish++;
        }
    }
    /*for (int i = 0; i < c; ) {
        while (finishdates.size() > 0 &&
               nextFinish < finishdates.size() &&
               finishdates[nextFinish] == i) {
            n++;
            nextFinish++;
        }
        while (n > 0) {
            finishdates.push_back(v[i] + m - 1);
            n--;
            result++;
            i++;
        }
    }
    */
    cout << result;
=======
    int busy[10] = {0};
    for (int i = 0; i < c; i++) {
        cin >> k;
        for (int i = 0; i < n; i++) {
            if (busy[i] <= k) {
                //                cerr << x << '>' << busy[i] << '\n';
                busy[i] = k + m;
                count++;
                break;
            }
        }
    }
    cout << count;
>>>>>>> 98132e3 (2024. nov. 8., péntek, 18:50:27 CET)
}
