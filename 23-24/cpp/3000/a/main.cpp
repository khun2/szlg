#include <bits/stdc++.h>
using namespace std;

int feladat1(const vector<int> vec) {
    return vec.size();
}
string feladat2(const vector<int> vec) {
    for(int i:vec){
        if(i<0){
            return "YES";
        }
    }
    return "NO";
}
int feladat3(const vector<int> vec){
    int out=0;
    for(int i:vec){
        if(i%2==0){
            out++;
        }
    }
    return 0;
}
int feladat4(const vector<int> vec) {
    int num=vec[0];
    for(int i:vec){
        if(i>num){
            num=i;
        }
    }
    return num;
}
int feladat5(const vector<int> vec) {
    return vec.size();
}
int main() {
    vector<int> input;

    ifstream f("input.txt");
    string s;
    while (f >> s) {
        input.push_back(stoi(s));
    }

    cout << "feladat 1: " << feladat1(input) << '\n';
}