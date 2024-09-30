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
	r.push_back(last);
	for (int i = 0; i < n - 1; i++) {
		if(last + k >= v[i])
			r.push_back(v[i]);
	}
	if (last + k <)
	cout << r.size() << '\n';
	for (int x : r){
		cout << x << ' ';	
	}
}
