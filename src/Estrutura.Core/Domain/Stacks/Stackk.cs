using Estrutura.Core.Domain.Stacks;

namespace Estrutura.Core.Domain.Stacks;

public class Stackk<T>
{
    public StackNode<T> top;
    private int size;
    public int Count => size;


    public Stackk()
    {
        top = null;
        size = 0;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public void Push(T value)
    {
        StackNode<T> node = new StackNode<T>(value);
        node.Next = top;
        top = node;
        size++;

    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        var value = top.Value;
        top = top.Next;
        size--;
        return value;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return top.Value;
    }

    public void Clear()
    {
        top = null;
        size = 0;
    }

    public bool Contains(T value)
    {
        var actual = top;
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