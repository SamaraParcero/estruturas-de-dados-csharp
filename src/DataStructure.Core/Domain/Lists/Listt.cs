

using System.Collections;

namespace DataStructure.Core.Domain.Lists;

public class Listt<T> : IEnumerable<T>
{

    internal ListNode<T>? head;
    internal ListNode<T>? tail;
    private int size;

    public int Count => size;


    public Listt()
    {
        head = null;
        tail = null;
        size = 0;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public void Add(T value)
    {
        ListNode<T> node = new ListNode<T>(value);
        if (head == null)
        {
            head = node;
            tail = node;
            size++;
        }
        else
        {
            tail.Next = node;
            tail = node;
            size++;
        }
    }

    public void AddFirst(T value)
    {
        ListNode<T> node = new ListNode<T>(value);
        if (head == null)
        {
            head = node;
            tail = node;
            size++;
        }
        else
        {
            node.Next = head;
            head = node;
            size++;
        }

    }

    public void Add(int position, T value)
    {
        if (position < 0 || position > size)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position out of range");
        }

        ListNode<T> node = new ListNode<T>(value);

        if (position == 0)
        {
            node.Next = head;
            head = node;
            if (tail == null)
            {
                tail = node;
            }
            size++;
        }
        else
        {
            ListNode<T> actual = head;

            for (int i = 0; i < position - 1; i++)
            {
                actual = actual.Next;
            }

            node.Next = actual.Next;
            actual.Next = node;

            if (node.Next == null)
            {
                tail = node;
            }
            size++;
        }


    }

    public T Remove(T value)
    {
        if (head == null)
        {
            throw new InvalidOperationException("The value doesn't exist");
        }

        if (head.Value!.Equals(value))
        {
            ListNode<T> node = head;
            head = head.Next;
            if (head == null)
            {
                tail = null;
            }
            size--;
            return node.Value;
        }


        ListNode<T>? before = head;
        ListNode<T>? nodeList = head.Next;

        while (nodeList != null)
        {
            if (nodeList.Value!.Equals(value))
            {
                before.Next = nodeList.Next;
                if (nodeList.Next == null)
                {
                    tail = before;
                }
                size--;
                return nodeList.Value;
            }

            before = nodeList;
            nodeList = nodeList.Next;
        }

        throw new InvalidOperationException("The value doesn't exist");
    }

    public T RemoveAt(int position)
    {
        if (position < 0 || position >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position out of range");
        }

        ListNode<T> removed;

        if (position == 0)
        {
            if (head == tail)
            {
                tail = null;
            }
            removed = head;
            head = head.Next;
        }
        else
        {
            ListNode<T> actual = head;

            for (int i = 0; i < position - 1; i++)
            {
                actual = actual.Next;
            }

            removed = actual.Next;
            actual.Next = removed.Next;

            if (actual.Next == null)
            {
                tail = actual;
            }
        }
        size--;
        return removed.Value;

    }

    public T Get(int position)
    {
        if (position < 0 || position >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position out of range");
        }


        if (position == 0)
        {
            return head.Value;
        }
        else
        {
            ListNode<T> actual = head;

            for (int i = 0; i < position; i++)
            {
                actual = actual.Next;
            }

            return actual.Value;
        }

    }

    public T Find(T value)
    {
        if (head == null)
        {
            throw new InvalidOperationException("The value doesn't exist");
        }

        ListNode<T> node = head;

        while (node != null)
        {
            if (node.Value!.Equals(value))
            {
                return node.Value;
            }
            node = node.Next;
        }

        throw new InvalidOperationException("The value doesn't exist");
    }
    
    public int IndexOf(T value)
    {
        if (head == null)
        {
            return -1;
        }

        ListNode<T> actual = head;
        int index = 0;
        while (actual != null)
        {

            if (Equals(actual.Value, value))
            {
                return index;
            }
            actual = actual.Next;
            index++;
        }

        return -1;

    }

    public void Clear()
    {
        head = null;
        tail = null;
        size = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var actual = head;
        while (actual != null)
        {
            yield return actual.Value!;
            actual = actual.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}