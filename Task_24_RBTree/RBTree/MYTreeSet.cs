using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTree
{
    // Implementation of MyTreeSet
    public class MyTreeSet<E> where E : IComparable<E>
    {
        internal MyTreeMap<E, object> m;

        public MyTreeSet() => m = new MyTreeMap<E, object>();

        public MyTreeSet(MyTreeMap<E, object> map) => m = map;

        public MyTreeSet(IComparer<E> comparator) => m = new MyTreeMap<E, object>(comparator);

        public MyTreeSet(IEnumerable<E> collection)
        {
            m = new MyTreeMap<E, object>();
            foreach (var item in collection)
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

        public void AddAll(IEnumerable<E> collection)
        {
            foreach (var item in collection)
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

        public bool ContainsAll(IEnumerable<E> collection)
        {
            return collection.All(Contains);
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public bool Remove(E element)
        {
            return m.Remove(element);
        }

        public void RemoveAll(IEnumerable<E> collection)
        {
            foreach (var item in collection)
            {
                Remove(item);
            }
        }

        public void RetainAll(IEnumerable<E> collection)
        {
            var set = new HashSet<E>(collection);
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
    }

    

}
