/*
2^15 = 32768 であり, 各位の数字の和は 3 + 2 + 7 + 6 + 8 = 26 となる.

同様にして, 2^1000 の各位の数字の和を求めよ.
*/
using System;

namespace p016
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] result = new int[500];
            for (int i = 0; i < 500; i++) {
                result[i] = 0;
            }
            result[0] = 1;

            for (int i = 0; i < 1000; i++) {
                for (int j = 0; j < 500; j++) {
                    result[j] *= 2;
                }
                for (int j = 0; j < 499; j++) {
                    int tmp = result[j] / 10;
                    result[j + 1] += tmp;
                    result[j] %= 10;
                }
            }
            int sum = 0;
            for (int i = 0; i < 500; i++) {
                sum += result[i];
            }
            Console.WriteLine($"The answer is {sum}.");
        }
    }
}
