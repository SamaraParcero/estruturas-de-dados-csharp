
using DataStructure.Core.Domain.Lists;

namespace DataStructure.Core.Domain.BinaryTree;

public class BinarySearchTree<T> where T : IComparable<T>
{
    internal Node<T>? Root { get; set; }

    public BinarySearchTree()
    {
        Root = null;

    }

    public bool IsEmpty()
    {
        return Root == null;
    }



    public void Add(T value)
    {
        var node = new Node<T>(value);

        if (Root == null)
        {
            Root = node;
        }
        else
        {
            AddRecursive(Root, node);
        }

    }

    private void AddRecursive(Node<T> actual, Node<T> node)
    {
        if (node.Value.CompareTo(actual.Value) < 0)
        {
            if (actual.Left == null)
            {
                actual.Left = node;
            }
            else
            {
                AddRecursive(actual.Left, node);
            }
        }
        else if (node.Value.CompareTo(actual.Value) > 0)
        {
            if (actual.Right == null)
            {
                actual.Right = node;
            }
            else
            {
                AddRecursive(actual.Right, node);
            }
        }
        else
        {
            throw new InvalidOperationException("The value already exists");
        }

    }

    public Listt<T> InOrderTransversal()
    {
        Listt<T> nodes = new Listt<T>();
        InOrderRecursive(Root, nodes);
        return nodes;
    }

    private void InOrderRecursive(Node<T> node, Listt<T> nodes)
    {
        if (node != null)
        {
            InOrderRecursive(node.Left, nodes);
            nodes.Add(node.Value);
            InOrderRecursive(node.Right, nodes);
        }
    }

    public T Remove(T value)
    {
        T removedValueNode = value;
        Root = RemoveRecursive(Root, value);
        return removedValueNode;
    }


    private Node<T> RemoveRecursive(Node<T> actualNode, T value)
    {
        if (actualNode == null)
        {
            throw new InvalidOperationException("The value doesn't exist");
        }

        if (value.CompareTo(actualNode.Value) < 0)
        {
            actualNode.Left = RemoveRecursive(actualNode.Left, value);
        }
        else if (value.CompareTo(actualNode.Value) > 0)
        {
            actualNode.Right = RemoveRecursive(actualNode.Right, value);
        }
        else
        {
            if (actualNode.Left == null)
            {
                return actualNode.Right;
            }
            if (actualNode.Right == null)
            {
                return actualNode.Left;
            }
            Node<T> successor = FindSmallestNode(actualNode.Right);
            actualNode = new Node<T>(successor.Value){Left = actualNode.Left, Right = RemoveRecursive(actualNode.Right, successor.Value)};

        }

        return actualNode;
    }

    private Node<T> FindSmallestNode(Node<T> node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node;
    }

    public T FindSmallestValue(Node<T> node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node.Value;
    }

    public T FindBiggestValue(Node<T> node)
    {
        while (node.Right != null)
        {
            node = node.Right;
        }
        return node.Value;
    }

    public T Search(Node<T> node, T value)
    {
        if (node == null)
        {
            throw new InvalidOperationException("The value doesn't exist");
        }

        if (value.CompareTo(node.Value) < 0)
        {
            return Search(node.Left, value);
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            return Search(node.Right, value);
        }
        else
        {
            return node.Value;
        }
    }

    public int Size(Node<T> node)
    {
        if (node == null)
        {
            return 0;
        }
        return 1 + Size(node.Left) + Size(node.Right);
    }

    public void Clear()
    {
        Root = null;
    }

}