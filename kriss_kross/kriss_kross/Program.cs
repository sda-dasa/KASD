using System;
using System.Drawing;
using System.Windows.Forms;
using kriss_kross;

namespace krisskross
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CrissCrossFrame());


        }




    }
    



}
