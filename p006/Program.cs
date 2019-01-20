/*
最初の10個の自然数について, その二乗の和は, 1^2 + 2^2 + ... + 10^2 = 385

最初の10個の自然数について, その和の二乗は, (1 + 2 + ... + 10)^2 = 3025

これらの数の差は 3025 - 385 = 2640 となる.

同様にして, 最初の100個の自然数について二乗の和と和の二乗の差を求めよ.
*/
using System;

namespace p006
{
    class Program
    {
        static int LASTNUM = 100;

        static void Main(string[] args)
        {
            (int, int) sumpow_powsum(int maxnum) {
                int sum1 = 0;
                int sum2 = 0;
                for (int i = 1; i <= maxnum; i++) {
                    sum1 += i;
                    sum2 += i * i;
                }
                return (sum1 * sum1, sum2);
            }

            (int sumpow, int powsum) = sumpow_powsum(LASTNUM);
            Console.WriteLine("The answer is {0}.", arg0: sumpow - powsum);
        }
    }
}
