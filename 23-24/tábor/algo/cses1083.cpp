#include <bits/stdc++.h>
using namespace std;

int main() {
    int n, num;
    cin >> n;
    vector<bool> v(n+1);
    for (int i = 1; i < n; i++) {
        cin >> num;
        v[num] = 1;
    }
    for (int i = 1; i <= n; i++) {
        if(!v[i]) {
            cout << i;
            return 0;
        }
    }
}