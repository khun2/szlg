#include <bits/stdc++.h>
using namespace std;

void writer(vector<int>& v) {
    for(int x : v) {
        cout << x << ' ';
    }
    cout << '\n';
}

void csere(vector<int>& v, int i1, int i2) {
    if(i1==i2) return;
    int temp=v[i1];
    v[i1] = v[i2];
    v[i2] = temp;
    return;
}

int smallest_innentől(vector<int>& v, int i) {
    int n = i;
    for(i++;i < v.size(); i++)
        if(v[i] < v[n]) n = i;
    return n;
}

void insert(vector<int>& v, int i) {
    while (0 < i && v[i-1] > v[i]) {
        csere(v, i - 1, i);
        i--;
    }
}

void SelSort(vector<int>& v) {
    int index;
    for (int i = 0; i < v.size() - 1; i++) {
        index = smallest_innentől(v, i);
        csere(v, index, i);
    }
}

void insertion_sort(vector<int>& v) {
    for(int i = 1; i < v.size(); i++)
        insert(v, i);
}

bool bubbler(vector<int>& v, int n) {
    int i = 1;
    while(i < n-1) {
        if (v[i-1] > v[i]) csere(v, i-1, i);
        i++;
    }
    if (v[i-1] > v[i]) {
        csere(v, i-1, i);
        return true;
    }
    return false;
}

void bubble_sort(vector<int>& v) {
    for(int i = v.size()-1; i > 0; i--){
        if(!bubbler(v, i+1)) i--;
    }
}

vector<int> create_list(int n, int lower, int upper){
    vector<int> result(n);
    for(int i = 0; i <= n; i++){
	result[i] = lower + i;
    }
    return result;
}

void fischer_mix(vector<int>& v) {
    srand(time(NULL));
    for(int i = 0; i < v.size(); i++){
	csere(v, i, rand() % (v.size() -1));
    }
}

int main() {
    vector<int> v = create_list(15,2,17);//v{1,4,2,5,2,6,43,6,3,2,9,4};
    //bubble_sort(v);
    fischer_mix(v);
    writer(v);
    fischer_mix(v);
    writer(v);
}
