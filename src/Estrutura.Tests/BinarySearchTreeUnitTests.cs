

using System.Reflection;
using Estrutura.Core.Domain.BinaryTree;

namespace Estrutura.Tests;

public class BinarySearchTreeUnitTests
{


    [Fact]
    public void Test1TreeStartsEmpty()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        Assert.True(tree.IsEmpty());
        Assert.Equal(0, tree.Size(tree.Root));
    }




    [Fact]
    public void Test2InsertDuplicateNodeValue()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        var node1 = tree.Insert(10);
        tree.Insert(10);
        var result = tree.InOrderTransversal();
        Assert.Single(result);
        Assert.Equal(node1.Value, result[0]);
    }

    [Fact]
    public void Test3InsertRootNode()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        var nodes = tree.InOrderTransversal();
        Assert.Empty(nodes);
        var insertNodeValue = 10;
        var node = tree.Insert(insertNodeValue);

        Assert.NotNull(tree.Root);
        Assert.Equal(node, tree.Root);
        Assert.Equal(node.Value, tree.Root.Value);
    }



    [Fact]
    public void Test4InsertNodeRightAndLeft()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        var nodeValue1 = tree.Insert(10);
        var nodeValue2 = tree.Insert(5);
        var nodeValue3 = tree.Insert(15);
        Assert.Equal(nodeValue1, tree.Root);
        Assert.Equal(nodeValue1.Value, tree.Root.Value);
        Assert.Equal(nodeValue2, tree.Root.Left);
        Assert.Equal(nodeValue2.Value, tree.Root.Left.Value);
        Assert.Equal(nodeValue3, tree.Root.Right);
        Assert.Equal(nodeValue3.Value, tree.Root.Right.Value);
    }

    [Fact]
    public void Test5RemoveNonExistentNode()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        var node2 = tree.Insert(10);
        var node1 = tree.Insert(5);
        var node3 = tree.Insert(15);

        tree.Remove(12);
        List<int> list = new List<int> { node1.Value, node2.Value, node3.Value };
        var result = tree.InOrderTransversal();
        Assert.Equal(list, result);
    }

    [Fact]
    public void Test6RemoveRootNodeWithoutSons()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        var rootNode = tree.Insert(10);
        tree.Remove(rootNode.Value);
        Assert.Null(tree.Root);
    }


    [Fact]
    public void Test7RemoveRootNodeWithSons()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        var rootNode = tree.Insert(10);
        var leftSon = tree.Insert(5);
        tree.Remove(rootNode.Value);
        Assert.Equal(leftSon, tree.Root);
        Assert.Equal(leftSon.Value, tree.Root.Value);
    }

    [Fact]
    public void Test8RemoveNodeLeaf()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        tree.Insert(10);
        tree.Insert(5);

        tree.Remove(5);

        Assert.Null(tree.Root.Left);
    }

    [Fact]
    public void Test9RemoveNodeWithOneSon()
    {
        var tree = new BinarySearchTree<int>();
        tree.Insert(10);
        var nodeValue2 = tree.Insert(5);
        var nodeValue1 = tree.Insert(3);

        tree.Remove(nodeValue2.Value);

        Assert.Equal(nodeValue1, tree.Root.Left);
        Assert.Equal(nodeValue1.Value, tree.Root.Left.Value);
    }

    [Fact]
    public void Test10RemoveNodeWithBothSons()
    {
        var tree = new BinarySearchTree<int>();
        var node2 = tree.Insert(10);
        var node1 = tree.Insert(5);
        var nodeRemoved = tree.Insert(15);
        var node3 = tree.Insert(12);
        var node4 = tree.Insert(18);


        tree.Remove(nodeRemoved.Value);


        var list = new List<int> { node1.Value, node2.Value, node3.Value, node4.Value };
        var result = tree.InOrderTransversal();

        Assert.Equal(list, result);
    }

    [Fact]
    public void Test11RemoveRootWithTwoSons()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        var root = tree.Insert(10);
        var leftSon = tree.Insert(5);
        var rightSon = tree.Insert(15);
        var sucessor = tree.Insert(12);
        tree.Remove(root.Value);
        Assert.Equal(12, tree.Root.Value);
        Assert.Equal(leftSon, tree.Root.Left);
        Assert.Equal(leftSon.Value, tree.Root.Left.Value);
        Assert.Equal(rightSon, tree.Root.Right);
        Assert.Equal(rightSon.Value, tree.Root.Right.Value);
        var list = new List<int> { leftSon.Value, sucessor.Value, rightSon.Value };
        Assert.Equal(list, tree.InOrderTransversal());
    }

    [Fact]
    public void Test12TraverseInOrderEmptyTree()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        var result = tree.InOrderTransversal();
        Assert.Empty(result);
    }

    [Fact]
    public void Test13TraverseInOrderTree()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        var node2 = tree.Insert(10);
        var node1 = tree.Insert(5);
        var node4 = tree.Insert(15);
        var node3 = tree.Insert(12);

        List<int> list = new List<int> { node1.Value, node2.Value, node3.Value, node4.Value };
        var result = tree.InOrderTransversal();

        Assert.Equal(list, result);
    }

    [Fact]
    public void Test14FindSmallestNodeOnTree()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        tree.Insert(10);
        var smallest = tree.Insert(5);
        tree.Insert(15);
        tree.Insert(12);

        var smallestResult = tree.FindSmallestNode(tree.Root);
        Assert.Equal(smallest, smallestResult);
        Assert.Equal(smallest.Value, smallestResult.Value);
    }

    [Fact]
    public void Test15FindBiggestNodeOnTree()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        tree.Insert(10);
        tree.Insert(5);
        var biggest = tree.Insert(15);
        tree.Insert(12);

        var biggestResult = tree.FindBiggestNode(tree.Root);
        Assert.Equal(biggest, biggestResult);
        Assert.Equal(biggest.Value, biggestResult.Value);
    }

    [Fact]
    public void Test16SearchExistenteNodeValue()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        tree.Insert(10);
        tree.Insert(5);
        var node = tree.Insert(15);
        tree.Insert(12);
        var SearchedNode = tree.Search(tree.Root, node.Value);
        Assert.NotNull(SearchedNode);
        Assert.Equal(node, SearchedNode);
        Assert.Equal(node.Value, SearchedNode.Value);
    }

    [Fact]
    public void Test17SearchNonExistenteNodeValue()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(12);
         var nodeValue = 15;
        var nonSearchedNode = tree.Search(tree.Root, nodeValue);
        Assert.Null(nonSearchedNode);
    }

    [Fact]
    public void Test18SizeofEmptyTree()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        Assert.Equal(0, tree.Size(tree.Root));
    }

       [Fact]
    public void Test19VerifyingSizeOfTree()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        int testSize = 0;
        tree.Insert(14);
        testSize++;
        tree.Insert(15);
        testSize++;
        tree.Insert(12);
        testSize++;
        Assert.Equal(testSize, tree.Size(tree.Root));
    }

    [Fact]
    public void Test20ClearEmptyTree()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        Assert.Empty(tree.InOrderTransversal());
        tree.Clear();
        Assert.Equal(tree.Root, null);
        Assert.Empty(tree.InOrderTransversal());
    }

    [Fact]
    public void Test21ClearTree()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();
        tree.Insert(10);
        tree.Insert(5);

        Assert.NotEmpty(tree.InOrderTransversal());

        tree.Clear();
        Assert.Equal(tree.Root, null);
        Assert.Empty(tree.InOrderTransversal());
    }



}