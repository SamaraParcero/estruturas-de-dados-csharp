namespace DataStructure.Core.Domain.Stacks;

public record StackNode<T>(T Value)
{
    public StackNode<T>? Next { get; set; }

}