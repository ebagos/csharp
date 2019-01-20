/*


左右どちらから読んでも同じ値になる数を回文数という. 2桁の数の積で表される回文数のうち, 最大のものは 9009 = 91 × 99 である.

では, 3桁の数の積で表される回文数の最大値を求めよ.
*/
using System;

namespace p004
{
    class Program
    {
        static int Rotate(int n) {
            int rc = 0;
            while (n > 0) {
                rc = rc * 10 + (n % 10);
                n /= 10;
            }
            return rc;
        }
        static void Main(string[] args)
        {
            int ans = 0;
            for (int i = 999; i > 99; i--) {
                for (int j = 999; j > i; j--) {
                    int x = i * j;
                    if (x == Rotate(x)) {
                        if (ans < x) {
                            ans = x;
                            Console.WriteLine(ans);
                        }
                    }
                }
            }
            Console.WriteLine("The answer is {0}.", arg0: ans);
        }
    }
}
