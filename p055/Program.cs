/*
47とその反転を足し合わせると, 47 + 74 = 121となり, 回文数になる.

全ての数が素早く回文数になるわけではない. 349を考えよう,

    349 + 943 = 1292,
    1292 + 2921 = 4213
    4213 + 3124 = 7337

349は, 3回の操作を経て回文数になる.

まだ証明はされていないが, 196のようないくつかの数字は回文数にならないと考えられている. 反転したものを足すという操作を経ても回文数にならないものをLychrel数と呼ぶ. 先のような数の理論的な性質により, またこの問題の目的のために, Lychrel数で無いと証明されていない数はLychrel数だと仮定する.

更に, 10000未満の数については，常に以下のどちらか一方が成り立つと仮定してよい.

    50回未満の操作で回文数になる
    まだ誰も回文数まで到達していない

実際, 10677が50回以上の操作を必要とする最初の数である: 4668731596684224866951378664 (53回の操作で28桁のこの回文数になる).

驚くべきことに, 回文数かつLychrel数であるものが存在する. 最初の数は4994である.

10000未満のLychrel数の個数を答えよ.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace p055
{
    class Program
    {
        const int MAX = 50;

        static int[] plus(int[] a, int[] b) {
            int[] result = new int[MAX];
            for (int i = 0; i < MAX; i++) {
                result[i] = a[i] + b[i];
            }
            for (int i = 0; i < MAX - 1; i++) {
                result[i + 1] += result[i] / 10;
                result[i] %= 10;
            }
            return result;
        }

        static int[] makeArray(int n) {
            int[] result = new int[MAX];
            for (int i = 0; i < MAX - 1; i++) {
                if (n == 0) {
                    break;
                }
                result[i] = n % 10;
                n /= 10;
            }
            return result;
        }

        static int[] reverse(int[] n) {
            int[] result = new int[MAX];
            int checker = MAX - 1;
            for (int i = MAX - 1; i >= 0; i--) {
                if (n[i] != 0) {
                    checker = i;
                    break;
                }
            }
            for (int i = 0; i <= checker; i++) {
                result[checker - i] = n[i];
            }
            return result;
        }

        static bool rcheck(int[] n) {
            int checker = MAX - 1;
            for (int i = MAX - 1; i >= 0; i--) {
                if (n[i] != 0) {
                    checker = i;
                    break;
                }
            }
            int[] tmp = reverse(n);
            for (int i = 0; i <= checker; i++) {
                if (tmp[i] != n[i]) {
                    return false;
                }
            }
            return true;
        }

        static bool isLychrel(int n) {
            int[] c = makeArray(n);
            for (int i = 0; i < MAX; i++) {
                c = plus(c, reverse(c));
                if (rcheck(c)) {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= 10_000; i++) {
                if (isLychrel(i)) {
                    result.Add(i);
                }
            }
            foreach (int n in result) {
                Console.Write($"{n}, ");
            }
            Console.WriteLine($"\nThe answer is {result.Count}.");
        }
    }
}
