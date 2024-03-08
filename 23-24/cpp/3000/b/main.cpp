#include <iostream> // konzolra írás
#include <fstream> // fájlból olvasáshoz
#include <vector> // lista c++-ban
#include <string>
using namespace std;

string feladat1(const vector<int>& vec) {
    int i=0;
    while(vec[i]<=0 && i<=vec.size()){
        i++;
    }     
    return i == vec.size() ? "NO" : "YES";
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
double feladat5(const vector<int>vec){
    double num=0;
    for(int i: vec){
        num+=i;
    }
    return (num/vec.size())/2;
}
string feladat6(const vector <int> vec){
    int i=0;
    while(vec[i]>=0 && i<=vec.size()){
        i++;
    }
    return i == vec.size() ? "NO" : "YES";
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
    int i=0;
    while(vec[i-1] >= 0 && vec[i] >= 0){
        i++;
    }
    return i == vec.size() ? "NO" : "YES";
}
int feladat9(const vector<int>vec){
    int i = vec.size() - 1;
    while (vec[i] % 19!=0)
    {
        i--;
    }
    return i=0 ? -1 : i;
}
void feladat10(const vector<int>vec){
    cout<<"feladat 10:\n";
    for(int i: vec){
        if(i%5==0){
            cout<<i<<" ";
        }
    }
    cout<<"\n";
}

int main() {
    vector<int> vec;

    ifstream f("input.txt");
    string s;
    while (f >> s) {
        vec.push_back(stoi(s));
    }

    cout << "feladat 1: " << feladat1(vec) << '\n';
    cout << "feladat 2: " << feladat2(vec) << '\n';
    cout << "feladat 3: " << feladat3(vec) << '\n';
    cout << "feladat 4: " << feladat4(vec) << '\n';
    cout << "feladat 5: " << feladat5(vec) << '\n';
    cout << "feladat 6: " << feladat6(vec) << '\n';
    cout << "feladat 7: " << feladat7(vec) << '\n';
    cout << "feladat 8: " << feladat8(vec) << '\n';
    cout << "feladat 9: " << feladat9(vec) << '\n';
    feladat10(vec);
}