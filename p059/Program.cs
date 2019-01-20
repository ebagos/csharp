/*
各文字はそれぞれ一意のコードに割り当てられている. よく使われる標準としてASCII (American Standard Code for Information Interchange) がある. ASCIIでは, 大文字A = 65, アスタリスク (*) = 42, 小文字k = 107というふうに割り当てられている.

モダンな暗号化の方法として, テキストファイルの各バイトをASCIIに変換し, 秘密鍵から計算された値とXORを取るという手法がある. XOR関数の良い点は, 暗号化に用いたのと同じ暗号化鍵でXORを取ると平文を復号できる点である. 65 XOR 42 = 107であり, 107 XOR 42 = 65である.

破られない暗号化のためには, 鍵は平文と同じ長さのランダムなバイト列でなければならない. ユーザーは暗号文と暗号化鍵を別々の場所に保存する必要がある. また, もし一方が失われると, 暗号文を復号することは不可能になる.

悲しいかな, この手法はほとんどのユーザーにとって非現実的である. そこで, 鍵の変わりにパスワードを用いる手法が用いられる. パスワードが平文より短ければ (よくあることだが), パスワードは鍵として繰り返し用いられる. この手法では, 安全性を保つために十分長いパスワードを用いる必要があるが, 記憶するためにはある程度短くないといけない.

この問題での課題は簡単になっている. 暗号化鍵は3文字の小文字である. cipher1.txtは暗号化されたASCIIのコードを含んでいる. また, 平文はよく用いられる英単語を含んでいる. この暗号文を復号し, 平文のASCIIでの値の和を求めよ.
*/

/*
英文だからスペースが一番多いものが正解というかなりあれな根拠から解く
*/
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace p059
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            try {
            StreamReader sr = new StreamReader(@"cipher.txt", Encoding.GetEncoding("UTF-8"));
            str = sr.ReadToEnd();
            sr.Close();
            } catch (Exception e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            string[] strs = str.Trim().Split(',');
            List<int> codes = new List<int>();
            for (int i = 0; i < strs.Count(); i++) {
                codes.Add(int.Parse(strs[i]));
            }

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int maxSpace = 0;
            string maxSeed = "";
            string maxText = "";
            foreach (int a0 in alphabet) {
                foreach (int a1 in alphabet) {
                    foreach (int a2 in alphabet) {
                        int[] seed = new int[3] {a0, a1, a2};
                        string text = "";
                        for (int i = 0; i < codes.Count(); i++) {
                            text += (char)(codes[i] ^ seed[i % 3]);
                        }
//                        Console.WriteLine(text);
                        int spaces = text.Where(c => c == ' ').Count();
                        if (maxSpace < spaces) {
                            maxSpace = spaces;
                            maxSeed = ((char)a0).ToString() + ((char)a1).ToString() + ((char)a2).ToString();
                            maxText = text;
                        }
                    }
                }
            }
            Console.WriteLine(maxText);
            Console.WriteLine($"The answer is \"{maxSeed}\".");
        }
    }
}
