using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ClassMTM;
using Class_18;
using LinkedList;
using ZedGraph;
using static System.Net.WebRequestMethods;
using System.Threading;

namespace compareHashTree
{
    public partial class Graphic : Form
    {
          
        public Graphic()
        {
            InitializeComponent();

            GraphPane pane = Graph.GraphPane; pane.Title.Text = "Зависимость времени выполнения " +
                "\n операции от размера отображений";
            pane.XAxis.Title.Text = "Размер отображений \n (кол-во элементов)";
            pane.YAxis.Title.Text = "Время выполнения операции \n (миллисекунды)";

        }


        private void start_Click(object sender, EventArgs e)
        {


            if (choose_operation.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите варианты в обоих списках"); return;
            }



            double [,] time = new double[2, 4]; int size = 100;

            MYTreeMap<int, object> tree_ = Program.CreateTree<int>(size);
            Random rInt = new Random();
            MYHashMap<int, object> hash = Program.CreateHashMap<int>(size);

            for (int i = 0; i < 3; i++) // 3
            {

                for (int k = 0; k < 9 * size; k++) // 9
                {
                    hash.Put(rInt.Next(0, size), false);
                    
                    tree_.Put(rInt.Next(0, size), false);
                }

                //tree_ = Program.CreateTree<int>(size);
                //hash = Program.CreateHashMap<int>(size);

                time[0, i] = GetTime_OfOperationWork<int>
                    (choose_operation.SelectedIndex, size, hash);
                
                time[1, i] = GetTime_OfOperationWork<int>
                    (choose_operation.SelectedIndex,size, tree: tree_);

                size *= 10;

            }

            //MessageBox.Show($"{time[1, 1]}");


            PrintGraph(time);


        }


        public void PrintGraph(double[,] time)
        {
            GraphPane pane = Graph.GraphPane; pane.CurveList.Clear();
            PointPairList list = new PointPairList();
            LineItem curve;


            //for (int x = 1000, j = 0; j < 3; x *= 10, j++)
            //    list.Add(x, time[0, j]);

            //curve = pane.AddCurve("ttt", list, Color.Black);

            //Graph.AxisChange(); Graph.Invalidate();

            //PointPairList list1 = new PointPairList();
            //LineItem curve1;

            //for (int x = 1000, j = 0; j < 3; x *= 10, j++)
            //    list.Add(x, time[1, j]);

            //curve = pane.AddCurve("tret", list, Color.Green);

            //Graph.AxisChange(); Graph.Invalidate();

            //Random rInt = new Random();
            //MYHashMap<int, object> hash = Program.CreateHashMap<int>(1000);

            //for (int k = 0; k < 11; k++) // 9
            //{
            //    hash.Put(rInt.Next(0, 1000), false);

            //}
            //Stopwatch stp = new Stopwatch();
            //stp.Start();
            //if (hash is MYHashMap<int, object>)
            //    for (int i = 1; i <= 2; i++)
            //    {
            //        object el = rInt.Next(0, 1000);  // создание рандомного содержимого для удаления
            //        hash.Remove(el);
            //    }
            //stp.Stop();

            //MessageBox.Show($"{stp.ElapsedMilliseconds}");

            Color[] colors = { Color.Aqua, Color.Red };

            string[] mas_name = { "Хэш-Таблица_", "Дерево_" };

            for (int i = 0; i < 2; i++)
            {

                for (int x = 1000, j = 0; j < 3; x *= 10, j++)
                    list.Add(x, time[i, j]);


                curve = pane.AddCurve($" {mas_name[i]}",
                    list, colors[i]);
                curve.Line.Width = 2.5F;

                list = new PointPairList();

                Graph.AxisChange();
                Graph.Invalidate();

            }







        }




        internal static long GetTime_OfOperationWork<T>(int operation_type, int size,
           MYHashMap<T, object> hash = null, MYTreeMap<T, object> tree = null)
        {
            Stopwatch stp = new Stopwatch();
            Random t = new Random();
            if (tree != null)
            {
                switch (operation_type)
                {
                    case 0: // Get
                        {
                            stp.Start();
                            if (tree is MYTreeMap<int, object>)
                                for (int i = 1; i <= 20; i++)
                                {
                                    object key = t.Next(0, size); // создание рандомного ключа для получения 
                                    tree.GetValue((T)key);
                                }
                            Thread.Sleep(20);
                            stp.Stop();
                            break;
                        }
                    case 1: // Put
                        {                            
                            stp.Start();
                            if (tree is MYTreeMap<int, object>)
                                for (int i = 1; i <= 20; i++)
                                {
                                    object key = t.Next(0, size);  // создание рандомного ключа для вставки
                                    tree.Put((T)key, false);
                                }

                            stp.Stop();

                            break;
                        }
                    case 2: // Remove
                        {
                            if (tree is MYTreeMap<int, object>)
                                for (int i = 1; i <= 20; i++)
                                {
                                    object el = t.Next(0, size);
                                    tree.Remove(el);
                                }

                            stp.Stop();

                            break;
                        }
                    default: break;

                }
            }
            else
            {
                if (hash != null)
                {
                    switch (operation_type)
                    {
                        case 0: // Get
                            {
                                stp.Start();
                                if (hash is MYHashMap<int, object>)
                                    for (int i = 1; i <= 20; i++)
                                    {
                                        object key = t.Next(0, size); // создание рандомного ключа для получения значения
                                        hash.GetEntire((T)key);
                                    }
                                stp.Stop();
                                break;
                            }
                        case 1: // Put
                            {
                                stp.Start();
                                if (hash is MYHashMap<int, object>)
                                    for (int i = 1; i <= 20; i++)
                                    {
                                        object el = t.Next(0, size);  // создание рандомного содержимого для вставки
                                        hash.Put((T)el, false);
                                    }
                                stp.Stop();

                                break;
                            }
                        case 2: // Remove
                            {
                                stp.Start();
                                if (hash is MYHashMap<int, object>)
                                    for (int i = 1; i <= 20; i++)
                                    {
                                        object el = t.Next(0, size);  // создание рандомного содержимого для удаления
                                        hash.Remove(el);
                                    }
                                stp.Stop();

                                break;
                            }
                        default: break;

                    }

                }
            }

            

            return stp.ElapsedMilliseconds / 20;



        }







    }









}
