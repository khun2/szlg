#include <bits/stdc++.h>
using namespace std;

int feladat1(const vector<int>& v) {
    int i = v.size() - 1;
    while (i > -1 && cbrt(v[i]) - floor(cbrt(v[i])) != 0) i--;
    return i;
}
int feladat2(const vector<int>& v) {
    return v.size();
}
int feladat3(const vector<int>& v) {
    int n = 0;
    for (int i = 1; i < v.size(); i++) n += (v[i-1] - v[i]);
    return n;
}
bool feladat4(const vector<int>& v) {
    int i = 1;
    while (i < v.size() && v[i] % i != 0) i++;
    return i != v.size();
}
bool feladat5(const vector<int>& v) {
    if(v.size() < 3) return 0;
    int n = v[1] - v[0];
    int i = 2;
    while (i < v.size() && v[i] - v[i-1] == n) i++;
    return i == v.size();
}
int feladat6(const vector<int>& v) {
    int i = 0;
    while (i < v.size() && sqrt(v[i]) != floor(sqrt(v[i]))) i++;
    return i == v.size() ? -1 : v[i]*v[i];
}

bool isPrime(const int& n) {
    //chatgpt thank you
    if (n <= 1) return false;
    for (int i = 2; i * i <= n; ++i) {
        if (n % i == 0)
            return false;
    }
    return true;
}

bool feladat7(const vector<int>& v) {
   int i = 0;
   while (i < v.size() && !isPrime(v[i])) i++;
   return i != v.size();
}
bool feladat8(const vector<int>& v) {
    int i = 0;
    while (i < v.size() && (v[i] >= -50 && v[i] <= 50)) i++;
    return i == v.size();
}
vector<int> feladat9(const vector<int>& v) {
    vector <int> vec;
    for (int x : v) {
        if (isPrime(x)) vec.push_back(x);
    }
    return vec;
}
int feladat10(const vector<int>& v) {
    double avrg = 0;
    for (int x : v) avrg += x;
    avrg /= v.size();
    int closest = v[0];
    for (int i = 1; i < v.size(); i++) {
        if (abs(v[i] - avrg) < abs(closest - avrg)) closest = v[i];
    }
    return closest;
}
vector<pair<int,float>> feladat11(const vector<int>& v) {
    int m;
    cin >> m;
    vector<pair<int,float>> out;
    map<int, vector <int>> ma;
    for(int x : v) {
        ma[abs(x % m)].push_back(x);
    }
    for (auto[key, value] : ma) {
        sort(ma[key].begin(), ma[key].end());
        if (ma[key].size() % 2 == 0) {
            // n = vector felénél lévő elem meg az utána lévő szám átlaga
            float n = (ma[key][ma[key].size() / 2 - 1] + ma[key][(ma[key].size() / 2)]) / 2;
            out.push_back({key, n});
        }
        else out.push_back({key, ma[key][(ma[key].size() / 2)]});
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
    cout << "feladat 5: " << feladat5(input) << '\n';
    cout << "feladat 6: " << feladat6(input) << '\n';
    cout << "feladat 7: " << feladat7(input) << '\n';
    cout << "feladat 8: " << feladat8(input) << '\n';
    cout << "feladat 9:\n";
    vector<int> f9 = feladat9(input);
    for (int x : f9) cout << x << ' ';
    cout << "\nfeladat 10: " << feladat10(input) << '\n';
    cout << "feladat 11:\n";
    vector <pair<int, float>> f11 = feladat11(input);
    for (pair<int, float> p : f11){
        cout << p.first << ": " << p.second << '\n';
    }  
}