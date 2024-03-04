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
    cout<<"\n";
    return;
}
string feladat6(const vector<int> vec) {
    for (int i = 0; i < vec.size(); i++)
    {
        if(vec[i]%29==0){
            string string=to_string(i);
            return "az első ilyen szám: "+string;
        }
    }
    
    return "nincsen ilyen szám";
}
string feladat7(const vector<int> vec) {
    for(int i:vec){
        if(i%2==1){return "NO";}
    }
    return "YES";
}
int feladat8(const vector<int> vec) {
    int num=0;
    for(int i:vec){
        num+=i;
    }
    return vec.size()/num;
}
string feladat9(const vector<int> vec) {
    for (size_t i = 0; i < vec.size()-1; i++)
    {
        if(vec[i]<0&&vec[i+1]==0){return "YES";}
    }
    
    return "NO";
}
int feladat10(const vector<int> vec) {
    int num=-1;
    for (size_t i = 0; i < vec.size(); i++)
    {
        if(vec[i]%17==0){
            num=i;
        }
    }
    if(num==-1){cout<<"Nincsen 17-tel osztható szám(ezért -1-et ad vissza)";}
    return num;
}
void feladat11(const vector<int> vec) {
    cout << "feladat 11:\n";
    int m;
    cin >> m;
    vector<vector<int>> result(m);
    for (size_t i = 0; i < m; i++)
    {
        for (size_t j :vec)
        {
            if(j%m==i){
                
                result[i].push_back(j);
                //cout<<j<<" ";
            }
        }
        cout<<"összesen "<<result[i].size()<<" "<<i<<" maradéku van\n";
    }
    cout<<"a számok:\n";
    /*for (size_t i = 0; i < m; i++)
    {
        for (size_t j = 0; j < result[i].size(); j++)
        {
            cout<<result[i][j]<<" ";
        }
        
    }*/
    
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
    //cout << "feladat 8: " << feladat8(input) << '\n';
    cout << "feladat 9: " << feladat9(input) << '\n';
    cout << "feladat 10: " << feladat10(input) << '\n';
    feladat11(input);
}