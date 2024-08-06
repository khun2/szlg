#include <bits/stdc++.h>
using namespace std;

int main() {
    int n;
    cin >> n;
    vector<int> v(n);
    for(int i = 0; i < n; i++) {
        cin >> v[i];
    }
    sort(v.begin(), v.end());
    int m = 1;
    for(int i = 1; i < n; i++) {
        if(v[i] != v[i-1]) m++;
    }
    cout << m;
}