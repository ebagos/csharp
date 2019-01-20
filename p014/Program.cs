/*
正の整数に以下の式で繰り返し生成する数列を定義する.

    n → n/2 (n が偶数)

    n → 3n + 1 (n が奇数)

13からはじめるとこの数列は以下のようになる.
13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1

13から1まで10個の項になる. この数列はどのような数字からはじめても最終的には 1 になると考えられているが, まだそのことは証明されていない(コラッツ問題)

さて, 100万未満の数字の中でどの数字からはじめれば最長の数列を生成するか.

注意: 数列の途中で100万以上になってもよい
*/
using System;
using System.Collections.Generic;

namespace p014
{
    class Program
    {
        static long collatz_loop(long n) {
            long count = 1;
            while (n > 1) {
                if (n % 2 == 0) {
                    n /= 2;
                } else {
                    n = n * 3 + 1;
                }
                count++;
            }
            return count;
        }

        static long collatz_recursive(long n, long iter) {
            if (n <= 1) {
                return iter;
            } else if (n % 2 == 0) {
                return collatz_recursive(n / 2, iter + 1);
            } else {
                return collatz_recursive(n * 3 + 1, iter + 1);
            }
        }

        static Dictionary<long, long> dict = new Dictionary<long, long>();

        static long next(long n) {
            if (n % 2 == 0) {
                return n / 2;
            } else {
                return n * 3 +1;
            }
        }

        static void add(long n1) {
            long val;
            var n2 = next(n1);
            if (!dict.TryGetValue(n2, out val)) {
                add(n2);
            }
            dict[n1] = dict[n2] + 1;
        }

        static void Main(string[] args)
        {
            var sw = new System.Diagnostics.Stopwatch();

            long max = 0;
            long key = 0;

            sw.Start();
            for (long i = 2; i <= 1_000_000; i++) {
                long rc = collatz_loop(i);
                if (max < rc) {
                    max = rc;
                    key = i;
                }
            }
            sw.Stop();
            Console.WriteLine($"The answer ... value = {key}, count = {max}, elapsed {sw.Elapsed}");

            max = 0;
            key = 0;

            sw.Restart();
            for (long i = 2; i <= 1_000_000; i++) {
                long rc = collatz_recursive(i, 1);
                if (max < rc) {
                    max = rc;
                    key = i;
                }
            }
            sw.Stop();
            Console.WriteLine($"The answer ... value = {key}, count = {max}, elapsed {sw.Elapsed}");

            max = 0;
            key = 0;
            long val;

            sw.Restart();
            dict.Add(1, 1);
            for (long i = 2; i < 1_000_000; i++) {
//                Console.WriteLine(i);
                if (!dict.TryGetValue(i, out val)) {
                    add(i);
                    if (max < dict[i]) {
                        max = dict[i];
                        key = i;
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"The answer ... value = {key}, count = {max}, elapsed {sw.Elapsed}");
        }
    }
}
