//doesnt work
#include <bits/stdc++.h>
using namespace std;

int main()
{
    int count, prev, num, out = 1;
    cin >> count;
    cin >> prev;
    for (size_t i = 1; i < count; i++)
    {
        cin >> num;
        if (num <= prev)
        {
            out += 1;
        }
        prev = num;
    }
    if (num <= prev)
    {
        out += 0;
    }
    cout << out;
    return 0;
}