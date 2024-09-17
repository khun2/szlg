#include <algorithm>
#include <iostream>
#include <set>
#include <vector>

using namespace std;

vector<vector<int>> g, groupS;
set<int> visited;

void dfs(int u) {
    visited.insert(u);
    groupS.back().push_back(u);
    for (int v : g[u]) {
        if (!visited.count(v)) {
            dfs(v);
        }
    }
}

int main() {
    int N, M;
    cin >> N >> M;
    g.resize(N + 1);
    for (int i = 0; i < M; i++) {
        int A, B;
        cin >> A >> B;
        g[A].push_back(B);
        g[B].push_back(A);
    }

    for (int u = 1; u <= N; u++) {
        if (!visited.count(u)) {
            groupS.push_back({});
            dfs(u);
        }
    }

    cout << groupS.size() << "\n";
    for (auto& group : groupS) {
        sort(group.begin(), group.end());
        for (int u : group) cout << u << " ";
        cout << "\n";
    }
}