using System;
using System.Collections.Generic;

namespace PL.Structs
{
    public class BinaryTree<T> : ITree, ITree<T>, IPLType
    {
        protected BinaryTreeNode<T> root = null;
        private int deep = 0;
        private int leafCount = 0;
        private IComparer<T> comparer;

        public ITreeNode<T> Root { get => root; }

        public int Deep
        {
            get
            {
                return GetDeepTree(ref root);
            }
        }
        public int LeadCount
        {
            get
            {
                leafCount = 0;
                LeafTreeCount(ref root);
                return leafCount;
            }
        }

        public BinaryTree()
        {
            comparer = Comparer<T>.Default;
        }

        public BinaryTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public void Add(T value)
        {
            AddNode(new BinaryTreeNode<T>(value, null, null), ref root);
        }

        public void AddRange(IEnumerable<T> range)
        {
            foreach (var item in range)
                AddNode(new BinaryTreeNode<T>(item, null, null), ref root);
        }

        public bool Remove(T value)
        {
            return RemoveNode(value, ref root);
        }

        public List<T> LeftNodeRight()
        {
            List<T> list = new List<T>(); 
            LNR(ref root, list);
            return list;
        }

        public List<T> RightNodeLeft()
        {
            List<T> list = new List<T>();
            RNL(ref root, list);
            return list;
        }

        public List<T> NodeLeftRight()
        {
            List<T> list = new List<T>();
            NLR(ref root, list);
            return list;
        }
        
        private void AddNode(BinaryTreeNode<T> node, ref BinaryTreeNode<T> root)
        {
            if (root == null)
                root = node;
            else if (comparer.Compare(node.Value, root.Value) < 0)
                AddNode(node, ref root.Left);
            else if (comparer.Compare(node.Value, root.Value) > 0)
                AddNode(node, ref root.Right);
            else
                root.CountValue++;
            root = Balance(ref root);
        }
        
        private bool RemoveNode(T value, ref BinaryTreeNode<T> root)
        {
            if (root != null)
            {
                if (comparer.Compare(root.Value, value) == 0)
                {
                    BinaryTreeNode<T> l = root.Left, r = root.Right;
                    root = null;
                    if (l != null || r != null)
                    {
                        if (l != null && r == null)
                            AddNode(l, ref this.root);
                        else if (l == null && r != null)
                            AddNode(r, ref this.root);
                        else
                        {
                            AddNode(l, ref this.root);
                            AddNode(r, ref this.root);
                        }                    }
                    return true;
                }
                else if (comparer.Compare(value, root.Value) < 0)
                    return RemoveNode(value, ref root.Left);
                else
                    return RemoveNode(value, ref root.Right);
            }
            else
                return false;
        }
        private void DeepTree(ref BinaryTreeNode<T> root, int deep)
        {
            if (root != null)
            {
                if (deep > this.deep)
                    this.deep = deep;
                DeepTree(ref root.Left, deep + 1);
                DeepTree(ref root.Right, deep + 1);
            }
        }
        private int GetDeepTree(ref BinaryTreeNode<T> root)
        {
            deep = 0;
            DeepTree(ref root, 1);
            return deep;
        }
        private void LeafTreeCount(ref BinaryTreeNode<T> root)
        {
            if (root != null)
            {
                leafCount++;
                LeafTreeCount(ref root.Left);
                LeafTreeCount(ref root.Right);
            }
        }

        private BinaryTreeNode<T> Balance(ref BinaryTreeNode<T> root)
        {
            int z = BFactor(ref root);
            if (z >= 2)
            {
                if (BFactor(ref root.Right) < 0)
                    root.Right = RotateRight(ref root.Right);
                return RotateLeft(ref root);
            }
            if (z <= -2)
            {
                if (BFactor(ref root.Left) > 0)
                    root.Left = RotateLeft(ref root.Left);
                return RotateRight(ref root);
            }
            else
                return root;
        }

        private BinaryTreeNode<T> RotateLeft(ref BinaryTreeNode<T> root)
        {
            BinaryTreeNode<T> node = root.Right;
            BinaryTreeNode<T> temp = node.Left;
            node.Left = root;
            root.Right = temp;
            return node;
        }

        private BinaryTreeNode<T> RotateRight(ref BinaryTreeNode<T> root)
        {
            BinaryTreeNode<T> node = root.Left;
            BinaryTreeNode<T> temp = node.Right;
            node.Right = root;
            root.Left = temp;
            return node;
        }

        private int BFactor(ref BinaryTreeNode<T> root)
        {
            return GetDeepTree(ref root.Right) - GetDeepTree(ref root.Left);   
        }

        private void LNR(ref BinaryTreeNode<T> root, List<T> list)
        {
            if (root != null)
            {
                LNR(ref root.Left, list);
                list.Add(root.Value);
                LNR(ref root.Right, list);
            }
        }

        private void RNL(ref BinaryTreeNode<T> root, List<T> list)
        {
            if (root != null)
            {
                RNL(ref root.Right, list);
                list.Add(root.Value);
                RNL(ref root.Left, list);
            }
        }
        private void NLR(ref BinaryTreeNode<T> root, List<T> list)
        {
            if (root != null)
            {
                list.Add(root.Value);
                NLR(ref root.Left, list);
                NLR(ref root.Right, list);
            }
        }

        public override string ToString()
        {
            return Tree<T>.TreeToString(this);
        }

        
    }
}

