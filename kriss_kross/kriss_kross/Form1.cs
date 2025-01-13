using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using krisskross;
using System.Drawing;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Reflection;
using static System.Windows.Forms.LinkLabel;
using WMPLib;


namespace kriss_kross
{
    public partial class CrissCrossFrame : Form
    {

        private WordArea area = new WordArea();

        private string PathToMedia = @"C:\Users\Даша\Downloads\classic-click.wav";

        public CrissCrossFrame()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            string [] wordsmas = listWords.Text.Split('\n');

            area = new WordArea(wordsmas);

            if (area.Success == WordArea.SuccessDegree.SchemeIsNotCreated)
            {
                MessageBox.Show("По заданным словам не удается построить связную схему крисс-кросс");
            }
            else
            {
                if (area.Success == WordArea.SuccessDegree.ListIsWrong)
                    MessageBox.Show("Список слов не должен включать повторяющихся слов");
                else
                {
                    gamePicture.Image = null;
                    if (gamePicture.Image == null)
                    {
                        Bitmap bmp = new Bitmap(gamePicture.Width, gamePicture.Height);
                        using (Graphics graphic = Graphics.FromImage(bmp)) { area.DrawCrossword(graphic); }

                        gamePicture.Image = bmp;

                        Graphics g = Graphics.FromImage(gamePicture.Image);

                        gamePicture.Invalidate();
                        gamePicture.Update();

                        show_solve.Visible = true;
                        WMP.URL = PathToMedia;


                    }


                }




            }


        }

        private void show_solve_Click(object sender, EventArgs e)
        {
            string[] wordsmas = listWords.Text.Split('\n');

            using (Graphics g = Graphics.FromImage(gamePicture.Image))
            {

                for (int k = 0; k < wordsmas.Length; k++)
                {
                    for (int i = 0; i < wordsmas[k].Length; i++)
                    {
                        if (area.Anima(g, wordsmas[k], i))
                        {
                            gamePicture.Invalidate();
                            gamePicture.Update();

                            WMP.Ctlcontrols.play();

                            Thread.Sleep(210);

                        }

                        WMP.Ctlcontrols.stop();


                    }


                }

            }


        }
    }
}
