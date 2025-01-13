

//using LinkedList;
//using System.Collections;
//using MYVector;

//namespace Class_MYHashSet
//{

//    public class Program
//    {

//        public class ForCompare : IComparer
//        {            
//            public int Compare(object s1, object s2)
//            {
//                if (s1 is null || s1 is null) throw new ArgumentNullException("s");
//                if (s1 is string str1 && s2 is string str2) 
//                    return str1.Length - str2.Length > 0 ? 1 : str1.Length == str2.Length ? 0 : -1;

//                else throw new ArgumentException();

//            }

//        }



//        class ComparerForList : IComparer
//        {


//            public int Compare (object obj1, object obj2)
//            {
//                if (obj1 is null || obj2 is null) throw new ArgumentNullException();

//                if (obj1 is MYLinkedList<string> list1 && obj2 is MYLinkedList<string> list2)
//                    return CompareNodes(list1.First, list2.First);

//                else throw new ArgumentException();

//            }



//            public int CompareNodes (object obj1, object obj2)
//            {
//                if (obj1 is null || obj2 is null)
//                    if (obj1 is null) return -1; 
//                    else return 1;

//                if (obj1 is Node<string> list1 && obj2 is Node<string> list2)
//                {
//                    if (list1.Info.Length > list2.Info.Length) return 1;
                    
//                    if (list1.Info.Length < list2.Info.Length) return -1; 
                    
//                    else return CompareNodes(list1.Next, list2.Next);

//                    //else if (list1.First.Info.Length == list2.First.Info.Length)
//                    //    return Compare(list1.First.Next, list2.First.Next);

//                }
//                else throw new ArgumentException("can not convert obj to string");


//            }





//        }





//        static void Main(string[] args)
//        {

//            int size = 0;
            


//            StreamReader reader = new StreamReader("input.txt");
                        
           
//            MYVector<string> source = new MYVector<string>();

//            while (!reader.EndOfStream)
//            {
//                //source[k] = reader.ReadLine(); Console.WriteLine(source[k]); k++;
//                source.Add(reader.ReadLine());
                

//            }

//            reader.Close();

//            IComparer rule = new ForCompare();

//            MYLinkedList<string>[] sorted_list = new MYLinkedList<string>[source.Size()];

//            for (int i = 0; i < source.Size(); i++)
//                sorted_list[i] = new MYLinkedList<string>();

//            // добавляем строки в список, сразу сортируя слова строк по размеру:


//            for (int i = 0; i < source.Size(); i++)
//            {
//                string[] line = source.Get(i).Split(' ');

//                int min = line[0].Length;

//                Array.Sort(line, rule);

//                foreach (string item in line) sorted_list[i].Add(item);

//            }


//            // сравниваем строки (используем списки)
//            IComparer rule_for_list = new ComparerForList();

//            Array.Sort(sorted_list, rule_for_list);

//            MYHashSet<string> result = new MYHashSet<string>();

//            for (int i = 0; i < sorted_list.Length; i++)
//            {
//                string str = string.Empty;
//                foreach (string item in sorted_list[i]) str += item + ' ';

//                result.Add(str);


//            }


//            for (int i = 0; i < sorted_list.Length; i++)
//                foreach (string item in sorted_list[i]) Console.WriteLine(item);

//            Console.WriteLine();

//            string[] res = result.ToArray();
//            foreach (string str in res) Console.WriteLine(str);



//        }












//    }




//} 



