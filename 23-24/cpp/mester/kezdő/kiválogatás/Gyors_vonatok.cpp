#include <bits/stdc++.h>
using namespace std;

int main(){
    int c, s, num;
    vector<int> v;
    cin>>c;
    cin>>s;
    for (int i = 0; i < c; i++)
    {
        cin>>num;
        if(num<s){
            v.push_back(i+1);
        }
    }
    cout<<v.size();
    for (int i : v)
    {
        cout<<" "<< i;
    }
    cout<<"\n";
}