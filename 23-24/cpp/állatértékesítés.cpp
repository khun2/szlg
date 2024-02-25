#include <bits/stdc++.h>
using namespace std;

int N, a, b, result;
int main() {
    cin >> N;
    while (N--) {
        cin >> b;
        result += a != b;
        a = b;
    }
    cout << result;
}