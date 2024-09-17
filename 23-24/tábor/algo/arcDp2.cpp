#include <bits/stdc++.h>
using namespace std;

int main() {
    int n, k, minimum;
    cin >> n >> k;
    vector<int> stones(n), dp(n);
    for(int i = 0; i < n; i++) {
        cin >> stones[i];
    }
    dp[0] = 0;
    for (int i = 1; i < n; i++) {
        minimum = INT_MAX;
        for (int j = 1; j <= k && i-j >= 0; j++) {
            minimum = min(dp[i-j] + abs(stones[i-j]-stones[i]), minimum);
        }
        dp[i] = minimum;
    }
    cout << dp[n-1];
}