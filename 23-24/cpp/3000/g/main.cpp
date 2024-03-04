#include <iostream> // konzolra írás
#include <fstream> // fájlból olvasáshoz
#include <vector> // lista c++-ban
#include <string>
using namespace std;

int feladat1(const vector<int>& v) {
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
}