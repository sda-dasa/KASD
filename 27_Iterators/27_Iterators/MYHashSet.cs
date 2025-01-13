using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_18;
using Itr;
using LinkedList;
using task_14;
using MYCollections;



namespace Class_MYHashSet
{
    internal class MYHashSet <E> : MySet<E>
    {
        MYHashMap<E, object> map; 
        public int Size { get { return map.Size; } set { return; } }

        public MYHashSet(int initialCapacity = 16, float loadFactor = 0.75F)
        {
            map = new MYHashMap<E, object>(initialCapacity, loadFactor);
        }
        


        public MYHashSet(MyCollection<E> arr) 
        {
            map = new MYHashMap<E, object>(arr.Size);

            if (arr is null) throw new ArgumentNullException();

            //map = new MYHashMap<E, object>(arr.Length); 
                                   
            foreach (E el in arr.ToArray()) { map.Put(el, false); } 

        }

       public bool Remove(object item) => map.Remove(item);
       

        public void Add(E el)
        {
            if (el is null) throw new ArgumentNullException();
            
            map.Put(el, false);

        }

        public void AddAll(MyCollection<E> arr)
        {
            if (arr is null) throw new ArgumentNullException();

            if (arr.Size + Size / map.Capacity >= map.LoadFactor)
                map.NewLength(arr.Size);

            foreach (E el in arr.ToArray()) if (!(el is null)) map.Put(el, false);

        }

        public void Clear() { map.clear(); }

        //public void Clear() => map.Clear();

        public bool IsEmpty() => map.IsEmpty();

        public bool Contains (object el)
        {
            if (el is null) return false;

            if (!map.IsEmpty()) return map.ContainsKey(el);
            else return false;

        }
               

        public bool ContainsAll(MyCollection<E> arr)
        {
            if (arr is null) return false;
            if (map.IsEmpty()) return false;

            foreach (E item in arr.ToArray()) if (!map.ContainsKey(item)) return false;

            return true;

        }


        public void RemoveAll(MyCollection<E> arr)
        {
            if (arr is null) throw new ArgumentNullException();

            if (map.IsEmpty()) return;

            int s = Size;

            foreach (E item in arr.ToArray()) map.Remove(item);

        }

        public bool RemoveAll (object[] arr)
        {
            if (arr is null) throw new ArgumentNullException();

            if (map.IsEmpty()) return false;

            int s = Size;           

            foreach (E item in arr) map.Remove(item);
              
            return arr.Length == 0 || s - Size > 0;

        }

        public void RetainAll(MyCollection<E> arr)
        {
            if (arr is null) throw new ArgumentNullException();

            if (map.IsEmpty()) throw new Exception ("map is null");

            map.clear(); AddAll(arr);
        }




        public E[] ToArray()
        {
            E[] newAr = new E[Size]; int i = 0;
            foreach (var item in map)
            {
                newAr[i] = item; i++;
            }

            return newAr;

        }

        


        public void ToArray(ref E[] arr)
        {
            if (arr is null) arr = ToArray();

            if (arr.Length >= Size)
            {
                int i = 0;
                foreach (var item in map)
                {
                    arr[i] = item; i++;
                }
                return;
            }
            throw new ArgumentException("The length of the array is less than the length of the list");

        }


        public E First()
        {
            if (map.IsEmpty()) throw new Exception("map is null");
            return map.FirstKey();
        }

        public E Last()
        {
            if (map.IsEmpty()) throw new Exception("map is null");
            return map.LastKey();
        }


        public E Get (int index)
        {
            if (map.IsEmpty()) throw new Exception("map is empty");

            if (index > Size) throw new Exception("index out of the set");
            
            int i = 0;

            foreach (var item in map)
                if (i == index) return item;

            return default(E);

        }


        public E FindNext (object curr)
        {

            if (curr is null) throw new ArgumentNullException();

            return map.FindNextKey(curr);


        }



        public MySet<E> SubSet (E fromEl, E toEl)
        {
            MYHashSet<E> newSet = new MYHashSet<E>(Size);
            bool flag = false;
            foreach (var item in map)
            {
                if (item.Equals(fromEl) || flag)
                {
                    flag = true; newSet.Add(item);
                }
                if (item.Equals(toEl)) break;

            }
            return newSet;


        }




        public MYItr<E> Iterator() => new MYItr<E>(this);

        public MySet<E> HeadSet(E toElement)
        {
            throw new NotImplementedException();
        }

        public MySet<E> TailSet(E fromElement)
        {
            throw new NotImplementedException();
        }

        public class MYItr<T> : MYIterator<T>
        {

            public T Cursor { get; private set; }
            MYHashSet<T> mSet;

            public MYItr(MYHashSet<T> mSet)
            {
                try { Cursor = mSet.First(); } catch { throw new Exception("mSet is Empty"); }

                this.mSet = mSet;

            }


            public bool HasNext()
            {
                if (Cursor is null) throw new Exception("Set is Empty");

                if (!Cursor.Equals(mSet.Last())) return true;

                return false;

            }


            public T Next()
            {

                if (Cursor is null) throw new Exception("Set is Empty");

                if (HasNext()) return mSet.FindNext(Cursor);

                throw new Exception("outside of the set");

            }

            public bool Remove()
            {
                if (Cursor is null) throw new Exception("Set is Empty");

                T newCursor = Next();

                if (mSet.map.Remove(Cursor)) { Cursor = newCursor; return true; }

                return false;

            }


        }









    }







}
