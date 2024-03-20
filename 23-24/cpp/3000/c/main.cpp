#include <iostream> // konzolra írás
#include <fstream> // fájlból olvasáshoz
#include <vector> // lista c++-ban
#include <string>
#include <map>
using namespace std;

bool feladat1(const vector<int>& v) {
    if (v.size() == 0) return 0;
    int i=0;
    while (i <= v.size() && v[i]%100 != 0)
    {
        i++;
    }
    return i != v.size();
}
int feladat2(const vector<int>& v) {
    if (v.size() == 0) return 0;
    int i = v.size()-1;
    while (i >= 0 && v[i] % 7 != 0) {
        i--;
    }
    return i;
}
int feladat3(const vector<int>& v) {
    if (v.size() == 0) return 0;
    int i = 0;
    while(i <= v.size() && v[i] % 19 == 0) {
        i++;
    }
    return i == v.size() ? -1 : i;
}
double feladat4(const vector<int>& v){
    if (v.size() == 0) return 0;
    double num=0;
    for(int i:v){
        num+=i;
    }
    return (num/v.size())*(num/v.size());
}
bool feladat5(const vector<int>& v){
    int i = 0;
    while(v[i]>=10 && i <= v.size()) {i++; }
    return i != v.size();
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
vector <double> feladat7(const vector<int>& v){
    cout<<"feladat 7: ";
    vector <double> out;
    for(double i = 0; i < v.size(); i++){
        if(v[i]%15==0){
            out.push_back(v[i]/2.0);
        }
    }
    return out;
}
int feladat8(const vector<int>& v){
    return v.size();
}
bool feladat9(const vector<int>& v){
    int i = 0;
    while(v[i-1] >= 0 && v[i] <= 0 && i <= v.size()) {i++; }
    return i != v.size();
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

map <int, vector <int>> feladat11(const vector <int>& v){
    int m;
    cin >> m;
    map<int, vector <int>> ma;
    for(int i : v) {
        ma[abs(i % m)].push_back(i);
    }
    return ma;
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
    vector<double> f7 = feladat7(input);
    for(double x : f7){
        cout<<x<<' ';
    }
    cout<<'\n';
    cout << "feladat 8: " << feladat8(input) << '\n';
    cout << "feladat 9: " << feladat9(input) << '\n';
    cout << "feladat 10: " << feladat10(input) << '\n';
    cout<<"feladat 11:\n";
    map <int, vector <int>> f11 = feladat11(input);
    for (auto[key, value] : f11)
    {
        cout << key << ": ";
        for(int x : f11[key]){
            cout<<x<<" ";
        }
        cout<<'\n';
    }

}