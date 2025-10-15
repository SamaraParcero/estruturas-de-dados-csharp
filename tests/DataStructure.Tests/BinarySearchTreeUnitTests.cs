


using System.Collections.Immutable;
using DataStructure.Core.Domain.BinaryTree;

namespace DataStructure.Tests;

public class BinarySearchTreeUnitTests
{

    private static Random random = new Random(123);
    private static int count = 0;

    private dynamic CreateTree(string type)
    {
        switch (type)
        {
            case "int":
                return new BinarySearchTree<int>();

            case "string":
                return new BinarySearchTree<string>();

            case "double":
                return new BinarySearchTree<double>();

            case "float":
                return new BinarySearchTree<float>();

            case "object":
                return new BinarySearchTree<Objectt>();

            default:
                throw new ArgumentException("Invalid Type");
        }
    }

    private dynamic GetValue(string type)
    {
        count++;

        switch (type)
        {
            case "int":
                return random.Next(1, 10000) + count;

            case "string":
                return $"valor{random.Next(1, 10000) + count}";

            case "double":
                return Math.Round(random.NextDouble() * 10000 + count, 2);

            case "float":
                return (float)Math.Round(random.NextDouble() * 10000 + count, 2);

            case "object":
                return new Objectt($"Obj{count}");

            default:
                throw new ArgumentException("Invalid Type");
        }
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test1TreeStartsEmpty(string type)
    {
        dynamic tree = CreateTree(type);
        Assert.True(tree.IsEmpty());
        Assert.Equal(0, tree.Size(tree.Root));
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test2InsertDuplicateNodeValue(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic insertedNodeValue = GetValue(type);
        tree.Insert(insertedNodeValue);
        var exception = Assert.Throws<InvalidOperationException>(() => tree.Insert(insertedNodeValue));
        Assert.Equal("The value already exists", exception.Message);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test3InsertRootNode(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic nodes = tree.InOrderTransversal();
        Assert.Empty(nodes);
        dynamic insertNodeValue = GetValue(type);
        dynamic node = tree.Insert(insertNodeValue);
        Assert.NotNull(tree.Root);
        Assert.Equal(node, tree.Root);
        Assert.Equal(node.Value, tree.Root.Value);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test4InsertNode(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic insertedNode = GetValue(type);
        tree.Insert(insertedNode);
        var searchedNode = tree.Search(tree.Root, insertedNode);
        Assert.Equal(insertedNode, searchedNode.Value);

    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test5RemoveNonExistentNode(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic insertedNodeValue = GetValue(type);
        dynamic insertedNodeValue2 = GetValue(type);
        dynamic insertedNodeValue3 = GetValue(type);
        dynamic nonInsertedNodeValue3 = GetValue(type);
        tree.Insert(insertedNodeValue);
        tree.Insert(insertedNodeValue2);
        tree.Insert(insertedNodeValue3);

        var exception = Assert.Throws<InvalidOperationException>(() => tree.Remove(nonInsertedNodeValue3));
        Assert.Equal("The value doesn't exist", exception.Message);

    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test6RemoveRootNodeWithoutSons(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic insertedNodeValue = GetValue(type);
        var rootNode = tree.Insert(insertedNodeValue);
        tree.Remove(rootNode.Value);
        Assert.Null(tree.Root);
        Assert.Empty(tree.InOrderTransversal());
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test7RemoveRootNodeWithSon(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic insertedNodeValue = GetValue(type);
        dynamic insertedNodeValue2 = GetValue(type);
        dynamic rootNode = tree.Insert(insertedNodeValue);
        var son = tree.Insert(insertedNodeValue2);
        tree.Remove(rootNode.Value);
        Assert.Equal(son, tree.Root);
        Assert.Equal(son.Value, tree.Root!.Value);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test8RemoveNodeLeaf(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic insertedNodeValue = GetValue(type);
        dynamic insertedNodeValue2 = GetValue(type);
        var node1 = tree.Insert(insertedNodeValue);
        var node2 = tree.Insert(insertedNodeValue2);
        tree.Remove(insertedNodeValue2);
        var result = tree.InOrderTransversal();
        Assert.Single(result);
        Assert.Null(node1.Left);
        Assert.Null(node1.Right);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test9RemoveNode(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic insertNodeValue1 = GetValue(type);
        dynamic insertNodeValue2 = GetValue(type);
        dynamic insertNodeValue3 = GetValue(type);
        dynamic insertNodeValue4 = GetValue(type);
        tree.Insert(insertNodeValue1);
        tree.Insert(insertNodeValue2);
        tree.Insert(insertNodeValue3);
        tree.Insert(insertNodeValue4);
        tree.Remove(insertNodeValue4);
        var searchedNode = tree.Search(tree.Root, insertNodeValue4);
        Assert.Null(searchedNode);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test10TraverseInOrderEmptyTree(string type)
    {
        dynamic tree = CreateTree(type);
        var result = tree.InOrderTransversal();
        Assert.Empty(result);
    }


    [Theory]
    [InlineData(10, 5, 15)]
    public void Test11InOrderTransversalCorrectIntList(int insertNodeValue1, int insertNodeValue2, int insertNodeValue3)
    {
        var tree = new BinarySearchTree<int>();
        tree.Insert(insertNodeValue1);
        tree.Insert(insertNodeValue2);
        tree.Insert(insertNodeValue3);

        var list = new List<int> { insertNodeValue1, insertNodeValue2, insertNodeValue3 }.OrderBy(node => node).ToList();
        var result = tree.InOrderTransversal();

        Assert.Equal(list, result);
    }

    
    [Theory]
    [InlineData("banana", "abacaxi", "cogumelo")]
    public void Test12InOrderTransversalCorrectStringList(string insertNodeValue1, string insertNodeValue2, string insertNodeValue3)
    {
        var tree = new BinarySearchTree<string>();
        tree.Insert(insertNodeValue1);
        tree.Insert(insertNodeValue2);
        tree.Insert(insertNodeValue3);

        var list = new List<string> { insertNodeValue1, insertNodeValue2, insertNodeValue3 }.OrderBy(node => node).ToList();
        var result = tree.InOrderTransversal();

        Assert.Equal(list, result);
    }


    [Theory]
    [InlineData(10.5, 5.2, 15.8)]
    public void Test13InOrderTransversalCorrectDoubleList(double insertNodeValue1, double insertNodeValue2, double insertNodeValue3)
    {
        var tree = new BinarySearchTree<double>();
        tree.Insert(insertNodeValue1);
        tree.Insert(insertNodeValue2);
        tree.Insert(insertNodeValue3);

        var list = new List<double> { insertNodeValue1, insertNodeValue2, insertNodeValue3 }.OrderBy(node => node).ToList();
        var result = tree.InOrderTransversal();

        Assert.Equal(list, result);
    }

    [Theory]
    [InlineData(10.5f, 5.2f, 15.8f)]
    public void Test14InOrderTransversalCorrectFloatList(float insertedNodeValue1, float insertedNodeValue2, float insertedNodeValue3)
    {
        var tree = new BinarySearchTree<float>();
        tree.Insert(insertedNodeValue1);
        tree.Insert(insertedNodeValue2);
        tree.Insert(insertedNodeValue3);

        var list = new List<float> { insertedNodeValue1, insertedNodeValue2, insertedNodeValue3 }.OrderBy(node => node).ToList();
        var result = tree.InOrderTransversal();

        Assert.Equal(list, result);
    }


    [Fact]
    public void Test15InOrderTransversalCorrectObjectList()
    {
        var objectt1 = new Objectt("banana");
        var objectt2 = new Objectt("abacaxi");
        var objectt3 = new Objectt("laranja");

        var tree = new BinarySearchTree<Objectt>();
        tree.Insert(objectt1);
        tree.Insert(objectt2);
        tree.Insert(objectt3);

        var list = new List<Objectt> { objectt2, objectt1, objectt3 };
        var result = tree.InOrderTransversal();

        Assert.Equal(list.Select(node => node.Name), result.Select(node => node.Name));
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test16FindSmallestNodeOnTree(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic min = GetValue(type);
        tree.Insert(min);

        for (int i = 0; i < 9; i++)
        {
            dynamic insertNode = GetValue(type);
            tree.Insert(insertNode);

            if (insertNode.CompareTo(min) < 0)
            {
                min = insertNode;
            }

        }

        var smallest = tree.FindSmallestNode(tree.Root!);
        Assert.Equal(min, smallest.Value);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test17FindBiggestNodeOnTree(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic max = GetValue(type);
        tree.Insert(max);

        for (int i = 0; i < 9; i++)
        {
            dynamic insertNode = GetValue(type);
            tree.Insert(insertNode);

            if (insertNode.CompareTo(max) > 0)
            {
                max = insertNode;
            }

        }

        var biggest = tree.FindBiggestNode(tree.Root!);
        Assert.Equal(max, biggest.Value);

    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test18SearchExistenteNodeValue(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic insertedNodeValue = GetValue(type);
        dynamic insertedNodeValue2 = GetValue(type);
        dynamic insertedNodeValue3 = GetValue(type);
        dynamic insertedNodeValue4 = GetValue(type);
        tree.Insert(insertedNodeValue);
        tree.Insert(insertedNodeValue2);
        var node = tree.Insert(insertedNodeValue3);
        tree.Insert(insertedNodeValue4);
        var SearchedNode = tree.Search(tree.Root!, node.Value);
        Assert.NotNull(SearchedNode);
        Assert.Equal(node, SearchedNode);
        Assert.Equal(node.Value, SearchedNode.Value);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test19SearchNonExistenteNodeValue(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic insertedNodeValue = GetValue(type);
        dynamic insertedNodeValue2 = GetValue(type);
        dynamic insertedNodeValue3 = GetValue(type);
        tree.Insert(insertedNodeValue);
        tree.Insert(insertedNodeValue2);
        tree.Insert(insertedNodeValue3);
        var nodeValue = GetValue(type);
        var nonSearchedNode = tree.Search(tree.Root!, nodeValue);
        Assert.Null(nonSearchedNode);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test20SizeofEmptyTree(string type)
    {
        dynamic tree = CreateTree(type);
        Assert.Equal(0, tree.Size(tree.Root));
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test21VerifyingSizeOfTree(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic insertedNodeValue = GetValue(type);
        dynamic insertedNodeValue2 = GetValue(type);
        dynamic insertedNodeValue3 = GetValue(type);
        int testSize = 0;
        tree.Insert(insertedNodeValue);
        testSize++;
        tree.Insert(insertedNodeValue2);
        testSize++;
        tree.Insert(insertedNodeValue3);
        testSize++;
        Assert.Equal(testSize, tree.Size(tree.Root!));
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test22ClearEmptyTree(string type)
    {
        dynamic tree = CreateTree(type);
        Assert.Empty(tree.InOrderTransversal());
        tree.Clear();
        Assert.Null(tree.Root);
        Assert.Empty(tree.InOrderTransversal());
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test23ClearTree(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic insertedNodeValue = GetValue(type);
        dynamic insertedNodeValue2 = GetValue(type);
        tree.Insert(insertedNodeValue);
        tree.Insert(insertedNodeValue2);

        Assert.NotEmpty(tree.InOrderTransversal());

        tree.Clear();
        Assert.Null(tree.Root);
        Assert.Empty(tree.InOrderTransversal());
    }



}