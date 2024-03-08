#include <iostream> // konzolra írás
#include <fstream> // fájlból olvasáshoz
#include <vector> // lista c++-ban
#include <string>
using namespace std;

string feladat1(const vector<int>& v) {
    int i=0;
    while (v[i]%100 != 0 && i <= v.size())
    {
        i++;
    }
    return i==v.size() ? "NO" : "YES";
}
int feladat2(const vector<int>& v) {
    int i = v.size()-1;
    while (v[i] % 7 != 0 && i >= 0)
    {
        i--;
    }
    return i==0 ? -1 : i;
}
int feladat3(const vector<int>& v) {
    int i = 0;
    while(v[i] % 19 == 0 && i <= v.size()) {
        i++;
    }
    return i == v.size() ? -1 : i;
}
double feladat4(const vector<int>& v){
    double num=0;
    for(int i:v){
        num+=i;
    }
    return (v.size()/num)*(v.size()/num);
}
string feladat5(const vector<int>& v){
    int i = 0;
    while(v[i]>=10 && i <= v.size()) {i++; }
    return i==v.size() ? "NO" : "YES";
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
    cout<<"feladat 7: \t";
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
    int i = 0;
    while(v[i-1] >= 0 && v[i] <= 0 && i <= v.size()) {i++; }
    return i==v.size() ? "NO" : "YES";
}
double feladat10(const vector<int>& v){
    double smallest=v[0];
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
    cout << "feladat 2: " << feladat2(input) << '\n';
    cout << "feladat 3: " << feladat3(input) << '\n';
    cout << "feladat 4: " << feladat4(input) << '\n';
    cout << "feladat 5: " << feladat5(input) << '\n';
    cout << "feladat 6: " << feladat6(input) << '\n';
    feladat7(input);
    cout << "feladat 8: " << feladat8(input) << '\n';
    cout << "feladat 9: " << feladat9(input) << '\n';
    cout << "feladat 10: " << feladat10(input) << '\n';
//  cout << "feladat 11: " << feladat11(input) << '\n';

}