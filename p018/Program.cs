/*
以下の三角形の頂点から下まで移動するとき, その数値の和の最大値は23になる.

3
7 4
2 4 6
8 5 9 3

この例では 3 + 7 + 4 + 9 = 23.

以下の三角形を頂点から下まで移動するとき, その最大の和を求めよ.

75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

*/
using System;
using System.Collections.Generic;

namespace p018
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> triangle = new List<List<int>>();
            triangle.Add(new List<int>() {75});
            triangle.Add(new List<int>() {95, 64});
            triangle.Add(new List<int>() {17, 47, 82});
            triangle.Add(new List<int>() {18, 35, 87, 10});
            triangle.Add(new List<int>() {20, 04, 82, 47, 65});
            triangle.Add(new List<int>() {19, 01, 23, 75, 03, 34});
            triangle.Add(new List<int>() {88, 02, 77, 73, 07, 63, 67});
            triangle.Add(new List<int>() {99, 65, 04, 28, 06, 16, 70, 92});
            triangle.Add(new List<int>() {41, 41, 26, 56, 83, 40, 80, 70, 33});
            triangle.Add(new List<int>() {41, 48, 72, 33, 47, 32, 37, 16, 94, 29});
            triangle.Add(new List<int>() {53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14});
            triangle.Add(new List<int>() {70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57});
            triangle.Add(new List<int>() {91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48});
            triangle.Add(new List<int>() {63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31});
            triangle.Add(new List<int>() {04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23});

            for (int y = triangle.Count - 1; y > 1; y--) {
                for (int x = 0; x < triangle[y].Count - 1; x++) {
                    if (triangle[y][x] > triangle[y][x+1]) {
                        triangle[y-1][x] += triangle[y][x];
                    } else {
                        triangle[y-1][x] += triangle[y][x+1];
                    }
                }
            }
            if (triangle[1][0] > triangle[1][1]) {
                triangle[0][0] += triangle[1][0];
            } else {
                triangle[0][0] += triangle[1][1];
            }
            Console.WriteLine($"The answer is {triangle[0][0]}.");
        }
    }
}
