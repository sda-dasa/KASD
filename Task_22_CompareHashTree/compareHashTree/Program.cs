using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_18;
using ClassMTM;

namespace compareHashTree
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
        }

        public static MYTreeMap<K, object> CreateTree<K>(int size)
        {

            MYTreeMap<K, object> tree = new MYTreeMap<K, object>();


            Random rInt = new Random();
            for (int i = 0; i < size; i++)
            {
                object next = rInt.Next(0, 100);
                tree.Put((K)next, false);
            }
            return tree;


        }


        public static MYHashMap<K, object> CreateHashMap<K>(int size)
        {

            MYHashMap<K, object> hash = new MYHashMap<K, object>(size + size / 2);


            Random rInt = new Random();
            for (int i = 0; i < size; i++)
            {
                object next = rInt.Next(0, size);
                
                //if (i == 70) 
                //    MessageBox.Show("");

                hash.Put((K)next, false);
                //if (hash.Size < i)
                //    MessageBox.Show($"{hash.Size} {i} {next} {size}");

            }
            return hash;



        }








    }









}
