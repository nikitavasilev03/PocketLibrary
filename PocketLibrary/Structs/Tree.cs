namespace PL.Structs
{
    public class Tree<T> : ITree, ITree<T>, IPLType
    {
        public ITreeNode<T> Root { get; }



        public override string ToString()
        {
            return Tree<T>.TreeToString(this);
        }

        public static string TreeToString(ITree<T> tree)
        {
            return TreeToString(tree.Root, 0, "");
        }

        private static string TreeToString(ITreeNode<T> node, int deep, string chr)
        {
            string s = string.Empty;
            for (int i = 0; i < deep; i++)
                s += "│   ";
            s += chr + node + "\n\r";
            foreach (var item in node.UnderNodes)
                if (item == node.UnderNodes[node.UnderNodes.Count - 1])
                    s += TreeToString(item, deep + 1, "└");
                else
                    s += TreeToString(item, deep + 1, "├");
            return s;
        }
    }
}
