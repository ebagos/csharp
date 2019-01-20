/*
素数を小さい方から6つ並べると 2, 3, 5, 7, 11, 13 であり, 6番目の素数は 13 である.
10 001 番目の素数を求めよ.
*/
using System;
using System.Collections.Generic;

namespace p007
{
    class Program
    {
        static bool IsPrime(int num) {
            int yaku = 0;
            for (int dv = 1; dv <= num; dv++) {
                if (num % dv == 0) {
                    yaku++;
                }
            }
            if (yaku == 2) {
                return true;
            } else {
                return false;
            }
        }

        static List<int> GeneratePrimes(int n) {
            List<int> primes = new List<int>();
            primes.Add(2);
            int i = 3;
//            int cnt = 1;
            while (primes.Count < n) {
                if (IsPrime(i) == true) {
//                    Console.WriteLine("{0} : {1}", arg0: cnt, arg1: i);
//                    cnt++;
                    primes.Add(i);
                }
                i += 2;
            }
            return primes;
        }

        static void Main(string[] args)
        {
            List<int> result = GeneratePrimes(10_001);
            Console.WriteLine("The answer is {0}.", arg0: result[result.Count - 1]);
        }
    }
}
