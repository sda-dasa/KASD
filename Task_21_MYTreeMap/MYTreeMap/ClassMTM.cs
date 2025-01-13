using System.Numerics;
using System.Xml.Linq;
using MYVector;

namespace ClassMTM
{


    internal class TreeNode<K, V>
    {
        public V Value { get; set; } public K Key { get; set; }
        public TreeNode<K, V>? Left { get; set; }
        public TreeNode<K, V>? Right { get; set; }

        public TreeNode(K key, V value)
        {
            Value = value; Key = key;
        }

    }

    internal class MYTreeMap<K, V> 
    {
        
        private IComparer<K> comparator;
        public TreeNode<K, V>? root;
        public int Size {  get; private set; }

        public MYTreeMap()
        {
            comparator = Comparer<K>.Default; Size = 0;
        }

        public MYTreeMap (IComparer<K> comparator)
        {
            this.comparator = comparator; Size = 0;
        }

        public void Clear()
        {
            root = null; Size = 0;

        }

        public bool IsEmpty() => Size == 0;

        private int Compare(K key1, K key2) => comparator.Compare(key1, key2);


        public void Put (K key, V value) => root = Put(key, value, root);

        private TreeNode<K,V> Put (K key, V value, TreeNode<K, V> root)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            if (value is null) throw new ArgumentNullException(nameof(value));

            if (root is null)
            {
                root = new TreeNode<K, V> (key, value); Size++; return root;
            }
            if (Compare(root.Key, key) > 0)
            {
                Size++; root.Left = Put(key, value, root.Left);

            }
            else
            {
                Size++; root.Right = Put(key, value, root.Right);

            }

            return root;


        }

        public bool ContainsKey(object key) => ContainsKey(key, root);

        private bool ContainsKey (object key, TreeNode<K, V> root)
        {
            if (key is null) throw new ArgumentNullException (nameof(key));

            if (root is null) return false;

            if (key is K okey)
            {
                if (Compare(root.Key, okey) == 0) return true;

                if (Compare (root.Key, okey) > 0) return ContainsKey(key, root.Left);

                if (Compare (root.Key, okey) < 0) return ContainsKey (key, root.Right);

            }
            return false;


        }


        public bool ContainsValue (object value) => ContainsValue(value, root);


        private bool ContainsValue(object val,  TreeNode<K, V> root)
        {
            if (val is null) throw new ArgumentNullException(nameof(val));

            if (!(root is null))
            {
                if (!(root.Value is null) && root.Value.Equals(val)) return true;
                
                return ContainsValue(val, root.Left) || ContainsValue(val, root.Right);
                                
            }
            return false;

        }


        public V? GetValue (K key) => GetValue (key, root);

        private V? GetValue (K key, TreeNode<K, V> root)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            if (!(root is null))
            {

                if (Compare(root.Key, key) == 0) return root.Value;

                if (Compare(root.Key, key) > 0) return GetValue(key, root.Left);

                if (Compare(root.Key, key) < 0) return GetValue(key, root.Right);

            }
            return default;

        }


        public void Remove(object key) { root = Remove(key, root); Size--; }

        private TreeNode<K, V>? Remove (object key, TreeNode<K, V> root)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            if (root is null) return root;

            if (key is K okey)
            {
                if (Compare(root.Key, okey) > 0) root.Left = Remove(key, root.Left);
                
                if (Compare (root.Key, okey) < 0) root.Right = Remove(key, root.Right);

                if (Compare (root.Key, okey) == 0)
                {
                    if (root.Left is null) return root.Right;

                    if (root.Right is null) return root.Left;

                    root.Key = LeftNode(root.Right).Key; root.Value = LeftNode(root.Right).Value;

                    root.Right = Remove(root.Key, root.Right);

                }
                return root;

            }
            throw new Exception("key can not be type K");



        }

        private TreeNode<K, V> LeftNode (TreeNode<K, V> root)
        {
            TreeNode<K, V> leftNode = root;
            while (root.Left != null)
            {
                leftNode = root.Left;
                root = root.Left;
            }
            return leftNode;
        }

        public K? FirstKey()
        {
            TreeNode<K, V> node = root;
            while (!(node.Left is null) && !(node is null)) node = node.Left;

            return node.Key;

        }

        public K? LastKey()
        {
            TreeNode<K, V> node = root;
            while (!(node.Right is null) && !(node is null)) node = node.Right;

            return node.Key;
        }



        public (K, V)? FirstEntry ()
        {
            TreeNode<K, V> node = root;
            while (!(node.Left is null) && !(node is null)) node = node.Left;

            return (node.Key, node.Value);

        }


        public (K, V)? LastEntry()
        {
            TreeNode<K, V> node = root;
            while (!(node.Right is null) && !(node is null)) node = node.Right;

            return (node.Key, node.Value);
        }



        public MYTreeMap<K, V> HeadMap(K keyend) // < keyend
        {
            if (keyend is null) throw new ArgumentNullException(nameof(keyend));

            MYTreeMap<K, V> newTree = new MYTreeMap<K, V>(comparator);
            TreeNode<K, V> node = root;
            while (node != null)
            {
                if (Compare(node.Key, keyend) < 0) newTree.Put(node.Key, node.Value);
                node = node.Left;

            }
            return newTree;

        }


        public void KeySet() => KeySet(root);
        
        private MYVector<K> KeySet(TreeNode<K, V> root, MYVector<K>? set = null)
        {
            if (set is null) set = new MYVector<K>();
            if (root != null)
            {
                KeySet(root.Left, set);
                set.Add(root.Key);
                KeySet(root.Right, set);
            }
            return set;

        }


        public MYTreeMap<K, V> SubMap(K start, K end) => SubMap(start, end, root);


        private MYTreeMap<K, V> SubMap(K start, K end, TreeNode<K, V> root, MYTreeMap<K, V> result = null)
        {
            if (start is null || end is null) throw new ArgumentNullException();

            if (result is null) result = new MYTreeMap<K, V>(comparator);

            if (root != null)
            {
                if (Compare(root.Key, start) >= 0 && Compare(root.Key, end) < 0) 
                    result.Put(root.Key, root.Value);
                SubMap(start, end, root.Left, result);
                SubMap(start, end, root.Right, result);

            }
            return result;


        }



        public MYTreeMap<K, V> TailMap(K keystart) // > keystart
        {
            if (keystart is null) throw new ArgumentNullException(nameof(keystart));

            MYTreeMap<K, V> newTree = new MYTreeMap<K, V>(comparator);
            TreeNode<K, V> node = root;
            while (node != null)
            {
                if (Compare(root.Key, keystart) > 0) newTree.Put(node.Key, node.Value);
                node = node.Right;

            }
            return newTree;

        }


        public (K, V)? LowerEntry (K key) // <
        {            
            if (key is null) throw new ArgumentNullException(nameof(key));

            TreeNode<K, V> node = root;

            while (node != null)
            {
                if (Compare(node.Key, key) >= 0 && Compare(node.Left.Key, key) < 0)
                    return (node.Left.Key, node.Left.Value);

                if (Compare(node.Key, key) < 0 && Compare(node.Right.Key, key) >= 0)
                    return (node.Key, node.Value);

                if (Compare(node.Key, key) >= 0 && Compare(node.Left.Key, key) >= 0)
                    node = node.Left;

                if (Compare(node.Key, key) < 0 && Compare(node.Right.Key, key) < 0)
                    node = node.Right;

            }
            return null;

        }




        public (K, V)? FloorEntry(K key) // <=
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            TreeNode<K, V> node = root;

            while (node != null)
            {
                if (Compare(node.Key, key) > 0 && Compare(node.Left.Key, key) <= 0)
                    return (node.Left.Key, node.Left.Value);

                if (Compare(node.Key, key) <= 0 && Compare(node.Right.Key, key) > 0)
                    return (node.Key, node.Value);

                if (Compare(node.Key, key) > 0 && Compare(node.Left.Key, key) > 0)
                    node = node.Left;

                if (Compare(node.Key, key) < 0 && Compare(node.Right.Key, key) < 0)
                    node = node.Right;

            }
            return null;

        }





        public (K, V)? HigherEntry(K key) // >
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            TreeNode<K, V> node = root;

            while (node != null)
            {
                if (Compare(node.Key, key) > 0 && Compare(node.Left.Key, key) <= 0)
                    return (node.Key, node.Value);

                if (Compare(node.Key, key) <= 0 && Compare(node.Right.Key, key) > 0)
                    return (node.Right.Key, node.Right.Value);

                if (Compare(node.Key, key) <= 0 && Compare(node.Right.Key, key) <= 0)
                    node = node.Right;

                if (Compare(node.Key, key) >= 0 && Compare(node.Left.Key, key) >= 0)
                    node = node.Left;

            }
            return null;

        }



        public (K, V)? CeilingEntry(K key)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            TreeNode<K, V> node = root;

            while (node != null)
            {
                if (Compare(node.Key, key) >= 0 && Compare(node.Left.Key, key) < 0)
                    return (node.Key, node.Value);

                if (Compare(node.Key, key) < 0 && Compare(node.Right.Key, key) >= 0)
                    return (node.Right.Key, node.Right.Value);

                if (Compare(node.Key, key) < 0 && Compare(node.Right.Key, key) < 0)
                    node = node.Right;

                if (Compare(node.Key, key) > 0 && Compare(node.Left.Key, key) > 0)
                    node = node.Left;

            }
            return null;

        }



        public (K, V)? PollFirstEntry()
        {            
            TreeNode<K, V> node = root;
            while (!(node.Left.Left is null) && !(node is null)) node = node.Left;

            (K, V)? res = (node.Left.Key, node.Left.Value);

            node.Left = null;

            return res;


        }


        public (K, V)? PollLastEntry()
        {
            TreeNode<K, V> node = root;
            while (!(node.Right.Right is null) && !(node is null)) node = node.Right;

            (K, V)? res = (node.Right.Key, node.Right.Value);

            node.Right = null;

            return res;

        }







    }





}
