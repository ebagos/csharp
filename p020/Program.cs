/*
n × (n - 1) × ... × 3 × 2 × 1 を n! と表す.

例えば, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800 となる. この数の各桁の合計は 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27 である.

では, 100! の各桁の数字の和を求めよ.
*/
using System;
using System.Linq;

namespace p020
{
    class Program
    {
        static int MAX = 200;
        static void Main(string[] args)
        {
            int[] result = new int[MAX];
            for (int i = 0; i < MAX; i++) {
                result[i] = 0;
            }

            result[0] = 1;
            for (int i = 2; i <= 100; i++) {
                for (int j = 0; j < MAX; j++) {
                    result[j] *= i;
                }
                for (int j = 0; j < MAX - 1; j++) {
                    result[j+1] += result[j] / 10;
                    result[j] %= 10;
                }
            }

            for (int i = MAX - 1; i >= 0; i--) {
                Console.Write(result[i]);
            }
            Console.WriteLine($"\nThe answer is {result.Sum()}.");
        }
    }
}
