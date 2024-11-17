#include <iostream>
#include <algorithm>
#include <iomanip>
#include <string>
#define all(x) x.begin(), x.end()
using namespace std;

int main()
{
    string s1, s2, s3, last;
    cin >> s1;
    int k = 1;
    for (int i = 1; s1 != last; i++) {
        last = s1;
        sort(all(s1));
        s2 = s1;
        reverse(all(s1));
        int n = max(s1.size(), s2.size()), m = min(s1.size(), s2.size());
        int n1 = stoi(s1), n2 = stoi(s2);
        s3 = to_string(n1 - n2);
        if (s3 == last) break;
        cout << "X" << i << "=";
        for (int j = 0; j < n - m; j++) cout << '0';
        cout << s1 << '-';
        for (int j = 0; j < n - m; j++) cout << '0';
        cout << s2 << '=';
        for (int j = 0; j < n - m; j++) cout << '0';
        cout << s3 << "，\n";
        s1 = s3;
    }
    cout << "黑洞數=" << s3 << '\n';
    system("pause");
}

