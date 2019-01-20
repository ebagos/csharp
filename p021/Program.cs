/*
d(n) を n の真の約数の和と定義する. (真の約数とは n 以外の約数のことである. )
もし, d(a) = b かつ d(b) = a (a ≠ b のとき) を満たすとき, a と b は友愛数(親和数)であるという.

例えば, 220 の約数は 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110 なので d(220) = 284 である.
また, 284 の約数は 1, 2, 4, 71, 142 なので d(284) = 220 である.

zそれでは10000未満の友愛数の和を求めよ.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace p021
{
    class Program
    {
        static List<int> makeDivisorList(int num) {
            List<int> rc = makeTrueDivisorList(num);
            rc.Add(num);
            return rc;
        }

        static List<int> makeTrueDivisorList(int num) {
            if (num < 1) {
                return new List<int>();
            } else if (num == 1 || num == 2 || num == 3) {
                return new List<int>() {1};
            } else {
                List<int> divisorList = new List<int>();
                divisorList.Add(1);
                for (int i = 2; i < num / 2 + 1; i++) {
                    if (num % i == 0) {
                        divisorList.Add(i);
                    }
                }
                return divisorList;
            }
        }

        static bool isFriend(int num) {
            List<int> a = makeTrueDivisorList(num);
            int fa = a.Sum();
            if (fa == num) {
                return false;
            }
            List<int> b = makeTrueDivisorList(fa);
            int fb = b.Sum();
            if (fb == num) {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 1; i < 10_000; i++) {
                if (isFriend(i)) {
                    Console.WriteLine(i);
                    sum += i;
                }
            }
            Console.WriteLine($"The answer is {sum}.");
        }
    }
}
