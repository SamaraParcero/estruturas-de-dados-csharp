
using Estrutura.Core.Domain.Queues;

namespace Estrutura.Tests;

public class QueueUnitTests
{

    [Fact]
    public void Test1QueueStartsEmpty()
    {
        Queuee<int> queue = new Queuee<int>();
        Assert.Equal(0, queue.Count);
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void Test2EnqueueIncreasesCount()
    {
        Queuee<int> queue = new Queuee<int>();
        int testSize = 0;
        queue.Enqueue(2);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        queue.Enqueue(5);
        testSize++;
        Assert.Equal(testSize, queue.Count);
    }

    [Fact]
    public void Test3EnqueueOneValueinAEmptyQueue()
    {
        Queuee<int> queue = new Queuee<int>();
        int insertNodeValue1 = 4;
        int testSize = 0;
        queue.Enqueue(insertNodeValue1);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        Assert.Equal(insertNodeValue1, queue.head!.Value);
        Assert.Equal(insertNodeValue1, queue.tail!.Value);
    }

    [Fact]
    public void Test4EnqueueTwoValuesinAEmptyQueue()
    {
        Queuee<int> queue = new Queuee<int>();
        int insertNodeValue1 = 4;
        int insertNodeValue2 = 6;
        int testSize = 0;
        queue.Enqueue(insertNodeValue1);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        queue.Enqueue(insertNodeValue2);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        Assert.Equal(insertNodeValue1, queue.head!.Value);
        Assert.Equal(insertNodeValue2, queue.head.Next!.Value);
        Assert.Equal(insertNodeValue2, queue.tail!.Value);
        Assert.Null(queue.tail.Next);
    }

    [Fact]
    public void Test5DequeueDecreasesCount()
    {
        Queuee<int> queue = new Queuee<int>();
        int testSize = 0;
        int insertNodeValue = 10;
        queue.Enqueue(insertNodeValue);
        testSize++;
        queue.Enqueue(20);
        testSize++;
        var removed = queue.Dequeue();
        testSize--;
        Assert.Equal(insertNodeValue, removed.Value);
        Assert.Equal(testSize, queue.Count);
    }

    [Fact]
    public void Test6DequeueEmptyQueueThrowsException()
    {
        Queuee<int> queue = new Queuee<int>();
        var exception = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        Assert.Equal("Queue is empty", exception.Message);
    }


    [Fact]
    public void Test8DequeueQueueWithOneNode()
    {
        Queuee<int> queue = new Queuee<int>();
        int testSize = 0;
        int insertNodeValue = 2;
        queue.Enqueue(insertNodeValue);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        Assert.Equal(insertNodeValue, queue.head!.Value);
        Assert.Equal(insertNodeValue, queue.tail!.Value);
        Assert.Null(queue.tail.Next);

        var removedNode1 = queue.Dequeue();
        Assert.Equal(insertNodeValue, removedNode1.Value);
        Assert.Null(queue.head);
        Assert.Null(queue.tail);
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void Test9DequeueQueueWithALotOfNodes()
    {
        Queuee<int> queue = new Queuee<int>();
        int testSize = 0;
        int insertNodeValue1 = 2;
        int insertNodeValue2 = 3;
        int insertNodeValue3 = 4;
        int insertNodeValue4 = 7;
        int insertNodeValue5 = 1;
        queue.Enqueue(insertNodeValue1);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        queue.Enqueue(insertNodeValue2);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        queue.Enqueue(insertNodeValue3);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        queue.Enqueue(insertNodeValue4);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        queue.Enqueue(insertNodeValue5);
        testSize++;
        Assert.Equal(testSize, queue.Count);

        var removedNode1 = queue.Dequeue();
        testSize--;
        Assert.Equal(testSize, queue.Count);
        Assert.Equal(insertNodeValue1, removedNode1.Value);
        Assert.Equal(insertNodeValue2, queue.head!.Value);
    }

    [Fact]
    public void Test10DequeueReturnsCorrectNode()
    {
        Queuee<int> queue = new Queuee<int>();
        int insertNodeValue = 2;
        int insertNodeValue2 = 4;
        queue.Enqueue(insertNodeValue);
        queue.Enqueue(insertNodeValue2);

        var removedNode1 = queue.Dequeue();
        var removedNode2 = queue.Dequeue();

        Assert.Equal(insertNodeValue, removedNode1.Value);
        Assert.Equal(insertNodeValue2, removedNode2.Value);
    }


    [Fact]
    public void Test11IsEmptyAfterDequeues()
    {
        Queuee<int> queue = new Queuee<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);

        queue.Dequeue();
        queue.Dequeue();

        Assert.True(queue.IsEmpty());
    }



    [Fact]
    public void Test12EnqueueOtherTypeOfNode()
    {
        Queuee<string> queue = new Queuee<string>();
        string a = "A";
        string b = "B";
        string c = "C";
        string d = "D";
        queue.Enqueue(a);
        queue.Enqueue(b);
        queue.Enqueue(c);

        Assert.Equal(a, queue.Dequeue().Value);
        Assert.Equal(b, queue.Dequeue().Value);
        queue.Enqueue(d);
        Assert.Equal(c, queue.Dequeue().Value);
        Assert.Equal(d, queue.Dequeue().Value);
    }



    [Fact]
    public void Test13ClearReturnsEmptyQueue()
    {
        Queuee<int> queue = new Queuee<int>();
        int testSize = 0;
        int insertNodeValue = 2;
        int insertNodeValue2 = 3;
        int insertNodeValue3 = 4;
        queue.Enqueue(1);
        testSize++;
        queue.Enqueue(insertNodeValue);
        testSize++;
        queue.Enqueue(insertNodeValue2);
        testSize++;
        queue.Dequeue();
        testSize--;
        queue.Enqueue(insertNodeValue3);
        testSize++;
        Assert.Equal(testSize, queue.Count);
        Assert.False(queue.IsEmpty());
        queue.Clear();
        Assert.True(queue.IsEmpty());
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Test14QueueContaisValue()
    {
        Queuee<int> queue = new Queuee<int>();
        int enqueuedValue = 10;
        queue.Enqueue(5);
        queue.Enqueue(enqueuedValue);
        queue.Enqueue(20);
        var containsResult = queue.Contains(enqueuedValue);
        Assert.True(containsResult);
    }

    [Fact]
    public void Test15QueueDoesNotContaisValue()
    {
        Queuee<int> queue = new Queuee<int>();
        int notEnqueuedValue = 10;
        queue.Enqueue(5);
        queue.Enqueue(11);
        queue.Enqueue(20);
        var containsResult = queue.Contains(notEnqueuedValue);
        Assert.False(containsResult);
    }
}
