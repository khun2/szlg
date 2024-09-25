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
    vector<int> v = create_list(15,2,17);
    fischer_mix(v);
    writer(v);
    fischer_mix(v);
    writer(v);
}
