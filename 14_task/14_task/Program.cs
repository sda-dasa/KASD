
using System;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace task_14
{
    public class MYArrayDeque<E>
    {
        E[] elements; byte head; int tail; public int Size { get { return elements.Length; } }

        //public MYArrayDeque(int numElements = 15) { head = 0; tail = numElements; }

        public MYArrayDeque (int numElements = 16) {  elements = new E[numElements]; head = 0; tail = 0; }



        public MYArrayDeque(E[] array)
        {
            if (array.Length == 0) return;
            head = 0; tail = array.Length - 1;

            elements = new E[array.Length];

            for (int i = 0; i < elements.Length; i++) elements[i] = array[i];
        }


        public bool IsEmpty(E e) => Size == 0;
        


        public void Add(E el)
        {
            if (tail == elements.Length)
            {
                E[] array = new E[(tail * 2) + 1];
                for (int i = 0; i <= tail; i++) array[i] = elements[i];
                elements = array;
            }
            elements[tail++] = el;
            
        }

        public void AddAll(E[] array)
        {
            if (array is null) throw new ArgumentNullException("array");
            if (tail + array.Length >= elements.Length)
            {
                E[] newAr = new E[tail + array.Length + (tail + array.Length) / 2];
                for (int i = 0; i <= tail  - 1; i++) newAr[i] = elements[i];
                elements = newAr;
            }
            for (int i = tail; i < tail + array.Length; i++)
                elements[i] = array[i - tail];
            tail += array.Length;

        }
        
        public bool Contains(object val)
        {
            if (val is null) throw new ArgumentNullException("val");

            for (int i = 0; i <= tail; i++)
            {
                foreach (E t in elements)
                {
                    if (t != null && Equals(t, val)) return true;
                }
            }
            return false;
        }


        public bool ContainsAll(E[] array)
        {
            if (array is null) throw new ArgumentNullException("array");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null && Contains(array[i])) return true;
            }
            return false;
        }
        

        public void Clear(E e) => tail = 0;


        public void Remove(E val)
        {
            if (Contains(val))
            {
                int index = FindIndex(val); E[] array = new E[--tail + 1];
                for (int i = 0; i < index; i++) 
                    array[i] = elements[i];

                for (int i = index + 1; i <= tail; i++) 
                    array[i] = elements[i];
                elements = array;

            }

        }


        public void RemoveAll(E[] array)
        {
            if (array is null) throw new ArgumentNullException("array");
            for (int i = 0; i < array.Length; i++) Remove(array[i]);

        }


        public void RetainAll(E[] a)
        {
            for (int i = 0; i < a.Length; i++) elements[i] = a[i];
            tail = a.Length - 1;
        }
        


        private int FindIndex(object val)
        {
            if (val is null) throw new ArgumentNullException("val");
            for (int i = 0; i <= tail; i++)
                if (val.Equals(elements[i])) return i;
             
            return -1;
        }


        //public void ToArray()
        //{
        //    E[] array = new E[tail];
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        array[i] = elements[i];
        //    }
        //}


        //public E[] ToArray()
        //{
        //    E[] newArr = new E[Size]; for (int i = 0; i <  Size; i++) newArr[i] = elements[i];
        //    return newArr;
        //}


        //public E[] ToArray(E[] arr)
        //{
        //    if (arr is null) { E[] newArr = this.ToArray(); return newArr; }

        //    arr = this.ToArray(); return arr;

        //}





        //public void ToArray(E[] a)
        //{
        //    for (int i = 0; i < tail; i++)
        //    {
        //        Add(a[i]);
        //    }
        //    tail += a.Length;
        //    E[] array = new E[tail];
        //    for (int i = 0; i < array.Length; i++) array[i] = elements[i];
        //}




        public E[] ToArray()
        {
            E[] newAr = new E[Size];
            for (int i = 0; i <= tail; i++) newAr[i] = elements[i];
            return newAr;

        }

        public void ToArray(ref E[] array)
        {
            if (array == null) array = ToArray();

            if (array.Length >= tail + 1)
                for (int i = 0; i < Size; i++) array[i] = elements[i]; return;
            throw new ArgumentException("The length of the array is less than the length of the vector");

        }



        public E Element() => elements[head];
        


        public E Peek()
        {
            if (Size == 0) return default(E);
            return elements[head];
        }


        public E Poll()
        {
            if (Size == 0) return default(E);
            else
            {
                E val = elements[head]; Remove(elements[head]);
                return val;
            }
        }

        public void AddFirst(E val)
        {
            E[] array = new E[++tail + 1];
            array[0] = val;
            for (int i = 1; i <= tail; i++) array[i] = elements[i];
            elements = array;

        }

        public void AddLast(E val)
        {
            if (val is null) throw new ArgumentNullException("val");
            Add(val);
        }
        



        public bool Offer(E val)
        {
            if (val is null) throw new ArgumentNullException("val");
            Add(val);
            if (Contains(val)) return true;
            else return false;
        }




        public E GetFirst()
        {
            return elements[head];
        }


        public E GetLast()
        {
            return elements[tail - 1];
        }



        public bool OfferFirst(E obj)
        {
            AddFirst(obj);
            if (Contains(obj)) return true;
            else return false;
        }




        public bool OfferLast(E obj)
        {
            AddLast(obj);
            if (Contains(obj)) return true;
            else return false;
        }

        public E Pop()
        {
            E element = elements[head];
            Remove(element);
            return element;
        }


        public void Push(E obj)
        {
            E[] array = new E[tail + 1];
            array[0] = obj;
            for (int i = 1; i <= tail; i++) array[i] = elements[i];
            elements = array;
            tail += 1;
        }


        public E PeekFirst()
        {
            if (tail == 0) return default(E);
            else return elements[head];
        }



        public E PeekLast()
        {
            if (tail == 0) return default(E);
            else return elements[tail - 1];
        }




        public E PollFirst()
        {
            if (tail == 0) return default(E);
            else
            {
                E q = elements[head];
                Remove(elements[head]);
                return q;
            }
        }


        public E PollLast()
        {
            if (tail == 0) return default(E);
            else
            {
                E q = elements[tail - 1];
                Remove(elements[tail - 1]);
                return q;
            }
        }


        public E RemoveLast()
        {
            E element = elements[tail - 1];
            Remove(elements[tail - 1]);
            return element;
        }

        public E RemoveFirst()
        {
            E element = elements[head];
            Remove(elements[head]);
            return element;
        }
        public bool RemoveLastOccurrence(object obj)
        {
            int index = -1;
            for (int i = 0; i < tail; i++) if (obj.Equals(elements[i])) index = i;
            if (index > -1)
            {
                E[] array = new E[tail--];
                for (int i = 0; i < index; i++) array[i] = elements[i];
                for (int i = index + 1; i < tail--; i++) array[i] = elements[i];
                elements = array;
                tail--;
                return true;
            }
            else return false;
        }
        public bool RemoveFirstOccurrence(object obj)
        {
            int index = -1;
            for (int i = 0; i < tail; i++) if (obj.Equals(elements[i])) { index = i; break; }
            if (index > -1)
            {
                E[] array = new E[tail--];
                for (int i = 0; i < index; i++) array[i] = elements[i];
                for (int i = index + 1; i < tail--; i++) array[i] = elements[i];
                elements = array;
                tail--;
                return true;
            }
            else return false;
        }
        public void Print()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            string s = "";
            foreach (E t in elements)
            {
                s += t + " ";
            }
            return s;
        }

    }
}