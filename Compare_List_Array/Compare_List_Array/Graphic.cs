using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MYArray;
using MYLinkedList;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Compare_List_Array
{
    public partial class Graphic : Form
    {
        public Graphic()
        {
            InitializeComponent();

            GraphPane pane = Graph.GraphPane; pane.Title.Text = "Зависимость времени выполнения " +
                "\n операции от размера массивов и типа объектов";
            pane.XAxis.Title.Text = "Размер массивов \n (кол-во элементов)";
            pane.YAxis.Title.Text = "Время выполнения операции \n (миллисекунды)";

        }

        private void start_Click(object sender, EventArgs e)
        {

            long[,] time = new long[2, 4]; int size = 1000;

            if (choose_operation.SelectedIndex < 0 || choose_structure.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите варианты в обоих списках"); return;
            }
            else
            {
                switch (choose_structure.SelectedIndex)
                {
                    case 0: // int
                        {
                            MyArrayList_<int> array = Program.CreateArray<int>(size);
                            MYLinkedList<int> list_ = Program.CreateList<int>(size);
                            Random rInt = new Random();

                            for (int i = 0; i < 3; i++) // 3
                            {
                                for (int k = 0; k < 9 * size; k++) // 9
                                {
                                    array.Add(rInt.Next(0, 100));
                                    list_.Add(rInt.Next(0, 100));

                                }

                                time[0, i] = GetTime_OfOperationWork<int>
                                    (choose_operation.SelectedIndex, array);
                                time[1, i] = GetTime_OfOperationWork<int>
                                    (choose_operation.SelectedIndex, list: list_);

                                size *= 10;

                            }

                            break;
                        }
                    case 1:
                        {

                            MyArrayList_<string> array = Program.CreateArray<string>(size);
                            MYLinkedList<string> list_ = Program.CreateList<string>(size);
                            RandomString rString = new RandomString();

                            for (int i = 0; i < 3; i++)
                            {
                                for (int k = 0; k < 9 * size; k++)
                                {
                                    array.Add(rString.Next(0));
                                    list_.Add(rString.Next(0));

                                }

                                time[0, i] = GetTime_OfOperationWork<string>
                                    (choose_operation.SelectedIndex, array);
                                time[1, i] = GetTime_OfOperationWork<string>
                                    (choose_operation.SelectedIndex, list: list_);

                                size *= 10;
                            }

                            break;

                        }

                    default: break;

                }


                PrintGraph(time);



            }
            
        }


        public void PrintGraph(long[,] time)
        {
            GraphPane pane = Graph.GraphPane; pane.CurveList.Clear();
            PointPairList list = new PointPairList();
            LineItem curve;

            Color[] colors = { Color.Aqua, Color.Red };

            string[] mas_name = { "Массив_", "Список_" };

            for (int i = 0; i < 2; i++)
            {

                for (int x = 10000, j = 0; j < 3; x *= 10, j++)
                    list.Add(x, time[i, j]);


                curve = pane.AddCurve($" {mas_name[i]}",
                    list, colors[i]);
                curve.Line.Width = 2.5F;

                list = new PointPairList();

                Graph.AxisChange();
                Graph.Invalidate();

            }

            


        }
        

        public static long GetTime_OfOperationWork<T>(int operation_type, 
            MyArrayList_<T> array = null, MYLinkedList<T> list = null )
        {
            Stopwatch stp = new Stopwatch();
            Random t = new Random();
            if (array != null)
            {
                switch (operation_type)
                {
                    case 0: // Get
                        {                            
                            stp.Start();
                            for (int i = 1; i<= 20; i++)
                            {
                                int index = t.Next(1, array.Size() - 1 ); // создание рандомного объекта для вставки 
                                array.Get(index);
                            }
                            stp.Stop();
                            break;
                        }
                    case 1: // Set
                        {   
                            RandomString rString = new RandomString();
                            stp.Start();
                            for (int i = 1; i <= 20; i++)
                            {
                                object el = t.Next(0,100);  // создание рандомного содержимого для вставки
                                if (array is MyArrayList_<string>)
                                    el = rString.Next(0); 

                                int index = t.Next(1, array.Size() - 1);
                                array.Set(index, (T)el);
                            }
                            stp.Stop();

                            break;
                        }
                    case 2: // Add (index, T el)
                        {
                            RandomString rString = new RandomString();
                            stp.Start();
                            for (int i = 1; i <= 20; i++)
                            {
                                object el = t.Next(0, 100);  // создание рандомного содержимого для вставки
                                if (array is MyArrayList_<string>)
                                    el = rString.Next(0);

                                int index = t.Next(1, array.Size() - 2);
                                array.Add(index, (T)el);
                            }
                            stp.Stop();

                            break;
                        }
                    default: break;  

                }
            }
            else
            {
                if (list!= null)
                {
                    switch (operation_type)
                    {
                        case 0: // Get
                            {
                                stp.Start();
                                for (int i = 1; i <= 20; i++)
                                {
                                    int index = t.Next(1, list.Size - 1); // создание рандомного объекта для вставки 
                                    list.Get(index);
                                }
                                stp.Stop();
                                break;
                            }
                        case 1: // Set
                            {
                                RandomString rString = new RandomString();
                                stp.Start();
                                for (int i = 1; i <= 20; i++)
                                {
                                    object el = t.Next(0, 100);  // создание рандомного содержимого для вставки
                                    if (list is MYLinkedList<string>)
                                        el = rString.Next(0);

                                    int index = t.Next(1, list.Size - 1);
                                    list.Set(index, (T)el);
                                }
                                stp.Stop();

                                break;
                            }
                        case 2: // Add (i, val)
                            {
                                RandomString rString = new RandomString();
                                stp.Start();
                                for (int i = 1; i <= 20; i++)
                                {
                                    object el = t.Next(0, 100);  // создание рандомного содержимого для вставки
                                    if (list is MYLinkedList<string>)
                                        el = rString.Next(0);

                                    int index = t.Next(1, list.Size - 2);
                                    list.Add(index, (T)el);
                                }
                                stp.Stop();

                                break;
                            }
                        default: break;

                    }

                }
            }
            
            return stp.ElapsedMilliseconds;


        }



    }



}
