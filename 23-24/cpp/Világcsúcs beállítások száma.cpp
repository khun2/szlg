#include <bits/stdc++.h>
using namespace std; 
 
int main(){
    int count,prev,current,yr,same=0;
    cin>>count;
    cin>>yr>>prev;
    for (int i = 0; i < count-1; i++)
    {
        cin>>yr>>current;
        if(current==prev){same++;}
        prev=current;
    }
    cout<<same<<"\n";
    return 0;
}