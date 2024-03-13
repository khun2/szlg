#include <bits/stdc++.h>
using namespace std;

vector <double> feladat1(const vector<int>& v) {
    vector <double> out;
    for(int x : v) {
        if(x % 17 == 0) {
            out.push_back(x/3);
        }
    }
    return out;
}
double feladat2(const vector<int>& v) {
    int i = v.size() - 1;
    while (v[i] % 9 != 0 && v[i] % 25 != 0 && i != -1) {
        i++;
    }
    return i == -1 ? i : sqrt(v[i]);
}
int feladat3(const vector<int>& v) {
    int i = 0;
    while (v[i] % 3 != 0 && v[i] % 5 != 0 && i <= v.size()) {
        i++;
    }
    return i == v.size() ? -1 : i;
}
bool feladat4(const vector<int>& v) {
    int i = 0;
    while ((v[i] < 0 || v[i] > 20) && i <= v.size()) {
        i++;
    }
    return i == v.size();
}
bool feladat5(const vector<int>& v) {
    int i = 1;
    while((v[i] <= 0 && v[i-1] != 0 && v[i+1] != 0) && i <= v.size()) {i++; }
    return i != v.size();
}
int feladat6(const vector<int>& v) {
    int num = 0;
    for (int x : v) {
        if (x % 6 == 0) {num++; }
    }
    return num;
}
int feladat7(const vector<int>& v) {
    return v.size();
}
int feladat8(const vector<int>& v) {
    if(v.size() ==1){ return v[0];}
    int big = INT_MIN, bigger = INT_MIN + 1;
    for(int x : v) {
        if(x > big) {
            if(x > bigger) {
                bigger = x;
            }
            else {
                big = x;
            }
        }
    }
    return big;
}
bool feladat9(const vector<int>& v) {
    int i = 0;
    //ez nehéz
    return false;
}
int feladat10(const vector<int>& v) {
    long long num=v[0];
    const long long mod = 1e9+7;
    for(int x : v){
        num *= x;
        num %= mod;
    }
    return num/2;
}
map <int, vector <int>> feladat11(const vector <int>& v){
    int m;
    cin >> m;
    map<int, vector <int>> ma;
    for(int x : v) {
        ma[abs(x % m)].push_back(x);
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
    
    vector <double> f1 = feladat1(input);
    for (int x : f1) {
        cout << x;
    }
    cout << "feladat 2: " << feladat2(input) << '\n';
    cout << "feladat 3: " << feladat3(input) << '\n';
    cout << "feladat 4: " << feladat4(input) << '\n';
    cout << "feladat 5: " << feladat5(input) << '\n';
    cout << "feladat 6: " << feladat6(input) << '\n';
    cout << "feladat 7: " << feladat7(input) << '\n';
    cout << "feladat 8: " << feladat8(input) << '\n';
    cout << "feladat 9: " << feladat9(input) << '\n';
    cout << "feladat 10: " << feladat10(input) << '\n';
    cout<<"feladat 11:\n";
    map <int, vector <int>> f11 = feladat11(input);
    for (auto[key, value] : f11)
    {
        cout << key << ": ";
        double num = 0;
        for(int x : f11[key]){
            num += x;
        }
        cout << num / f11[key].size();
        cout<<'\n';
    }
}