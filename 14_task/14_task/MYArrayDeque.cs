using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYDeq
{
    internal class MYArrayDeque<E>
    {
        E[] elements; byte head; int tail; public int Size { get { return elements.Length; } }

        //public MYArrayDeque(int numElements = 15) { head = 0; tail = numElements; }

        public MYArrayDeque(int numElements = 16) { elements = new E[numElements]; head = 0; tail = 0; }


#nullable disable
        public MYArrayDeque(E[] array)
        {
            if (array is null) throw new ArgumentNullException("array");
            //if (array.Length == 0) return;
            head = 0; tail = array.Length - 1;

            elements = new E[array.Length];

            for (int i = 0; i < elements.Length; i++) elements[i] = array[i];
        }

#nullable restore

        public bool IsEmpty(E e) => Size == 0;



        public void Add(E val)
        {
            if (val is null) throw new ArgumentNullException("val");
            if (tail == elements.Length)
            {
                E[] array = new E[(tail * 2) + 1];
                for (int i = 0; i < tail; i++) array[i] = elements[i];
                elements = array;
            }
            elements[tail++] = val;

        }

        public void AddAll(E[] array)
        {
            if (array is null) throw new ArgumentNullException("array");
            if (tail + array.Length >= elements.Length)
            {
                E[] newAr = new E[tail + array.Length + (tail + array.Length) / 2];
                for (int i = 0; i <= tail - 1; i++) newAr[i] = elements[i];
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
                int index = IndexFirstOccurence(val); E[] array = new E[--tail + 1];
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



        private int IndexFirstOccurence(object val) // индекс первого вхождения
        {
            if (val is null) throw new ArgumentNullException("val");
            for (int i = 0; i <= tail; i++)
                if (val.Equals(elements[i])) return i;

            return -1;
        }


        private int IndexLastOccurence (object val)
        {
            if (val is null ) throw new ArgumentNullException("val");

            for (int i = tail; i >= 0; i--)
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
            for (int i = 0; i < tail; i++) newAr[i] = elements[i];
            return newAr;

        }

        public void ToArray(ref E[] array)
        {
            if (array == null) array = ToArray();

            if (array.Length >= tail + 1)
                for (int i = 0; i < Size; i++) array[i] = elements[i]; return;
            throw new ArgumentException("The length of the array is less than the length of the vector");

        }



        //public E Element() => elements[head];



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



        public void Push(E val)
        {
            if (val is null) throw new ArgumentNullException(nameof(val));
            E[] array = new E[++tail + 1];
            array[0] = val;
            for (int i = 1; i < tail; i++) array[i] = elements[i - 1];
            elements = array;
        }


        public void AddFirst(E val) => this.Push(val);  
        

        public void AddLast(E val)
        {
            if (val is null) throw new ArgumentNullException("val");
            Add(val);
        }


        public void ShowEl()
        {
            if (Size == 0) return;
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine(elements[i]);
            }
        }



        public E GetFirst()
        {
            if (Size > 0) return elements[head];
            throw new IndexOutOfRangeException("Deque is empty");
        }


        public override string ToString()
        {
            string res = string.Empty;
            for (int i = 0; i < Size; i++)
            {
                res += elements[i] + "\n";
            }
            return res;
        }



        public bool RemoveFirstOccurrence(object obj)
        {
            if (obj is null) throw new ArgumentException("obj");
            int index = IndexFirstOccurence(obj);
            if (index > -1)
            {
                E[] array = new E[tail--];
                for (int i = 0; i < index; i++)
                    array[i] = elements[i];
                for (int i = index + 1; i <= tail; i++)
                    array[i] = elements[i];
                elements = array;
                return true;
            }

            return false;
        }



        public E GetLast()
        {
            if (Size > 0) return elements[tail];
            throw new IndexOutOfRangeException("Deque is empty");
        }


        private bool Offer(E val)
        {
            if (val is null) throw new ArgumentNullException("val");
            Add(val);
            if (Contains(val)) return true;
            else return false;
        }

#nullable disable
        public bool OfferFirst(E val)
        {
            AddFirst(val); if (Contains(val)) return true;
            return false;
        }




        public bool OfferLast(E obj)
        {
            AddLast(obj); if (Contains(obj)) return true;
            return false;
        }
#nullable restore


        public E Pop()
        {
            E val = elements[head];
            Remove(val);
            return val;
        }




        public E PeekFirst()
        {
            if (tail == 0) return default(E);
            else return elements[head];
        }



        public E PeekLast()
        {
            if (Size == 0) return default(E);
            else return elements[tail];
        }


        public bool RemoveLastOccurrence(object obj)
        {
            if (obj is null) throw new ArgumentException("obj");
            int index = IndexLastOccurence(obj);

            if (index > -1)
            {
                E[] array = new E[tail--];
                for (int i = 0; i < index; i++)
                    array[i] = elements[i];
                for (int i = index + 1; i <= tail; i++)
                    array[i] = elements[i];
                elements = array;
                return true;
            }
            return false;

        }





        public E PollFirst()
        {
            if (Size == 0) return default(E);
            else
            {
                E val = elements[head];
                Remove(elements[head]);
                return val;
            }
        }


        public E PollLast()
        {
            if (Size == 0) return default(E);
            else
            {
                E val = elements[tail];
                Remove(elements[tail]);
                return val;
            }
        }


        public E RemoveLast()
        {
            if (Size == 0) throw new IndexOutOfRangeException("Deque is empty");
            E element = elements[tail];
            Remove(elements[tail]);
            return element;
        }

        public E RemoveFirst()
        {
            if (Size == 0) throw new IndexOutOfRangeException("Deque is empty");
            E element = elements[head];
            Remove(elements[head]);
            return element;
        }






    }

}

