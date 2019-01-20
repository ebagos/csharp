/*
5000個以上の名前が書かれている46Kのテキストファイル names.txt を用いる. まずアルファベット順にソートせよ.

のち, 各名前についてアルファベットに値を割り振り, リスト中の出現順の数と掛け合わせることで, 名前のスコアを計算する.

たとえば, リストがアルファベット順にソートされているとすると, COLINはリストの938番目にある. またCOLINは 3 + 15 + 12 + 9 + 14 = 53 という値を持つ. よってCOLINは 938 × 53 = 49714 というスコアを持つ.

ファイル中の全名前のスコアの合計を求めよ.
*/
using System;
using System.IO;
using System.Text;

namespace p022
{
    class Program
    {
        static string readFile(string path) {
            string str = "";
            try {
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding("UTF-8"));
            str = sr.ReadToEnd();
            sr.Close();
            } catch (Exception e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return str;
        }

        static int getValue(string name) {
            int sum = 0;
            for (int i = 0; i < name.Length; i++) {
                sum += name[i] - 'A' + 1;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            string str = readFile(@"names.txt");
            string[] names = str.Replace("\"", "").Split(',');
            Array.Sort(names);

            int sum = 0;
            int idx = 1;
            foreach (string name in names) {
                sum += idx * getValue(name);
                idx++;
            }

            Console.WriteLine($"The answer is {sum}.");
        }
    }
}
