/*
次の情報が与えられている.

1900年1月1日は月曜日である.
9月, 4月, 6月, 11月は30日まであり, 2月を除く他の月は31日まである.
2月は28日まであるが, うるう年のときは29日である.
うるう年は西暦が4で割り切れる年に起こる. しかし, 西暦が400で割り切れず100で割り切れる年はうるう年でない.
20世紀（1901年1月1日から2000年12月31日）中に月の初めが日曜日になるのは何回あるか?
*/
using System;

namespace p019
{
    class Program
    {
        static int[] daysOfMonth = new int[13] {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

        static int isUru(int year) {
            int rc = 0;
            if (year % 4 == 0) {
                rc = 1;
                if (year % 100 == 0 && year % 400 != 0) {
                    rc = 0;
                }
            }
            return rc;
        }

        static bool isNextSunday(int days) {
            bool rc = false;
            if (days % 7 == 6) {
                rc = true;
            } else {
                rc = false;
            }
            return rc;
        }

        static void Main(string[] args)
        {
            int count = 0;
            int days = 0;
            foreach(int v in daysOfMonth) {
                days += v;
            }
            days += isUru(1990);
            if (isNextSunday(days)) {
                count++;
            }
            for (int year = 1901; year < 2001; year++) {
                for (int month = 1; month < 13; month++) {
                    days += daysOfMonth[month];
                    if (month == 2) {
                        days += isUru(year);
                    }
                    if (isNextSunday(days)) {
                        if (!(year == 2000 && month == 12)) {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine($"The answer is {count}.");
        }
    }
}
