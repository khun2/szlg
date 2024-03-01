#include <bits/stdc++.h>
using namespace std;

int main()
{
    int count, out = -6, vak = 0, day;
    cin >> count;
    for (size_t i = 0; i < count; i++)
    {
        cin >> day;
        if (day)
        {
            out += 1;
            vak += 1;
            if (vak == 7)
            {
                cout << out;
                return 0;
            }
        }
        else
        {
            vak = 0;
            out += 1;
        }
    }

    return 0;
}
