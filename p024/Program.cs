/*
順列とはモノの順番付きの並びのことである. たとえば, 3124は数 1, 2, 3, 4 の一つの順列である. すべての順列を数の大小でまたは辞書式に並べたものを辞書順と呼ぶ. 0と1と2の順列を辞書順に並べると
012 021 102 120 201 210
になる.
0,1,2,3,4,5,6,7,8,9からなる順列を辞書式に並べたときの100万番目はいくつか?
*/
using System;

namespace p024
{
    class Program
    {
        static int factorial(int n) {
            if (n == 0) {
                return 1;
            }
            int ans = 1;
            for (int i = 1; i <= n; i++) {
                ans *= i;
            }
            return ans;
        }

        static void Main(string[] args)
        {
            const int TARGET = 1_000_000;
            int target = TARGET - 1;
            string ans = "";
            string org = "0 1 2 3 4 5 6 7 8 9";
            string[] sl = org.Split(' ');
            for (int i = 9; i >= 0; i--) {
                int x = factorial(i);
                string n = sl[target/x];
                for (int j = target / x; j < sl.Length - 1; j++) {
                    sl[j] = sl[j+1];
                }
                target %= x;
                ans += n.ToString();
            }
            Console.WriteLine($"The answer is {ans}.");
        }
    }
}
