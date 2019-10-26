using System.Collections.Generic;

namespace PL.Structs
{
    public class BinaryTreeNode<T> : ITreeNode, ITreeNode<T>, IPLType
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Right;
        public BinaryTreeNode<T> Left;
        public int CountValue { get; set; } = 1;

        public BinaryTreeNode()
        {
        }

        public BinaryTreeNode(T value, BinaryTreeNode<T> right, BinaryTreeNode<T> left)
        {
            Value = value;
            Right = right;
            Left = left;
        }

        public List<ITreeNode<T>> UnderNodes
        {
            get 
            {
                var list = new List<ITreeNode<T>>();
                if (Right != null)
                    list.Add(Right);
                if (Left != null)
                    list.Add(Left);
                return list;
            } 
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
