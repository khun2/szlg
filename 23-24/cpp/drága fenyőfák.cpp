#include <bits/stdc++.h>
using namespace std;
//helyesen működik de mester nem fogadja el valami elrich okból

int main()
{
    int n, k, num;
    cin >> n >> k;
    vector<int> vec;
    for (size_t i = 0; i < n; i++)
    {
        cin >> num;
        if (num > k)
        {
            vec.push_back(i + 1);
        }
    }
    cout << vec.size();
    for (size_t i = 0; i < vec.size(); i++)
    {
        cout << " " << vec[i];
    }

    return 0;
}
