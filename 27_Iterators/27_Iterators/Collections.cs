using System;
using System.Collections.Generic;
using Itr;

namespace MYCollections;


// 1) Интерфейс MyCollection

public interface MyCollection<T>
{
    void Add(T e);
    void AddAll(MyCollection<T> a);
    void Clear();
    bool Contains(object o);
    bool ContainsAll(MyCollection<T> a);
    bool IsEmpty();
    bool Remove(object o);
    void RemoveAll(MyCollection<T> a);
    void RetainAll(MyCollection<T> a);
    int Size { get; protected set; }
    T[] ToArray();
    void ToArray(ref T[] a);
    T Get(int index);
}


// 2) Интерфейс MyList
public interface MYList<T> : MyCollection<T>
{
    void Add(int index, T e);
    void AddAll(int index, MyCollection<T> elems);
    //T Get(int index);
    int IndexOf(object o);
    int LastIndexOf(object o);
    MYListIterator<T> ListIterator();
    MYListIterator<T> ListIterator(int index);
    T Remove(int index);
    void Set(int index, T e);
    MyList<T> SubList(int fromIndex, int toIndex);
}

// 4) Интерфейс MyQueue
public interface MyQueue<T> : MyCollection<T>
{
    T Element();
    bool Offer(T obj);
    T Peek();
    T Poll();
}

//// 6) Интерфейс MyDeque
interface MyDeque<T> : MyCollection<T>
{
    void AddFirst(T obj);
    void AddLast(T obj);
    T GetFirst();
    T GetLast();
    bool OfferFirst(T obj);
    bool OfferLast(T obj);
    T Pop();
    void Push(T obj);
    T PeekFirst();
    T PeekLast();
    T PollFirst();
    T PollLast();
    T RemoveLast();
    T RemoveFirst();
    bool RemoveLastOccurrence(object obj);
    bool RemoveFirstOccurrence(object obj);
}

// 8) Интерфейс MySet
public interface MySet<E> : MyCollection<E>
{
    E First();
    E Last();
    MySet<E> SubSet(E fromElement, E toElement);
    MySet<E> HeadSet(E toElement);
    MySet<E> TailSet(E fromElement);
}

// 10) Интерфейс MySortedSet
public interface MySortedSet<E> : MySet<E>
{
    E First();
    E Last();
    MySortedSet<E> SubSet(E fromElement, E toElement);
    MySortedSet<E> HeadSet(E toElement);
    MySortedSet<E> TailSet(E fromElement);
}


// 11) Интерфейс MyNavigableSet
public interface MYNavigableSet<K> : MySortedSet<K>
{
    K LowerEntry(K key);
    K FloorEntry(K key);
    K HigherEntry(K key);
    K CeilingEntry(K key);
    K LowerKey(K key);
    K FloorKey(K key);
    K HigherKey(K key);
    K CeilingKey(K key);
    K PollFirstEntry();
    K PollLastEntry();
    K FirstEntry();
    K LastEntry();
}





// 13) Интерфейс MyMap
interface MyMap<K, E>
{
    void Сlear();
    bool ContainsKey(object key);
    bool ContainsValue(object value);
    MySet<E> EntrySet(MySet<E> input = null);
    E Get(object key);
    bool IsEmpty();
    MySet<K> KeySet(MySet<K> input = null);
    bool Put(K key, E value);
    void PutAll(MyMap<K, E> m);
    bool Remove(object key);
    int Size { get; protected set; }
    MyCollection<E> Values(MyCollection<E> newCollect);
}

// 15) Интерфейс MySortedMap
interface MySortedMap<K, V> : MyMap<K, V> 
{
    K FirstKey();
    K LastKey();
    MySortedMap<K, V> HeadMap(K end);
    MySortedMap<K, V> SubMap(K start, K end);
    MySortedMap<K, V> TailMap(K start);
}

// 16) Интерфейс MyNavigableMap
interface MYNavigableMap<K, V> : MySortedMap<K, V> 
{
    V LowerEntry(K key);

    V FloorEntry(K key);

    V HigherEntry(K key);

    V CeilingEntry(K key);

    K LowerKey(K key);

    K FloorKey(K key);

    K HigherKey(K key);
    
    K CeilingKey(K key);
    
    V PollFirstEntry();
    
    V PollLastEntry();
    
    V FirstEntry();
    
    V LastEntry();

}



