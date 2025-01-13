using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;
using System.Windows.Forms;

namespace Class_18
{
    internal class Pair<K, E>
    {
        public K key; public E entire; public Pair(K key, E entire) { this.key = key; this.entire = entire; }
    }

    internal class MYHashMap<K, E>
    {
        byte size; float loadFactor; public byte Size { get { return size; } }

        MYLinkedList< Pair<K, E> >[] table;

        public MYHashMap(int initialCapacity = 16, float loadFactor = 0.75F) 
        {
            table = new MYLinkedList<Pair<K, E>>[initialCapacity];

            for (int i = 0; i < initialCapacity; i++) table[i] = new MYLinkedList<Pair<K, E>>();
            
            this.size = 0; this.loadFactor = loadFactor;

        }

        public void Put (K key, E entire)
        {
            if (key == null) throw new ArgumentNullException("key");

            Pair<K, E> pair = new Pair<K, E>(key, entire);

            int index = Math.Abs(key.GetHashCode()) % table.Length;

            if (table[index].IsEmpty())
            {
                table[index].AddLast(pair);
            }
            else
            {
                if (table.Length > 0 && (float)size / table.Length >= loadFactor) NewLength();

                int i = 0;
                foreach (Pair<K, E> p in table[index])
                {
                    if (p.key != null && p.key.GetHashCode() == pair.key.GetHashCode())
                    {
                        if (p.key.Equals(pair.key))
                        { table[index].Set(i, pair); size--; break; }
                    }
                    i++;
                }
                if (i >= table[index].Size - 1) table[index].AddLast(pair);

            }

            size++;

        }

        private void NewLength()
        {
            //MYLinkedList<Pair<K, E>> [] new_table = new MYLinkedList<Pair<K, E>>[(int) (table.Length * 1.75)];

            //for (int i = 0; i < size; i++) new_table[i] = table[i];
                
            //for (int i = size; i < new_table.Length; ++i) new_table[i] = new MYLinkedList<Pair<K, E>>();

            //table = new_table;

            MYHashMap<K, E> newmap = new MYHashMap<K, E>(table.Length + table.Length / 2);

            foreach (MYLinkedList<Pair<K, E>> pair in table)
            {
                foreach (Pair<K, E> p in pair)
                {
                    if (p != null) { newmap.Put(p.key, p.entire); }
                }

            }

            this.table = newmap.table;

        }

        public void Clear()
        {
            table = new MYLinkedList<Pair<K, E>>[table.Length]; size = 0;
        }


        public E GetEntire (K key)
        {
            if (key == null) throw new ArgumentException("key");

            int index = Math.Abs(key.GetHashCode()) % table.Length;

            if (table[index].IsEmpty()) return default;

            foreach (Pair<K, E> p in table[index])
            {
                if (p.key != null && p.key.GetHashCode() == key.GetHashCode())
                {
                    if (p.key.Equals(key)) return p.entire;
                }
            }
            return default;


        }


        public void SetEntire(K key, E value)
        {
            if (key == null) throw new ArgumentException("key");

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


        public Pair<K, E>[] EntrySet()
        {
            Pair<K, E>[] res = new Pair<K, E>[size];
            int i = 0;
            foreach (MYLinkedList<Pair<K, E>> pair in table)
            {
                foreach(Pair<K, E> p in pair)
                {
                    if (p != null) { res[i] = p; i++; }
                }

            }
            return res;
        }


        public K[] KeySet()
        {

            K [] res = new K[this.size];
            int i = 0;
            foreach (MYLinkedList<Pair<K, E>> pair in table)
            {
                if (pair.IsEmpty()) continue;

                foreach (Pair<K, E> p in pair)
                {
                    if (p != null) { res[i] = p.key; i++; }
                }

            }
            return res;


        }


        public void Remove (object key)
        {

            if (key is null) throw new ArgumentException("key");

            if (IsEmpty()) throw new Exception("Map is empty");

            int index = key.GetHashCode() % table.Length;

            foreach (Pair<K, E> p in table[index])
            {
                if (p.key != null && p.key.GetHashCode() == key.GetHashCode())
                {
                    if (p.key.Equals(key)) table[index].Remove(p);
                }
            }
            size--;

        }





    }
}
