/*
驚くべきことに, 各桁を4乗した数の和が元の数と一致する数は3つしかない.

    1634 = 1**4 + 6**4 + 3**4 + 4**4
    8208 = 8**4 + 2**4 + 0**4 + 8**4
    9474 = 9**4 + 4**4 + 7**4 + 4**4

ただし, 1=1**4は含まないものとする. この数たちの和は 1634 + 8208 + 9474 = 19316 である.

各桁を5乗した数の和が元の数と一致するような数の総和を求めよ.
*/
using System;

namespace p030
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

        static int pow(int n, int x) {
            int result = 1;
            for (int i = 0; i < x; i++) {
                result *= n;
            }
            return result;
        }

        static int limit(int x) {
            int max = 100;
            int tmp = 0;
            for (int i = 0; i < max; i++) {
                tmp = i * pow(9, x);
                if ( fill(9, i) > tmp) {
                    break;
                }
            }
            return tmp;
        }

        static void sub1() {
            const int POWER = 5;
            int ans = 0;
            int[] seed = new int[10];
            for (int i = 0; i < 10; i++) {
                seed[i] = pow(i, POWER);
            }
            for (int i = 2; i < limit(POWER); i++) {
                string s = i.ToString();
                int val = 0;
                for (int j = 0; j < s.Length; j++) {
                    int idx = s[j] - '0';
                    val += seed[idx];
                }
                if (val == i) {
                    Console.WriteLine($"The condition meets with {i}.");
                    ans += val;
                }
            }
            Console.WriteLine($"The answer is {ans}.");
        }

        static int num2pow(int n, int c) {
            int sum = 0;
            for (int m = n;;) {
                int x = m % 10;
                sum += pow(x, c);
                m /= 10;
                if (m == 0) {
                    break;
                }
            }
            return sum;
        }

        static void sub2() {
            const int POWER = 5;
            int ans = 0;
            for (int i = 2; i < limit(POWER); i++) {
                int x = num2pow(i, POWER);
                if (x == i) {
                    Console.WriteLine($"The condition meets with {i}.");
                    ans += x;
                }
            }
            Console.WriteLine($"The answer is {ans}.");
        }

        static void Main(string[] args)
        {
            sub1();
            sub2();
        }
    }
}
