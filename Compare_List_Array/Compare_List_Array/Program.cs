using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MYArray;
using MYLinkedList;

namespace Compare_List_Array
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Graphic());

        }




        public static MYLinkedList<T> CreateList<T>(int size)
        {
            MYLinkedList<T> list = new MYLinkedList<T>();


            if (list is MYLinkedList<string>)
            {
                RandomString rString = new RandomString();
                for (int i = 0; i < size; i++)
                {
                    object next = rString.Next(0);
                    list.Add((T)next);
                }

            }
            if (list is MYLinkedList<int>)
            {
                Random rInt = new Random();
                for (int i = 0; i < size; i++)
                {
                    object next = rInt.Next(0, 100);
                    list.Add((T)next);
                }

            }

            return list;
        }


        //public delegate T CreateRandom<T>(int n);


        public static MyArrayList_<T> CreateArray<T>(int size)
        {
            MyArrayList_<T> array = new MyArrayList_<T>();

            if (array is MyArrayList_<string>)
            {
                RandomString rString = new RandomString();
                for (int i = 0; i < size; i++)
                {
                    object next = rString.Next(0);
                    array.Add((T)next);
                }

            }
            if (array is MyArrayList_<int>)
            {
                Random rInt = new Random();
                for (int i = 0; i < size; i++)
                {
                    object next = rInt.Next(0, 1000);
                    array.Add((T)next);
                }

            }

            return array;


        }


    }




    class RandomChar
    {
        protected string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public char Next(int minValue)
        {
            Random r = new Random();
            return chars[r.Next(minValue, 62)];
        }

        public int GetCode(char m)
        {
            for (int i = 0; i < chars.Length; i++) if (chars[i] == m) return i;
            return 0;
        }


    }

    class RandomString : RandomChar
    {
        public string Next(char minChar = 'A')
        {
            RandomChar temp = new RandomChar(); Random r = new Random(); string result = string.Empty;

            for (int i = 0; i < r.Next(1, 6); i++)
            {
                result += temp.Next(temp.GetCode(minChar));
            }

            return result;
        }


        public new string Next(int minVal)
        {
            RandomChar temp = new RandomChar(); Random r = new Random(); string result = string.Empty;

            for (int i = 0; i < r.Next(1, 6); i++)
            {
                result += temp.Next(minVal);
            }

            return result;
        }

    }












}
