#include <iostream> // konzolra írás
#include <fstream> // fájlból olvasáshoz
#include <vector> // lista c++-ban
#include <string>
using namespace std;

int feladat1(const vector<int>& v) {
    int num=v[0];
    for(int i=1;i<v.size();i++){
        num*=v[i];
    }
    return num;
}
int feladat2(const vector<int>& v) {
    for (int i = v.size() - 1; i >= 0; i--)
    {
        if(v[i]%5==0||v[i]%7==0){
            return i;
        }
    }
    return -1;
}
int feladat3(const vector<int>& v) {
    for (int i = 0; i < v.size(); i++)
    {
        if(v[i]%21==0){
            return i;
        }
    }
    return -1;
}
string feladat4(const vector<int>& v) {
    for(int i:v){
        if(i>=0){
            return "NO";
        }
    }
    return "YES";
}
string feladat5(const vector<int>& v) {
    for(int i:v){
        if(i>0&&i<10){
            return "YES";
        }
    }
    return "NO";
}
int feladat6(const vector<int>& v) {

}
int feladat7(const vector<int>& v) {

}
int feladat8(const vector<int>& v) {

}
int feladat9(const vector<int>& v) {

}
int feladat10(const vector<int>& v) {

}
int feladat11(const vector<int>& v) {
    
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
    cout << "feladat 11: " << feladat1(input) << '\n';    
}