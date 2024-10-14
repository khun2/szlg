#include <bits/stdc++.h>
using namespace std;

int main() {
    int n, k, m, c, nextFinish = 0;
    cin >> n >> k >> m >> c;
    vector<int> v(c), finishdates(0);
    for (int i = 0; i < c; i++) {
        cin >> v[i];
        cerr << v[i] << '\n';
    }
    int result = 0, available = n;
    cerr << "sikerült beolvasni\n\n\n";
    for (int i = 0; i < c; i++) {
        while (finishdates.size() > 0 &&
               finishdates[nextFinish] == i) {
            available++;
            nextFinish++;
        }
        if (available > 0) {
            finishdates.push_back(v[i] + m - 1);
            available--;
            result++;
        }
    }
    cout << result;
}
