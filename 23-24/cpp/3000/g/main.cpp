#include <bits/stdc++.h>
using namespace std;

int feladat1(const vector<int>& v) {
    return v.size();
}
int feladat2(const vector<int>& v) {
    int i = v.size() - 1;
    while (i > -1 && (v[i] < -10 || v[i] > 10)) i--;
    return i;
}
bool feladat3(const vector<int>& v) {
    int i = 0;
    while (i < v.size() && v[i] < 100) i++;
    return i == v.size();
}
int feladat4(const vector<int>& v) {
    int i = 0;
    while (i < v.size() && v[i] % 15 != 0) i++;
    return i == v.size() ? -1 : v[i];
}
double feladat5(const vector<int>& v) {
    double num = 0;
    for (int x : v) num += x;
    return num/2;
}
int feladat6(const vector<int>& v) {
    int i = 0;
    while (i < v.size() && cbrt(v[i]) - floor(cbrt(v[i])) != 0) {
        i++;
    }
    return i != v.size();
}
vector<int> feladat7(const vector<int>& v) {
    vector<int> f7;
    for(int x : v) {
        if (sqrt(x) == floor(sqrt(x))) {
            f7.push_back(sqrt(x));
        }
    }
    return f7;
}
bool feladat8(const vector<int>& v) {
    int i = 2;
    while(i < v.size() && (v[i-2] >= 0 || v[i-1] != 0 || v[i] != 0)) i++;
    return i != v.size();
}
bool feladat9(const vector<int>& v) {
    int i = 1;
    while (i < v.size() && v[i-1] < v[i]) i++;
    return i == v.size();
}
int feladat10(const vector<int>& v) {
    if(v.size() == 1){ return v[0];}
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
map <int, vector<int>> feladat11(const vector<int>& v) {
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

    cout << "feladat 1: " << feladat1(input) << '\n';
    cout << "feladat 2: " << feladat2(input) << '\n';
    cout << "feladat 3: " << feladat3(input) << '\n';
    cout << "feladat 4: " << feladat4(input) << '\n';
    cout << "feladat 5: " << feladat5(input) << '\n';
    cout << "feladat 6: " << feladat6(input) << '\n';
    cout << "feladat 7:\n";
    vector<int> f7  = feladat7(input);
    for (int x : f7) {
        cout << x << " ";
    }
    cout << "\nfeladat 8: " << feladat8(input) << '\n';
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
        double avrg = num / f11[key].size();
        cout << "átlag: " << avrg << '\n';
        for (int x : f11[key]) {
            cout << abs(avrg - x) << ' ';
        }
        cout<<'\n';
    }   
}