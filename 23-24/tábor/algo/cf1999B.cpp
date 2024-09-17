#include <bits/stdc++.h>
using namespace std;

void solve() {
    int a, b ,c ,d;
    cin >> a >> b >> c >> d;
    int num = 0;
    if(a > c && b > d) num+=2;
    if(a > d && b > c) num+=2;
    cout << num << '\n';
}

int main() {
    int t;
    cin >> t;
    for(int i = 0; i < t; i++) {
        solve();
    }
}