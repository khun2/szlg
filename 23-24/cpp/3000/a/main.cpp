#include <bits/stdc++.h>
using namespace std;

int feladat1(const vector<int> vec) {
    return vec.size();
}
string feladat2(const vector<int> vec) {
    int i=0;
    while(vec[i] <= 0 && i <= vec.size()){
        i++;
    }
    return i == vec.size() ? "NO": "YES";
}
int feladat3(const vector<int> vec){
    int out=0;
    for(int i:vec){
        if(i%2==0){
            out++;
        }
    }
    return out;
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
    cout<<"\n";
    return;
}
string feladat6(const vector<int> vec) {
    int i = 0;
    while(vec[i] != 0 && i<=vec.size()){
        i++;
    }
    return i == vec.size() ? "nincsen ilyen": to_string(i);
}
string feladat7(const vector<int> vec) {
    int i = 0;
    while (vec[i]%2!=0 && i<=vec.size())
    {
        i++;
    }
    return i == vec.size() ? "NO": "YES";
}
double feladat8(const vector<int> vec) {
    double num=0;
    for(int i:vec){
        num+=i;
    }
    return vec.size()/num;
}
string feladat9(const vector<int> vec) {
    int i= vec.size()-1;
    while (vec[i] < 0 && vec[i+1] == 0 && i >= -1)
    {
        i--;
    }
    return i == -1 ? "NO": "YES";
}
int feladat10(const vector<int> vec) {
    int num=-1;
    for (size_t i = 0; i < vec.size(); i++)
    {
        if(vec[i]%17==0){
            num=i;
        }
    }
    if(num==-1){cout<<"Nincsen 17-tel osztható szám(ezért -1-et ad vissza) ";}
    return num;
}
void feladat11(const vector<int> vec) {
    
    return;
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
    //feladat11(input);
}