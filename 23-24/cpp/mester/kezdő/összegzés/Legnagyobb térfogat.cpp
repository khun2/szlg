#include <bits/stdc++.h>
using namespace std;

int main(){
    int count,side, vol=0;
    cin>>count;
    for (size_t i = 0; i < count; i++)
    {   
        cin>>side;
        vol+=side*side*side;
    }
    cout<<vol;
    return 0;
}