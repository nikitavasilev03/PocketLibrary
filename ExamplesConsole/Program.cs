using PL.Structs;
using System;

using static PL.Console.Out;

namespace ExamplesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            var rnd = new Random();
            int[] array = new int[50];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1000);
            }

            Print(array, "\n");

            tree.AddRange(array);
            Print(tree);
        }
    }
}
