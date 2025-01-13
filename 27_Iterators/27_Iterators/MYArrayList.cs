using Itr;
using MYVector;
using System;
using MYCollections;
namespace MyArrayList;

public class MyArrayList<T> : MyList<T>
{
    private T[] elementData;
    private int size;

    public int Size { get { return size; } set { value = size; } }
    private int len;
    public int Сapacity { get { return len; } private set { len = value; } } // вот это может лучше свойством сделать/ возможное количество элементов


    public MyArrayList(int capacity = 0) // создание пустого массива
    {
        if (capacity < 0 || capacity > 1000) throw new Exception("Значение емкости должно лежать в пределах от 0 до 1000");
        this.size = 0;
        this.Сapacity = capacity;
        this.elementData = new T[this.Сapacity]; // ~ new T[0]

    }

    public MyArrayList(MyCollection<T> a) //создание массива с помощью другого массива
    {
        if (a == null) throw new ArgumentNullException("array a");
        size = a.Size; Сapacity = a.Size;
        elementData = a.ToArray();

    }


    // если размер дин. массива больше размера внутреннего массива, нужно создать 
    // новый массив с размером 1.5х (сохранить его во внутренней переменной объекта MyArrayList_
    public void Add(T item) // добавляем один элемент в конец
    {
        if (item == null) throw new ArgumentNullException("item");
        if (this.Сapacity <= this.size) NewSize();
        if (this.Сapacity >= this.size + 1) this.elementData[this.size++] = item;

    }

    private void NewSize(int countAddedItems = 0)
    {
        T[] newAr = new T[Сapacity + countAddedItems + 1 + (Сapacity + countAddedItems) / 2];
        for (int i = 0; i < this.size; i++) newAr[i] = elementData[i];
        elementData = newAr;
        Сapacity = newAr.Length;

    }

    public void AddAll(MyCollection<T> a) // для добавления элементов из массива
    {
        if (a == null) throw new ArgumentNullException("array a");

        if (a.Size == 0) return;

        if (Сapacity <= size + a.Size - 1) NewSize(a.Size);

        if (Сapacity >= this.size + a.Size)
            for (int i = 0; i < a.Size; i++) this.elementData[this.size++] = a.Get(i);

    }

    public void Clear()
    {
        this.elementData = new T[0];
        this.size = 0;
        this.Сapacity = 0;
    }


    public bool Contains(object a)
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

    public bool ContainsAll(MyCollection<T> a)
    {
        ArgumentNullException.ThrowIfNull(a); // if (a == null) throw new ArgumentNullException ("a");
        if (a.Size == 0) throw new ArgumentException("sent array is empty");

        foreach (T item in a.ToArray())
            if (!this.elementData.Contains(item)) return false;


        return true;

    }

    public bool IsEmpty() => size == 0;

    public void RemoveAll(MyCollection<T> a)
    {
        if (a == null) throw new ArgumentNullException("array a");
        if (a.Size == 0) return;
        T[] NewAr = new T[size];
        int index = 0; bool flag;
        for (int i = 0; i < size; i++)
        {
            flag = false;
            for (int j = 0; j < a.Size || flag; j++)
                if (elementData[i].Equals(a.Get(j))) flag = true;

            if (!flag) NewAr[index++] = elementData[i];

        }
        elementData = NewAr;
        size = index;

    }


    public void RetainAll(MyCollection<T> a)
    {
        if (this.IsEmpty()) return;
        if (a == null) throw new ArgumentNullException("array");
        if (a.Size == 0) return;
        T[] newAr = new T[size]; int index = 0;
        for (int i = 0; i <= size - 1; i++)
        {
            for (int j = 0; j < a.Size - 1; j++)
            {
                if (a.Get(j) != null && elementData[i].Equals(a.Get(j))) 
                { newAr[index++] = elementData[i]; break; }
            }
        }

        elementData = newAr;
        size = newAr.Length;

    }

    public T[] ToArray() // возвращает массив объектов, который содержит все элементы массива
    {
        T[] newAr = new T[size];
        for (int i = 0; i < size; i++) newAr[i] = elementData[i];
        return newAr;
    }


    public void ToArray(ref T[] array)
    {
        if (array == null) array = ToArray();

        if (array.Length >= size)
            for (int i = 0; i < size; i++) array[i] = elementData[i]; return;
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

    public int IndexOf(object el)
    {
        if (el == null) throw new ArgumentNullException("el");
        if (this.elementData == null) throw new Exception("arra is null");

        for (int i = 0; i < this.size; i++) if (this.elementData[i].Equals(el)) return i;

        return -1;

    }



    public int LastIndexOf(object el)
    {
        if (el == null) throw new ArgumentNullException("el");
        if (this.elementData == null) throw new Exception("array is null");
        if (IsEmpty()) throw new Exception("array is empty");

        for (int i = this.size - 1; i >= 0; i--) if (elementData[i].Equals(el)) return i;

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


    public bool Remove(object el)
    {
        if (el is null) throw new ArgumentNullException();

        if (IsEmpty()) throw new Exception("array is empty");

        if (Remove(IndexOf(el)) is T item) return true;

        return false;


    }



    public void Set(int index, T el)
    {
        if (this.elementData == null) throw new Exception("array is null");
        if (index < 0 || index >= this.size) throw new ArgumentOutOfRangeException("index");
        this.elementData[index] = el;
    }

    public MyList<T> SubList(int fromIndex, int toIndex)
    {
        if (this.elementData == null) throw new Exception("array is null");
        if (fromIndex < 0 || fromIndex > this.size || toIndex < 0 ||
            toIndex > this.size) throw new ArgumentOutOfRangeException("index");
        if (toIndex - 1 - fromIndex <= 0) throw new ArgumentOutOfRangeException("index");

        MyArrayList<T> arr = new(toIndex - fromIndex);

        for (int i = fromIndex; i <= toIndex - 1; i++) arr.Add(elementData[i]);

        return arr;

    }






    public MYListIterator<T> ListIterator() => new MYItr<T>(this);

    public MYListIterator<T> ListIterator(int index) => new MYItr<T>(this, index);




    public class MYItr<E> : MYListIterator<E>
    {

        public int Cursor { get; private set; }
        MyArrayList<E> mAr;

        public MYItr(MyArrayList<E> mAr, int index = 0)
        {
            Cursor = index;

            this.mAr = mAr;

        }


        public bool HasNext()
        {
            if (Cursor < mAr.size) return true;

            return false;

        }


        public E Next()
        {
            if (HasNext()) return mAr.elementData[Cursor + 1];

            throw new Exception("outside of vector");

        }

        public bool Remove()
        {
            if (mAr.Remove(Cursor) is E el) return true;

            return false;

        }




        public int NextIndex()
        {
            if (Cursor + 1 < mAr.size) return Cursor + 1;

            throw new Exception("current index is the last index of this vector");

        }



        public bool HasPrevious()
        {
            if (Cursor >= 1) return true;

            return false;


        }

        public E Previous()
        {
            if (HasPrevious()) return mAr.elementData[Cursor - 1];

            throw new Exception("outside of the vector");

        }



        public int PreviousIndex()
        {

            if (Cursor - 1 >= 0) return Cursor - 1;

            throw new Exception("current index is the first index of this vector");


        }


        public void Set(E el)
        {
            mAr.Set(Cursor, el);

        }


        public void Add(E el)
        {

            mAr.Add(NextIndex(), el);


        }




    }














}