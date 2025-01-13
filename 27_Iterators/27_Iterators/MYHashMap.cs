using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;
using Class_MYHashSet;
using System.Reflection;
using MYCollections;
using MYVector;
using System.Dynamic;


namespace Class_18
{
    internal class Pair<K, E>
    {
        public K key; public E entire; public Pair(K key, E entire) { this.key = key; this.entire = entire; }
    }

    internal class MYHashMap<K, E> : IEnumerable<K>, MyMap<K, E>
    {
        int size; public float LoadFactor { get; private set; } 
        public int Size { get { return size; } set { size = value; } }

        public int Capacity { get { return table.Length; } }

        protected MYLinkedList< Pair<K, E> >[] table;

        public MYHashMap(int initialCapacity = 16, float loadFactor = 0.75F) 
        {
            table = new MYLinkedList<Pair<K, E>>[initialCapacity];

            for (int i = 0; i < initialCapacity; i++) table[i] = new MYLinkedList<Pair<K, E>>();
            
            size = 0; LoadFactor = loadFactor;

        }

        public bool Put (K key, E entire)
        {
            if (key is null) throw new ArgumentNullException("key");

            Pair<K, E> pair = new(key, entire);

            int index = Math.Abs(key.GetHashCode()) % table.Length;

            if (table[index].IsEmpty())
            {
                table[index].AddLast(pair);
            }
            else
            {
                if (table.Length > 0 && (float)size / table.Length >= LoadFactor) NewLength();

                int i = 0;
                foreach (Pair<K, E> p in table[index])
                {
                    if (p.key != null && p.key.GetHashCode() == pair.key.GetHashCode())
                    {
                        if (p.key.Equals(pair.key))
                        { table[index].Set(i, pair); break; }
                    }
                    i++;
                }
                if (i >= table[index].Size - 1) table[index].AddLast(pair);

            }

            size++;

            return true;

        }

        public void NewLength(int added_length = 0)
        {
            MYLinkedList<Pair<K, E>> [] new_table = new MYLinkedList<Pair<K, E>>[(int) (table.Length * 1.75) + added_length];

            for (int i = 0; i < size; i++) new_table[i] = table[i];
                
            for (int i = size; i < new_table.Length; ++i) new_table[i] = new MYLinkedList<Pair<K, E>>();

            table = new_table;

        }



        public void PutAll(MyMap<K, E> m)
        {
            if (m.IsEmpty()) return;
            if (m is null) throw new ArgumentException("map is null");
            K[] keys = m.KeySet().ToArray(); int i = 0;
            foreach (E entries in m.EntrySet().ToArray())
            {
                Put(keys[i], entries); i++;
            }

        }


        public void Сlear()
        {
            table = new MYLinkedList<Pair<K, E>>[table.Length]; size = 0;
        }

        

        public E Get (object key)
        {
            if (key is null) throw new ArgumentException("key");

            int index = Math.Abs(key.GetHashCode()) % table.Length;

            if (table[index].IsEmpty()) throw new Exception("Map is empty");

            foreach (Pair<K, E> p in table[index])
            {
                if (p.key != null && p.key.GetHashCode() == key.GetHashCode())
                {
                    if (p.key.Equals(key)) return p.entire;
                }
            }
            throw new Exception("key is not found");


        }


        public void SetEntire(K key, E value)
        {
            if (key is null) throw new ArgumentException("key");

            int index = Math.Abs(key.GetHashCode()) % table.Length;

            if (table[index].IsEmpty()) return;

            foreach (Pair<K, E> p in table[index])
            {
                if (p.key != null && p.key.GetHashCode() == key.GetHashCode())
                {
                    if (p.key.Equals(key)) p.entire = value;
                }
            }


        }


        public bool ContainsKey(object key)
        {
            if (key is null) throw new ArgumentException("key");

            int index = Math.Abs(key.GetHashCode() % table.Length);

            foreach (Pair<K, E> p in table[index])
            {
                if (p.key != null && p.key.GetHashCode() == key.GetHashCode())
                {
                    if (p.key.Equals(key)) return true; // приведение???
                }
            }
            return false;
        }

        public bool IsEmpty() => size == 0;


        public bool ContainsValue(object value)
        {
            if (value is null) throw new ArgumentException(nameof(value));

            if (IsEmpty()) return false;


            foreach (MYLinkedList<Pair<K, E>> pair in table)
            {
                if (pair.IsEmpty()) continue;

                foreach (Pair<K, E> p in pair)
                {
                    if (p.entire != null && p.entire.Equals(value)) return true;
                }

            }

            return false;

        }


        public MySet<E> EntrySet(MySet<E> input = null)
        {
            if (input is null) input = new MYHashSet<E>();

            input.Clear();
            foreach (MYLinkedList<Pair<K, E>> pair in table)
            {
                foreach (Pair<K, E> p in pair)
                {
                    if (p != null) { input.Add(p.entire);}
                }

            }
            return input;


        }


        public MySet<K> KeySet(MySet<K> input = null)
        {
            if (input is null) input = new MYHashSet<K>();
            input.Clear();
            foreach (MYLinkedList<Pair<K, E>> pair in table)
            {
                foreach (Pair<K, E> p in pair)
                {
                    if (p != null) { input.Add(p.key); }
                }

            }
            return input;


        }

        public MyCollection<E> Values(MyCollection<E> newCollect)
        {
            if (IsEmpty()) return newCollect;

            if (newCollect is null) throw new ArgumentException(nameof(newCollect));

            newCollect.Clear(); newCollect.AddAll(EntrySet());

            return newCollect;

        }

        public bool Remove (object key)
        {

            if (key is null) throw new ArgumentException("key");

            if (IsEmpty()) throw new Exception("Map is empty");

            int index = key.GetHashCode() % table.Length;

            foreach (Pair<K, E> p in table[index])
            {
                if (p.key != null && p.key.GetHashCode() == key.GetHashCode())
                {
                    if (p.key.Equals(key)) 
                    {
                        int s = table[index].Size;
                        table[index].Remove(p);

                        if (s - table[index].Size > 0) { size--; return true; }

                    }
                }
            }
            return false;

        }


        public K FirstKey()
        {
            if (!IsEmpty())
            {
                foreach (MYLinkedList<Pair<K, E>> pair in table)
                    if (!pair.IsEmpty()) return pair.First().key;
            }

            throw new Exception("map is empty");

        }


        public K LastKey()
        {
            if (!IsEmpty())
            {
                K res = default(K);
                foreach (MYLinkedList<Pair<K, E>> pair in table)
                    if (!pair.IsEmpty()) res = pair.Last().key;

                return res;

            }

            throw new Exception("map is empty");

        }




        public K FindNextKey(object currentKey)
        {
            if (IsEmpty()) throw new Exception("hashMap is empty");

            if (currentKey is null) throw new Exception("currentKey is null");

            int index = Math.Abs(currentKey.GetHashCode()) % table.Length;
            int i = 0;
            foreach (Pair<K, E> p in table[index])
            {
                if (p.key != null && p.key.GetHashCode() == currentKey.GetHashCode())
                {
                    if (p.key.Equals(currentKey))
                        try { return table[index].Get(i + 1).key; }
                        catch 
                        {
                            index++; while (table[index].IsEmpty()) index++;

                            return table[index].GetFirst().key;

                                
                        }

                }
                i++;
            }
            index++; while (table[index].IsEmpty()) index++;

            return table[index].GetFirst().key;




        }




        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<K> IEnumerable<K>.GetEnumerator()
        {

            foreach (MYLinkedList<Pair<K, E>> pair in table)
            {
                if (pair.IsEmpty()) continue;

                foreach (Pair<K, E> p in pair)
                {
                    yield return p.key;
                }

            }


        }

        public void clear() { table = new MYLinkedList<Pair<K, E>>[table.Length]; size = 0; }
    }
}
