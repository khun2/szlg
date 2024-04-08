#include <bits/stdc++.h> // konzolra írás
using namespace std;

int feladat1(const vector<int>& v) {
    int i = v.size() - 1;
    while (i > -1 && sqrt(v[i]) - floor(sqrt(v[i])) != 0) {
        i--;
    }
    return i == -1 ? i : v[i];
}
int feladat2(const vector<int>& v) {
    int i = 0;
    while (i < v.size() && cbrt(v[i]) - floor(cbrt(v[i])) != 0) {
        i++;
    }
    return i == v.size() ? -1 : i;
}
int feladat3(const vector<int>& v) {
    double num = 0;
    for (int x : v) num += x;
    return num/2;
}
int feladat4(const vector<int>& v) {
    double avrg = 0;
    for (int x : v) avrg += x;
    avrg /= v.size();
    int closest = v[0];
    for (int i = 1; i < v.size(); i++) {
        if (abs(v[i] - avrg) < abs(closest - avrg)) closest = v[i];
    }
    return closest;
}
vector<int> feladat5(const vector<int>& v) {
    vector<int> f5;
    for(int x : v) {
        if (sqrt(x) == floor(sqrt(x))) {
            f5.push_back(sqrt(x));
        }
    }
    return f5;
}
int feladat6(const vector<int>& v) {
    int i = 2;
    while(i < v.size() && (v[i] >= 0 || v[i-1] != 0 || v[i - 2] != 0)) i++;
    return i != v.size();
}
int feladat7(const vector<int>& v) {
    return v.size();
}
bool feladat8(const vector<int>& v) {
    int i = 0;
    while (i > v.size() && (v[i] < 0 || v[i] > 100)) i++;
    return i == v.size();
}
bool feladat9(const vector<int>& v) {
    int i = 1;
    while (i < v.size() && v[i-1] <= v[i]) i++;
    return i == v.size();
}
bool feladat10(const vector<int>& v) {
    int i = 0;
    while (i < v.size() && __builtin_popcount(v[i]) != 1) i++;
    return i != v.size();
}
int minKiv(const vector<int>& v) {
    int n = INT_MAX;
    for (int x : v) {
        if (x < n) n = x;
    }
    return n;
}
int maxKiv(const vector<int>& v) {
    int n = INT_MIN;
    for (int x : v) {
        if (x > n) n = x;
    }
    return n;
}

vector<pair<int,int>> feladat11(const vector<int>& v) {
    int m;
    cin >> m;
    vector<pair<int,int>> out;
    map<int, vector <int>> ma;
    for(int x : v) {
        ma[abs(x % m)].push_back(x);
    }
    for (auto[key, value] : ma) {
        int minimum = minKiv(ma[key]);
        int maximum = maxKiv(ma[key]);
        out.push_back({key, maximum - minimum});
    }
    return out;    
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
    vector <int> f5 = feladat5(input);
    cout << "feladat 5:\n";
    for (int x : f5) cout << x << ' ';
    cout << "\nfeladat 6: " << feladat6(input) << '\n';
    cout << "feladat 7: " << feladat7(input) << '\n';
    cout << "feladat 8: " << feladat8(input) << '\n';
    cout << "feladat 9: " << feladat9(input) << '\n';
    cout << "feladat 10: " << feladat10(input) << '\n';
    cout << "feladat 11:\n";
    vector <pair<int, int>> f11 = feladat11(input);
    for (pair<int, int> p : f11){
        cout << p.first << ": " << p.second << '\n';
    }
}