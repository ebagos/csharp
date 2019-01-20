/*
フィボナッチ数列の項は前の2つの項の和である. 最初の2項を 1, 2 とすれば, 最初の10項は以下の通りである. 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

数列の項の値が400万以下の, 偶数値の項の総和を求めよ.
 */

using System;

namespace p002
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            int sum = 0;
            for (i = 1; ; i++) {
                int val = Fibo(i);
                if (val > 4_000_000) {
                    break;
                }
                if (val % 2 == 0) {
                    sum += val;
                }
            }
            Console.WriteLine("The answer is {0}.", arg0: sum);
        }
        static int Fibo(int n) {
            if (n < 1) {
                return 0;
            } else if ( n == 1) {
                return 1;
            } else if ( n == 2) {
                return 2;
            } else {
                return Fibo(n - 2) + Fibo(n - 1);
            }
        }
    }
}
