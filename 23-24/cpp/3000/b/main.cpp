#include <iostream> // konzolra írás
#include <fstream> // fájlból olvasáshoz
#include <vector> // lista c++-ban
#include <string>
using namespace std;

bool feladat1(const vector<int>& vec) {
    int i=0;
    while(!(vec[i]<=0)){
        i++;
    }    
    return vec.size()<i;
}

int main() {
    vector<int> vec;

    ifstream f("input.txt");
    string s;
    while (f >> s) {
        vec.push_back(stoi(s));
    }

    cout << "feladat 1: " << feladat1(vec) << '\n';
}