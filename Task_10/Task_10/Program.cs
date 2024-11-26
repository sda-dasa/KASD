using Heap;

int[] massive = { 19, 100, 3, 17, 36, 25, 1, 2, 7 };

Heap.Heap tat = new Heap.Heap(massive);

tat.ShowEl(tat.Size);

tat.Add(4);
tat.ShowEl(tat.Size);
Console.WriteLine(tat.GetMax());