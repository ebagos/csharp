/*2の平方根は無限に続く連分数で表すことができる.
√ 2 = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213...
最初の4回の繰り返しを展開すると以下が得られる.
1 + 1/2 = 3/2 = 1.5
1 + 1/(2 + 1/2) = 7/5 = 1.4
1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...
1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...
次の3つの項は99/70, 239/169, 577/408である. 第8項は1393/985である. これは分子の桁数が分母の桁数を超える最初の例である.
最初の1000項を考えたとき, 分子の桁数が分母の桁数を超える項はいくつあるか?
*/
using System;

namespace p057
{
    class Program
    {
        const int MAXCOLUMN = 500;
        const int MAXTRIAL = 1_000;

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
                n[i + 1] += (n[i] / 10);
                n[i] %= 10;
            }
        }

        static int[] plus(int[] a, int[] b) {
            int[] result = new int[MAXCOLUMN];
            for (int i = 0; i < MAXCOLUMN; i++) {
                result[i] = 0;
            }
            for (int i = 0; i < MAXCOLUMN; i++) {
                result[i] = a[i] + b[i];
            }
            normalize(ref result);
            return result;
        }

        static int[] mul(int[] a, int n) {
            int[] result = new int[MAXCOLUMN];
            for (int i = 0; i < MAXCOLUMN; i++) {
                result[i] = 0;
            }
            for (int i = 0; i < MAXCOLUMN; i++) {
                result[i] = a[i] * n;
            }
            normalize(ref result);
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
        static void Main(string[] args)
        {
            int[] bunshi = makeArray(3);
            int[] bunbo = makeArray(2);
            int koeta = 0;

            for (int i = 0; i < MAXTRIAL; i++) {
                int[] nbunbo = plus(bunshi, bunbo);
                int[] nbunshi = plus(mul(bunbo, 2), bunshi);
                if (count(bunbo) < count(bunshi)) {
                    koeta++;
                }
                bunbo = nbunbo;
                bunshi = nbunshi;
            }
            Console.WriteLine($"The answer is {koeta}.");
        }
    }
}
