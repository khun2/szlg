#include<bits/stdc++.h>
using namespace std;

int main(){
    int n, out, num;
    string f, s;
    cin >> n >> f >> out;
    for (int i = 0; i < n-1; i++) {
        cin >> s >> num;
        if(s == f) {
            out += num;
        }
    }
    cout<<out;
}