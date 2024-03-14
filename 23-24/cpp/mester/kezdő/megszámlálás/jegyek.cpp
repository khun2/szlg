#include <bits/stdc++.h>
using namespace std;

int main()
{
    array<int,5> arr;
    int n;
    cin>>n;
    for (int i = 0; i < n; i++)
    {
        int num;
        cin >> num;
        arr[num-1]++;
    }
    for(int x : arr) {
        cout << x << ' '; 
    }
}