/*
Googol (10^100)は非常に大きな数である: 1の後に0が100個続く. 100^100は想像を絶する. 1の後に0が200回続く. その大きさにも関わらず, 両者とも数字和 ( 桁の和 ) は1である.

a, b < 100 について自然数 ab を考える. 数字和の最大値を答えよ.
*/
using System;
using System.Numerics;

namespace p056
{
    class Program
    {
        static BigInteger pow(int x, int n) {
            BigInteger result = new BigInteger(1);
            for (int i = 0; i < n; i++) {
                result *= x;
            }
            return result;
        }

        static BigInteger aadd(BigInteger x) {
            BigInteger result = new BigInteger(0);

            while(x > 0) {
                result += x % 10;
                x /= 10;
            }
            return result;
        }
        static void Main(string[] args)
        {
            BigInteger result = new BigInteger(0);
            for (int i = 1; i < 100; i++) {
                for (int j = 1; j < 100; j++) {
                    BigInteger rc = aadd(pow(i, j));
                    if (result < rc) {
                        result = rc;
                    }
                }
            }
            Console.WriteLine($"The answer is {result}.");
        }
    }
}
