


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
    public void Test2AddDuplicateNodeValue(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic addedNodeValue = GetValue(type);
        tree.Add(addedNodeValue);
        Action action = () => tree.Add(addedNodeValue); 
        var exception =  Assert.Throws<InvalidOperationException>(action);
        Assert.Equal("The value already exists", exception.Message);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test3AddRootNode(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic nodes = tree.InOrderTransversal();
        Assert.Equal(0, nodes.Count);
        dynamic addedNodeValue = GetValue(type);
        tree.Add( addedNodeValue);
        Assert.NotNull(tree.Root);
        Assert.Equal( addedNodeValue, tree.Root.Value);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test4AddNode(string type)
    {
        dynamic tree = CreateTree(type);
        dynamic addedNode = GetValue(type);
        tree.Add(addedNode);
        var searchedNode = tree.Search(tree.Root, addedNode);
        Assert.Equal(addedNode, searchedNode);

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
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        dynamic nonAddedNodeValue3 = GetValue(type);
        tree.Add(addedNodeValue);
        tree.Add(addedNodeValue2);
        tree.Add(addedNodeValue3);

        var exception = Assert.Throws<InvalidOperationException>(() => tree.Remove(nonAddedNodeValue3));
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
        dynamic addedNodeValue = GetValue(type);
        tree.Add(addedNodeValue);
        tree.Remove(addedNodeValue);
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
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        tree.Add(addedNodeValue);
        tree.Add(addedNodeValue2);
        tree.Remove(addedNodeValue);
        Assert.Equal(addedNodeValue2, tree.Root!.Value);
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
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        tree.Add(addedNodeValue);
        tree.Add(addedNodeValue2);
        tree.Remove(addedNodeValue2);
        var result = tree.InOrderTransversal();
        Assert.Equal(1, result.Count);
        var exception = Assert.Throws<InvalidOperationException>(() => tree.Search(tree.Root, addedNodeValue2));
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
        dynamic addedNodeValue1 = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        dynamic addedNodeValue4 = GetValue(type);
        tree.Add(addedNodeValue1);
        testSize++;
        tree.Add(addedNodeValue2);
        testSize++;
        tree.Add(addedNodeValue3);
        testSize++;
        tree.Add(addedNodeValue4);
        testSize++;
        tree.Remove(addedNodeValue4);
        testSize--;
        var result = tree.InOrderTransversal();
        Assert.Equal(testSize, result.Count);
        var exception = Assert.Throws<InvalidOperationException>(() => tree.Search(tree.Root, addedNodeValue4));
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
    public void Test11InOrderTransversalCorrectIntList(int addedNodeValue1, int addedNodeValue2, int addedNodeValue3)
    {
        var tree = new BinarySearchTree<int>();
        tree.Add(addedNodeValue1);
        tree.Add(addedNodeValue2);
        tree.Add(addedNodeValue3);

        var list = new Listt<int> { addedNodeValue1, addedNodeValue2, addedNodeValue3 }.OrderBy(node => node).ToList();
        var result = tree.InOrderTransversal();
        Assert.Equal(list, result);
    }


    [Theory]
    [InlineData("banana", "abacaxi", "cogumelo")]
    public void Test12InOrderTransversalCorrectStringList(string addedNodeValue1, string addedNodeValue2, string addedNodeValue3)
    {
        var tree = new BinarySearchTree<string>();
        tree.Add(addedNodeValue1);
        tree.Add(addedNodeValue2);
        tree.Add(addedNodeValue3);

        var list = new Listt<string> { addedNodeValue1, addedNodeValue2, addedNodeValue3 }.OrderBy(node => node).ToList();
        var result = tree.InOrderTransversal();

        Assert.Equal(list, result);
    }


    [Theory]
    [InlineData(10.5, 5.2, 15.8)]
    public void Test13InOrderTransversalCorrectDoubleList(double addedNodeValue1, double addedNodeValue2, double addedNodeValue3)
    {
        var tree = new BinarySearchTree<double>();
        tree.Add(addedNodeValue1);
        tree.Add(addedNodeValue2);
        tree.Add(addedNodeValue3);

        var list = new Listt<double> { addedNodeValue1, addedNodeValue2, addedNodeValue3 }.OrderBy(node => node).ToList();
        var result = tree.InOrderTransversal();

        Assert.Equal(list, result);
    }

    [Theory]
    [InlineData(10.5f, 5.2f, 15.8f)]
    public void Test14InOrderTransversalCorrectFloatList(float addedNodeValue1, float addedNodeValue2, float addedNodeValue3)
    {
        var tree = new BinarySearchTree<float>();
        tree.Add(addedNodeValue1);
        tree.Add(addedNodeValue2);
        tree.Add(addedNodeValue3);

        var list = new Listt<float> { addedNodeValue1, addedNodeValue2, addedNodeValue3 }.OrderBy(node => node).ToList();
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
        tree.Add(objectt1);
        tree.Add(objectt2);
        tree.Add(objectt3);

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
        tree.Add(min);

        for (int i = 0; i < 9; i++)
        {
            dynamic addedNode = GetValue(type);
            tree.Add(addedNode);

            if (addedNode.CompareTo(min) < 0)
            {
                min = addedNode;
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
        tree.Add(max);

        for (int i = 0; i < 9; i++)
        {
            dynamic addedNode = GetValue(type);
            tree.Add(addedNode);

            if (addedNode.CompareTo(max) > 0)
            {
                max = addedNode;
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
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        dynamic addedNodeValue4 = GetValue(type);
        tree.Add(addedNodeValue);
        tree.Add(addedNodeValue2);
        tree.Add(addedNodeValue3);
        tree.Add(addedNodeValue4);
        var searchedNode = tree.Search(tree.Root!, addedNodeValue3);
        Assert.NotNull(searchedNode);
        Assert.Equal(addedNodeValue3, searchedNode);
        Assert.Equal(addedNodeValue3, searchedNode);
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
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        tree.Add(addedNodeValue);
        tree.Add(addedNodeValue2);
        tree.Add(addedNodeValue3);
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
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        int testSize = 0;
        tree.Add(addedNodeValue);
        testSize++;
        tree.Add(addedNodeValue2);
        testSize++;
        tree.Add(addedNodeValue3);
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
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        tree.Add(addedNodeValue);
        tree.Add(addedNodeValue2);
        Assert.NotEmpty(tree.InOrderTransversal());
        tree.Clear();
        Assert.Null(tree.Root);
        Assert.Empty(tree.InOrderTransversal());
    }



}