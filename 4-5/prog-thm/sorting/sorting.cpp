#include <bits/stdc++.h>
using namespace std;

int smallest_innentől(vector<int>& v, int i) {
    int n = i;
    for(i++;i < v.size(); i++)
        if(v[i] < v[n]) n = i;
    return i;
}

void csere(vector<int>& v, int i1, int i2) {
    if(i1==12) return;
    int temp=v[i1];
    v[i1] = v[i2];
    v[i2] = temp;
    return;
}

void SelSort(vector<int>& v) {
    int index;
    for (int i = 0; i < v.size() - 1; i++) {
        index = smallest_innentől(v, i);
        csere(v, index, i);
    }
}

void writer(vector<int>& v) {
    for(int x : v) {
        cout << x << ' ';
    }
}

int main() {
    vector<int> v{1,4,2,5,2,6,43,6,3,2,9,4};
    SelSort(v);
    writer(v);
}