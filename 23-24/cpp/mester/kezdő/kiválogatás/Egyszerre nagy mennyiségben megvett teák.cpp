#include <bits/stdc++.h>
using namespace std;

int main()
{
    int count,num;
    string comp;
    vector<string>vec;
    cin>>count;
    for (size_t i = 0; i < count; i++)
    {
        cin>>comp;
        cin>>num;
        if(num>500){
            vec.push_back(comp);
        }
    }
    cout<<vec.size();
    for(string i:vec){
        cout<<" "<<i;
    }
    cout<<"\n";    
    return 0;
}
