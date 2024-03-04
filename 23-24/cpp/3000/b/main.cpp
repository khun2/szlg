#include <iostream> // konzolra írás
#include <fstream> // fájlból olvasáshoz
#include <vector> // lista c++-ban
#include <string>
using namespace std;

string feladat1(const vector<int>& vec) {
    for(int i:vec){
        if(i>0){
            return "YES";
        }
    }
    return "NO";
}
int feladat2(const vector<int>vec){
    return vec.size();
}
int feladat3(const vector<int>vec){
    int smallest=vec[0];
    for(int i:vec){
        if(i<smallest){
            smallest=i;
        }
    }
    return smallest;
}
int feladat4(const vector<int>vec){
    int i=0;
    while(vec[i]%33!=0&&i<vec.size()){
        i++;
    }
    if(vec[i]%33!=0){return -1;}
    return i;
}
int feladat5(const vector<int>vec){

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