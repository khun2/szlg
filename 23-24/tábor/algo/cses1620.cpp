#include <bits/stdc++.h>
using namespace std;

bool hits_target(const long long& target, const long long& time, const vector<int>& v) {
    long long printed = 0;
    for(int x : v) {
        printed += time/x;
        if(printed >= target) return true;
    }
    return false;
}

int main() {
    long long n, target, l = 0, r = 1e18, mid;
    cin >> n >> target;
    vector<int> v(n);
    for(int i = 0; i < n; i++) {
        cin >> v[i];
    }
    while (l + 1 < r) {
        mid = (l + r) / 2;
        if(hits_target(target, mid, v)) r = mid;
        else l = mid;
    }
    cout << r;
}