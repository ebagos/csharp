/*
10以下の素数の和は 2 + 3 + 5 + 7 = 17 である.
200万以下の全ての素数の和を求めよ.
*/
using System;
using System.Collections.Generic;

namespace p010
{
    class Program
    {
        static bool IsPrime(int num) {
            if (num < 2) {
                return false;
            }
            if (num == 2 || num == 3 || num == 5) {
                return true;
            }
            int prime = 7;
            int step = 4;
            int num_sqrt = (int)Math.Sqrt((double)num);
            while (prime <= num_sqrt) {
                if (num % prime == 0) {
                    return false;
                }
                prime += step;
                step = 6 - step;
            }
            return true;
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

        static void Main(string[] args)
        {
            List<int> primes = MakePrimeList(2_000_000);
            long sum = 0;
            foreach (int prime in primes) {
                sum += prime;
            }
            Console.WriteLine($"The answer is {sum}");
        }
    }
}
