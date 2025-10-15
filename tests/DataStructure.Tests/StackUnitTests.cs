using DataStructure.Core.Domain.Stacks;

namespace DataStructure.Tests;

public class StackUnitTests
{

    private static Random random = new Random();
    private static int count = 0;

    private dynamic CreateStack(string type)
    {
        switch (type)
        {
            case "int":
                return new Stackk<int>();

            case "string":
                return new Stackk<string>();

            case "double":
                return new Stackk<double>();

            case "float":
                return new Stackk<float>();

            case "object":
                return new Stackk<Objectt>();

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
    public void Test1StackStartsEmpty(string type)
    {
        dynamic stack = CreateStack(type);
        Assert.Equal(0, stack.Count);
        Assert.True(stack.IsEmpty());
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test2PushIncreasesCount(string type)
    {
        dynamic stack = CreateStack(type);
        int testSize = 0;
        dynamic pushValue1 = GetValue(type);
        stack.Push(pushValue1);
        testSize++;
        Assert.Equal(testSize, stack.Count);
        dynamic pushValue2 = GetValue(type);
        stack.Push(pushValue2);
        testSize++;
        Assert.Equal(testSize, stack.Count);
        Assert.False(stack.IsEmpty());
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test3PushOneValueInAEmptyStack(string type)
    {
        dynamic stack = CreateStack(type);
        int testSize = 0;
        dynamic pushedNodeValue = GetValue(type);
        stack.Push(pushedNodeValue);
        testSize++;
        Assert.Equal(testSize, stack.Count);
        Assert.Equal(pushedNodeValue, stack.top.Value);
        Assert.Null(stack.top.Next);
    }



    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test4PushTwoValuesinAEmptyStack(string type)
    {
        dynamic stack = CreateStack(type);
        int testSize = 0;
        dynamic pushedNodeValue = GetValue(type);
        dynamic pushedNodeValue2 = GetValue(type);
        stack.Push(pushedNodeValue);
        testSize++;
        Assert.Equal(testSize, stack.Count);
        stack.Push(pushedNodeValue2);
        testSize++;
        Assert.Equal(testSize, stack.Count);
        Assert.Equal(pushedNodeValue2, stack.top.Value);
        Assert.Equal(pushedNodeValue, stack.top.Next!.Value);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test5PopDecreasesCount(string type)
    {
        dynamic stack = CreateStack(type);
        int testSize = 0;
        dynamic pushValue1 = GetValue(type);
        stack.Push(pushValue1);
        testSize++;
        dynamic pushValue2 = GetValue(type);
        stack.Push(pushValue2);
        testSize++;
        stack.Pop();
        testSize--;
        Assert.Equal(testSize, stack.Count);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test6PopReturnsCorrectValue(string type)
    {
        dynamic stack = CreateStack(type);
        dynamic top1 = GetValue(type);
        stack.Push(top1);
        dynamic top2 = GetValue(type);
        stack.Push(top2);
        Assert.Equal(top2, stack.top.Value);

        dynamic popped = stack.Pop();
        Assert.Equal(top2, popped);
        dynamic popped2 = stack.Pop();
        Assert.Equal(top1, popped2);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test7PopEmptyStackThrowsException(string type)
    {
        dynamic stack = CreateStack(type);
        var exception = Assert.Throws<InvalidOperationException>(() => stack.Pop());
        Assert.Equal("Stack is empty", exception.Message);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test8IsEmptyAfterPops(string type)
    {
        dynamic stack = CreateStack(type);
        dynamic pushValue1 = GetValue(type);
        stack.Push(pushValue1);
        dynamic pushValue2 = GetValue(type);
        stack.Push(pushValue2);

        stack.Pop();
        stack.Pop();

        Assert.True(stack.IsEmpty());
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test9PeekEmptyStackThrowsException(string type)
    {
        dynamic stack = CreateStack(type);
        var exception = Assert.Throws<InvalidOperationException>(() => stack.Peek());
        Assert.Equal("Stack is empty", exception.Message);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]

    public void Test10PeekReturnsTop(string type)
    {
        dynamic stack = CreateStack(type);
        int testSize = 0;
        dynamic pushValue1 = GetValue(type);
        stack.Push(pushValue1);
        testSize++;
        dynamic top = GetValue(type);
        stack.Push(top);
        testSize++;
        dynamic peeked = stack.Peek();
        Assert.Equal(top, peeked);
        Assert.Equal(testSize, stack.Count);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test11ClearReturnsEmptyStack(string type)
    {
        dynamic stack = CreateStack(type);
        int testSize = 0;
        dynamic pushedNodeValue = GetValue(type);
        dynamic pushedNodeValue2 = GetValue(type);
        dynamic pushedNodeValue3 = GetValue(type);
        dynamic pushedNodeValue4 = GetValue(type);
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
        Assert.False(stack.IsEmpty());
        stack.Clear();
        Assert.True(stack.IsEmpty());
        Assert.Equal(0, stack.Count); ;
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test12StackContainsValue(string type)
    {
        dynamic stack = CreateStack(type);
        dynamic pushedValue1 = GetValue(type);
        dynamic pushedValue2 = GetValue(type);
        dynamic pushedValue3 = GetValue(type);
        stack.Push(pushedValue1);
        stack.Push(pushedValue2);
        stack.Push(pushedValue3);
        var containsResult = stack.Contains(pushedValue2);
        Assert.True(containsResult);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test13StackDoesNotContainsValue(string type)
    {
        dynamic stack = CreateStack(type);
        dynamic pushedValue1 = GetValue(type);
        dynamic pushedValue2 = GetValue(type);
        dynamic pushedValue3 = GetValue(type);
        stack.Push(pushedValue1);
        stack.Push(pushedValue2);
        stack.Push(pushedValue3);
        dynamic notEnqueuedValue = GetValue(type);
        var containsResult = stack.Contains(notEnqueuedValue);
        Assert.False(containsResult);
    }
}
