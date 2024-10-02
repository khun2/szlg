#include <bits/stdc++.h>
#include <iostream>
#include <vector>
using namespace std;

int main(){
	int n,k,last;
	cin >> n >> k;
	vector<int> v(n), r;
	for (int i = 0; i < n; i++) {
		cin >> v[i];
	}
	last = v[0];
	for (int i = 0; i < n - 1; i++) {
		if(last + k >= v[i]){
			r.push_back(i+1);
			last = v[i];
		}
	}
	if (last + k < v[n-1])
		r.pop_back();
	r.push_back(n);
	cout << r.size() << '\n';
	for (int x : r){
		cout << x << ' ';	
	}
}
