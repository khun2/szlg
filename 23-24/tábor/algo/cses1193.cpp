#include <bits/stdc++.h>
using namespace std;

vector<string> v;
vector<vector<bool>> visited;

void dfs(int y, int x, int prev) {
    if(visited[y][x]) return;
    visited[y][x] = true;
    
}

int main() {
    int n, m, xA, yA;
    cin >> n >> m;
    v.resize(n);
    visited.resize(n, vector<bool>(m));
    bool found = 0;
    for(int i = 0; i < n; i++) {
        cin >> v[i];
        for(int j = 0; j < m && !found; j++) {
            if(v[i][j] == 'A') {
                yA = i; xA = j; found = 1;
            }
        }
    }
    dfs(yA, xA);
}