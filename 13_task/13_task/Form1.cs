//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace _13_task
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }
//    }
//}


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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _13_task
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

            //string e = "zstr"; string r = "string2"; int d = e.CompareTo(r);
            //MessageBox.Show($"{d}");

            //char y = 'x'; char s = 'y'; d = y.CompareTo(s);


        }


        object[] mas0; object[] mas;

        private void button1_Click(object sender, EventArgs e)
        {

            bool flag = false;
            double[,] times = new double[0, 0];
            if (comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1 && type_for_sort.SelectedIndex > -1)
            {
                DialogResult opi = MessageBox.Show("Запустить тесты", "Продолжить?", MessageBoxButtons.OKCancel);

                if (opi == DialogResult.OK)
                {
                    int sz = 10;
                    switch (comboBox2.SelectedIndex) // вид сортировок 
                    {
                        case 0:
                            {
                                times = new double[5, 4];
                                //object[] mas0 = new object[sz]; object[] mas1 = new object[sz];

                                switch (type_for_sort.SelectedIndex)
                                {

                                    case 0: // string
                                        {
                                            for (int j = 0; j <= 3; j++)
                                            {
                                                for (int i = 0; i <= 3; i++)
                                                {
                                                    object[] mas0 = new string[sz]; object[] mas1 = new string[sz];

                                                    Make_Mas(sz, ref mas0, comboBox1.SelectedIndex, 0);
                                                    Array.Copy(mas0, 0, mas1, 0, sz);
                                                    string default_comp = string.Empty;
                                                    Sorts<string> rString = new Sorts<string>(default_comp);

                                                    times[0, j] += Get_SortTime<string>((string[])mas1, rString.BubbleSort);
                                                    Array.Copy(mas0, 0, mas1, 0, sz);
                                                    
                                                    times[1, j] += Get_SortTime<string>((string[])mas1, rString.ShakerSort);
                                                    Array.Copy(mas0, 0, mas1, 0, sz);
                                                    times[2, j] += Get_SortTime<string>((string[])mas1, rString.SelectionSort);
                                                    Array.Copy(mas0, 0, mas1, 0, sz);
                                                    times[3, j] += Get_SortTime<string>((string[])mas1, rString.InsertionSort);
                                                    Array.Copy(mas0, 0, mas1, 0, sz);
                                                    times[4, j] += Get_SortTime<string>((string[])mas1, rString.GnomeSort);

                                                }
                                                
                                                sz *= 10;

                                                for (int i = 0; i <= 4; i++) times[i, j] /= 4.0;

                                            }
                                            flag = true;
                                            break;
                                        }
                                    case 1:
                                        {
                                            // char
                                            //{
                                            //    for (int j = 0; j <= 3; j++)
                                            //    {
                                            //        for (int i = 0; i <= 3; i++)
                                            //        {
                                            //            object[] mas0 = new object[sz]; object[] mas1 = new object[sz];
                                            //            Make_Mas(sz, ref mas0, comboBox1.SelectedIndex, 0);
                                            //            Array.Copy(mas0, 0, mas1, 0, sz);

                                            //            char default_comp = 'z';
                                            //            Sorts<char> rChar = new Sorts<char>(default_comp);

                                            //            times[0, j] += Get_SortTime<char>(mas1, rChar.BubbleSort);
                                            //            Array.Copy(mas0, 0, mas1, 0, sz);
                                            //            times[1, j] += Get_SortTime<string>((string[])mas1, rChar.ShakerSort);
                                            //            Array.Copy(mas0, 0, mas1, 0, sz);
                                            //            times[2, j] += Get_SortTime<string>((string[])mas1, rString.SelectionSort);
                                            //            Array.Copy(mas0, 0, mas1, 0, sz);
                                            //            times[3, j] += Get_SortTime<string>((string[])mas1, rString.InsertionSort);
                                            //            Array.Copy(mas0, 0, mas1, 0, sz);
                                            //            times[4, j] += Get_SortTime<string>((string[])mas1, rString.GnomeSort);

                                            //        }

                                            //        sz *= 10;

                                            //        for (int i = 0; i <= 4; i++) times[i, j] /= 4.0;
                                            //    }

                                            // сделать для Pair

                                            flag = true;
                                            break;
                                        }
                                    default: break;
                                }

                                break;

                            }
                        case 1:
                            {
                                times = new double[2, 5];
                                switch (type_for_sort.SelectedIndex)
                                {

                                    case 0: // string
                                        {
                                            for (int j = 0; j <= 4; j++)
                                            {
                                                for (int i = 0; i <= 4; i++)
                                                {
                                                    object[] mas0 = new string[sz]; object[] mas1 = new string[sz];

                                                    Make_Mas(sz, ref mas0, comboBox1.SelectedIndex, 0);
                                                    Array.Copy(mas0, 0, mas1, 0, sz);
                                                    string default_comp = string.Empty;
                                                    Sorts<string> rString = new Sorts<string>(default_comp);

                                                    times[0, j] += Get_SortTime<string>((string[])mas1, rString.ShellSort);
                                                    Array.Copy(mas0, 0, mas1, 0, sz);
                                                    times[1, j] += Get_SortTime<string>((string[])mas1, sort_add: rString.BitonicSort);

                                                }

                                                sz *= 10;

                                                for (int i = 0; i <= 4; i++) times[i, j] /= 5.0;

                                            }
                                            flag = true;
                                            break;

                                        }
                                    case 1: // Pair
                                        {
                                            break;
                                        }
                                    default: break;
                                }

                                break;
                            }
                        case 2:
                            {
                                times = new double[5, 6];
                                switch (type_for_sort.SelectedIndex)
                                {
                                    case 0:
                                        {
                                            for (int j = 0; j <= 3; j++)
                                            {
                                                for (int i = 0; i <= 3; i++)
                                                {
                                                    object[] mas0 = new string[sz]; object[] mas1 = new string[sz];

                                                    Make_Mas(sz, ref mas0, comboBox1.SelectedIndex, 0);
                                                    Array.Copy(mas0, 0, mas1, 0, sz);
                                                    string default_comp = string.Empty;
                                                    Sorts<string> rString = new Sorts<string>(default_comp);

                                                    times[0, j] += Get_SortTime<string>((string[])mas1, rString.MergeSort);
                                                    Array.Copy(mas0, 0, mas1, 0, sz);
                                                    times[1, j] += Get_SortTime<string>((string[])mas1, rString.Heap_Sort);
                                                    Array.Copy(mas0, 0, mas1, 0, sz);
                                                    times[2, j] += Get_SortTime<string>((string[])mas1, rString.CombSort);
                                                   
                                                }

                                                sz *= 10;

                                                for (int i = 0; i <= 4; i++) times[i, j] /= 5.0;

                                            }
                                            flag = true;
                                            break;
                                        }
                                    case 1:
                                        {
                                            flag = true;
                                            break;
                                        }
                                    default: break;

                                }

                                break;

                            }
                        default: MessageBox.Show("Выберите значения в обоих списках"); break;

                    }


                }


            }
            else MessageBox.Show("Выберите значения во всех списках");


            if (flag)
            {
                // Сохранить результаты - показать кнопку
                Graph.Visible = true;
                GraphPane pane = Graph.GraphPane; pane.CurveList.Clear();
                PointPairList list = new PointPairList();
                LineItem curve;

                int K = comboBox2.SelectedIndex == 0 ? 5 : comboBox2.SelectedIndex == 1 ? 2 : 3;

                for (int i = 0; i < K; i++)
                {

                    for (int x = 10, j = 0; j < 4 + comboBox2.SelectedIndex; x *= 10, j++)
                        list.Add(x, times[i, j]);


                    curve = pane.AddCurve($"{nameSorts[comboBox2.SelectedIndex][i]}",
                        list, colors[i], SymbolType.Default);
                    curve.Line.Width = 2.5F;

                    list = new PointPairList();

                    Graph.AxisChange();
                    Graph.Invalidate();

                }



                button2.Visible = true;

            }


        }


        private delegate void SortDelegate<T>(ref T[] array);
        private delegate void SortDelegate_Addition<T>(ref T[] array, params int[] a);


        private Color[] colors = { Color.Aqua, Color.Red, Color.DarkGreen, Color.LightCoral, Color.Purple };

        private string[][] nameSorts =
        {
            new string [] { "пузырьком", "шейкерная", "выбором", "вставками", "гномья" },
            new string [] { "битонная",  "Шелла", "деревом" },
            new string [] { "слиянием", "пирамидальная", "расчёской"}
        };



        private static long Get_SortTime<T>(T[] mas1, SortDelegate<T> sort = null, SortDelegate_Addition<T> sort_add = null, params int[] par)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (!(sort is null)) sort(ref mas1);
            else if (!(sort_add is null)) sort_add(ref mas1, par);
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


        
        private void Make_Mas(int size, ref object [] ar, int mode, byte type_)
        {            
            switch (mode)
            {
                case 0:
                   ArraysGroup.FirstGroup_mas(size, ref ar, type_); break;
                case 1:
                    ArraysGroup.SecondGroup_mas(size, ref ar, type_); break;
                case 2:
                    ArraysGroup.ThirdGroup_mas(size, ref ar, type_); break;
                case 3:
                    var sd = new Graphic(); int selected = 50;
                    if (sd.repeated_el.SelectedItem != null) selected = (int)sd.repeated_el.SelectedItem;
                    ArraysGroup.FourthGroup_mas(size, ref ar, type_, selected);
                    break;
                default: MessageBox.Show("Выберите значения в обоих списках"); break;

            }
            
        }


        private async void button2_Click(object sender, EventArgs e)
        {

            string path = "_saved_.txt";
            using (StreamWriter writer = new StreamWriter(path, true, Encoding.ASCII))
            {
                for (int i = 0; i <= mas.Length - 1; i++) await writer.WriteAsync($"{mas[i]}");
                for (int i = 0; i <= mas.Length - 1; i++) await writer.WriteAsync($"{mas0[i]}");
            }

        }


    }


}


//for (int j = 0; j <= 3; j++)
//{
//    for (int i = 0; i <= 3; i++)
//    {
//        //mas0 = new int[sz];
//        //int[] mas0 = new int[sz];
//        //mas0 = Make_Mas(sz, comboBox1.SelectedIndex);
//        ////mas = new int[sz];
//        //Array.Copy(mas0, 0, mas, 0, sz);
//        //times[0, j] += Get_SortTime(mas, Sorts<int>.BubbleSort);
//        //Array.Copy(mas0, 0, mas, 0, sz);
//        //times[1, j] += Get_SortTime(mas, Sorts.ShakerSort);
//        //Array.Copy(mas0, 0, mas, 0, sz);
//        //times[2, j] += Get_SortTime(mas, Sorts.SelectionSort);
//        //Array.Copy(mas0, 0, mas, 0, sz);
//        //times[3, j] += Get_SortTime(mas, Sorts.InsertionSort);
//        //Array.Copy(mas0, 0, mas, 0, sz);
//        //times[4, j] += Get_SortTime(mas, Sorts.GnomeSort);

//    }
//    sz *= 10;

//    for (int i = 0; i <= 4; i++) times[i, j] /= 5.0;

//}        