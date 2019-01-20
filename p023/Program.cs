/*
完全数とは, その数の真の約数の和がそれ自身と一致する数のことである. たとえば, 28の真の約数の和は, 1 + 2 + 4 + 7 + 14 = 28 であるので, 28は完全数である.
真の約数の和がその数よりも少ないものを不足数といい, 真の約数の和がその数よりも大きいものを過剰数と呼ぶ.
12は, 1 + 2 + 3 + 4 + 6 = 16 となるので, 最小の過剰数である. よって2つの過剰数の和で書ける最少の数は24である. 数学的な解析により, 28123より大きい任意の整数は2つの過剰数の和で書けることが知られている. 2つの過剰数の和で表せない最大の数がこの上限よりも小さいことは分かっているのだが, この上限を減らすことが出来ていない.
2つの過剰数の和で書き表せない正の整数の総和を求めよ.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace p023
{
    class Program
    {
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

        static bool isOver(int num) {
            bool rc = false;
            List<int> a = makeTrueDivisorList(num);
            int fa = a.Sum();
            if (fa > num) {
                rc = true;
            } else {
                rc = false;
            }
            return rc;
        }
        static void Main(string[] args)
        {
            List<int> ar = new List<int>();
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            for (int i = 1; i <= 28123; i++) {
                bool rc = isOver(i);
                dict.Add(i, rc);
                if (rc == true) {
                    ar.Add(i);
                }
            }
            foreach (int x in ar) {
                foreach (int y in ar) {
                    bool val;
                    if (dict.TryGetValue(x + y, out val)) {
                        dict.Remove(x + y);
                    }
                    dict.Add(x + y, true);
                }
            }
            int sum = 0;
            for (int i = 1; i <= 28123; i++) {
                if (dict[i] == false) {
                    sum += i;
                }
            }
            Console.WriteLine($"The answer is {sum}.");
        }
    }
}
