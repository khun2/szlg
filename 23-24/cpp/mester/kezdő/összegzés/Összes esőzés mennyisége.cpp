#include <bits/stdc++.h>
using namespace std;

int main(){
    int n, v,out=0;
    cin>>n;
    for (size_t i = 0; i < n; i++)
    {
        cin>>v;
        out+=v;
    }
    cout<<out;
}