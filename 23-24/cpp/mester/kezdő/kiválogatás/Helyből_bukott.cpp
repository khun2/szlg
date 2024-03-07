#include <bits/stdc++.h>
using namespace std;

int main(){
    int c,num,out=0;
    cin>>c;
    for (int i = 0; i < c; i++)
    {
        cin>>num;
        if(num<10){
            out++;
        }
    }
    cout<<out;
}