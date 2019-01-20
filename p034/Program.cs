/*
145は面白い数である. 1! + 4! + 5! = 1 + 24 + 120 = 145となる.

各桁の数の階乗の和が自分自身と一致するような数の和を求めよ.

注: 1! = 1 と 2! = 2 は総和に含めてはならない.
*/
using System;

namespace p034
{
    class Program
    {
        static int fill(int n, int c) {
            int sum = 0;
            for (int i = 0; i < c; i++) {
                sum = sum * 10 + n;
            }
            return sum;
        }

        static int factorial(int n) {
            int result = 1;
            for (int i = 1; i <= n; i++) {
                result *= i;
            }
            return result;
        }

        static int limit() {
            int max = 100;
            int tmp = 0;
            for (int i = 0; i < max; i++) {
                tmp = i * factorial(9);
                if (fill(9, i) > tmp) {
                    break;
                }
            }
            return tmp;
        }

        static int num2fac(int n) {
            int sum = 0;
            for (int m = n;;) {
                int x = m % 10;
                sum += factorial(x);
                m /= 10;
                if (m == 0) {
                    break;
                }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 3; i < limit(); i++) {
                if (i == num2fac(i)) {
                    Console.WriteLine(i);
                    sum += i;
                }
            }
            Console.WriteLine($"The answer is {sum}.");
        }
    }
}
