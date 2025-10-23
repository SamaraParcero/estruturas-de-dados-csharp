namespace DataStructure.Core.Domain.Lists;

public record ListNode<T>(T Value)
{
    public ListNode<T>? Next { get; set; }

}