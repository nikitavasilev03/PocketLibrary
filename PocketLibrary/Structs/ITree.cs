using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Structs
{
    public interface ITree
    {

    }
    public interface ITree<T>
    {
        ITreeNode<T> Root { get; }
    }
}
