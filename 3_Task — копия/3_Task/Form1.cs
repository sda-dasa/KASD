using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Program_3;
using System.Windows.Forms.VisualStyles;
using ZedGraph;
using System.IO;

namespace _3_Task
{
    public partial class Graphic : Form
    {
        public Graphic()
        {
            InitializeComponent();
           
            button2.Visible = false;

            GraphPane pane = Graph.GraphPane; pane.Title.Text = "Зависимость времени сортировки " +
                "\n от размера массивов и вида алгоритма";
            pane.XAxis.Title.Text = "Размер сортируемого массива \n (кол-во элементов)";
            pane.YAxis.Title.Text = "Время сортировки \n (миллисекунды)";

        }


        int[] mas0; int[] mas;

        private void button1_Click(object sender, EventArgs e)
        {
            
            //int[][] mas0 = {
            //    new int[10], new int [10], new int [10], new int [10], new int [10], new int [10], new int [10],
            //    new int[100], new int[100], new int[100], new int[100], new int[100], new int[100], new int[100],
            //    new int[1000], new int[1000], new int[1000], new int[1000], new int[1000], new int[1000], new int[1000],
            //    new int[10000],  new int[10000],  new int[10000],  new int[10000],  new int[10000], new int[10000], new int[10000], new int[10000],
            //    new int[100000],new int[100000], new int[100000], new int[100000], new int[100000], new int[100000], new int[100000], new int[100000],
            //   };
            //int[][] mas = {
            //    new int[10], new int [10], new int [10], new int [10], new int [10], new int [10], new int [10],
            //    new int[100], new int[100], new int[100], new int[100], new int[100], new int[100], new int[100],
            //    new int[1000], new int[1000], new int[1000], new int[1000], new int[1000], new int[1000], new int[1000],
            //    new int[10000],  new int[10000],  new int[10000],  new int[10000],  new int[10000], new int[10000], new int[10000], new int[10000],
            //    new int[100000],new int[100000], new int[100000], new int[100000], new int[100000], new int[100000], new int[100000], new int[100000],
            //   };
            
            
            bool flag = false;
            double[,] times = new double [0,0];
            if (comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1 )
            {
                DialogResult opi = MessageBox.Show("Запустить тесты", "Продолжить?", MessageBoxButtons.OKCancel);
               
                if (opi == DialogResult.OK)
                {
                    long q = 0; int sz = 10; 
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            times = new double [5, 4];
                            
                            for (int j = 0; j <= 3; j++)
                            {
                                for (int i = 0; i <= 4 ; i++)
                                {
                                    mas0 = new int[sz];
                                    mas0 = Make_Mas(sz, comboBox1.SelectedIndex);
                                    mas = new int[sz];
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    times[0, j] += Get_SortTime(mas, Sorts.BubbleSort);
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    times[1, j] += Get_SortTime(mas, Sorts.ShakerSort);
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    times[2, j] += Get_SortTime(mas, Sorts.SelectionSort);
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    times[3, j] += Get_SortTime(mas, Sorts.InsertionSort);
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    times[4, j] += Get_SortTime(mas, Sorts.GnomeSort);
                                }
                                sz *= 10;

                                for (int i = 0; i <= 4; i++) times[i, j] /= 5.0;

                            }
                            flag = true;
                            break;
                        case 1:

                            times = new double[2, 5];
                            
                            for (int j = 0; j <= 4; j++)
                            {
                                for (int i = 0; i <= 4; i++)
                                {
                                    mas0 = new int[sz];
                                    mas0 = Make_Mas(sz, comboBox1.SelectedIndex);
                                    mas = new int[sz];
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    times[0, j] += Get_SortTime(mas, Sorts.ShellSort);
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    times[1, j] += Get_SortTime(mas, null, sort_add: Sorts.Bitonic.BitonicSort, 0, mas.Length, 1);
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    
                                }
                                sz *= 10;

                                for (int i = 0; i <= 1; i++) times[i, j] /= 5.0;

                            }
                            flag = true;
                            break;
                            // q += Get_SortTime(mas, Sorts.Tree.TreeSort);
                        case 2:
                            times = new double[5, 6];
                            for (int j = 0; j <= 5; j++)
                            {
                                for (int i = 0; i <= 4; i++)
                                {
                                    mas0 = new int[sz];
                                    mas0 = Make_Mas(sz, comboBox1.SelectedIndex);
                                    // запихнуть в файл
                                    mas = new int[sz];
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    //times[0, j] += Get_SortTime(mas, null, Sorts.Quick.QuickSort, 0, mas.Length - 1);
                                    times[0, j] += Get_SortTime(mas, Sorts.ClassMerge.MergeSort);
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    times[1, j] += Get_SortTime(mas, Sorts.CountingSort);
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    times[2, j] += Get_SortTime(mas, Sorts.HeapSort.Heap_Sort);
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    times[3, j] += Get_SortTime(mas, Sorts.Comb.CombSort);
                                    Array.Copy(mas0, 0, mas, 0, sz);
                                    times[4, j] += Get_SortTime(mas, null, Sorts.RadixSort, 0, mas.Length, 8);
                                }
                                sz *= 10;

                                for (int i = 0; i <= 4; i++) times[i, j] /= 5.0;

                            }
                            flag = true;
                            break;

                        default: MessageBox.Show("Выберите значения в обоих списках"); break;

                    }


                }


            }
            else MessageBox.Show("Выберите значения в обоих списках");


            if (flag)
            {
                // Сохранить результаты - показать кнопку
                Graph.Visible = true;
                GraphPane pane = Graph.GraphPane; pane.CurveList.Clear();
                PointPairList list = new PointPairList();
                LineItem curve; 

                int K = comboBox2.SelectedIndex == 0 ? 5 : comboBox2.SelectedIndex == 1 ? 2 : 5;

                for (int i = 0; i < K; i++)
                {
                    
                    for (int x = 10, j = 0; j < 4 + comboBox2.SelectedIndex; x *= 10, j++)
                        list.Add(x, times[i, j]);
                                        

                    curve = pane.AddCurve($"{nameSorts[comboBox2.SelectedIndex][i]}",
                        list, colors[i] , SymbolType.Default);
                    curve.Line.Width = 2.5F;

                    list = new PointPairList();

                    Graph.AxisChange();
                    Graph.Invalidate();

                }

                

                button2.Visible = true;

            }


        }


        public delegate int[] SortDelegate(int[] array);
        public delegate int[] SortDelegate_Addition(int[] array, params int [] a);


        private Color[] colors = { Color.Aqua, Color.Red, Color.DarkGreen, Color.LightCoral, Color.Purple};

        private string[][] nameSorts =
        {
            new string [] { "пузырьком", "шейкерная", "выбором", "вставками", "гномья" },
            new string [] { "битонная",  "Шелла", "деревом" },
            new string [] { "слиянием", "подсчётом", "пирамидальная", "расчёской", "поразрядная" }
        };



        public static long Get_SortTime (int[] mas1, SortDelegate sort = null, SortDelegate_Addition sort_add = null, params int [] par)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (sort != null) sort(mas1);
            else if (sort_add != null) sort_add(mas1, par);
            sw.Stop();
            return sw.ElapsedMilliseconds;

        }

        /*
        public static bool Sorted(int[] array) 
        {
            for (int i = 1; i < array.Length; i++) { if (array[i] < array[i - 1]) return false; }
            return true;
        }
        */




       private int[] Make_Mas (int size, int mode)
       {
            int [] ar = new int[size];
            switch (mode)
            {
                case 0:
                    ar = ArraysGroup.FirstGroup_mas(size); break;
                case 1:
                    ar = ArraysGroup.SecondGroup_mas(size); break;
                case 2:
                    ar = ArraysGroup.ThirdGroup_mas(size); break;
                case 3:
                    var sd = new Graphic(); int selected = 50;
                    if (sd.repeated_el.SelectedItem != null) selected = (int) sd.repeated_el.SelectedItem;
                    ar = ArraysGroup.FourthGroup_mas(size, selected);
                    break;
                default: MessageBox.Show("Выберите значения в обоих списках"); break;

            }
            return ar;
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            
            string path = "_saved_.txt";
            using (StreamWriter writer = new StreamWriter(path, true, Encoding.ASCII))
            {
                for (int i = 0; i<= mas.Length - 1; i++) await writer.WriteAsync($"{mas[i]}");
                for (int i = 0; i <= mas.Length - 1; i++) await writer.WriteAsync($"{mas0[i]}");
            }

        }

        
    }


}


