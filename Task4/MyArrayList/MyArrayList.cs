﻿namespace MyArrayList;

public class MyArrayList<T>
{
    private T[] elementData;
    private int size;
    private int len;
    public int Сapacity { get { return len; } private set { len = value; } } // вот это может лучше свойством сделать/ возможное количество элементов


    public MyArrayList(int capacity = 0) // создание пустого массива
    {
        if (capacity < 0 || capacity > 1000) throw new Exception("Значение емкости должно лежать в пределах от 0 до 1000");
        this.size = 0;
        this.Сapacity = capacity;
        this.elementData = new T[this.Сapacity]; // ~ new T[0]

    }

    public MyArrayList(T[] a) //создание массива с помощью другого массива
    {
        if (a == null) throw new ArgumentNullException("array a");
        this.size = a.Length; this.Сapacity = a.Length;
        this.elementData = a;
    }

    
    // если размер дин. массива больше размера внутреннего массива, нужно создать 
    // новый массив с размером 1.5х (сохранить его во внутренней переменной объекта MyArrayList_
    public void Add(T item) // добавляем один элемент в конец
    {
        if (item == null) throw new ArgumentNullException("item")
        if (this.Сapacity <= this.size) NewSize();
        if (this.Сapacity >= this.size + 1) this.elementData[this.size++] = item;

    }

    private void NewSize(int countAddedItems = 0)
    {
        T[] newAr = new T[this.Сapacity + countAddedItems + 1 + (this.Сapacity + countAddedItems) / 2];
        for (int i = 0; i < this.size; i++) newAr[i] = this.elementData[i];
        this.elementData = newAr;
        this.Сapacity = newAr.Length;

    }

    public void AddAll(T[] a) // для добавления элементов из массива
    {
        if (a == null) throw new ArgumentNullException("array a");

        if (a.Length == 0) return;

        if (this.Сapacity <= this.size + a.Length - 1) NewSize(a.Length);

        if (this.Сapacity >= this.size + a.Length)
            for (int i = 0; i < a.Length; i++) this.elementData[this.size++] = a[i];

    }

    public void Clear()
    {
        this.elementData = [];
        this.size = 0;
        this.Сapacity = 0;
    }


    private bool Contains(object a)
    {
        foreach (T t in this.elementData)
            if (t.Equals(a)) return true;
        return false;
    }

    public void ShowEl(int range, int begin = 0)
    {
        if (range < 0 || (begin + range) > this.Сapacity || begin < 0) throw new ArgumentOutOfRangeException("range");

        for (int i = begin; i <= begin + range - 1; i++)
            Console.WriteLine($" {this.elementData[i]} ");
    }

    public bool ContainsAll(T[] a)
    {
        ArgumentNullException.ThrowIfNull(a); // if (a == null) throw new ArgumentNullException ("a");
        if (a.Length == 0) throw new ArgumentException("sent array is empty");

        foreach (T item in a)
            if (!this.elementData.Contains(item)) return false;
        return true;

    }

    public bool IsEmpty() => this.size == 0;

    public void RemoveAll(T[] a)
    {
        if (a == null) throw new ArgumentNullException("array a");
        if (a.Length == 0) return;
        T[] NewAr = new T[this.size];
        int index = 0; bool flag;
        for (int i = 0; i < this.size; i++)
        {
            flag = false;
            for (int j = 0; j < a.Length || flag; j++)
                if (this.elementData[i].Equals(a[j])) flag = true;

            if (!flag) NewAr[index++] = this.elementData[i];

        }
        this.elementData = NewAr;
        this.size = index;

    }



    public int Size() => this.size;


    public void RetainAll(T[] a)
    {
        if (this.IsEmpty()) return;
        if (a == null) throw new ArgumentNullException("array");
        if (a.Length == 0) return;
        T[] newAr = new T[this.size]; int index = 0;
        for (int i = 0; i <= this.size - 1; i++)
        {
            for (int j = 0; j < a.Length - 1; j++)
            {
                if (a[j] != null && this.elementData[i].Equals(a[j])) { newAr[index++] = this.elementData[i]; break; }
            }
        }

        this.elementData = newAr;
        this.size = newAr.Length;

    }

    public T[] ToArray() // возвращает массив объектов, который содержит все элементы массива
    {
        T[] newAr = new T[this.elementCount];
        for (int i = 0; i < this.elementCount; i++) newAr[i] = this.elementData[i];
        return newAr;
    }


    public void ToArray(ref T[] a)
    {
         if (array == null) array = ToArray();

         if (array.Length >= this.elementCount)
             for (int i = 0; i < this.elementCount; i++) array[i] = this.elementData[i]; return;
         throw new ArgumentException("The length of the array is less than the length of the list");
    }

    public void Add(int index, T el)
    {
        if (el == null) throw new ArgumentNullException("el");
        
        if (this.Сapacity <= index) NewSize(index);
        this.elementData[index] = el;

        this.size = this.size < index ? index + 1 : this.size;

    }

    public void AddAll(int index, T[] arr)
    {
        if (arr == null) throw new ArgumentNullException("arr");

        if (this.elementData == null) throw new Exception("array is null");
        if (arr.Length == 0) return;

        if (this.Сapacity <= index + arr.Length) NewSize(index + arr.Length);
        for (int i = 0; i <= arr.Length - 1; i++) this.elementData[index + i] = arr[i];

    }

    public T Get(int index)
    {
        if (this.elementData == null) throw new Exception("array is null");
        if (index < 0 || index >= this.size) throw new ArgumentOutOfRangeException("index");

        return this.elementData[index];

    }

    public int IndexOf(T el)
    {
        if (el == null) throw new ArgumentNullException("el");
        if (this.elementData == null) throw new Exception("arra is null");

        for (int i = 0; i < this.size; i++) if (this.elementData[i].Equals(el)) return i;

        return -1;

    }



    public int LatIndexOf(T el)
    {
        if (el == null) throw new ArgumentNullException("el");
        if (this.elementData == null) throw new Exception("arra is null");

        for (int i = this.size - 1; i >= 0; i--) if (this.elementData[i].Equals(el)) return i;

        return -1;

    }

    public T Remove(int index)
    {
        if (this.elementData == null) throw new Exception("array is null");
        if (index < 0 || index >= this.size) throw new ArgumentOutOfRangeException("index");

        T[] newAr = new T[this.size - 1]; int j = 0;
        for (int i = 0; i < this.size; i++)
            if (i != index) newAr[j++] = this.elementData[i];
        this.elementData = newAr;
        this.size = newAr.Length;

        return this.Get(index);

    }


    public void Set(int index, T el)
    {
        if (this.elementData == null) throw new Exception("array is null");
        if (index < 0 || index >= this.size) throw new ArgumentOutOfRangeException("index");
        this.elementData[index] = el;
    }

    public T[] Sublist(int fromIndex, int toIndex)
    {
        if (this.elementData == null) throw new Exception("array is null");
        if (fromIndex < 0 || fromIndex > this.size || toIndex < 0 ||
            toIndex > this.size) throw new ArgumentOutOfRangeException("index");
        if (toIndex - 1 - fromIndex <= 0) throw new ArgumentOutOfRangeException("index");

        T[] arr = new T[toIndex - fromIndex]; int j = 0;

        for (int i = fromIndex; i <= toIndex - 1; i++) arr[j++] = this.elementData[i];

        return arr;

    }



}
