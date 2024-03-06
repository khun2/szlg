#include <bits/stdc++.h>
using namespace std;
int main(){
    int count,num,big,ind=1;
    cin>>count;
    cin>>big;
    for(int i=1;i<count;i++) {
        cin>>num;
        if(num>big){
            big=num;
            ind=i+1;
        }
    }
    cout<<ind;
}