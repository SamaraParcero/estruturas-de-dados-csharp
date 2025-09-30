using Estrutura.Core.Domain.Stacks;

namespace Estrutura.Tests;

public class StackUnitTests
{

    [Fact]
    public void Test1StackStartsEmpty()
    {
        Stackk<int> stack = new Stackk<int>();
        Assert.Equal(0, stack.Count);
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void Test2PushIncreasesCount()
    {
        Stackk<int> stack = new Stackk<int>();
        int testSize = 0;
        stack.Push(5);
        testSize++;
        Assert.Equal(testSize, stack.Count);
        stack.Push(10);
        testSize++;
        Assert.Equal(testSize, stack.Count);
        Assert.False(stack.IsEmpty());
    }

    [Fact]
    public void Test3PushOneValueInAEmptyStack()
    {
        Stackk<int> stack = new Stackk<int>();
        int testSize = 0;
        int pushedNodeValue = 5;
        stack.Push(pushedNodeValue);
        testSize++;
        Assert.Equal(testSize, stack.Count);
        Assert.Equal(pushedNodeValue, stack.top.Value);
        Assert.Equal(null, stack.top.Next);
    }


    [Fact]
    public void Test4PushTwoValuesinAEmptyStack()
    {
        Stackk<int> stack = new Stackk<int>();
        int testSize = 0;
        int pushedNodeValue = 5;
        int pushedNodeValue2 = 2;
        stack.Push(pushedNodeValue);
        testSize++;
        Assert.Equal(testSize, stack.Count);
        stack.Push(pushedNodeValue2);
        testSize++;
        Assert.Equal(testSize, stack.Count);
        Assert.Equal(pushedNodeValue2, stack.top.Value);
        Assert.Equal(pushedNodeValue, stack.top.Next.Value);
    }

    [Fact]
    public void Test5PopDecreasesCount()
    {
        Stackk<int> stack = new Stackk<int>();
        int testSize = 0;
        stack.Push(7);
        testSize++;
        stack.Push(8);
        testSize++;
        stack.Pop();
        testSize--;
        Assert.Equal(testSize, stack.Count);
    }

    [Fact]
    public void Test6PopReturnsCorrectValue()
    {
        Stackk<int> stack = new Stackk<int>();
        int top1 = 3;
        stack.Push(top1);
        int top2 = 6;
        stack.Push(top2);
        Assert.Equal(top2, stack.top.Value);

        int popped = stack.Pop();
        Assert.Equal(top2, popped);
        int popped2 = stack.Pop();
        Assert.Equal(top1, popped2);
    }

    [Fact]
    public void Test7PopEmptyStackThrowsException()
    {
        Stackk<int> stack = new Stackk<int>();
        var exception = Assert.Throws<InvalidOperationException>(() => stack.Pop());
        Assert.Equal("Stack is empty", exception.Message);
    }


    [Fact]
    public void Test8IsEmptyAfterPops()
    {
        Stackk<int> stack = new Stackk<int>();
        stack.Push(5);
        stack.Push(10);

        stack.Pop();
        stack.Pop();

        Assert.True(stack.IsEmpty());
    }


    [Fact]
    public void Test9PeekEmptyStackThrowsException()
    {
        Stackk<int> stack = new Stackk<int>();
        var exception = Assert.Throws<InvalidOperationException>(() => stack.Peek());
        Assert.Equal("Stack is empty", exception.Message);
    }

    [Fact]
    public void Test10PeekReturnsTop()
    {
        Stackk<int> stack = new Stackk<int>();
        int testSize = 0;
        stack.Push(9);
        testSize++;
        int top = 12;
        stack.Push(top);
        testSize++;
        int peeked = stack.Peek();
        Assert.Equal(top, peeked);
        Assert.Equal(testSize, stack.Count);
    }

    [Fact]
    public void Test11StackViewStackReturnsCorrectListOrder()
    {
        Stackk<int> stack = new Stackk<int>();
        int pushNodeValue = 1;
        int pushNodeValue2 = 3;
        int pushNodeValue3 = 2;

        stack.Push(pushNodeValue);
        stack.Push(pushNodeValue2);
        stack.Push(pushNodeValue3);

        var result = stack.ViewStack();
        var expected = new List<int> { pushNodeValue3, pushNodeValue2, pushNodeValue };
        Assert.Equal(expected, result);
    }



    [Fact]
    public void Test12PushOtherTypeOfNode()
    {
        Stackk<string> stack = new Stackk<string>();
        string a = "A";
        string b = "B";
        string c = "C";
        string d = "D";
        stack.Push(a);
        stack.Push(b);
        stack.Push(c);

        Assert.Equal(c, stack.Pop());
        Assert.Equal(b, stack.Pop());
        stack.Push(d);
        Assert.Equal(d, stack.Pop());
        Assert.Equal(a, stack.Pop());
    }

    [Fact]
    public void Test13ClearReturnsEmptyStack()
    {
        Stackk<int> stack = new Stackk<int>();
        int testSize = 0;
        int pushedNodeValue = 2;
        int pushedNodeValue2 = 3;
        int pushedNodeValue3 = 4;
        int pushedNodeValue4 = 1;
        stack.Push(pushedNodeValue);
        testSize++;
        stack.Push(pushedNodeValue2);
        testSize++;
        stack.Push(pushedNodeValue3);
        testSize++;
        stack.Pop();
        testSize--;
        stack.Push(pushedNodeValue4);
        testSize++;
        Assert.Equal(testSize, stack.Count);
        var resultBefore = stack.ViewStack();
        var expectedBefore = new List<int> { pushedNodeValue4, pushedNodeValue2, pushedNodeValue };
        Assert.Equal(expectedBefore, resultBefore);
        stack.Clear();
        Assert.Empty(stack.ViewStack());
        Assert.True(stack.IsEmpty());
        Assert.Equal(0, stack.Count); ;
    }
}
