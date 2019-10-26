using System.Collections.Generic;

namespace PL.Structs
{
    public interface ITreeNode
    {

    }
    public interface ITreeNode<T>
    {
        T Value { get; set; }
        List<ITreeNode<T>> UnderNodes { get; }
    }
}
