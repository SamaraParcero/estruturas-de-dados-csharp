

namespace DataStructure.Core.Domain.Lists;

public class Listt<T>
{

    public ListNode<T>? head;
    public ListNode<T>? tail;
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

    public void Insert(int position, T value)
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

    public ListNode<T>? Remove(T value)
    {
        if (head == null)
        {
            return null;
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
            return node;
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
                return nodeList;
            }

            before = nodeList;
            nodeList = nodeList.Next;
        }

        return null;
    }

    public ListNode<T> RemoveAt(int position)
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
        return removed;

    }

    public ListNode<T> Get(int position)
    {
        if (position < 0 || position >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position out of range");
        }


        if (position == 0)
        {
            return head;
        }
        else
        {
            ListNode<T> actual = head;

            for (int i = 0; i < position; i++)
            {
                actual = actual.Next;
            }

            return actual;
        }

    }

    public ListNode<T> Find(T value)
    {
        if (head == null)
        {
            return null;
        }

        ListNode<T> node = head;

        while (node != null)
        {
            if (node.Value!.Equals(value))
            {
                return node;
            }
            node = node.Next;
        }

        return null;
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

            if (actual.Value.Equals(value))
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





}