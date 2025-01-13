using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace Heap;
public class Heap
{
    private int[] heapMassive;
    private int elementCount;
    private int capacity;
    public int Size { get => elementCount; private set { this.elementCount = value; } }
    
    public void ShowEl(int range, int begin = 0)
    {
        if (range < 0 || (begin + range) > this.elementCount || begin < 0)
            throw new ArgumentOutOfRangeException("range");

        for (int i = begin; i <= begin + range - 1; i++)
            Console.WriteLine(this.heapMassive[i]);
    }

    public int GetMax() => this.heapMassive[0];


    public Heap(int[] array)
    {
        this.heapMassive = array; this.elementCount = array.Length; this.capacity = array.Length;
        for (int i = elementCount / 2; i >= 0; i--)
        {
            this.Heapify(i);
        }
    }


    public void Heapify(int i)
    {
        int leftChild;
        int rightChild;
        int largestChild;

        for (; ; )
        {
            leftChild = 2 * i + 1;
            rightChild = 2 * i + 2;
            largestChild = i;

            if (leftChild < elementCount && heapMassive[leftChild] > heapMassive[largestChild])
            {
                largestChild = leftChild;
            }

            if (rightChild < elementCount && heapMassive[rightChild] > heapMassive[largestChild])
            {
                largestChild = rightChild;
            }

            if (largestChild == i)
            {
                break;
            }

            int temp = heapMassive[i];
            heapMassive[i] = heapMassive[largestChild];
            heapMassive[largestChild] = temp;
            i = largestChild;
        }
    }

    public void Add(int el)
    {
        if (this.elementCount >= this.capacity) Resize();
        heapMassive[elementCount] = el; elementCount++;

        int i = elementCount - 1;
        int parent = (i - 1) / 2;

        while (i > 0 && heapMassive[parent] <= heapMassive[i])
        {
            int temp = heapMassive[i];
            heapMassive[i] = heapMassive[parent];
            heapMassive[parent] = temp;

            i = parent;
            parent = (i - 1) / 2;
        }

    }


    public void Resize()
    {
        int[] newAr = new int[this.capacity * 2];
        for (int i = 0; i < this.elementCount; i++) newAr[i] = this.heapMassive[i];
        this.heapMassive = newAr;
        this.capacity = newAr.Length;
    }

    public int PopMax()
    {
        int max = heapMassive[0]; heapMassive[0] = heapMassive[elementCount - 1];
        Heapify(0); heapMassive[elementCount - 1] = 0; elementCount--; return max;

    }

    public void SetKey(int index, int value)
    {
        if (index >= this.elementCount) throw new ArgumentOutOfRangeException("index");

        this.heapMassive[index] = value;
        for (int i = elementCount / 2; i >= 0; i--)
        {
            this.Heapify(i);
        }
    }

    
    public Heap Total (Heap heap)
    {
        int[] total_massive = new int[this.elementCount + heap.elementCount];

        for (int i = 0; i < this.elementCount; i++) total_massive[i] =  this.heapMassive[i];
        for (int i = this.elementCount - 1; i < this.elementCount + heap.elementCount; i++) total_massive[i] = this.heapMassive[i];

        Heap total = new Heap(total_massive);

        return total;

    }
    


}