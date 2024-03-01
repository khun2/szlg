//not good
#include <bits/stdc++.h>
using namespace std;

int main()
{
    int count, nap;;
    bool isSmog;
    vector<int> vec;
    cin>>count;
    for (size_t i = 0; i < count; i++)
    {
        cin>>nap;
        if(!isSmog&&nap>100){
            //cout<<"\t"<<nap<<"\n";
            vec.push_back(i+1);
            isSmog=true;
        }
        else{
            isSmog=false;
        }
    }
    
    cout<<vec.size();
    for(int i:vec){
        cout<<" "<<i;
    }
    cout<<"\n";
    return 0;
}
