

using Estrutura.Core.Domain.BinaryTree;

namespace Estrutura.Core.Domain.Queues;

public class Queuee<T>
{
    public QueueNode<T>? head;
    public QueueNode<T>? tail;
    private int size;

    public int Count => size;


    public Queuee()
    {
        head = null;
        tail = null;
        size = 0;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public void Enqueue(T value)
    {
        QueueNode<T> node = new QueueNode<T>(value);

        if (IsEmpty())
        {
            head = node;
            tail = node;
        }
        else
        {
            tail.Next = node;
            tail = node;
        }

        size++;
        //Console.WriteLine("Enqueued: " + value);
    }

    public QueueNode<T> Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var node = head;
        head = head.Next;

        if (head == null)
        {
            tail = null;
        }

        size--;
        //Console.WriteLine("Dequeued: " + node.Value);
        return node;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        size = 0;
    }



    public List<T> ViewQueue()
    {
        List<T> nodes = new List<T>();
        var actual = head;

        while (actual != null)
        {
            nodes.Add(actual.Value);
            //Console.Write(actual.Value + " ");
            actual = actual.Next;

        }

        return nodes;
    }



}