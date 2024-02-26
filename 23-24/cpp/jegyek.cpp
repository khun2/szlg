#include <bits/stdc++.h>
using namespace std;

int main()
{
    int count, _1 = 0, _2 = 0, _3 = 0, _4 = 0, _5 = 0, num;
    cin >> count;
    for (size_t i = 0; i < count; i++)
    {
        cin >> num;
        switch (num)
        {
        case 1:
            _1 += 1;
            break;
        case 2:
            _2 += 1;
            break;
        case 3:
            _3 += 1;
            break;
        case 4:
            _4 += 1;
            break;
        case 5:
            _5 += 1;
            break;
        }
    }
    cout << _1 << " " << _2 << " " << _3 << " " << _4 << " " << _5;
    return 0;
}
