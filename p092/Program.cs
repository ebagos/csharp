/*
各桁の2乗を足し合わせて新たな数を作ることを, 同じ数が現れるまで繰り返す.
例えば
　　44 → 32 → 13 → 10 → 1 → 1
　　85 → 89 → 145 → 42 → 20 → 4 → 16 → 37 → 58 → 89
のような列である. どちらも1か89で無限ループに陥っている.
驚くことに, どの数から始めても最終的に1か89に到達する.
では, 10,000,000より小さい数で89に到達する数はいくつあるか.
*/
using System;
using System.Linq;

namespace p092
{
    class Program
    {
        static int ketaSquare(int n) {
            int result = 0;
            while (n != 0) {
                result += (n % 10) * (n % 10);
                n /= 10;
            }
            return result;
        }

        static void Main(string[] args)
        {
            int count = 0;
            const int MAX = 9 * 9 * 7 + 1;  // 9,999,999に1を足しておく
            int[] memo = new int[MAX];
            for (int i = 0; i < MAX; i++) {
                memo[i] = -1;
            }
            memo[1] = 0;
            memo[89] = 1;
            for (int i = 2; i < 10_000_000; i++) {
                int n = i;
                while (true) {
                    n = ketaSquare(n);
                    if (memo[n] != -1) {
                        break;
                    }
                }
                if (memo[n] == 1) {
                    count++;
                    if (i < MAX) {
                        memo[i] = 1;
                    } else if (i < MAX) {
                        memo[i] = 0;
                    }
                }
            }
            Console.WriteLine($"The answer is {count}.");
        }
    }
}
