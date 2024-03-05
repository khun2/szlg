#include <bits/stdc++.h>
using namespace std;

int main()
{
    int num;
    array<int,6> arr;
    arr.fill(0);
    cin>>arr[0];
    for (int i = 0; i < arr[0]; i++)
    {
        cin >> num;
        switch (num)
        {
        case 1:
            arr[1] += 1;
            break;
        case 2:
            arr[2] += 1;
            break;
        case 3:
            arr[3] += 1;
            break;
        case 4:
            arr[4] += 1;
            break;
        case 5:
            arr[5] += 1;
            break;
        }
    }
    cout << arr[1] << " " << arr[2] << " " << arr[3] << " " << arr[4] << " " << arr[5];
}
