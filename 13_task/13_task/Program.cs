using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using _13_task;
using System.Collections;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Program_3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Graphic());

            //ArraysGroup.SecondGroup_mas(10);

            //Pair p = new Pair(); Pair[] pairs = new Pair[4]; for (int i = 0; i < 4; i++)
            //{
            //    pairs[i] = new Pair(4-i, 4-i);
            //}

            //object[] mas = pairs;
            //Sorts<Pair> n = new Sorts<Pair>(p);

            //n.BubbleSort(ref pairs);

            //for (int i = 0; i < 4; i++) Console.WriteLine($"{pairs[i].First}   {pairs[i].Second}");


        }



    }


    class Pair: IComparer<Pair>, IComparable<Pair>
    {
        
        public int First { get; set; }
        public int Second { get; set; }
        public Pair (int first = 0, int second = 0)
        {
            this.First = first; this.Second = second;

        }


        public int CompareTo(Pair other) 
        {

            if (other is null) throw new ArgumentException("Не корректное значение параметра");

            return (this.First + this.Second).CompareTo(other.First + other.Second);


        } // !!!! реализовать!!!

        public int Compare(Pair pair1, Pair pair2)
        {

            if (pair1 is null || pair2 is null) throw new ArgumentException("Не корректное значение параметра");
                       
            return (pair1.First + pair1.Second).CompareTo(pair2.First + pair2.Second);

            throw new NotImplementedException();

        }

        public Pair Next(int minVal, int maxVal)
        {
            Random r = new Random(); Pair res = new Pair(minVal, maxVal);

            res.First = r.Next(); res.Second = r.Next(); return res;

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

    class RandomString: RandomChar
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

    

    internal class ArraysGroup
    {

        public static void FourthGroup_mas(int size, ref object [] mas, byte type_, bool order = true) // byte type_
        {
            //T [] array = new T [size];
            //Random rInt = new Random();

            RandomChar rChar = new RandomChar();
            RandomString rString = new RandomString();
            if (mas is null) return;

            if (mas.Length < size) mas = new object[size];

            if (order)
            {
                //array[0] = r.Next(200, 1000);
                //for (int i = 1; i <= size - 1; i++) array[i] = r.Next(array[i - 1], 1000);
               
                switch (type_)
                {
                    case 0:
                        {
                            mas[0] = rString.Next('A');
                            for (int i = 1; i <= size - 1; i++) mas[i] = rString.Next(Convert.ToString(mas[i - 1])[0]);
                            break;
                        }
                    case 1:
                        {
                            mas[0] = rChar.Next(0);
                            for (int i = 1; i <= size - 1; i++) mas[i] = rChar.Next(rChar.GetCode((char)mas[i-1]));
                            break;
                        }
                    default: break;
                }

            }
            else
            {
                //array[size - 1] = r.Next(0, 100);
                //for (int i = size - 2; i >= 0; i--) array[i] = r.Next(array[i + 1], 1000);

                switch (type_)
                {
                    case 0:
                        {
                            mas[size - 1] = rString.Next('A');
                            for (int i = size - 2; i >= 0; i--) mas[i] = rString.Next(Convert.ToString(mas[i + 1])[0]);
                            break;
                        }
                    case 1:
                        {
                            mas[0] = rChar.Next(0);
                            for (int i = size - 2; i >= 0; i--) mas[i] = rChar.Next(rChar.GetCode((char)mas[i + 1]));
                            break;
                        }
                    default: break;
                }




            }
            

        }

        public static void FourthGroup_mas(int size, ref object[] mas, byte type_, int repeat_elemet_part = 50)
        {
            //int[] array = new int[size]; Random r = new Random();
            //for (int i = 0; i < size; i++) array[i] = r.Next(0, 1000);
            //int rep = r.Next(0, 1000);
            //for (int i = 0; i <= size * repeat_elemet_part / 100.0; i++)
            //    array[r.Next(0, size)] = rep;

            //return array;
            Random r = new Random();
            if (mas is null) return;
            if (mas.Length < size) mas = new object [size];

            switch (type_)
            {
                
                case 0:
                    {
                        RandomString rString = new RandomString();

                        for (int i = 0; i< size; i++)
                        {
                            mas[i] = rString.Next(0);
                        }

                        string rep = rString.Next(0);
                        
                        for (int i = 0; i <= size * repeat_elemet_part / 100.0; i++)
                            mas[r.Next(0, size)] = rep;

                        break;
                    }
                case 1:
                    {
                        RandomChar rChar = new RandomChar();

                        for (int i = 0; i < size; i++)
                        {
                            mas[i] = rChar.Next(0);
                        }

                        char rep = rChar.Next(0);

                        for (int i = 0; i <= size * repeat_elemet_part / 100.0; i++)
                            mas[r.Next(0, size)] = rep;

                        break;
                    }
                default: break;

            }



        }


        public static void ThirdGroup_mas(int size, ref object[] mas, byte type_)
        {
            //int[] array = new int[size]; Random r = new Random(); array[0] = r.Next(0, 1000);
            //for (int i = 1; i <= size - 1; i++) array[i] = r.Next(array[i - 1], 1000);
            //for (int i = 0; i <= r.Next(3, 20); i++) array[r.Next(0, size)] = array[r.Next(0, size)];
            //return array;
                        
            if (mas is null) return;
            if (mas.Length < size) mas = new object[size];
            Random r = new Random();
            switch (type_)
            {
                case 0:
                    {
                        RandomString rString = new RandomString();
                        mas[0] = rString.Next('A');
                        for (int i = 1; i <= size - 1; i++) mas[i] = rString.Next(Convert.ToString(mas[i - 1])[0]);
                        break;
                    }
                case 1:
                    {
                        RandomChar rChar = new RandomChar();
                        mas[0] = rChar.Next(0);
                        for (int i = 1; i <= size - 1; i++) mas[i] = rChar.Next(rChar.GetCode((char)mas[i - 1]));
                        break;
                    }
                default: break;

            }

            for (int i = 0; i <= r.Next(3, 20); i++) mas[r.Next(0, size)] = mas[r.Next(0, size)];


        }

        public static void SecondGroup_mas(int size, ref object[] mas, byte type_)
        {
            //int[] array = new int[size]; int subsize; Random r = new Random(); int i = 0;

            //while (size != 0)
            //{
            //    subsize = r.Next(1, size + 1);
            //    for (int j = i; j <= subsize + i - 1; j++)
            //    {
            //        if (j == i) array[j] = r.Next(0, 10000);
            //        else array[j] = r.Next(array[j - 1], 10000);
            //    }
            //    i += subsize;

            //    size = size - subsize;
            //}

            //return array;

            if (mas is null) return; if (mas.Length < size) mas = new object[size];

            Random r = new Random(); int i = 0; int subsize;

            switch (type_)
            {
                case 0:
                    {
                        RandomString rString = new RandomString();
                        while (size != 0)
                        {
                            subsize = r.Next(1, size + 1);
                            for (int j = i; j <= subsize + i - 1; j++)
                            {
                                if (j == i) mas[j] = mas[i] = rString.Next(Convert.ToString(mas[i - 1])[0]);
                                else mas[j] = rString.Next(0);
                            }
                            i += subsize;

                            size = size - subsize;
                        }
                        break;
                    }
                case 1:
                    {
                        RandomChar rChar = new RandomChar();
                        while (size != 0)
                        {
                            subsize = r.Next(1, size + 1);
                            for (int j = i; j <= subsize + i - 1; j++)
                            {
                                if (j == i) mas[j] = mas[i] = rChar.Next(rChar.GetCode((char)mas[i - 1]));
                                else mas[j] = rChar.Next(0);
                            }
                            i += subsize;

                            size = size - subsize;
                        }
                        break;
                    }
                default: break;


            }




        }

        public static void FirstGroup_mas(int size, ref object[] mas ,byte type_)
        {
            //Random r = new Random(); int[] a = new int[size];
            //for (int i = 0; i <= size - 1; i++) a[i] = r.Next(0, 1000);
            //return a;
            if (mas is null) return;
            if (mas.Length < size ) mas = new object[size];
            switch (type_)
            {
                case 0:
                    {
                        RandomString rString = new RandomString();
                        for (int i = 0; i <= size - 1; i++) mas[i] = rString.Next(0);

                        break;
                    }
                case 1:
                    {
                        RandomChar rChar = new RandomChar();
                        for (int i = 0; i <= size - 1; i++) mas[i] = rChar.Next(0);

                        break;
                    }
                default: break;


            }


        }

    }

    

    internal class Sorts<T> where T : IComparable<T>
    {

        private IComparable<T> comparator;


        public Sorts(IComparable<T> comparator) 
        {
            this.comparator = comparator;
        }

        public int CompareTo(T obj) => comparator.CompareTo(obj);


        public int Compare(T f, T s) => f.CompareTo(s);
        


        private static void Swap(ref T e1, ref T e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        public void BubbleSort(ref T[] array)
        {
            int len = array.Length;
            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < len - i; j++)
                {
                    if (Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

        }

        public void ShakerSort(ref T[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                bool swapFlag = false;

                for (int j = i; j < array.Length - i - 1; j++)
                {
                    if (Compare(array[j], array[j+1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }


                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (Compare(array[j-1], array[j]) > 0)
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }
                        
        }

        public void InsertionSort(ref T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && Compare(array[j-1], array[j]) > 0)
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }
            }
            
        }


        public void SelectionSort(ref T[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                if (i == array.Length)
                    return;

                int result = i;
                for (int j = i; j < array.Length; ++j)
                {
                    if (Compare(array[result], array[j]) > 0)
                    {
                        result = j;
                    }
                }

                int index = result;

                if (index != i)
                {
                    Swap(ref array[index], ref array[i]);
                }

            }
                        
        }


        public void GnomeSort(ref T[] array)
        {
            int index = 1;
            int nextIndex = index + 1;

            while (index < array.Length)
            {
                if (Compare(array[index], array[index - 1]) > 0)
                {
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    Swap(ref array[index - 1], ref array[index]);
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex;
                        nextIndex++;
                    }
                }
            }

        }


        public void ShellSort(ref T[] array)
        {
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (Compare(array[j - d], array[j]) > 0))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }

        }

        public class Tree
        {
            public Tree(int data) { info = data; }
            public int info;
            public Tree L { get; set; }
            public Tree R { get; set; }
            public void Insert(int x)
            {
                if (x < info)
                {
                    if (L == null)
                    {
                        Tree q = new Tree(x) { L = null, R = null }; L = q;
                    }
                    else L.Insert(x);
                }
                else
                {
                    if (R == null) { Tree q = new Tree(x) { L = null, R = null }; R = q; }
                    else R.Insert(x);
                }

            }
            static int k = 0;
            public static void Input(int[] array, Tree t)
            {

                if (t != null && k < array.Length)
                {
                    Input(array, t.L);
                    array[k] = t.info; k++;
                    Input(array, t.R);
                }

            }

            public static int[] TreeSort(int[] array)
            {
                Tree for_sort = new Tree(array[0]);
                for (int i = 1; i < array.Length; i++) for_sort.Insert(array[i]);

                Input(array, for_sort);
                return array;
            }

        }

        private void CompareAndSwap(ref T[] array, int i, int j, int direction)
        {
            int k; k = Compare(array[j], array[i]) > 0 ? 1 : 0;
            if (direction == k) Swap(ref array[i], ref array[j]);

        }

        private void BitonicMerge(ref T[] array, int low, int count, int direction)
        {
            if (count > 1)
            {
                int k = count / 2;
                for (int i = low; i < low + k; i++)
                {
                    CompareAndSwap(ref array, i, i + k, direction);
                }
                BitonicMerge(ref array, low, k, direction);
                BitonicMerge(ref array, low + k, k, direction);
            }
        }


        public void BitonicSort(ref T[] array, params int[] param)
        {
            if (param[1] > 1)
            {
                int k = param[1] / 2;
                BitonicSort(ref array, param[0], k, 1);
                BitonicSort(ref array, param[0] + k, k, 0);
                BitonicMerge(ref array, param[0], param[1], param[2]);
            }
            
        }




        static int GetNextGap(int gap)
        {
            gap = (gap * 10) / 13;
            if (gap < 1)
            {
                return 1;
            }
            return gap;
        }


        public void CombSort(ref T[] array)
        {
            int length = array.Length; int gap = length; bool swapped = true;

            while (gap != 1 || swapped == true)
            {
                gap = GetNextGap(gap);
                swapped = false;

                //Compare all elements with current gap 
                for (int i = 0; i < length - gap; i++)
                {
                    if (Compare(array[i], array[i + gap]) > 0)
                    {
                        //Swap
                        Swap(ref array[i], ref array[i + gap]);

                        swapped = true;
                    }
                }
            }
            
        }


        private int Partition(T[] array, int low, int high)
        {
            //1. Select a pivot point.
            T pivot = array[high];

            int lowIndex = (low - 1);

            //2. Reorder the collection.
            for (int j = low; j < high; j++)
            {
                if (Compare(pivot, array[j]) >= 0)
                {
                    lowIndex++;

                    T temp = array[lowIndex];
                    array[lowIndex] = array[j];
                    array[j] = temp;
                }
            }

            T temp1 = array[lowIndex + 1];
            array[lowIndex + 1] = array[high];
            array[high] = temp1;

            return lowIndex + 1;

        }

        public void QuickSort(ref T[] array, params int[] low_high)
        {
            if (low_high[0] < low_high[1])
            {
                int partitionIndex = Partition(array, low_high[0], low_high[1]);

                //3. Recursively continue sorting the array
                QuickSort(ref array, low_high[0], partitionIndex - 1);
                QuickSort(ref array, partitionIndex + 1, low_high[1]);
            }
            

        }



        //public T[] CountingSort(T[] array)
        //{
        //    //поиск минимального и максимального значений
        //    var min = array[0];
        //    var max = array[0];
        //    foreach (T element in array)
        //    {
        //        if (this.CompareTo(element) < this.CompareTo(max))
        //        {
        //            max = element;
        //        }
        //        else if (this.CompareTo(element) > this.CompareTo(max))
        //        {
        //            min = element;
        //        }
        //    }

        //    //поправка
        //    var correctionFactor = min != 0 ? -min : 0;
        //    max += correctionFactor;

        //    var count = new int[max + 1];
        //    for (var i = 0; i < array.Length; i++)
        //    {
        //        count[array[i] + correctionFactor]++;
        //    }

        //    var index = 0;
        //    for (var i = 0; i < count.Length; i++)
        //    {
        //        for (var j = 0; j < count[i]; j++)
        //        {
        //            array[index] = i - correctionFactor;
        //            index++;
        //        }
        //    }

        //    return array;


        //}





        private void Merge(T[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new T[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (Compare(array[right], array[left]) > 0)
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }


        void Sort(ref T[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                Sort(ref array, lowIndex, middleIndex);
                Sort(ref array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

        }

        public void MergeSort(ref T[] array)
        {
            Sort(ref array, 0, array.Length - 1);
        }





        //public static int[] RadixSort(int[] array, params int[] lrn) //int l, int r, int N = 8)
        //{
        //    if (lrn[2] == 0) lrn[2] = 8;
        //    int k = (32 + lrn[2] - 1) / lrn[2];
        //    int M = 1 << lrn[2];
        //    int sz = array[lrn[1] - 1] - array[lrn[0]];
        //    int[] b = new int[sz];
        //    int[] c = new int[M];
        //    for (int i = 0; i < k; i++)
        //    {
        //        for (int j = 0; j < M; j++)
        //            c[j] = 0;
        //        for (int j = lrn[0]; j < lrn[1]; j++)
        //            c[array[j] >> (lrn[2] * i) & (M - 1)]++;
        //        for (int j = 1; j < M; j++)
        //            c[j] += c[j - 1];
        //        for (int j = lrn[1] - 1; j >= lrn[0]; j--)
        //            b[--c[array[j] >> (lrn[2] * i) & (M - 1)]] = array[j];
        //        int cur = 0;
        //        for (int j = lrn[0]; j < lrn[1]; j++)
        //            array[j] = b[cur++];
        //    }
        //    return array;

        //}


        public void Heap_Sort(ref T[] array)
        {
            var length = array.Length;
            for (int i = length / 2 - 1; i >= 0; i--)
            {
                Heapify(array, length, i);
            }
            for (int i = length - 1; i >= 0; i--)
            {
                T temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Heapify(array, i, 0);
            }


        }


        private void Heapify(T[] array, int length, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < length && Compare(array[left], array[largest]) > 0)
            {
                largest = left;
            }
            if (right < length && Compare(array[right], array[largest]) > 0)
            {
                largest = right;
            }
            if (largest != i)
            {
                T swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                Heapify(array, length, largest);
            }



        }





    }



}
