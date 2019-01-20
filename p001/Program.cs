/*
  1以上1000未満の整数で，3または5で割り切れるものの和を求める
  複数の解決法を提示し，どの解法を選ぶべきか評価せよ（コメントとしてソースコード内に記入せよ）
*/

using System;
using System.Linq;

namespace p001
{
    class Program
    {
        static void Main(string[] args)
        {
            // ループで
            {
                int sum = 0;
                for (int i = 1; i < 1000; i++) {
                    if (i % 3 == 0 || i % 5 == 0) {
                        sum += i;
                    }
                }
                Console.WriteLine("The answer is {0}.", arg0: sum);
            }

            // LINQで
            // map : Select
            // filter : Where
            // reduce : Aggregate
            {
                int rc = Enumerable.Range(1, 999)
                            .Where(num => num % 3 == 0 || num % 5 == 0)
                            .Sum();
                Console.WriteLine("The answer is {0}", arg0: rc);
            }
        }
    }
}
