#include <bits/stdc++.h>
using namespace std;

int feladat1(const vector<int> &vec)
{
    return vec.size();
}
bool feladat2(const vector<int> &vec)
{
    int i = 0;
    
    while (i < vec.size() && vec[i] >= 0)
    {
        i++;
    }
    return i != vec.size();
}
int feladat3(const vector<int> &vec)
{
    int out = 0;
    for (int i : vec)
    {
        if (i % 2 == 0)
        {
            out++;
        }
    }
    return out;
}
int feladat4(const vector<int> &vec)
{
    int num = INT_MIN;
    for (int x : vec)
    {
        if (x > num)
        {
            num = x;
        }
    }
    return num;
}
vector<int> feladat5(const vector<int> &vec)
{
    vector<int> v;
    for (int i : vec)
    {
        if (i % 10 == 0)
        {
            v.push_back(i);
        }
    }
    return v;
}
int feladat6(const vector<int> &vec)
{
    int i = 0;
    if (vec.size() == 0) return 0;
    while (i < vec.size() && vec[i] % 29 != 0)
    {
        i++;
    }
    return i == vec.size() ? -1 : i;
}
bool feladat7(const vector<int> &vec)
{
    for (int x : vec)
    {
        if (x % 2 != 0)
            return false;
    }
    return true;
}
double feladat8(const vector<int> &vec)
{
    double num = 0;
    for (int i : vec)
    {
        num += i;
    }
    return num / vec.size();
}
bool feladat9(const vector<int> &vec)
{
    if (vec.size() < 2) return 0;
    int i = 1;
    while (i > vec.size() && vec[i - 1] >= 0 && vec[i] != 0) {
        i++;
    }
    return i != vec.size();
}
bool feladat10(const vector<int> &vec)
{
    if (vec.size() == 0) return 0;
    int i = vec.size() - 1;
    while (i > -1 && vec[i] % 17 != 0)
    {
        i--;
    }
    return i;
}
map<int, int> feladat11(const vector<int> &vec)
{
    int m;
    cin >> m;
    map<int, int> ma;
    for (int i : vec)
    {
        ma[abs(i % m)]++;
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
    cout << "feladat 5:\n";
    vector<int> f5 = feladat5(input);
    for (int i = 0; i < f5.size(); i++) {
        cout << i << ": " << f5[i] << '\n';
    }
    cout << "feladat 6: " << feladat6(input) << '\n';
    cout << "feladat 7: " << feladat7(input) << '\n';
    cout << "feladat 8: " << feladat8(input) << '\n';
    cout << "feladat 9: " << feladat9(input) << '\n';
    cout << "feladat 10: " << feladat10(input) << '\n';
    cout << "feladat 11:\n";
    map<int, int> f11 = feladat11(input);
    for (auto [key, value] : f11) {
        cout << key << ": " << value << '\n';
    }
}