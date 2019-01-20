/*
三角数の数列は自然数の和で表わされ, 7番目の三角数は 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28 である. 三角数の最初の10項は:
1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
となる.
最初の7項について, その約数を列挙すると, 以下のとおり.
 1: 1
 3: 1,3
 6: 1,2,3,6
10: 1,2,5,10
15: 1,3,5,15
21: 1,3,7,21
28: 1,2,4,7,14,28
これから, 7番目の三角数である28は, 5個より多く約数をもつ最初の三角数であることが分かる.
では, 500個より多く約数をもつ最初の三角数はいくつか.
*/
using System;
using System.Collections.Generic;

namespace p012
{
    class Program
    {
        static int GetTriangleNumber(int num) {
            int rc = 0;
            for (int i = 1; i <= num; i++) {
                rc += i;
            }
            return rc;
        }

        static List<int> MakePrimeList(int num) {
            if (num < 2) {
                return (new List<int>());
            }
            List<int> prime_list = new List<int>(2_000_001);
            prime_list.Add(0);
            prime_list.Add(0);
            for (int i = 2; i <= num; i++) {
                prime_list.Add(i);
            }
            int num_sqrt = (int)Math.Sqrt((double)num);
            for (int i = 0; i < prime_list.Count; i++) {
                int prime = prime_list[i];
                if (prime == 0) {
                    continue;
                }
                if (prime > num_sqrt) {
                    break;
                }
                for (int non_prime = 2 * prime; non_prime <= num; non_prime += prime) {
                    prime_list[non_prime] = 0;
                }
            }
            List<int> result = new List<int>();
            foreach (int i in prime_list) {
                if ( i != 0) {
                    result.Add(i);
                }
            }
            return result;
        }

        static int DivisorNumber(int num) {
            if (num < 0) {
                return 0;
            } else if (num == 1) {
                return 1;
            } else {
                int num_sqrt = (int)Math.Sqrt((double)num);
                List<int> prime_list = MakePrimeList(num_sqrt);
                int divisor_num = 1;
                foreach (int prime in prime_list) {
                    int count = 1;
                    while (num % prime == 0) {
                        num /= prime;
                        count++;
                    }
                    divisor_num *= count;
                }
                if (num != 1) {
                    divisor_num *= 2;
                }
                return divisor_num;
            }
        }

        static void Main(string[] args)
        {
            int result = 1;
            while (DivisorNumber(GetTriangleNumber(result)) <= 500) {
                result++;
            }
            Console.WriteLine($"The answer is {result}.");
        }
    }
}
