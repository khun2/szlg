#include <bits/stdc++.h>
using namespace std;

void solve() { 
    int l = 1, r = 1000, third, area, dist;
    while(l +1 < r) {
        dist = r-l;
        third = (l+r) / 3;
        cout << "?  " << third << ' ' << r-third << endl;
        cin >> area;
        if(area == third*r-third) r = third;
        else if(area == third*(r-third+1)) {
            l = third;
            r -= third; 
        }
        else l = r-third;
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