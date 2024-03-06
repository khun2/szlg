#include <iostream> // konzolra írás
#include <fstream> // fájlból olvasáshoz
#include <vector> // lista c++-ban
#include <string>
using namespace std;

int feladat1(const vector<int>& v) {
    return v.size();
}
int feladat2(const vector<int>& v) {
    int i=v.size()-1;
    while (v[i]%3==0)
    {
        i--;
    }
    return i;
}
int feladat3(const vector<int>& v) {

}
int feladat4(const vector<int>& v) {

}
int feladat5(const vector<int>& v) {

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
    cout << "feladat 2: " << feladat2(input) << '\n';
    cout << "feladat 3: " << feladat3(input) << '\n';
    cout << "feladat 4: " << feladat4(input) << '\n';
    cout << "feladat 5: " << feladat5(input) << '\n';
    cout << "feladat 6: " << feladat6(input) << '\n';
    cout << "feladat 7: " << feladat7(input) << '\n';
    cout << "feladat 8: " << feladat8(input) << '\n';
    cout << "feladat 9: " << feladat9(input) << '\n';
    cout << "feladat 10: " << feladat10(input) << '\n';
    cout << "feladat 11: " << feladat11(input) << '\n';    
}