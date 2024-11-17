#include <iostream>
#include <algorithm>
#include <iostream>
#include <math.h>
using namespace std;
#define sz(x) ((int) x.size())

const int maxn = 5e3 + 5;
int dp[maxn][maxn];

string s1, s2;

int main() {
    cin >> s1 >> s2;

    int n = sz(s1), m = sz(s2);
    if (!n || !m) 
    {
        cout << max(n, m);
        return 0;
    }

    for (int i = 0; i <= n; i++) 
    {
        for (int j = 0; j <= m; j++) 
        {
            if (i == 0)
                dp[i][j] = j;

            else if (j == 0)
                dp[i][j] = i;

            else if (s1[i - 1] == s2[j - 1]) dp[i][j] = dp[i - 1][j - 1];
            else {
                dp[i][j] = min(min(dp[i - 1][j] + 1, dp[i][j - 1] + 1), dp[i - 1][j - 1] + 2);
            }
            // cout << dp[i][j] << ' ';
        }
        // cout << '\n';
    }
    cout << dp[n][m] << '\n';
    // system("pause");
    return 0;
}

