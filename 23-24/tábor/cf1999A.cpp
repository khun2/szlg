#include <bits/stdc++.h>
using namespace std;

void solve() {
    char a, b;
    cin >> a >> b;
    cout << a - '0' + b - '0' << '\n';
}

int main() {
    int t;
    cin >> t;
    for(int i = 0; i < t; i++){
        solve();
    }
}