#include <bits/stdc++.h>
using namespace std;

void solve() {
    long long n, s, m, l, r;
    cin >> n >> s >> m;
    vector<bool> v(m, false);
    for (int i = 0; i < n; i++) {
        cin >> l >> r;
        v[l] = 1; v[r] = 1;
    }
    bool busy = false;
    long long days = 0;
    for (int i = 0; i < m; i++) {
        if(busy) {
            if(v[i]) {
                busy = 0;
                days = 1;
                continue;
            }
            else continue;
        }
        if(v[i]) {
            days = 0;
            busy = 1;
        }
        days++;
        if(days == s) {
            cout << "YES\n";
            return;
        }
    }
    cout << "NO\n";
}

int main() {
    int t;
    cin >> t;
    for (int i = 0; i < t; i++) {
        solve();
    }
}