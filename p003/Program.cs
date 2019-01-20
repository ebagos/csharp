/*
13195 の素因数は 5, 7, 13, 29 である.

600851475143 の素因数のうち最大のものを求めよ.
*/

using System;
using System.Collections.Generic;

namespace p003
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> primes = prime_decompo(600_851_475_143);
            Console.WriteLine("The answer is {0}.", arg0: primes[primes.Count - 1]);
        }
        static List<long> prime_decompo(long n) {
            List<long> table = new List<long>();
            int i = 2;
            while (i * i <= n) {
                while (n % i == 0) {
                    n /= i;
                    table.Add(i);
                }
                i++;
            }
            if (n > 1) {
                table.Add(n);
            }
            return table;
        }
    }
}
