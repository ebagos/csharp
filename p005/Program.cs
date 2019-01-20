/*
2520 は 1 から 10 の数字の全ての整数で割り切れる数字であり, そのような数字の中では最小の値である.

では, 1 から 20 までの整数全てで割り切れる数字の中で最小の正の数はいくらになるか.
*/
using System;

namespace p005
{
    class Program
    {
        static int gcd(int a, int b) {
            if (a <= 0 || b <= 0) {
                return 0;
            }
            int tmp = a % b;
            while (tmp != 0) {
                a = b;
                b = tmp;
                tmp = a % b;
            }
            return b;
        }

        static int lcm(int a, int b) {
            if (a <= 0 || b <= 0) {
                return 0;
            }
            return a / gcd(a, b) * b;
        }

        static void Main(string[] args)
        {
            int n = 1;
            for (int i = 1; i <= 20; i++) {
                n = lcm(n, i);
            }
            Console.WriteLine("The answer is {0}.", arg0: n);
        }
    }
}
