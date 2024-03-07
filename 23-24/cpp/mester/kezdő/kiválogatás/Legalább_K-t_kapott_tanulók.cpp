#include <bits/stdc++.h>
using namespace std;

int main(){
    int c, num, min;
    vector<int> v;
    cin>>c;
    cin>>min;
    for (int i = 0; i < c; i++)
    {
        cin>>num;
        if(num>=min){
            v.push_back(i+1);
        }
    }
    cout<<v.size();
    for(int i:v){
        cout<<" "<<i;
    }
    cout<<"\n";
}