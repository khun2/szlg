#include <bits/stdc++.h>
#include <iostream>
#include <vector>
using namespace std;

int main(){
	int n,k,last;
	cin >> n >> k;
	vector<int> v(n), r(1,1);
	for (int i = 0; i < n; i++) {
		cin >> v[i];
	}
	for (int i = 1; i < n - 1; i++) {
		if(v[i] - v[r[r.size()-1]-1]>= k){
			r.push_back(i+1);
		}
	}
	r[r.size() - 1] = n;
	cout << r.size() << '\n';
	for (int x : r){
		cout << ' ' << x;	
	}
}
