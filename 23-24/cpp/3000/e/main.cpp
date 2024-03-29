
#include <bits/stdc++.h>
using namespace std;

int feladat1(const vector<int>& v) {
    return v.size();
}
int feladat2(const vector<int>& v) {
    int i=v.size()-1;
    while (i > -1 && v[i]%3 != 0) {
        i--;
    }
    return i;
}
int feladat3(const vector<int>& v) {
    int i = 0;
    while (i < v.size() && v[i] % 15 != 0) {i++;}
    return i == v.size() ? -1 : i;
}
bool feladat4(const vector<int>& v) {
    int i = 0;
    while (i < v.size() && (v[i] > -10 && v[i] < 10)) {i++;}
    return i == v.size();
}
long long feladat5(const vector<int>& v) {
    long long num=v[0];
    const long long mod = 1e9+7;
    for(int x : v){
        num *= x;
        num %= mod;
    }
    return (num*2) % mod;
}
int feladat6(const vector<int>& v) {
    int num = 0;
    for(int x : v) {
        //őszintén én sem tudom mit szívtam amikor elsőnek írtam
        if(x % 18 == 0) {num++;}
    }
    return num;
}
vector <int> feladat7(const vector<int>& v) {
    vector <int> out;
    for(int x : v) {
        if(x % 17 == 0 || x % 18 == 0) {
            out.push_back(x*x*x);
        }
    }
    return out;
}
int feladat8(const vector<int>& v) {
    if(v.size() ==1){ return v[0];}
    int smol = INT_MAX - 1, smoller = INT_MAX;
    for(int x : v) {
        if(x < smol) {
            if(x < smoller) {
                smoller = x;
            }
            else {
                smol = x;
            }
        }
    }
    return smol;
}
bool feladat9(const vector<int>& v) {
    int i = 0;
    while (i < v.size() && sqrt(v[i]) - floor(sqrt(v[i])) != 0) {
        i++;
    }
    return i != v.size();
}
bool feladat10(const vector<int>& v) {
    for (size_t i = 1; i < v.size()-1; i++)
    {
        if(v[i] < 0 && v[i-1] == 0 && v[i+1] == 0) {
            return true;
        }
    }
    return false;
}
vector <pair<int, bool>> feladat11(const vector<int>& v) {
    int m;
    cin >> m;
    vector <pair<int, bool>> out(m, {INT_MAX, false});
    for(int i = 0; i < v.size(); i++) {
        out[abs(v[i] % m)].second = true;
        if(out[abs(v[i] % m)].first > v[i]) {
            out[abs(v[i] % m)].first = v[i];
        }
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
    cout<<"feladat 7:\n";
    vector <int> f7 =feladat7(input);
    for(int x : f7) {
        cout<<x<<" ";
    }
    cout << "\nfeladat 8: " << feladat8(input) << '\n';
    cout << "feladat 9: " << feladat9(input) << '\n';
    cout << "feladat 10: " << feladat10(input) << '\n';
    cout << "feladat 11:\n";
    vector<pair<int, bool>> f11 = feladat11(input);
    for(size_t i = 0; i < f11.size(); i++){
        if(!f11[i].second){
            cout << i << ": nincs ilyen\n";
        }
        else {
            cout<<i<<": "<<f11[i].first<<'\n';
        }
    }
}