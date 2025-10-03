namespace DataStructure.Core.Domain.Stacks;

public class StackNode<T>
{
    public T Value { get; set; }
    public StackNode<T>? Next { get; set; }

    public StackNode(T value)
    {
        Value = value;
        Next = null;
    }
}