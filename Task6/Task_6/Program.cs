using MYVector;

MYVector<int> y = new(1, 0);
y.Add(0); 
int [] f = new int [] {12, 34, 4 , 89};

y.AddAll(f);
//Console.WriteLine(y.Size());
//y.ShowEl(y.Size()); 
int a = y.FirstElement(); y.Set(0, 108); 
Console.WriteLine(a); y.ShowEl(1); int[] c = null; //y.Add(c);


