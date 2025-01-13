using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{

    internal class Node<T> 
    {
        public Node(T info) => this.Info = info;

        public T Info { get; set; }

        public Node<T> Prev {  get; set; } public Node<T> Next { get; set; }


    }



    internal class MYLinkedList<T> : IEnumerable<T>
    {

        private Node<T> first; private Node<T> last; private int size;
        public int Size { get { return size; } }
        //LinkedList<sbyte> list;

        public MYLinkedList()
        {

        }

        public MYLinkedList(T[] arr)
        {

            if (arr is null) throw new ArgumentNullException(nameof(arr));

            foreach (T item in arr)
            {
                AddLast(item);
            }


        }


        public void AddLast(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            Node<T> node = new Node<T>(item);

            if (first is null)
                first = node;
            else
            {
                last.Next = node; // if last is null????
                node.Prev = last;
            }
            last = node;
            size++;



        }

        public void AddFirst(T item) // ???
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            Node<T> node = new Node<T>(item);
            Node<T> temp = first; //  а если first is null??? 
            node.Next = temp;
            first = node;
            if (size == 0)
                last = first;
            else
                temp.Prev = node; // ???? 
            size++;


        }


        public void Clear()
        {
            first = default(Node<T>); last = default(Node<T>); size = 0;
        }


        public T Get(int index)
        {
            if (index < 0 || index > Size - 1) throw new ArgumentOutOfRangeException(nameof(index));

            Node<T> current = first; int i = 0;
            while (current != null)
            {
                if (index == i++) return current.Info;
                current = current.Next;
            }
            throw new Exception("list must not contain null");

        }


        public T GetFirst()
        {
            if (first is null || Size == 0) throw new Exception("List is Empty");

            return first.Info;

        }

        public T GetLast()
        {
            if (last is null || Size == 0) throw new Exception("List is Empty");

            return last.Info;
        }


        public int IndexOf(object item)
        {
            Node<T> current = first; int i = 0;
            while (current != null)
            {
                if (current.Info != null && current.Info.Equals(item)) return i;
                current = current.Next; i++;
            }
            if (i < Size - 1) throw new Exception("list must not contain null");

            return -1;

        }

        public int LastIndexOf(object item)
        {
            Node<T> current = last; int i = Size - 1;
            while (current != null)
            {
                if (current.Info != null && current.Info.Equals(item)) return i;
                current = current.Prev; i--;
            }
            if (i > 0) throw new Exception("list must not contain null");

            return -1;

        }


        public void Set(int index, T value)
        {
            if (index < 0 || index >= Size) throw new IndexOutOfRangeException(nameof(index));

            int i = 0;
            Node<T> current = first;
            while (current != null)
            {
                if (i == index) { current.Info = value; return; }
                current = current.Next; i++;
            }
            //if (i < index) throw new Exception("list must not contain null"); // ???

        }


        public bool Remove (int index)
        {
            if (index < 0 || index >= Size) throw new ArgumentOutOfRangeException(nameof(index));

            Node<T> current = GetNode(index);


            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    // если последний
                    last = current.Prev;
                }

                // если узел не первый
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    // если первый
                    first = current.Next;
                }
                size--;

                return true;

            }
            return false;


        }


        private Node<T> GetNode(int index)
        {
            if (index < 0 || index >= Size) throw new ArgumentOutOfRangeException(nameof(index));

            if (first is null || Size == 0) throw new Exception("List is Empty");

            Node<T> current = first; int i = 0;

            // поиск удаляемого узла
            while (current != null)
            {
                if (index == i)
                {
                    break;
                }
                current = current.Next;
            }
            if (current is null && index < i) throw new Exception("List must not contain null");
            return current;

        }




        public void Remove(T info)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));
            if (first is null || Size == 0) throw new Exception("List is Empty");

            Node<T> current = first;

            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Info.Equals(info))
                {
                    break;
                }
                current = current.Next;
            }

            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    // если последний
                    last = current.Prev;
                }

                // если узел не первый
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    // если первый
                    first = current.Next;
                }
                size--;

            }


        }


        public void RemoveFirst()
        {
            first = first.Next; first.Prev = null; size--;
        }

        public void RemoveLast()
        {
            last = last.Prev; last.Next = null; size--;
        }


        public void RemoveAll(T[] arr)
        {
            if (arr is null) throw new ArgumentNullException(nameof(arr));
            if (first is null || Size == 0) throw new Exception("List is empty");

            foreach (T item in arr) Remove(item);

        }

        public void RetainAll(T[] arr)
        {
            Clear(); AddAll(arr);
        }


        public void Add(T item) => AddLast(item);

        public void AddAll(T[] arr)
        {
            if (arr is null) throw new ArgumentNullException(nameof(arr));
            foreach (T item in arr) AddLast(item);

        }

        public bool IsEmpty() => Size == 0 || first is null && last is null;

        public bool Contains(T item)
        {
            Node<T> current = first;
            while (current != null)
            {
                if (current.Info != null && current.Info.Equals(item))
                    return true;
                current = current.Next;
            }
            return false;
        }


        public bool ContainsAll(T[] arr)
        {
            if (arr is null) throw new ArgumentNullException(nameof(arr));
            bool flag = true;
            foreach (T item in arr)
                if (!Contains(item)) { flag = false; break; }
            return flag;

        }


        public T[] ToArray()
        {
            T[] newAr = new T[size]; int i = 0;
            foreach (T item in this)
            {
                newAr[i] = item; i++;
            }

            return newAr;

        }

        public void ToArray(ref T[] arr)
        {
            if (arr == null) arr = ToArray();

            if (arr.Length >= Size)
            {
                int i = 0;
                foreach (var item in this)
                {
                    arr[i] = item; i++;
                }
                return;
            }
            throw new ArgumentException("The length of the array is less than the length of the list");

        }


        public T PeekFirst ()
        {
            if (IsEmpty()) return default(T);

            return first.Info;
        }

        public T PeekLast()
        {
            if (IsEmpty() || last is null) return default(T);
            return last.Info;

        }

        public T PollFirst()
        {
            if (IsEmpty()) return default(T);

            T temp = first.Info;
            first = first.Next; first.Prev = null; size--;
            return temp;

        } 

        public T PollLast()
        {

            if (IsEmpty()) return default(T);

            T temp = last.Info;
            last = last.Prev; last.Next = null; size--;
            return temp;
        }

        public T Pop()
        {
            if (IsEmpty()) throw new Exception("List is Empty");

            T temp = first.Info;
            first = first.Next; first.Prev = null; size--;
            return temp;

        }

        public bool OfferFirst(T value)
        {
            AddFirst(value); return Contains(value);
        }

        public bool OfferLast (T value)
        {
            AddLast(value); return Contains(value);
        }

        public void Pop(T item) => AddFirst(item);

        public bool RemoveFirstOccurrence(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            //if (IsEmpty()) return false;
            int index = IndexOf(value);

            if (index < 0) return false;

            return Remove(index);

        }


        public bool RemoveLastOccurence(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            //if (IsEmpty()) return false;
            int index = LastIndexOf(value);

            if (index < 0) return false;

            return Remove(index);

        }


        public MYLinkedList<T> SubList(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || fromIndex >= Size)
                throw new ArgumentOutOfRangeException(nameof(fromIndex));
            if (toIndex < 0 || toIndex >= Size)
                throw new ArgumentOutOfRangeException(nameof(toIndex));

            if (IsEmpty()) throw new Exception("list is empty"); 

            Node<T> from = null; Node<T> to = null;

            Node<T> current = first; int i = 0;
            while (current != null)
            {
                if (fromIndex == i) from = current;
                if (toIndex == i) to = current.Next;
                    
                current = current.Next; i++;
            }

            MYLinkedList<T> sub = new MYLinkedList<T>();
            
            current = from; i = 0; 
            //to.Next = null; from.Prev = null;

            while (current != to)
            {
                sub.AddLast(current.Info);
                current = current.Next; i++;
            }
            sub.size = i + 1;

            return sub;

        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = first;
            while (current != null)
            {
                yield return current.Info;
                current = current.Next;
            }
        }





    }
}
