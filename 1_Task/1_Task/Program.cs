﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _1st_Task
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        // метод для перемножения вектора на матрицу
        public static int[] mul_matr(int[] a, int[,] b, int N, int M)
        {

            int[] res_1 = new int[N];
            for (int j = 0; j <= N - 1; j++)
            {
                for (int i = 0; i <= M - 1; i++)
                {
                    res_1[j] += b[i, j] * a[i];
                }

            }
            return res_1;
        }
        // метод, определяющий, симметричная ли матрица или нет
        public static bool simmetrial(int[,] matr, int N)
        {
            for (int i = 0; i <= N - 1; i++)
            {
                for (int j = i + 1; j <= N - 1; j++)
                {
                    if (matr[i, j] != matr[j, i])
                    {
                        Console.WriteLine("Матрица не симметричная и не является матрицей тензора!");
                        return false;
                    }
                }
            }
            return true;
        }

        //метод для определения длины вектора в заданном N-мерном пространстве
        public static void vector_lenght(string file_name) // file_name - путь к файлу с данными
        {

            Console.WriteLine("Ваши данные из файла:");

            bool conditionsright = true; // показывает есть ли несоответствия данных в файле
                                         // если переменная становится false - есть ошибки в данных

            string file = file_name;
            int[,] f = new int [1, 1]; int[] x = new int [1];
            var textFile = new StreamReader(file);
            string line = textFile.ReadLine(); int N = Convert.ToInt32(line);
            // определили размерность пространства
            if (N <= 0)
            {
                Console.WriteLine("Размерность пространства должна быть натуральным числом");
                conditionsright = false;
            }
            if (conditionsright)
            {
                Console.WriteLine($"N = {N} \nМатрица: \n");

                f = new int[N, N]; // матрица тензора

                line = textFile.ReadLine();


                x = new int[N];
                // записываем в f соответствующие значения из файла
                for (int j = 0; j <= N - 1 && conditionsright != false; j++)
                {
                    if (line == null || line == "" || N != line.Split().Length)
                    {
                        conditionsright = false; Console.WriteLine("Размерность матрицы не совпадает с размерностью пространства");
                    }
                    else
                    {
                        for (int i = 0; i <= N - 1; i++)
                        {
                            f[j, i] = Convert.ToInt32(line.Split()[i]); Console.Write($"{f[j, i]}  ");
                        }
                        line = textFile.ReadLine();
                        Console.Write("\n");
                    }
                }
            }
            // если в записи матрицы в файле ошибок нет - считываем данные для вектора
            if (conditionsright)
            {
                if (line != null && line != "")
                {
                    if (line.Split().Length == N) // длина исходного вектора должна совпадать с размерностью матрицы
                    {
                        Console.WriteLine("Вектор: \n");
                        for (int i = 0; i <= line.Split().Length - 1; i++)
                        {
                            x[i] = Convert.ToInt32(line.Split()[i]); Console.Write($"{x[i]}  ");
                        }
                        if (textFile.ReadLine() != null && textFile.ReadLine() != "")
                        {
                            Console.WriteLine("Матрица не квадратная и не является матрицей тензора!"); conditionsright = false;
                            // последней строкой в файле должен быть вектор - если есть ещё строки, они относятся к матрице, но являются лишними
                        }
                        Console.Write($"\n");
                        conditionsright &= simmetrial(f, N); // проверка на симметричность матрицы
                    }
                    else { Console.WriteLine("Длина вектора не совпадает с размерностью матрицы"); conditionsright = false; }
                }
                else { Console.WriteLine("Не найдено указание исходного вектора или матрица не является квадратной"); conditionsright = false; }
                // строки, отвечающей за описание вектора нет, если предыдущую строку рассматривать,
                // как вектор, то матрица уже не будет соответствовать необходимой размерности
            }

            // если все данные верны, то находим длину вектора
            if (conditionsright)
            {
                int[] res = mul_matr(x, f, N, N); // получаем сначала вектор -  произведение x на матрицу тензора
                int[,] x_tr = new int[N, 1]; for (int i = 0; i <= N - 1; i++) x_tr[i, 0] = x[i]; //формируем транспонированный вектор
                res = mul_matr(res, x_tr, 1, N); //получаем конечный результат
                Console.WriteLine($"Длина вектора x в данном N-мерном пространстве = {(int)Math.Sqrt(res[0])}");

            }

        }

        static void Main()
        {
            string a = @"_data_.txt"; //путь к вашему файлу
            vector_lenght(a);


        }











    }
}