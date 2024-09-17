#include <bits/stdc++.h>
using namespace std;

bool is_correct(int n) {
    int area;
    cout << "?  1 " << n << endl;
    cin >> area;
    return n == area;
}

void solve() { 
    int l = 1, r = 1000, mid;
    while(l +1 < r) {
        mid = (l+r) / 2;
        if(is_correct(mid)) l = mid;
        else r = mid;
    }
    cout << "! " << r << endl;
}


int main() {
    int t;
    cin >> t;
    for(int i = 0; i < t; i++) {
        solve();
    }
}