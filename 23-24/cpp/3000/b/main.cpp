#include <bits/stdc++.h>
using namespace std;

bool feladat1(const vector<int>& vec) {
    if (vec.size() == 0) return 0;
    int i=0;
    while(vec[i]<=0 && i<=vec.size()){
        i++;
    }     
    return i != vec.size();
}
int feladat2(const vector<int>& vec){
    return vec.size();
}
int feladat3(const vector<int>& vec){
    int smallest=INT_MAX;
    for(int x : vec){
        if(x < smallest) {
            smallest = x;
        }
    }
    return smallest;
}
int feladat4(const vector<int>& vec){
    int i=0;
    while(i < vec.size() && vec[i]%33!=0){
        i++;
    }
    return i == vec.size() ? -1 : i;
}
double feladat5(const vector<int>& vec){
    double num=0;
    for(int i: vec) {
        num+=i;
    }
    return (num/vec.size())/2;
}
bool feladat6(const vector<int>& vec){
    int i=0;
    while(i < vec.size() && vec[i]>=0){
        i++;
    }
    return i != vec.size();
}
int feladat7(const vector<int>& vec){
    int num=0;
    for(int i: vec){
        if(i%2==1){
            num++;
        }
    }
    return num;
}
bool feladat8(const vector<int>& vec){
    if (vec.size() < 2) return 0;
    int i=1;
    while(i < vec.size() && vec[i-1] >= 0 && vec[i] >= 0) {
        i++;
    }
    return i != vec.size();
}
int feladat9(const vector<int>& vec){
    int i = vec.size() - 1;
    if (vec.size() == 0) return 0;
    while (i >= 0 && vec[i] % 19 != 0)
    {
        i--;
    }
    return i;
}
vector <int> feladat10(const vector<int>& vec){
    vector <int> out;
    for(int i: vec){
        if(i%5==0){
            out.push_back(i);
        }
    }
    return out;
}
map <int, int> feladat11(const vector<int>& vec) {
    int m;
    cin >> m;
    map<int, int> ma;
    for(int i : vec) {
        ma[abs(i % m)] += i;
    }
    return ma;
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
    cout<<"feladat 10:\n";
    vector <int> f10 = feladat10(vec);
    for (int i = 0; i < f10.size(); i++)
    {
        cout << f10[i] << ' ';
    }
    cout<<"feladat 11:\n";
    map <int, int> f11 = feladat11(vec);
    for (auto[key, value] : f11)
    {
        cout << key << ": " << value << '\n';
    }
}