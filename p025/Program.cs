/*
フィボナッチ数列は以下の漸化式で定義される:
Fn = Fn-1 + Fn-2, ただし F1 = 1, F2 = 1.
最初の12項は以下である.
F1 = 1
F2 = 1
F3 = 2
F4 = 3
F5 = 5
F6 = 8
F7 = 13
F8 = 21
F9 = 34
F10 = 55
F11 = 89
F12 = 144
12番目の項, F12が3桁になる最初の項である.
1000桁になる最初の項の番号を答えよ.
*/
using System;

namespace p025
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAXCOL = 1_000;
            int[] f1 = new int[MAXCOL + 1];
            int[] f2 = new int[MAXCOL + 1];
            int[] f3 = new int[MAXCOL + 1];
            for (int i = 0; i < MAXCOL + 1; i++) {
                f1[i] = f2[i] = f3[i] = 0;
            }
            f1[0] = f2[0] = 1;
            int num = 2;

            while (true) {
                for (int i = 0; i <= MAXCOL; i++) {
                    f3[i] = f1[i] + f2[i];
                }
                num++;
                for (int i = 0; i < MAXCOL; i++) {
                    f3[i+1] += (f3[i] / 10);
                    f3[i] %= 10;

                    f1[i] = f2[i];
                    f2[i] = f3[i];
                }
                if (f3[MAXCOL - 1] != 0) {
                    break;
                }
            }
            Console.WriteLine($"The answer is {num}.");
        }
    }
}
