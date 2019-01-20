/*
12345から3つ選ぶ選び方は10通りである.
123, 124, 125, 134, 135, 145, 234, 235, 245, 345.
組み合わせでは, 以下の記法を用いてこのことを表す: 5C3 = 10.
一般に, r ≤ n について nCr = n!/(r!(n-r)!) である. ここで, n! = n×(n−1)×...×3×2×1, 0! = 1 と階乗を定義する.
n = 23 になるまで, これらの値が100万を超えることはない: 23C10 = 1144066.
1 ≤ n ≤ 100 について, 100万を超える nCr は何通りあるか?
*/
using System;
using System.Numerics;

namespace p053
{
    class Program
    {
        static BigInteger factorial(int n) {
            BigInteger result = new BigInteger(1);
            for (int i = 1; i <= n; i++) {
                result *= new BigInteger(i);
            }
            return result;
        }

        static void Main(string[] args)
        {
            int result = 0;
            for (int n = 1; n <= 100; n++) {
                for (int r = 1; r <= n; r++) {
                    var x = factorial(n) / (factorial(r) * factorial(n - r));
                    if (x > new BigInteger(1_000_000)) {
                        result++;
                    }
                }
            }
            Console.WriteLine($"The answer is {result}.");
        }
    }
}
