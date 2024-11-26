
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.ConstrainedExecution;

object[] mas = new object[2];

int n; int.TryParse(Console.ReadLine(), out n);

Request req = new Request(8, 0, 0);

MyPriorityQueue<Request> queue_ = new MyPriorityQueue<Request>(n, req);

int count = 0;

Stopwatch stopwatch = Stopwatch.StartNew();

for (int i = 0; i < n; i++)
{
    Random rand = new Random();
    int amount_reqs = rand.Next(1, 11);

    for (int j = 0; j < amount_reqs; j++)
    {
        req = new Request(rand.Next(1, 6), j, i); 

        queue_.Add(req); count++;
    }

}

string file = "log.txt";

using (StreamWriter writer = new StreamWriter(file))
{
    for (int i = 0; i < count - 1; i++)
    {
        Request qer = queue_.Peek();
        writer.WriteLine(qer.Number + " " + qer.Priority + " " + qer.AddingStep);
        if (i == --count) Console.WriteLine(qer.Number + " " + qer.Priority + " " + qer.AddingStep);
        queue_.Poll();
    }
}

Request q = queue_.Peek();
Console.WriteLine(q.Number + " " + q.Priority + " " + q.AddingStep);


stopwatch.Stop();
TimeSpan elapsedTime = stopwatch.Elapsed;
Console.WriteLine($"Время выполнения: {elapsedTime}");




public class Request: IComparer<Request>
{
    public int Priority { get; set; }
    public int Number { get; set; }
    public int AddingStep { get; set; }

    //public int CompareTo (Request other)
    //{
    //    if (other is null) throw new ArgumentException ("other"); 

    //    return CompareTo(other as Request);

    //}

    public int Compare(Request first, Request other)
    {

        if (first is null || other is null) throw new ArgumentException("Не корректное значение параметра");

        return first.Priority.CompareTo(other.Priority);

        throw new NotImplementedException();

    }

    public Request (int priority, int number, int addingStep)
    {
        Priority = priority; AddingStep = addingStep; Number = number;
    }

}




//internal class Sorts<T>
//{

//    private IComparable<T> comparator;


//    public Sorts(IComparable<T> comparator)
//    {
//        this.comparator = comparator;
//    }

//    public int CompareTo(T obj) => comparator.CompareTo(obj);

//}