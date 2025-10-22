


using System.Collections.Immutable;
using DataStructure.Core.Domain.BinaryTree;
using DataStructure.Core.Domain.Lists;

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
        Assert.Equal(0, nodes.Count);
        dynamic insertNodeValue = GetValue(type);
        dynamic node = tree.Insert(insertNodeValue);
        Assert.NotNull(tree.Root);
        Assert.Equal(node, tree.Root.Value);
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
        Assert.Equal(insertedNode, searchedNode);

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
        tree.Insert(insertedNodeValue);
        tree.Remove(insertedNodeValue);
        Assert.Null(tree.Root);
        dynamic nodes = tree.InOrderTransversal();
        Assert.Equal(0, nodes.Count);
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
        tree.Insert(insertedNodeValue);
        tree.Insert(insertedNodeValue2);
        tree.Remove(insertedNodeValue);
        Assert.Equal(insertedNodeValue2, tree.Root!.Value);
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
        tree.Insert(insertedNodeValue);
        tree.Insert(insertedNodeValue2);
        tree.Remove(insertedNodeValue2);
        var result = tree.InOrderTransversal();
        Assert.Equal(1, result.Count);
        var exception = Assert.Throws<InvalidOperationException>(() => tree.Search(tree.Root, insertedNodeValue2));
        Assert.Equal("The value doesn't exist", exception.Message);

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
        int testSize = 0;
        dynamic insertNodeValue1 = GetValue(type);
        dynamic insertNodeValue2 = GetValue(type);
        dynamic insertNodeValue3 = GetValue(type);
        dynamic insertNodeValue4 = GetValue(type);
        tree.Insert(insertNodeValue1);
        testSize++;
        tree.Insert(insertNodeValue2);
        testSize++;
        tree.Insert(insertNodeValue3);
        testSize++;
        tree.Insert(insertNodeValue4);
        testSize++;
        tree.Remove(insertNodeValue4);
        testSize--;
        var result = tree.InOrderTransversal();
        Assert.Equal(testSize, result.Count);
        var exception = Assert.Throws<InvalidOperationException>(() => tree.Search(tree.Root, insertNodeValue4));
        Assert.Equal("The value doesn't exist", exception.Message);
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
        Assert.Equal(0, result.Count);
    }


    [Theory]
    [InlineData(10, 5, 15)]
    public void Test11InOrderTransversalCorrectIntList(int insertNodeValue1, int insertNodeValue2, int insertNodeValue3)
    {
        var tree = new BinarySearchTree<int>();
        tree.Insert(insertNodeValue1);
        tree.Insert(insertNodeValue2);
        tree.Insert(insertNodeValue3);

        var list = new Listt<int> { insertNodeValue1, insertNodeValue2, insertNodeValue3 }.OrderBy(node => node).ToList();
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

        var list = new Listt<string> { insertNodeValue1, insertNodeValue2, insertNodeValue3 }.OrderBy(node => node).ToList();
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

        var list = new Listt<double> { insertNodeValue1, insertNodeValue2, insertNodeValue3 }.OrderBy(node => node).ToList();
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

        var list = new Listt<float> { insertedNodeValue1, insertedNodeValue2, insertedNodeValue3 }.OrderBy(node => node).ToList();
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

        var list = new Listt<Objectt> { objectt2, objectt1, objectt3 };
        var result = tree.InOrderTransversal();

        Assert.Equal(list.Select(node => node.Name), result.Select(node => node.Name));
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test16FindSmallestValueOnTree(string type)
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

        var smallest = tree.FindSmallestValue(tree.Root!);
        Assert.Equal(min, smallest);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test17FindBiggestValueOnTree(string type)
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

        var biggest = tree.FindBiggestValue(tree.Root!);
        Assert.Equal(max, biggest);

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
        tree.Insert(insertedNodeValue3);
        tree.Insert(insertedNodeValue4);
        var searchedNode = tree.Search(tree.Root!, insertedNodeValue3);
        Assert.NotNull(searchedNode);
        Assert.Equal(insertedNodeValue3, searchedNode);
        Assert.Equal(insertedNodeValue3, searchedNode);
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
        var exception = Assert.Throws<InvalidOperationException>(() => tree.Search(tree.Root, nodeValue));
        Assert.Equal("The value doesn't exist", exception.Message);
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