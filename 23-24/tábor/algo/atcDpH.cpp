#include <bits/stdc++.h>
using namespace std;

int main() {
    int H, W, mod = 1e9 + 7;
    char c;
    cin >> H >> W;
    vector<vector<int>> grid(H+1, vector<int>(W+1, 0));
    grid[1][1] = 1;
    for(int i = 1; i <= H; i++) {
        for (int j = 1; j <= W; j++) {
            cin >> c;
            if(c != '.') continue;
            grid[i][j] += grid[i-1][j] + grid[i][j-1];
            grid[i][j] %= mod;
        }
    }
    cout << grid[H][W];
}