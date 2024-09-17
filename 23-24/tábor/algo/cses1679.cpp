#include <algorithm>
#include <iostream>
#include <set>
#include <vector>

using namespace std;

vector<vector<int>> g;
vector<int> order;
set<int> visited, looked_at;
bool impossible;

void dfs(int num) {
    if(visited.count(num)) return;
    if(looked_at.count(num)) {
        impossible =true;
        return;
    }
    looked_at.insert(num);
    if(g[num].size() > 0) {
        for(int x : g[num]) dfs(x);
    }
    order.push_back(num);
    visited.insert(num);
}

int main() {
    int n, m, a , b;
    cin >> n >> m;
    g.resize(n+1);

    for(int i = 0; i < m; i++) {
        cin >> a >> b;
        g[b].push_back(a);
    }

    for(int i = 1; i <= n; i++) {
        dfs(i);
        if(impossible) {
            cout << "IMPOSSIBLE";
            return 0;
        }
        looked_at.clear();
    }

    for(int x : order) {
        cout << x << ' ';
    }
}
