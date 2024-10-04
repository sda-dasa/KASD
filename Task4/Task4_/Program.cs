using MyArrayList;



MyArrayList<string> s = new MyArrayList<string>();

s.Add("jk"); string[] a = { "kl", "sdk", "nkl", "bjcvk" }; s.AddAll(a);
string[] b = { "f" }; string[]? c = null;
s.ShowEl(3);
//Console.WriteLine(s.ContainsAll(b)); 
//Console.WriteLine(s.ContainsAll(c));
Console.WriteLine(s.ContainsAll(b));

//MyArrayList_<string> f = new MyArrayList_<string>(); Console.WriteLine(f.ContainsAll(b));
//Console.WriteLine(f.IsEmpty()); f.AddAll(b); Console.WriteLine(f.IsEmpty());

int[] r = { 3, 354, 34, 6 };
MyArrayList<int> test = new MyArrayList<int>();
//test.Get(34); test.Get(-1); 
test.Add(9, 2); test.Add(12, 6); Console.WriteLine(test.Size()); Console.WriteLine(test.Сapacity);
test.Add(16, 6);
test.Add(20, 11); test.Add(30, 7); test.Add(2); test.AddAll(r); test.AddAll(7, r); test.Add(10, 2);

Console.WriteLine(test.Get(12)); Console.WriteLine(test.IndexOf(6));

test.ShowEl(31);
//Console.WriteLine(test.Get(20));
//test.Remove (20);
//Console.WriteLine(test.Get(20));
//test.ShowEl(30);

//Console.WriteLine("\n\n");
int[] elements = new int[6];
test.ToArray(ref elements);
//Console.WriteLine(elements[10]);


elements = test.Sublist(2, 4);
Console.WriteLine(elements.Length);
//test.ShowEl(30);
//Console.WriteLine(test.Size()); Console.WriteLine(test.Сapacity); test.ShowEl(37); //test.ShowEl(2, 5);
