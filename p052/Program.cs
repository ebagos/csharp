/*
125874を2倍すると251748となる. これは元の数125874と順番は違うが同じ数を含む.

2x, 3x, 4x, 5x, 6x が x と同じ数を含むような最小の正整数 x を求めよ.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace p052
{
    class Program
    {
        static bool check(int n, int m) {
            string sortString(string input) {
                char[] characters = input.ToArray();
                Array.Sort(characters);
                return new string(characters);
            }
            if (int.Parse(sortString(n.ToString())) == int.Parse(sortString(m.ToString()))) {
                return true;
            } else {
                return false;
            }
        }
        static void Main(string[] args)
        {
            int n = 1;
            while (!(check(n, n *2) && check(n, n *3) && check(n, n * 4) && check(n, n * 5) && check(n, n * 6))) {
                n++;
            }
            Console.WriteLine($"The answer is {n}.");
        }
    }
}
