/*
 次の式は, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317 である.
では, 1^1 + 2^2 + 3^3 + ... + 1000^1000 の最後の10桁を求めよ.
*/
using System;

namespace p048
{
    class Program
    {
        static void normalize(ref int[] x, int keta) {
            for (int i = 0; i < keta - 1; i++) {
                x[i + 1] += x[i] / 10;
                x[i] %= 10;
            }
        }

        static void plus(int[] a, ref int[] result, int keta) {
            for (int i = 0; i < keta; i++) {
                result[i] += a[i];
            }
            normalize(ref result, keta);
        }

        static void power(ref int[] x, int n, int keta) {
            x[0] = 1;
            for (int th = 0; th < n; th++) {
                for (int i = 0; i < keta; i++) {
                    x[i] *= n;
                }
                normalize(ref x, keta);
            }
        }

        static void printout(int[] val, int keta) {
            for (int i = keta - 2; i >= 0; i--) {
                Console.Write(val[i]);
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            const int MAXKETA = 11;
            const int MAXREP = 1_000;

            int[] result = new int[MAXKETA];
            for (int i = 0; i < MAXKETA; i++) {
                result[i] = 0;
            }
            for (int i = 1; i <= MAXREP; i++) {
                int[] val = new int[MAXKETA];
                for (int j = 0; j < MAXKETA; j++) {
                    val[j] = 0;
                }
                power(ref val, i, MAXKETA);
                plus(val, ref result, MAXKETA);
            }
            printout(result, MAXKETA);
        }
    }
}
