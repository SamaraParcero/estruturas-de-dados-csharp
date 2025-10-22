namespace DataStructure.Core.Domain.BinaryTree;

public record Node<T>(T Value)
{
    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }
}
