#include <bits/stdc++.h>
using namespace std;

int feladat1(const vector<int> vec) {
    return vec.size();
}
string feladat2(const vector<int> vec) {
    for(int i:vec){
        if(i<0){
            return "YES";
        }
    }
    return "NO";
}
int feladat3(const vector<int> vec){
    int out=0;
    for(int i:vec){
        if(i%2==0){
            out++;
        }
    }
    return 0;
}
int feladat4(const vector<int> vec) {
    int num=vec[0];
    for(int i:vec){
        if(i>num){
            num=i;
        }
    }
    return num;
}
void feladat5(const vector<int> vec) {
    cout<<"feladat 5: A számok: ";
    for(int i:vec){
        if(i%10==0){
            cout<<i<<" ";
        }
    }
    return;
}
string feladat6(const vector<int> vec) {
    for (int i = 0; i < vec.size(); i++)
    {
        if(vec[i]%29==0){
            string string=to_string(i);
            return string;
        }
    }
    
    return "nincsen ilyen szám";
}
int feladat7(const vector<int> vec) {
    return vec.size();
}
int feladat8(const vector<int> vec) {
    return vec.size();
}
int feladat9(const vector<int> vec) {
    return vec.size();
}
int feladat10(const vector<int> vec) {
    return vec.size();
}
int feladat11(const vector<int> vec) {
    return vec.size();
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
    feladat5(input);
    cout << "feladat 6: " << feladat6(input) << '\n';
    cout << "feladat 7: " << feladat7(input) << '\n';
    cout << "feladat 8: " << feladat8(input) << '\n';
    cout << "feladat 9: " << feladat9(input) << '\n';
    cout << "feladat 10: " << feladat10(input) << '\n';

}