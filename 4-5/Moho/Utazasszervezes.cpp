#include <bits/stdc++.h>
using namespace std;

int main() {
    int n, k, m, c, count = 0;
    cin >> n >> k >> m >> c;
    int busy[10] = {0};
    for (int i = 0; i < c; i++) {
        cin >> k;
        for (int i = 0; i < n; i++) {
            if (busy[i] <= k) {
                busy[i] = k + m;
                count++;
                break;
            }
        }
    }
    cout << count;
}
