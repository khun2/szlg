#include <algorithm>
#include <iostream>
#include <set>
#include <vector>

using namespace std;

vector<vector<int>> g;
vector<int> longest_path;
set<int> visited;

void dfs(int num) {
    if(visited.count(num)) return;
    longest_path.push_back(num);
    if(g[num].size() > 0) {
        for(int x : g[num]) {
            dfs(x);
            if(longest_path[x] + 1 > longest_path[num]) {
                longest_path[num]
            }
        }
    }
    visited.insert(num);
}

int main() {
    int n, m, a , b;
    cin >> n >> m;
    g.resize(n+1);
    longest_path.resize(n+1);
    longest_path.

    for(int i = 0; i < m; i++) {
        cin >> a >> b;
        g[b].push_back(a);
    }

    dfs(n);

    for(int x : longest_path) {
        cout << x << ' ';
    }
}
