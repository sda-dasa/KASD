using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3_Task;

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

            ArraysGroup.SecondGroup_mas(10);

        }



    }

    internal class ArraysGroup
    {

        public static int[] FourthGroup_mas(int size, bool order = true)
        {
            int[] array = new int[size]; Random r = new Random();
            if (order)
            {
                array[0] = r.Next(200, 1000); 
                for (int i = 1; i <= size - 1; i++) array[i] = r.Next(array[i - 1], 1000);
            }
            else
            {
                array[size-1] = r.Next(0, 100);
                for (int i = size - 2; i >= 0; i--) array[i] = r.Next(array[i + 1], 1000);
            }
            return array;

        }

        public static int[] FourthGroup_mas(int size, int repeat_elemet_part = 50)
        {
            int[] array = new int[size]; Random r = new Random();
            for (int i = 0; i < size; i++) array[i] = r.Next(0, 1000);
            int rep = r.Next(0, 1000);
            for (int i = 0; i<= size * repeat_elemet_part / 100.0; i++)
                array[r.Next(0, size)] = rep;

            return array;
        }


        public static int[] ThirdGroup_mas(int size)
        {
            int[] array = new int[size]; Random r = new Random(); array[0] = r.Next(0, 1000);
            for (int i = 1; i <= size - 1; i++) array[i] = r.Next(array[i - 1], 1000);
            for (int i = 0; i <= r.Next(3, 20); i++) array[r.Next(0, size)] = array[r.Next(0, size)];
            return array;

        }

        public static int[] SecondGroup_mas(int size)
        {
            int[] array = new int[size]; int subsize; Random r = new Random(); int i = 0;

            while (size != 0)
            {
                subsize = r.Next(1, size + 1);
                for (int j = i; j <= subsize + i - 1; j++)
                {
                    if (j == i) array[j] = r.Next(0, 10000);
                    else array[j] = r.Next(array[j - 1], 10000);
                }
                i += subsize;

                size = size - subsize;
            }

            return array;

        }

        public static int[] FirstGroup_mas(int size)
        {
            Random r = new Random(); int[] a = new int[size];
            for (int i = 0; i <= size - 1; i++) a[i] = r.Next(0, 1000);
            return a;

        }

    }




    internal class Sorts
    {

        private static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        public static int[] BubbleSort(int[] array)
        {
            int len = array.Length;
            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return array;
        }

        public static int[] ShakerSort(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                bool swapFlag = false;

                for (int j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }


                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
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

            return array;
        }

        public static int[] InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j - 1] > array[j])
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }
            }
            return array;
        }


        public static int[] SelectionSort (int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                if (i == array.Length)
                    return array;

                int result = i;
                for (int j = i; j < array.Length; ++j)
                {
                    if (array[j] < array[result])
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

            return array;

        }


        public static int[] GnomeSort(int[] array)
        {
            int index = 1;
            int nextIndex = index + 1;

            while (index < array.Length)
            {
                if (array[index - 1] < array[index])
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

            return array;
        }


        public static int[] ShellSort(int[] array)
        {
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
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

        public class Bitonic
        {
            private static void CompareAndSwap(int[] array, int i, int j, int direction)
            {
                int k; k = array[i] > array[j] ? 1 : 0;
                if (direction == k) Swap(ref array[i], ref array[j]);

            }

            private static void BitonicMerge(int[] array, int low, int count, int direction)
            {
                if (count > 1)
                {
                    int k = count / 2;
                    for (int i = low; i < low + k; i++)
                    {
                        CompareAndSwap(array, i, i + k, direction);
                    }
                    BitonicMerge(array, low, k, direction);
                    BitonicMerge(array, low + k, k, direction);
                }
            }


            public static int[] BitonicSort(int[] array, params int[] param)
            {
                if (param[1] > 1)
                {
                    int k = param[1] / 2;
                    BitonicSort(array, param[0], k, 1);
                    BitonicSort(array, param[0] + k, k, 0);
                    BitonicMerge(array, param[0], param[1], param[2]);
                }
                return array;
            }

        }

        public class Comb
        {
            static int GetNextGap(int gap)
            {
                gap = (gap * 10) / 13;
                if (gap < 1)
                {
                    return 1;
                }
                return gap;
            }


            public static int[] CombSort (int[] array)
            {
                int length = array.Length; int gap = length; bool swapped = true;

                while (gap != 1 || swapped == true)
                {
                    gap = GetNextGap(gap);
                    swapped = false;

                    //Compare all elements with current gap 
                    for (int i = 0; i < length - gap; i++)
                    {
                        if (array[i] > array[i + gap])
                        {
                            //Swap
                            Swap(ref array[i], ref array[i + gap]);

                            swapped = true;
                        }
                    }
                }
                return array;

            }

        }

        public class Quick
        {
            private static int Partition(int[] array, int low, int high)
            {
                //1. Select a pivot point.
                int pivot = array[high];

                int lowIndex = (low - 1);

                //2. Reorder the collection.
                for (int j = low; j < high; j++)
                {
                    if (array[j] <= pivot)
                    {
                        lowIndex++;

                        int temp = array[lowIndex];
                        array[lowIndex] = array[j];
                        array[j] = temp;
                    }
                }

                int temp1 = array[lowIndex + 1];
                array[lowIndex + 1] = array[high];
                array[high] = temp1;

                return lowIndex + 1;

            }

            public static int [] QuickSort(int[] array, params int[] low_high)
            {
                if (low_high[0] < low_high[1])
                {
                    int partitionIndex = Partition(array, low_high[0], low_high[1]);

                    //3. Recursively continue sorting the array
                    QuickSort(array, low_high[0], partitionIndex - 1);
                    QuickSort(array, partitionIndex + 1, low_high[1]);
                }
                return array;

            }

        }


        public static int[] CountingSort(int[] array)
        {
            //поиск минимального и максимального значений
            var min = array[0];
            var max = array[0];
            foreach (int element in array)
            {
                if (element > max)
                {
                    max = element;
                }
                else if (element < min)
                {
                    min = element;
                }
            }

            //поправка
            var correctionFactor = min != 0 ? -min : 0;
            max += correctionFactor;

            var count = new int[max + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[array[i] + correctionFactor]++;
            }

            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i - correctionFactor;
                    index++;
                }
            }

            return array;
        }


        public class ClassMerge
        {
            private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
            {
                var left = lowIndex;
                var right = middleIndex + 1;
                var tempArray = new int[highIndex - lowIndex + 1];
                var index = 0;

                while ((left <= middleIndex) && (right <= highIndex))
                {
                    if (array[left] < array[right])
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


            static int[] Sort(int[] array, int lowIndex, int highIndex)
            {
                if (lowIndex < highIndex)
                {
                    var middleIndex = (lowIndex + highIndex) / 2;
                    Sort(array, lowIndex, middleIndex);
                    Sort(array, middleIndex + 1, highIndex);
                    Merge(array, lowIndex, middleIndex, highIndex);
                }

                return array;
            }

            public static int[] MergeSort(int[] array)
            { 
                return Sort(array, 0, array.Length - 1);
            }


        }


        
        public static int [] RadixSort(int [] array, params int[] lrn) //int l, int r, int N = 8)
        {
            if (lrn[2] == 0) lrn[2] = 8;
            int k = (32 + lrn[2] - 1) / lrn[2];
            int M = 1 << lrn[2];
            int sz = array[lrn[1] - 1] - array[lrn[0]];
            int [] b = new int[sz];
            int [] c = new int[M];
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < M; j++)
                    c[j] = 0;
                for (int j = lrn[0]; j < lrn[1]; j++)
                    c[array[j] >> (lrn[2] * i) & (M - 1)]++;
                for (int j = 1; j < M; j++)
                    c[j] += c[j - 1];
                for (int j = lrn[1] - 1; j >= lrn[0]; j--)
                    b[--c[array[j] >> (lrn[2] * i) & (M - 1)]] = array[j];
                int cur = 0;
                for (int j = lrn[0]; j < lrn[1]; j++)
                    array[j] = b[cur++];
            }
            return array;

        }

        public class HeapSort
        {
            public static int[] Heap_Sort(int[] array)
            {
                var length = array.Length;
                for (int i = length / 2 - 1; i >= 0; i--)
                {
                    Heapify(array, length, i);
                }
                for (int i = length - 1; i >= 0; i--)
                {
                    int temp = array[0];
                    array[0] = array[i];
                    array[i] = temp;
                    Heapify(array, i, 0);
                }

                return array;

            }

            
            private static void Heapify(int[] array, int length, int i)
            {
                int largest = i;
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                if (left < length && array[left] > array[largest])
                {
                    largest = left;
                }
                if (right < length && array[right] > array[largest])
                {
                    largest = right;
                }
                if (largest != i)
                {
                    int swap = array[i];
                    array[i] = array[largest];
                    array[largest] = swap;
                    Heapify(array, length, largest);
                }
            }

        }

        

    }

}
