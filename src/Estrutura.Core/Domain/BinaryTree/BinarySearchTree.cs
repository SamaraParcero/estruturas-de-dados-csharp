
using Estrutura.Core.Domain.BinaryTree;

namespace Estrutura.Core.Domain.BinaryTree;

public class BinarySearchTree<T> where T : IComparable<T>
{
    public Node<T>? Root;

    public BinarySearchTree()
    {
        Root = null;

    }

    public bool IsEmpty()
    {
        return Root == null;
    }



    public Node<T> Insert(T value)
    {
        Node<T> node = new Node<T>(value);

        if (Root == null)
        {
            Root = node;
        }
        else
        {
            InsertRecursive(Root, node);
        }

        return node;
    }

    private void InsertRecursive(Node<T> actual, Node<T> node)
    {
        if (node.Value.CompareTo(actual.Value) < 0)
        {
            if (actual.Left == null)
            {
                actual.Left = node;
            }
            else
            {
                InsertRecursive(actual.Left, node);
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
                InsertRecursive(actual.Right, node);
            }
        }
       
    }

    public List<T> InOrderTransversal()
    {
        List<T> nodes = new List<T>();
        InOrderRecursive(Root, nodes);
        return nodes;
    }

    private void InOrderRecursive(Node<T> node, List<T> nodes)
    {
        if (node != null)
        {
            InOrderRecursive(node.Left, nodes);
            nodes.Add(node.Value);
            InOrderRecursive(node.Right, nodes);
        }
    }

    public void Remove(T value)
    {
        Root = RemoveRecursive(Root, value);
    }


    private Node<T> RemoveRecursive(Node<T> actualNode, T value)
    {
        if (actualNode == null)
        {
            return null;
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
            actualNode.Value = successor.Value;
            actualNode.Right = RemoveRecursive(actualNode.Right, successor.Value);
        }

        return actualNode;
    }

    public Node<T> FindSmallestNode(Node<T> node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node;
    }

    public Node<T> FindBiggestNode(Node<T> node)
    {
        while (node.Right != null)
        {
            node = node.Right;
        }
        return node;
    }

    public Node<T> Search(Node<T> node, T value)
    {
        if (node == null)
        {
            return null;
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
            return node;
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