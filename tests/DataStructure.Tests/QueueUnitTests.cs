
using DataStructure.Core.Domain.Queues;

namespace DataStructure.Tests;

public class QueueUnitTests
{

    private static Random random = new Random();
    private static int count = 0;

    private dynamic CreateQueue(string type)
    {
        switch (type)
        {
            case "int":
                return new Queuee<int>();

            case "string":
                return new Queuee<string>();

            case "double":
                return new Queuee<double>();

            case "float":
                return new Queuee<float>();

            case "object":
                return new Queuee<Objectt>();

            default:
                throw new ArgumentException("Invalid Type");
        }
    }

    private dynamic GetValue(string type)
    {
        count++;

        switch (type)
        {
            case "int":
                return random.Next(1, 10000) + count;

            case "string":
                return $"valor{random.Next(1, 10000) + count}";

            case "double":
                return Math.Round(random.NextDouble() * 10000 + count, 2);

            case "float":
                return (float)Math.Round(random.NextDouble() * 10000 + count, 2);

            case "object":
                return new Objectt($"Obj{count}");

            default:
                throw new ArgumentException("Invalid Type");
        }
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test1QueueStartsEmpty(string type)
    {
        dynamic queue = CreateQueue(type);
        Assert.Equal(0, queue.Count);
        Assert.True(queue.IsEmpty());
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test2EnqueueIncreasesCount(string type)
    {
        dynamic queue = CreateQueue(type);
        int testSize = 0;
        dynamic enqueueValue1 = GetValue(type);
        queue.Enqueue(enqueueValue1);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        dynamic enqueueValue2 = GetValue(type);
        queue.Enqueue(enqueueValue2);
        testSize++;
        Assert.Equal(testSize, queue.Count);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test3EnqueueOneValueinAEmptyQueue(string type)
    {
        dynamic queue = CreateQueue(type);
        dynamic insertNodeValue1 = GetValue(type);
        int testSize = 0;
        queue.Enqueue(insertNodeValue1);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        Assert.Equal(insertNodeValue1, queue.head!.Value);
        Assert.Equal(insertNodeValue1, queue.tail!.Value);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test4EnqueueTwoValuesinAEmptyQueue(string type)
    {
        dynamic queue = CreateQueue(type);
        dynamic insertNodeValue1 = GetValue(type);
        dynamic enqueuedNodeValue2 = GetValue(type);
        int testSize = 0;
        queue.Enqueue(insertNodeValue1);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        queue.Enqueue(enqueuedNodeValue2);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        Assert.Equal(insertNodeValue1, queue.head!.Value);
        Assert.Equal(enqueuedNodeValue2, queue.head.Next!.Value);
        Assert.Equal(enqueuedNodeValue2, queue.tail!.Value);
        Assert.Null(queue.tail.Next);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test5DequeueDecreasesCount(string type)
    {
        dynamic queue = CreateQueue(type);
        int testSize = 0;
        dynamic enqueuedNodeValue = GetValue(type);
        queue.Enqueue(enqueuedNodeValue);
        testSize++;
        dynamic enqueuedNodeValue2 = GetValue(type);
        queue.Enqueue(enqueuedNodeValue2);
        testSize++;
        dynamic removed = queue.Dequeue();
        testSize--;
        Assert.Equal(enqueuedNodeValue, removed);
        Assert.Equal(testSize, queue.Count);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test6DequeueEmptyQueueThrowsException(string type)
    {
        dynamic queue = CreateQueue(type);
        var exception = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        Assert.Equal("Queue is empty", exception.Message);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test8DequeueQueueWithOneNode(string type)
    {
        dynamic queue = CreateQueue(type);
        int testSize = 0;
        dynamic enqueuedNodeValue = GetValue(type);
        queue.Enqueue(enqueuedNodeValue);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        Assert.Equal(enqueuedNodeValue, queue.head!.Value);
        Assert.Equal(enqueuedNodeValue, queue.tail!.Value);
        Assert.Null(queue.tail.Next);

        dynamic removedNode1 = queue.Dequeue();
        Assert.Equal(enqueuedNodeValue, removedNode1);
        Assert.Null(queue.head);
        Assert.Null(queue.tail);
        Assert.True(queue.IsEmpty());
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test9DequeueQueueWithALotOfNodes(string type)
    {
        dynamic queue = CreateQueue(type);
        int testSize = 0;
        dynamic insertNodeValue1 = GetValue(type);
        dynamic enqueuedNodeValue2 = GetValue(type);
        dynamic enqueuedNodeValue3 = GetValue(type);
        dynamic insertNodeValue4 = GetValue(type);
        dynamic insertNodeValue5 = GetValue(type);
        queue.Enqueue(insertNodeValue1);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        queue.Enqueue(enqueuedNodeValue2);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        queue.Enqueue(enqueuedNodeValue3);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        queue.Enqueue(insertNodeValue4);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        queue.Enqueue(insertNodeValue5);
        testSize++;
        Assert.Equal(testSize, queue.Count);

        dynamic removedNode1 = queue.Dequeue();
        testSize--;
        Assert.Equal(testSize, queue.Count);
        Assert.Equal(insertNodeValue1, removedNode1);
        Assert.Equal(enqueuedNodeValue2, queue.head!.Value);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test10DequeueReturnsCorrectNode(string type)
    {
        dynamic queue = CreateQueue(type);
        dynamic enqueuedNodeValue = GetValue(type);
        dynamic enqueuedNodeValue2 = GetValue(type);
        queue.Enqueue(enqueuedNodeValue);
        queue.Enqueue(enqueuedNodeValue2);

        dynamic removedNode1 = queue.Dequeue();
        dynamic removedNode2 = queue.Dequeue();

        Assert.Equal(enqueuedNodeValue, removedNode1);
        Assert.Equal(enqueuedNodeValue2, removedNode2);
    }



    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test11IsEmptyAfterDequeues(string type)
    {
        dynamic queue = CreateQueue(type);
        dynamic enqueuedNodeValue = GetValue(type);
        dynamic enqueuedNodeValue2 = GetValue(type);
        queue.Enqueue(enqueuedNodeValue);
        queue.Enqueue(enqueuedNodeValue2);

        queue.Dequeue();
        queue.Dequeue();

        Assert.True(queue.IsEmpty());
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test12ClearReturnsEmptyQueue(string type)
    {
        dynamic queue = CreateQueue(type);
        int testSize = 0;
        dynamic enqueuedNodeValue1 = GetValue(type);
        dynamic enqueuedNodeValue2 = GetValue(type);
        dynamic enqueuedNodeValue3 = GetValue(type);
        dynamic enqueuedNodeValue4 = GetValue(type);
        queue.Enqueue(enqueuedNodeValue1);
        testSize++;
        queue.Enqueue(enqueuedNodeValue2);
        testSize++;
        queue.Enqueue(enqueuedNodeValue3);
        testSize++;
        queue.Dequeue();
        testSize--;
        queue.Enqueue(enqueuedNodeValue4);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        Assert.False(queue.IsEmpty());
        queue.Clear();
        Assert.True(queue.IsEmpty());
        Assert.Equal(0, queue.Count);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test13QueueContainsValue(string type)
    {
        dynamic queue = CreateQueue(type);
        dynamic enqueuedValue1 = GetValue(type);
        dynamic enqueuedValue2 = GetValue(type);
        dynamic enqueuedValue3 = GetValue(type);
        queue.Enqueue(enqueuedValue1);
        queue.Enqueue(enqueuedValue2);
        queue.Enqueue(enqueuedValue3);
        var containsResult = queue.Contains(enqueuedValue2);
        Assert.True(containsResult);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test14QueueDoesNotContainsValue(string type)
    {
        dynamic queue = CreateQueue(type);
        dynamic notEnqueuedValue = GetValue(type);
        dynamic enqueuedValue1 = GetValue(type);
        dynamic enqueuedValue2 = GetValue(type);
        dynamic enqueuedValue3 = GetValue(type);
        queue.Enqueue(enqueuedValue1);
        queue.Enqueue(enqueuedValue2);
        queue.Enqueue(enqueuedValue3);
        var containsResult = queue.Contains(notEnqueuedValue);
        Assert.False(containsResult);
    }

    
}
