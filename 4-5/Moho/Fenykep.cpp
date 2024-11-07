#include <algorithm>
#include <bits/stdc++.h>
#include <utility>
#include <vector>
using namespace std;

int main() {
    ios::sync_with_stdio(false);
    cin.tie(0);
    int n;
    cin >> n;
    vector<pair<int, int>> v(n);
    vector<int> pics;
    for (int i = 0; i < n; i++) cin >> v[i].second >> v[i].first;
    sort(v.begin(), v.end());
    pics.push_back(v[0].first - 1);
    for (pair<int, int> x : v)
        if (x.second > pics[pics.size() - 1])
            pics.push_back(x.first - 1);
    cout << pics.size() << '\n';
    for (int x : pics) cout << x << ' ';
}
