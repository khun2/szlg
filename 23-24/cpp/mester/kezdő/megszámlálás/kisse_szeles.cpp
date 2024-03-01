#include <iostream>
using namespace std;

int main() {
    int num,k,viharos=0,speed;
    cin >> num >>speed>> k;
    int current=0;
    for (int i = 0; i < num; i++){
        cin>>current;
        if(current<speed&&current){viharos++;}
    }
    cout<<viharos;
    return 0;
}
