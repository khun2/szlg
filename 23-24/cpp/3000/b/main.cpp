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
    int num=0;
    for(int i: vec){
        num+=i;
    }
    return (num/vec.size())/2;
}
string feladat6(const vector <int> vec){
    for(int i:vec){
        if(i<0){
            return "NO";
        }
    }
    return "YES";
}
int feladat7(const vector <int> vec){
    int num=0;
    for(int i: vec){
        if(i%2==1){
            num+=1;
        }
    }
    return num;
}
string feladat8(const vector <int> vec){
    for (size_t i = 1; i < vec.size(); i++)
    {
        if(vec[i-1]<0&&vec[i]<0){
            return "YES";
        }
    }
    return "NO";
    
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