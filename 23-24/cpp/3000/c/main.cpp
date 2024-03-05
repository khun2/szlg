#include <iostream> // konzolra írás
#include <fstream> // fájlból olvasáshoz
#include <vector> // lista c++-ban
#include <string>
using namespace std;

string feladat1(const vector<int>& v) {
    for(int i: v){
        if(i%100==0){return "YES";}
    }
    return "NO";
}
int feladat2(const vector<int>& v) {
    for (int i = v.size() - 1; i >= 0; i--)
    {
        if(i%7==0){
            return i;
        }    
    }
    return -1;
}
int feladat3(const vector<int>& v){
    for(int i=0;i<v.size(); i++){
        if(v[i]%19==0){
            return i;
        }
    }
    return -1;
}
int feladat4(const vector<int>& v){
    int num=0;
    for(int i:v){
        num+=i;
    }
    return (num/v.size())*(num/v.size());
}
string feladat5(const vector<int>& v){
    for(int i:v){
        if(i%10!=0){
            return "NO";
        }
    }
    return "YES";
}
int feladat6(const vector<int>& v){
    int num=0;
    for(int i:v){
        if(i%9==0){
            num++;
        }
    }
    return num;
}
void feladat7(const vector<int>& v){
    cout<<"feladat 7:\n";
    for(int i=0;i<v.size();i++){
        if(v[i]%15==0){
            cout<<v[i]/2 <<" ";
        }
    }
    cout<<"\n";
}
int feladat8(const vector<int>& v){
    return v.size();
}
string feladat9(const vector<int>& v){
    for(int i=1;i<v.size();i++){
        if(v[i-1]<0&&v[i]>0){
            return "YES";
        }
    }
    return "NO";
}
int feladat10(const vector<int>& v){
    int smallest=v[0];
    for(int i:v){
        if(i<smallest){
            smallest=i;
        }
    }
    return smallest/2;
}
int main() {
    vector<int> input;

    ifstream f("input.txt");
    string s;
    while (f >> s) {
        input.push_back(stoi(s));
    }

    cout << "feladat 1: " << feladat1(input) << '\n';
    cout << "feladat 2: " << feladat1(input) << '\n';
    cout << "feladat 3: " << feladat1(input) << '\n';
    cout << "feladat 4: " << feladat1(input) << '\n';
    cout << "feladat 5: " << feladat1(input) << '\n';
    cout << "feladat 6: " << feladat1(input) << '\n';
    cout << "feladat 7: " << feladat1(input) << '\n';
    cout << "feladat 8: " << feladat1(input) << '\n';
    cout << "feladat 9: " << feladat1(input) << '\n';
    cout << "feladat 10: " << feladat1(input) << '\n';
//  cout << "feladat 11: " << feladat11(input) << '\n';

}