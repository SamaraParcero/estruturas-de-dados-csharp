using System;
using Estrutura.Core.Domain.BinaryTree;

namespace Estrutura.TestsConsole.BinaryTreeTests;

class BinarySearchTreeMain
{
    static void Main(string[] args)
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

        tree.Insert(15);
        tree.Insert(10);
        tree.Insert(20);
        tree.Insert(8);
        tree.Insert(12);
        tree.Insert(25);


        Console.WriteLine("Tree in orden before removing:");
        tree.InOrderTransversal();


        tree.Remove(10);

        Console.WriteLine();
        Console.WriteLine("Tree after removing:");
        tree.InOrderTransversal();
        Console.WriteLine();

        var node = tree.FindSmallestNode(tree.Root);
        Console.WriteLine("Min Node: " + node.Value);

        tree.Clear();
        tree.InOrderTransversal();


    }
}