#include <bits/stdc++.h>
using namespace std;

int main() {
    int n;
    cin >> n;
    vector<int> stones(n), dp(n);
    for(int i = 0; i < n; i++) {
        cin >> stones[i];
    }
    dp[0] = 0;
    dp[1] = abs(stones[0]-stones[1]);
    for (int i = 2; i < n; i++) {
        dp[i] = min((dp[i-1] + abs(stones[i-1] - stones[i])), (dp[i-2] + abs(stones[i-2] - stones[i])));
        cerr << dp[i] << '\n';
    }
    cout << dp[n-1];
}