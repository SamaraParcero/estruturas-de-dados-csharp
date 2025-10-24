

namespace DataStructure.Core.Domain.Queues;

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
    }

    public T Dequeue()
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
        return node.Value;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        size = 0;
    }

    public bool Contains(T value)
    {
        var actual = head;
        while (actual != null)
        {
            if (EqualityComparer<T>.Default.Equals(actual.Value, value))
            {
                return true;
            }
            actual = actual.Next;
        }
        return false;
    }






}