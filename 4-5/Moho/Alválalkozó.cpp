#include <bits/stdc++.h>
using namespace std;

int main() {
	int n, day=0, num;
	cin >> n;
	vector<int> r;
	for (int i = 1 ; i <= n ; i++) {
		cin >> num;
		if(num > day) {
			day++;
			r.push_back(i);
		}
	}
	cout << r.size() << '\n';
	for (int x : r) {
		cout << x << ' ';
	}
}
