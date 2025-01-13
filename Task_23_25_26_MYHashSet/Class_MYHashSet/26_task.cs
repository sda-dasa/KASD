using LinkedList;
using System.Collections;
using MYVector;


namespace Class_MYHashSet
{



    public class Program
    {




        static bool IsWord(string word)
        {
            if (word == null) return false;

            foreach (char c in word)
                if (!(c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z')) return false;

            return true;

        }






        static void Main(string[] args)
        {

            //Console.WriteLine("sjdv");


            MYHashSet<string> stringSet = new MYHashSet<string>();

            StreamReader reader = new StreamReader("input.txt");

            while (!reader.EndOfStream)
            {
                foreach (string word in reader.ReadLine().Split(' '))
                {
                    if (IsWord(word)) 
                        if (!stringSet.Contains(word.ToLower())) 
                            stringSet.Add(word.ToLower());


                }

            }



            string[] res = stringSet.ToArray();
            foreach (string str in res) Console.WriteLine(str);




        }




    }









}