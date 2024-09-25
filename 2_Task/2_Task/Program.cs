using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace KASD2
{
    internal class Program
    {
        static IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "," }; 
        static void Main(string[] args)
        {
            Complex A = new Complex(0, 0); Complex B = new Complex(0, 0);
            bool tr = true; int d;
            while (tr == true)
            {
                Console.WriteLine("Нажмите соответствующую клавишу для выбора операции:\n" +
                    "L - Ввод числа А\n"+
                    "Q - Завершение работы, выход \n" +
                    "R - Сложение двух чисел \n" +
                    "Y - Вычитание чисел \n" +
                    "U - Умножение чисел \n" +
                    "I - Деление чисел \n" +
                    "F - Нахождение модуля числа \n" +
                    "W - Нахождение аргумента числа \n"+
                    "G - Вывести реальную и мнимую часть числа \n"
                    );
                d = Console.Read(); Console.ReadLine(); 
               
                switch (d)
                {
                    case 133:
                    case 81:
                        tr = false;
                        break;
                    
                    case 76: 
                        Complex.Complex_Input("A", ref A); 
                        break;
                    case 82:
                        Complex.Complex_Input("B", ref B);
                        Console.WriteLine($"A + B = {(A + B).x}, {(A + B).y}");
                        A = A + B;
                        break;
                    case 89:
                        Complex.Complex_Input("B", ref B);
                        Console.WriteLine($"A - B = {(A - B).x}, {(A - B).y}");
                        A = A - B;
                        break;
                    case 85:
                        Complex.Complex_Input("B", ref B);
                        Console.WriteLine($"A x B = {Complex.Mul(A, B).x}, {Complex.Mul(A, B).y}");
                        A = Complex.Mul(A, B);
                        break;
                    case 73:
                        Complex.Complex_Input("B", ref B);
                        Console.WriteLine($"A / B = {(A / B).x}, {(A / B).y}"); 
                        A = A / B;
                        break;
                    case 70:
                        Console.WriteLine($"|A| = {Complex.Module(A)}");
                        break;
                    case 87:
                        Console.WriteLine($"Аргумент числа А {Complex.GetArgument(A)}"); break;
                    case 71:
                        Console.WriteLine($"Действительная часть: {Complex.Re(A)}\n Мнимая часть: {Complex.Im(A)}"); break;
                    default:
                        Console.WriteLine("Неизвестная команда"); break;
                
                }
            }
        }

        public struct Complex
        {
            public float x; public float y;
            public Complex(float a1, float a2)
            {
                x = a1; y = a2;
            }

            public static Complex Add(Complex first, Complex second) { Complex res = new Complex(first.x + second.x, first.y + second.y); return res; }

            public static Complex operator +(Complex first, Complex second) { return Add(first, second); }

            public static Complex operator -(Complex first, Complex second) { Complex res = new Complex(first.x - second.x, first.y - second.y); return res; }

            public static Complex Mul(Complex first, Complex second)
            {
                Complex res = new Complex(first.x * second.x - first.y * second.y, first.x * second.y - first.y * second.x); return res;
            }

            public static double Module(Complex A) { return Math.Sqrt(A.x * A.x + A.y * A.y); }

            public static float Re(Complex A) { return A.x; }

            public static float Im(Complex A) { return A.y; }

            public static Complex operator /(Complex first, Complex second)
            {
                float a = first.x * second.x + first.y * second.y; a /= (second.x * second.x + second.y * second.y);
                float b = first.y * second.x - first.x * second.y; b /= (second.x * second.x + second.y * second.y);
                Complex res = new Complex(a, b); return res;
            }


            public static void Complex_Input(string name_of_cmp, ref Complex A)
            {
                string h;
                Console.WriteLine("Введите действительную часть числа " + name_of_cmp);
                h = Console.ReadLine(); //Console.WriteLine(h);
                if (IsDigitOnly(h) == true)
                {
                    A.x = float.Parse(h, formatter);
                    Console.WriteLine("Введите мнимую часть числа " + name_of_cmp);
                    h = Console.ReadLine(); //Console.WriteLine(h);
                    if (IsDigitOnly(h) == true)
                    {
                        A.y = float.Parse(h, formatter);
                    }
                    else
                    {
                        Console.WriteLine("Введённые символы не являются числом, либо вместо \",\" в числе стоит \".\"");
                        Complex_Input(name_of_cmp, ref A);
                    }
                }
                else
                {
                    Console.WriteLine("Введённые символы не являются числом, либо вместо \",\" в числе стоит \".\"");
                    Complex_Input(name_of_cmp, ref A);
                }

            }

            public static double GetArgument (Complex A)
            {
                double c;
                if (A.x == 0) { c = (A.y > 0) ? Math.PI / 2 : -1 * Math.PI / 2; }
                else
                {
                    c = Math.Atan(A.y / A.x);
                    c += (A.x < 0 && A.y >= 0) ? Math.PI : (A.x < 0 && A.y < 0) ? -1 * Math.PI : 0;
                }
                return c;
               
            }

        }
        
        
        public static bool IsDigitOnly(string str)
        {
            foreach (char c in str)
            {
                if ((c < '0' || c > '9') && c != ',' && c != '-'
                    )  
                return false;
            }

            return true;
        }


    }
}
