using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace MYStack;

public class MYStack<T> : MYVector.MYVector<T>
{
    public void Push(T item) => this.Add(item);

    public T Pop()
    {
        if (this.Empty()) throw new InvalidOperationException("Stack is empty");
        return this.Remove(this.Size() - 1);
    }

    public T Peek()
    {
        if (this.Empty()) throw new InvalidOperationException("Stack is empty");
        return this.Get(this.Size() - 1);
    }

    public bool Empty() => this.IsEmpty();

    public int Search(T item)
    {
        //if (this.Empty()) throw new InvalidOperationException("Stack is empty");
        return this.IndexOf(item);
    }




}
