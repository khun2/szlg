#include <bits/stdc++.h>
using namespace std;

int main() {
    int n, k, last;
    cin >> n >> k;
    vector<int> v(n), r(1, 1);
    for (int i = 0; i < n; i++) { cin >> v[i]; }
    last = v[0];
    for (int i = 1; i < n; i++) {
        if (v[i] - last >= k) {
            r.push_back(i + 1);
            last = v[i];
        }
    }
    r[r.size() - 1] = n;
    cout << r.size() << '\n';
    for (int x : r) { cout << x << ' '; }
}
