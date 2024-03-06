#include <bits/stdc++.h>
using namespace std;

int main(){
    int count,k,out=0,feesh;
    cin>>count;
    cin>>k;
    for (size_t i = 0; i < count; i++)
    {
        cin>>feesh;
        if(feesh<k){
            out+=feesh;
        }
    }
    cout<<out;
}