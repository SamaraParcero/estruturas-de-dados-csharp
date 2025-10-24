namespace DataStructure.Core.Domain.Queues;

public record QueueNode<T>(T Value)
{

    public QueueNode<T>? Next { get; set; }

}