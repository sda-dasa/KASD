
using System;
using System.Drawing;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using MYDeq;

namespace task_14
{
    class Program
    {

        static void Main()
        {
            //Console.WriteLine("skdvl");
            //int n = 9; int[] maqs = new int[n--]; Console.WriteLine(maqs.Length); Console.WriteLine(n);

            // чтение из файла

            MYArrayDeque<string> origin = new MYArrayDeque<string>(0);

            string file = "input.txt";

            string[] mas_str = File.ReadAllLines(file);
            //const int amount = 4;
            //string[] mas_str = new string [amount]
            //{ 
            //    "eeeeyue 89qhacl", 
            //    "   hslds sdi ksd 9091890980980980980983892032 jsd9q3u9nsof90erqn   q0-q0-0-0- ", 
            //    "gsdfkjh q",
            //    " hlsj 83r jzdf 81 8 18 18 1hsf  888812  9190 "
            //};


            if (mas_str.Length > 0)
            {
                origin.Add(mas_str[0]);

                for (int i = 1; i < mas_str.Length; i++)
                {
                    if (Compare(origin.GetFirst(), mas_str[i]))
                    { origin.AddLast(mas_str[i]); continue; }

                    origin.AddFirst(mas_str[i]);

                }

                //origin.ShowEl();

                file = "sorted.txt";
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(origin.ToString());
                }

                Console.WriteLine("Введите кол-во пробелов");
                int n; int.TryParse(Console.ReadLine(), out n);

                if (!(n == 0 || n < 0))
                {
                    string[] mas_str_ = origin.ToArray();
                    for (int i = 0; i < origin.Size; i++)
                    {
                        if (CountOfSpace(mas_str_[i]) > n) origin.Remove(mas_str_[i]);
                    }
                }

                origin.ShowEl();


            }
            else Console.WriteLine("файл пуст");

        }

        public static byte CountOfSpace (string str)
        {
            byte count = 0;
            foreach (char c in str) if (c == ' ') count++; return count;

        }

        protected static bool Compare(string head, string current)
        {
            if (CountOfDigits(head) < CountOfDigits(current)) return true;
            return false;
        }

        protected static byte CountOfDigits(string str)
        {
            byte count = 0;
            foreach (char c in str) if (c >= '0' && c <= '9') count++;
            return count;
        }

    }
}