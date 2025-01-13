using Itr;
using MYCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTree
{
    // Implementation of MyTreeSet
    public class MyTreeSet<E>: MyNavigableSet<E> where E : IComparable<E> 
    {
        internal MyTreeMap<E, object> m;

        public MyTreeSet() => m = new MyTreeMap<E, object>();

        public MyTreeSet(MyTreeMap<E, object> map) => m = map;

        public MyTreeSet(IComparer<E> comparator) => m = new MyTreeMap<E, object>(comparator);

        public MyTreeSet(MyCollection<E> collection)
        {
            m = new MyTreeMap<E, object>();
            foreach (var item in collection.ToArray())
            {
                Add(item);
            }
        }

        public MyTreeSet(MyTreeSet<E> sortedSet)
        {
            m = new MyTreeMap<E, object>();
            foreach (var item in sortedSet.ToArray())
            {
                Add(item);
            }
        }

        public bool Add(E element)
        {
            if (!m.ContainsKey(element))
            {
                m.Put(element, null);
                return true;
            }
            return false;
        }

        public void AddAll(MyCollection<E> collection)
        {
            foreach (var item in collection.ToArray())
            {
                Add(item);
            }
        }

        public void Clear()
        {
            m = new MyTreeMap<E, object>();
        }

        public bool Contains(E element)
        {
            return m.ContainsKey(element);
        }

        public bool ContainsAll(MyCollection<E> collection)
        {
            return collection.ToArray().All(Contains);
        }




        public E LowerEntry(E key)
        {
            return m.LowerKey(key);

        }


        public E FloorEntry(E key)
        {
            return m.FloorKey(key);
        }
        
        public E HigherEntry(E key)
        {
            return m.HigherKey(key);
        }
        
        public E CeilingEntry(E key)
        {
            return m.CeilingKey(key);
        }
        
        public E LowerKey(E key)
        {
            return m.LowerKey(key);
        }
        
        public E FloorKey(E key)
        {
            return m.FloorKey(key);
        }
        
        
        public E HigherKey(E key)
        {
            return m.HigherKey(key);
        }
        
        public E CeilingKey(E key)
        {
            return m.CeilingKey(key);
        }
        
        
        
        
        public E PollFirstEntry()
        {
            return m.LowerKey(m.GetRoot().Key);
        }
        
        
        public E PollLastEntry()
        {
            return m.LowerKey(m.GetRoot().Key);
        }
        
        
        public E FirstEntry()
        {
            return m.LowerKey(m.GetRoot().Key);
        }
        
        
        
        public E LastEntry()
        {
            return m.HigherKey(m.GetRoot().Key);
        }









        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public bool Remove(E element)
        {
            return m.Remove(element);
        }

        public void RemoveAll(MyCollection<E> collection)
        {
            foreach (var item in collection.ToArray())
            {
                Remove(item);
            }
        }

        public void RetainAll(MyCollection<E> collection)
        {
            var set = new HashSet<E>(collection.ToArray());
            foreach (var item in ToArray())
            {
                if (!set.Contains(item))
                {
                    Remove(item);
                }
            }
        }

        public int Size()
        {
            return m.Size();
        }

        public E[] ToArray()
        {
            var list = new List<E>();
            InOrderTraversal(m.GetRoot(), list);
            return list.ToArray();
        }

        public E First()
        {
            var minNode = m.GetMinNode();
            if (minNode == null) throw new InvalidOperationException("Set is empty.");
            return minNode.Key;
        }

        public E Last()
        {
            var maxNode = m.GetMaxNode();
            if (maxNode == null) throw new InvalidOperationException("Set is empty.");
            return maxNode.Key;
        }

        // Helper methods
        private void InOrderTraversal(MyTreeMap<E, object>.Node<E, object> node, List<E> list)
        {
            if (node == null) return;
            InOrderTraversal(node.Left, list);
            list.Add(node.Key);
            InOrderTraversal(node.Right, list);
        }







        public MYItr<E> Iterator() => new MYItr<E>(this);




        public class MYItr<T> : MYIterator<T> where T: IComparable<T>            
        {

            public T Cursor { get; private set; }
            MyTreeSet<T> mTree;

            public MYItr(MyTreeSet<T> mTree)
            {
                Cursor = mTree.First();

                this.mTree = mTree;

            }


            public bool HasNext()
            {
                if (!Cursor.Equals(mTree.Last())) return true;

                return false;

            }


            public T Next()
            {
                if (HasNext()) return mTree.m.GetNode(Cursor).Right.Key;

                throw new Exception("outside of queue");

            }

            public bool Remove()
            {
                T newCursor = Next();

                if (mTree.Remove(Cursor) is T el) { Cursor = newCursor; return true; }

                return false;

            }


        }




    }






}
