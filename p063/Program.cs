/*
5桁の数 16807 = 7^5は自然数を5乗した数である. 同様に9桁の数 134217728 = 8^9も自然数を9乗した数である.
自然数を n 乗して得られる n 桁の正整数は何個あるか?
*/
/*
n乗すべき自然数の最大値は9なのだと仮定して、
9のn乗がn桁を超えない最大値を調べてから解答を求める
ちなみに9の21乗が21桁で、22乗も21桁
*/
using System;

namespace p063
{
    class Program
    {
        const int MAXCOLUMN = 100;

        static int[] makeArray(int n) {
            int[] result = new int[MAXCOLUMN];
            for (int i = 0; i < MAXCOLUMN; i++) {
                result[i] = 0;
            }
            for (int i = 0; i < MAXCOLUMN; i++) {
                result[i] = n % 10;
                n /= 10;
                if (n == 0) {
                    break;
                }
            }
            return result;
        }

        static void normalize(ref int[] n) {
            for (int i = 0; i < n.Length - 1; i++) {
                n[i + 1] += n[i] / 10;
                n[i] %= 10;
            }
        }

        static int[] power(int x, int n) {
            int [] result = makeArray(x);
            for (int i = 1; i < n; i++) {
                for (int j = 0; j < MAXCOLUMN; j++) {
                    result[j] *= x;
                }
                normalize(ref result);
            }
            return result;
        }

        static int count(int[] n) {
            int result = 0;
            for (int i = MAXCOLUMN - 1; i >= 0; i--) {
                if (n[i] != 0) {
                    break;
                }
                result++;
            }
            return MAXCOLUMN - result;
        }
        static int getLimit() {
            int beki = 1;
            while (count(power(9, beki)) >= beki) {
                beki++;
            }
            return beki;
        }

        static void Main(string[] args)
        {
            int result = 0;
            for (int i = 1; i < 10; i++) {
                for (int beki = 1; beki <= getLimit(); beki++) {
                    int[] tgt = power(i, beki);
                    if (count(tgt) == beki) {
                        result++;
                    }
                }
            }
            Console.WriteLine($"The answer is {result}.");
        }
    }
}
