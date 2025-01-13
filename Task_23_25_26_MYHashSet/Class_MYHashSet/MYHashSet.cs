using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_18;
using LinkedList;



namespace Class_MYHashSet
{
    internal class MYHashSet <E>  
    {
        MYHashMap<E, object> map; public int Size { get { return map.Size; }}

        public MYHashSet(int initialCapacity = 16, float loadFactor = 0.75F)
        {
            map = new MYHashMap<E, object>(initialCapacity, loadFactor);
        }
        


        public MYHashSet(E [] arr) 
        {
            map = new MYHashMap<E, object>(arr.Length);

            if (arr is null) throw new ArgumentNullException();

            //map = new MYHashMap<E, object>(arr.Length); 
                                   
            foreach (E el in arr) { map.Put(el, false); } 

        }

       

        public void Add(E el)
        {
            if (el is null) throw new ArgumentNullException();
            
            map.Put(el, false);

        }

        public void AddAll(E[] arr)
        {
            if (arr is null) throw new ArgumentNullException();

            if (arr.Length + Size / map.Capacity >= map.LoadFactor) map.NewLength(arr.Length);

            foreach (E el in arr) if (! (el is null)) map.Put(el, false);

        }


        public bool Contains (object el)
        {
            if (el is null) return false;

            if (!map.IsEmpty()) return map.ContainsKey(el);
            else return false;

        }
               

        public bool ContainsAll(E[] arr)
        {
            if (arr is null) return false;
            if (map.IsEmpty()) return false;

            foreach (E item in arr) if (!map.ContainsKey(item)) return false;

            return true;

        }
                

        public bool RemoveAll (E[] arr)
        {
            if (arr is null) throw new ArgumentNullException();

            if (map.IsEmpty()) return false;

            int s = Size;           

            foreach (E item in arr) map.Remove(item);
              
            return arr.Length == 0 || s - Size > 0;

        }

        public bool RetainAll(E[] arr)
        {
            if (arr is null) throw new ArgumentNullException();

            if (map.IsEmpty()) throw new Exception ("map is null");

            map.Clear(); AddAll(arr); if (ContainsAll(arr)) return true;

            return false;
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






    }
}
