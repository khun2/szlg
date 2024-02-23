#include <iostream>
using namespace std;

int main() {
    int num,k,viharos=0;
    cin >> num >> k;
    int current=0;
    for (int i = 0; i < num; i++){
        cin>>current;
        if(current>100){viharos++;}
    }
    cout<<viharos;
    return 0;
}
