/*
ピタゴラス数(ピタゴラスの定理を満たす自然数)とは a < b < c で以下の式を満たす数の組である.
a^2 + b^2 = c^2
例えば, 3^2 + 4^2 = 9 + 16 = 25 = 5^2 である.
a + b + c = 1000 となるピタゴラスの三つ組が一つだけ存在する.
これらの積 abc を計算しなさい.
*/
using System;
using System.Collections.Generic;

namespace p009
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(int, int, int)> result = new List<(int, int, int)>();
            for (int b = 1; b < 998; b++) {
                for (int a = 1; a < b; a++) {
                    int c = 1000 - a - b;
                    if ( a*a + b*b == c*c) {
                        result.Add((a, b, c));
                    }
                }
            }
            Console.WriteLine("The answer is {0}.", arg0: result[0]);
        }
    }
}
