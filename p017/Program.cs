/*
1 から 5 までの数字を英単語で書けば one, two, three, four, five であり, 全部で 3 + 3 + 5 + 4 + 4 = 19 の文字が使われている.

では 1 から 1000 (one thousand) までの数字をすべて英単語で書けば, 全部で何文字になるか.

注: 空白文字やハイフンを数えないこと. 例えば, 342 (three hundred and forty-two) は 23 文字, 115 (one hundred and fifteen) は20文字と数える. なお, "and" を使用するのは英国の慣習.
*/
using System;
using System.Collections.Generic;

namespace p017
{
    class Program
    {
        static Dictionary<int, string> dict = new Dictionary<int, string>() {
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
            {10, "ten"},
            {11, "eleven"},
            {12, "twelve"},
            {13, "thirteen"},
            {14, "fourteen"},
            {15, "fifteen"},
            {16, "sixteen"},
            {17, "seventeen"},
            {18, "eighteen"},
            {19, "nineteen"},
            {20, "twenty"},
            {30, "thirty"},
            {40, "forty"},
            {50, "fifty"},
            {60, "sixty"},
            {70, "seventy"},
            {80, "eighty"},
            {90, "ninety"},
            {1000, "onethousand"},
        };

        static string numberToWord(int num) {
            string val;

            if (dict.TryGetValue(num, out val)) {
                return val;
            } else if (num < 100) {
                int a = num % 10;
                int b = (num / 10) * 10;
                return numberToWord(b) + numberToWord(a);
            } else {
                int a = num % 100;
                int b = num / 100;
                if (a == 0) {
                    return numberToWord(b) + "handred";
                } else {
                    return numberToWord(b) + "handredand" + numberToWord(a);
                }
            }
        }

        static void Main(string[] args)
        {
            string words = "";
            for (int i = 1; i <= 1000; i++) {
                words += numberToWord(i);
            }
            words.Replace(" ", "");
            words.Replace("-", "");
//            Console.WriteLine(words);
            Console.WriteLine($"The answer is {words.Length}.");
        }
    }
}
