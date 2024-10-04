namespace MYVector;

public class MYVector<T>
{
    private T[]? elementData; // ? // массив для хранения элементов вектора
    private int elementCount; // количество элементов в массиве

    private int capacityIncrement; // значение, на кот увеличивается емкость вектора при необходимости

    private int capacity; 
    public int Capacity { get { return capacity; } private set { capacity = value; } }

    public MYVector(int initialCapacity, int capacityIncrement)
    {
        if (initialCapacity < 0 || initialCapacity > 1000 || capacityIncrement < 0 || capacityIncrement > 1000)
            throw new Exception("Значение емкости вектора и увеличения емкости должно лежать в пределах от 0 до 1000");

        this.elementCount = initialCapacity; this.capacityIncrement = capacityIncrement;
        this.elementData = new T[this.elementCount];
    }

    public MYVector(int initialCapacity) : this(initialCapacity, 0) { }

    public MYVector() : this(10, 0) { }

    public MYVector (T[] a)
    {
        if (a == null) throw new ArgumentNullException("array a");

        this.elementCount = a.Length; this.capacityIncrement = 0; this.elementData = a;

    }

    public void Add(T item) // добавляем один элемент в конец
    {
        if (item == null) throw new ArgumentNullException("item");
        if (this.Capacity <= this.elementCount) NewSize();
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

    public void addAll() { }


}
