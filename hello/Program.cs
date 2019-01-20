using System;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            var int5 = 1_000_000;
            Console.WriteLine("Hello World!");
            Console.WriteLine(int5);

            var name = "テスト";
            var s1 = $@"名前は
            {name}";
            var s2 = $"Now: {DateTime.Now:f}";
            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }
    }
}
