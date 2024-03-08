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
    int num=0;
    for(int i:v){
        if(i%18==0){
            num++;
        }
    }
    return num;
}
int feladat7(const vector<int>& v) {
    int smal=v[0], out=0;
    for(int i=1;i<v.size();i++){
        if(v[i]<smal){
            smal=v[i];
            out=v[i];
        }
    }
    return out;
}
void feladat8(const vector<int>& v) {
    cout<<"feladat 8:\n}";
    for(int i:v){
        if(i % 17==0 || i % 18 == 0){
            cout<<i*i<<" ";
        }
    }
}
int feladat9(const vector<int>& v) {
    return v.size();
}
string feladat10(const vector<int>& v) {
    for (int i = 1; i < v.size()-1; i++)
    {
        if(v[i] >0 && v[i-1] < 0 && v[i+1] < 0){
            return "YES";
        }
    }
    return "NO";
}
int feladat11(const vector<int>& v) {
    return -1;
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
    cout << "feladat 7: " << feladat7(input) << '\n';
    feladat8(input);
    cout << "feladat 9: " << feladat9(input) << '\n';
    cout << "feladat 10: " << feladat10(input) << '\n';
    cout << "feladat 11: " << feladat11(input) << '\n';    
}