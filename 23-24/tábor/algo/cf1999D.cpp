#include<bits/stdc++.h>
using namespace std;

void solve() {
    string s, t;
    cin >> s >> t;
    int sp = 0, tp = 0;
    while(sp < s.size()) {
        if(s[sp] == t[tp]) {
            sp++;
            if(tp < t.size()) {
                tp++;
            }
            continue;
        }
        if(s[sp] == '?') {
            if(tp < t.size()){
                s[sp] = t[tp];
                tp++;
            }
            else {
                s[sp] = 'a';
            }
            continue;
        }
        sp++;
    }
    if(tp == t.size()) {
        cout << "YES\n" << s << '\n';
    }
    else {
        cout << "NO\n";
    }
}

int main() {
    int t = 0;
    cin >> t;
    for(int i = 0; i < t; i++) {
        solve();
    }
}