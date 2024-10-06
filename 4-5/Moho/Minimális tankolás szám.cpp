#include <bits/stdc++.h>
#include <vector>
using namespace std;

int main() {
    int k, n, b, l, needed, best, i, count = 0;
    cin >> k >> n >> b >> l;
    bool repeat;

    needed = k / 100 * l;
    vector<pair<int, int>> v(n);
    vector<bool> visited(n, 0);
    for (int i = 0; i < n; i++) cin >> v[i].first >> v[i].second;
    while (b < needed) {
        repeat = 1;
        i = 1;
        best = 0;
        while (repeat) {
            if (i < n && b * 100 / l >= v[i].first) {
                if (visited[i]) {
                    i++;
                    continue;
                }
                if (visited[best] || v[best].second < v[i].second) {
                    best = i;
                    i++;
                }
            } else {
                repeat = 0;
                b += v[best].second;
                visited[best] = 1;
                count++;
                cerr << best;
            }
        }
    }
    cout << count;
}
