namespace MYVector;

public class MYVector<T>
{
    private T[] elementData; // ? // массив для хранения элементов вектора
    private int elementCount; // количество элементов в массиве

    private int capacityIncrement; // значение, на кот увеличивается емкость вектора при необходимости

    private int capacity; 
    public int Capacity { get { return capacity; } private set { capacity = value; } }
    
    // убрать поле InitialCapacity ?
    // может добавить метод для изменения capacityIncrement?
    public MYVector(int initialCapacity, int capacityIncrement)
    {
        if (initialCapacity <= 0 || initialCapacity > 1000 || capacityIncrement < 0 || capacityIncrement > 1000)
            throw new ArgumentException("Значение емкости вектора и увеличения емкости должно лежать в пределах от 1 до 1000");

        this.elementCount = 0; this.capacityIncrement = capacityIncrement;
        this.capacity = initialCapacity; this.elementData = new T[this.capacity]; 
        
    }

    public MYVector(int initialCapacity) : this(initialCapacity, 0) { }

    public MYVector() : this(10, 0) { }

    public MYVector (T[] a)
    {
        if (a == null) throw new ArgumentNullException("array a");
        if (a.Length > 1000) throw new ArgumentException("Длина вектора a не должна превышать 1000 элементов");
        this.elementCount = a.Length; this.capacityIncrement = 0; 
        this.elementData = a; this.capacity = a.Length;
    }

    public void Add(T item) // добавляем один элемент в конец
    {
        if (item == null) throw new ArgumentNullException("item");
        while (this.Capacity <= this.elementCount) NewSize();
        if (this.Capacity >= this.elementCount + 1) this.elementData[this.elementCount++] = item;

    }

    private void NewSize()
    {
        T[] newAr = capacityIncrement == 0 ?
            new T[this.Capacity * 2] : new T[this.Capacity + capacityIncrement];
        for (int i = 0; i < this.elementCount; i++) newAr[i] = this.elementData[i];
        this.elementData = newAr;
        this.Capacity = newAr.Length;

    }

    public void AddAll(T[] array) 
    {
        if (array == null) throw new ArgumentNullException("array");

        if (array.Length == 0) return;
        while (array.Length + this.elementCount > this.Capacity) NewSize();
        for (int i=0; i < array.Length; ++i) this.elementData[this.elementCount++] = array[i];
        
    }

    public T Get (int index)
    {
        if(index < 0 || index > this.elementCount) throw new ArgumentOutOfRangeException("index");
        return this.elementData[index];
    }

    public void Clear ()
    {
        this.elementData = []; this.elementCount = 0; this.Capacity = 0;
    }
    
    public bool Contains (object item)
    {
        if (item == null) throw new ArgumentNullException("item");

        foreach (T t in this.elementData)
            if (t.Equals(item)) return true;
        return false;

    }

    public bool ContainsAll (T[] array)
    {
        if (array == null) throw new ArgumentNullException("array");

        if (array.Length == 0) throw new ArgumentException ("array");


        foreach (T item in array)
            if (!this.elementData.Contains(item)) return false;
        return true;

    }

    public bool IsEmpty () =>  this.elementCount == 0;

    public void Remove (object item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        T[] newV = new T[this.Capacity]; int i = 0; bool found = false;

        foreach (T t in this.elementData)
            if (!t.Equals(item)) { newV[i] = t; i++; found = true; }

        if (found) { this.elementCount -=1; this.elementData = newV; }

    }

    public void RemoveAll (T[] array)
    {
        ArgumentNullException.ThrowIfNull(array, nameof(array));
        if (array.Length == 0) return;

        T[] NewV = new T[this.Capacity];
        int index = 0; bool flag;
        foreach (T t in this.elementData)
        {
            flag = false;
            for (int j = 0; j < array.Length || flag; j++)
                if (t.Equals(array[j])) flag = true;

            if (!flag) NewV[index++] = t;

        }
        this.elementData = NewV;
        this.elementCount = index;

    }

    public void RetainAll(T[] array)
    {
        if (this.IsEmpty()) return;
        if (array == null) throw new ArgumentNullException("sent array is empty");
        if (array.Length == 0) return;
        T[] newAr = new T[this.Capacity]; int index = 0;

        foreach (T t in this.elementData)
            foreach (T a in array) if (a != null && t.Equals(a)) { newAr[index++] = t; break; }

        this.elementData = newAr;
        this.elementCount = index;
    }

    public int Size() => this.elementCount;

    public T[] ToArray()
    {
        T[] newAr = new T[this.elementCount];
        for (int i = 0; i < this.elementCount; i++) newAr[i] = this.elementData[i];
        return newAr;

    }

    public void ToArray (ref T[] array)
    {
        if (array == null) array = ToArray();

        if (array.Length >= this.elementCount)
            for (int i = 0; i < this.elementCount; i++) array[i] = this.elementData[i]; return;
        throw new ArgumentException("The length of the array is less than the length of the vector");

    }

    public void Add (int index,  T value)
    {
        if (value == null) throw new ArgumentNullException("value"); 

        if (index < 0 || index > this.elementCount) throw new ArgumentOutOfRangeException("index");

        if (this.Capacity <= this.elementCount) this.NewSize();
        // использовать NewSize  - очень затратно, но не использовать NewSize - метод непонятный
        T[] newV = new T[this.Capacity];
        for (int i = 0, j = 0; i < this.elementCount + 1; i++, j++)
        {
            if (i == index && j == index) { newV[j] = value; i--; continue; }
            newV[j] = this.elementData[i];
        }
        this.elementCount++;
        this.elementData = newV;

    }

    public void ShowEl(int range, int begin = 0)
    {
        if (range < 0 || (begin + range) > this.Capacity || begin < 0) 
            throw new ArgumentOutOfRangeException("range");

        for (int i = begin; i <= begin + range - 1; i++)
            Console.WriteLine(this.elementData[i]);
    }

    public void AddAll(int index, T[] value)
    {
        if (value == null) throw new ArgumentNullException("value"); //?

        if (value.Length == 0) return;

        if (index < 0 || index > this.elementCount) throw new ArgumentOutOfRangeException("index");
        
        while (this.Capacity <= index + value.Length) NewSize();

        T[] newV = new T[this.Capacity];
        for (int i = 0, j = 0; i < this.elementCount + 1; i++, j++)
        {
            if (i == index && j == index) {
                foreach (T val in value) { newV[j] = val; j++; } i--; continue; 
            }
            newV[j] = this.elementData[i];
        }

        this.elementCount += value.Length;
        this.elementData = newV;

    }

    public int IndexOf(T item)
    {
        if (item == null) throw new ArgumentNullException("item");
        for (int i = 0; i < this.elementCount; i++) if (item.Equals(this.elementData[i])) return i;
        return -1;

    }

    public int LatIndexOf(T item)
    {
        if (item == null) throw new ArgumentNullException("item");

        for (int i = this.elementCount - 1; i >= 0; i--) if (this.elementData[i].Equals(item)) return i;

        return -1;

    }

    public T Remove (int index)
    {
        if (index < 0 || index > this.elementCount) throw new ArgumentOutOfRangeException("index");

        T val = Get(index); Remove(val); return val;

    }

    public void Set (int index,  T value)
    {
        if (index < 0 || index > this.elementCount) throw new ArgumentOutOfRangeException("index");
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        this.elementData[index] = value;
    }

    public MYVector<T> SubVector(int fromIndex, int toIndex)
    {
        MYVector<T> sub = new MYVector<T>(fromIndex - toIndex + 1, capacityIncrement);

        for (int i = fromIndex; i < toIndex; i++)
            sub.Add(this.elementData[i]);

        return sub;

    }
    
    public ref T FirstElement () => ref this.elementData[0]; //?

    public ref T LastElement() => ref this.elementData[this.elementCount - 1];

    public void RemoveEl_At(int pos)
    {
        if (pos < 0 || pos > this.elementCount) throw new ArgumentException("pos");

        T[] newV = new T[this.Capacity];
        for (int i = 0, j = 0; i < this.elementCount; i++, j++)
        {
            if (i == pos) { j--; continue; }
            newV[j] = this.elementData[i];
        }

        this.elementData = newV; this.elementCount--;

    }

    public void RemoveRange (int begin, int end)
    {
        if (begin < 0 || begin >= this.elementCount || begin >= end) 
            throw new ArgumentOutOfRangeException("begin");
        if (end < 0 || end > this.elementCount) throw new ArgumentOutOfRangeException("end");

        T[] newV = new T[this.Capacity]; bool flag = false;
        for (int i = 0, j = 0; i < this.elementCount; i++, j++)
        {
            if (i == begin) { j--; flag = true; continue; }
            if (i == end - 1) { j--; flag = false; continue; }
            if (flag) { j--; continue; }
            newV[j] = this.elementData[i];
        }

        this.elementData = newV; this.elementCount -= end - begin;

    }


}
