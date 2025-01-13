using MYCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RBTree
{
    // Implementation of MyTreeMap
    public class MyTreeMap<K, V> : MyNavigableMap<K, V> where K : IComparable<K>
    {
        private Node<K, V> root;
        private int size;
        
        private readonly IComparer<K> comparator;

        public MyTreeMap() : this(null) { }

        public MyTreeMap(IComparer<K> customComparator)
        {
            comparator = customComparator ?? Comparer<K>.Default;
            root = null;
            size = 0;
        }

        public Node<K, V> GetRoot()
        {
            return root;
        }

        private int Compare(K key1, K key2)
        {
            return comparator.Compare(key1, key2);
        }

        public bool ContainsKey(K key)
        {
            return GetNode(key) != null;
        }

        











        public void Put(K key, V value)
        {
            root = Insert(root, key, value);
        }

        public bool Remove(K key)
        {
            if (!ContainsKey(key)) return false;
            root = Delete(root, key);
            size--;
            return true;
        }

        public int Size()
        {
            return size;
        }

        public Node<K, V> GetMinNode()
        {
            return GetMin(root);
        }



        public Node<K, V> GetMaxNode()
        {
            return GetMax(root);
        }

        public Node<K, V> GetNode(K key)
        {
            Node<K, V> current = root;
            while (current != null)
            {
                int cmp = Compare(key, current.Key);
                if (cmp == 0) return current;
                current = cmp < 0 ? current.Left : current.Right;
            }
            return null;
        }

        private Node<K, V> Insert(Node<K, V> node, K key, V value)
        {
            if (node == null)
            {
                size++;
                return new Node<K, V>(key, value) { IsRed = true }; // Новый узел красный
            }

            int cmp = Compare(key, node.Key);
            if (cmp < 0)
                node.Left = Insert(node.Left, key, value);
            else if (cmp > 0)
                node.Right = Insert(node.Right, key, value);
            else
                node.Value = value;

            // Балансировка узлов
            if (IsRed(node.Right) && !IsRed(node.Left))
                node = RotateLeft(node);
            if (IsRed(node.Left) && IsRed(node.Left.Left))
                node = RotateRight(node);
            if (IsRed(node.Left) && IsRed(node.Right))
                FlipColors(node);

            return node;
        }

        private bool IsRed(Node<K, V> node)
        {
            return node != null && node.IsRed;
        }

        private Node<K, V> RotateLeft(Node<K, V> node)
        {
            Node<K, V> x = node.Right;
            node.Right = x.Left;
            x.Left = node;
            x.IsRed = node.IsRed;
            node.IsRed = true;
            return x;
        }

        private Node<K, V> RotateRight(Node<K, V> node)
        {
            Node<K, V> x = node.Left;
            node.Left = x.Right;
            x.Right = node;
            x.IsRed = node.IsRed;
            node.IsRed = true;
            return x;
        }

        private void FlipColors(Node<K, V> node)
        {
            node.IsRed = !node.IsRed;
            if (node.Left != null) node.Left.IsRed = !node.Left.IsRed;
            if (node.Right != null) node.Right.IsRed = !node.Right.IsRed;
        }



        private Node<K, V> Delete(Node<K, V> node, K key)
        {
            if (node == null) return null;

            int cmp = Compare(key, node.Key);
            if (cmp < 0)
            {
                node.Left = Delete(node.Left, key);
            }
            else if (cmp > 0)
            {
                node.Right = Delete(node.Right, key);
            }
            else
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                Node<K, V> minNode = GetMin(node.Right);
                node.Key = minNode.Key;
                node.Value = minNode.Value;
                node.Right = Delete(node.Right, minNode.Key);
            }

            return Balance(node);
        }

        private Node<K, V> GetMin(Node<K, V> node)
        {
            while (node.Left != null) node = node.Left;
            return node;
        }

        private Node<K, V> GetMax(Node<K, V> node)
        {
            while (node.Right != null) node = node.Right;
            return node;
        }

        private Node<K, V> Balance(Node<K, V> node)
        {
            // Placeholder for balancing logic (e.g., red-black tree or AVL tree balancing)
            return node;
        }

        public void PrintTree()
        {
            PrintTreeRecursive(root, "", true);
        }

        private void PrintTreeRecursive(Node<K, V> node, string indent, bool isLast)
        {
            if (node == null)
                return;

            Console.Write(indent);
            if (isLast)
            {
                Console.Write("└──");
                indent += "   ";
            }
            else
            {
                Console.Write("├──");
                indent += "|  ";
            }

            if (node == root)
            {
                //root.IsRed = false;

                Console.ForegroundColor = node.IsRed ? ConsoleColor.Gray : ConsoleColor.Red;
                Console.WriteLine($"{node.Key}");
                Console.ResetColor();


            }
            else 
            {
                Console.ForegroundColor = node.IsRed ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine($"{node.Key}");
                Console.ResetColor();
            }

            

            PrintTreeRecursive(node.Left, indent, false);
            PrintTreeRecursive(node.Right, indent, true);
        }


        public class Node<TK, TV>
        {
            public TK Key { get; set; }
            public TV Value { get; set; }
            public Node<TK, TV> Left { get; set; }
            public Node<TK, TV> Right { get; set; }
            public bool IsRed { get; set; } // True for Red, False for Black

            public Node(TK key, TV value)
            {
                Key = key;
                Value = value;
                Left = null;
                Right = null;
                IsRed = false; // New nodes are red by default
            }
        }











        public V PollFirstEntry()
        {
            V val = FirstEntry();
            Remove(HigherKey(GetRoot().Key));
            return val;
        }
        public V PollLastEntry()
        {
            V el = LastEntry();
            Remove(LowerKey(GetRoot().Key));
            return el;
        }
        public V FirstEntry()
        {
            return LowerEntry(GetRoot().Key);
        }
        public V LastEntry()
        {
            return LowerEntry(GetRoot().Key);
        }





        public V LowerEntry(K key)
        {
            return GetRoot().Left.Value;
        }
        public V FloorEntry(K key)
        {
            throw new NotImplementedException();
        }
        public V HigherEntry(K key)
        {
            return GetRoot().Right.Value;
        }
        public V CeilingEntry(K key)
        {
            throw new NotImplementedException();
        }
        public K LowerKey(K key)
        {
            return GetNode(key).Key;
        }
        public K FloorKey(K key)
        {
            return GetNode(key).Left.Key;
        }
        public K HigherKey(K key)
        {
            return GetNode(key).Right.Key;
        }
        public K CeilingKey(K key)
        {
            throw new NotImplementedException();
        }










    }












}
