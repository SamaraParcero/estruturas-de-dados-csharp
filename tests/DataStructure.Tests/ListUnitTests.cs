
using DataStructure.Core.Domain.Lists;

namespace DataStructure.Tests;

public class ListUnitTests
{

    private static Random random = new Random();
    private static int count = 0;

    private dynamic CreateList(string type)
    {
        switch (type)
        {
            case "int":
                return new Listt<int>();

            case "string":
                return new Listt<string>();

            case "double":
                return new Listt<double>();

            case "float":
                return new Listt<float>();

            case "object":
                return new Listt<Objectt>();

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
    public void Test1ListStartsEmpty(string type)
    {
        dynamic list = CreateList(type);
        Assert.Equal(0, list.Count);
        Assert.True(list.IsEmpty());
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test2AddIncreasesCount(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue1 = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        list.Add(addedNodeValue1);
        testSize++;
        Assert.Equal(testSize, list.Count);
        list.Add(addedNodeValue2);
        testSize++;
        Assert.Equal(testSize, list.Count);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test3AddValueInAnEmptyList(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue1 = GetValue(type);
        list.Add(addedNodeValue1);
        testSize++;
        Assert.Equal(testSize, list.Count);
        Assert.False(list.IsEmpty());
        Assert.Equal(addedNodeValue1, list.head!.Value);
        Assert.Equal(addedNodeValue1, list.tail!.Value);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test4AddTwoValuesInAnEmptyList(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue1 = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        list.Add(addedNodeValue1);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        Assert.Equal(testSize, list.Count);
        Assert.False(list.IsEmpty());
        Assert.Equal(addedNodeValue1, list.head!.Value);
        Assert.Equal(addedNodeValue2, list.head.Next!.Value);
        Assert.Equal(addedNodeValue2, list.tail!.Value);
        Assert.Null(list.tail.Next);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test5InsertInAnInvalidPosition(string type)
    {
        dynamic list = CreateList(type);
        dynamic addedNodeValue1 = GetValue(type);
        dynamic insertNodeValue = GetValue(type);
        list.Add(addedNodeValue1);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => { list.Insert(-1, insertNodeValue); });
        Assert.Contains("Position out of range", exception.Message);
        Assert.Equal("position", exception.ParamName);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test6InsertInAPositionLargerThanSize(string type)
    {
        dynamic list = CreateList(type);
        dynamic addedNodeValue1 = GetValue(type);
        dynamic insertNodeValue1 = GetValue(type);
        list.Add(addedNodeValue1);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => { list.Insert(3, insertNodeValue1); });
        Assert.Contains("Position out of range", exception.Message);
        Assert.Equal("position", exception.ParamName);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test7InsertInFirstPosition(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic firstNodeValue = GetValue(type);
        dynamic InsertedNodeValue = GetValue(type);
        list.Add(firstNodeValue);
        testSize++;
        list.Insert(0, InsertedNodeValue);
        testSize++;
        Assert.Equal(testSize, list.Count);
        Assert.Equal(InsertedNodeValue, list.head!.Value);
        Assert.Equal(firstNodeValue, list.head.Next!.Value);
        Assert.Equal(firstNodeValue, list.tail!.Value);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test8InsertInLastPosition(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic firstNodeValue = GetValue(type);
        dynamic addedNodeValue1 = GetValue(type);
        dynamic InsertedNodeValue2 = GetValue(type);
        list.Add(firstNodeValue);
        testSize++;
        list.Add(addedNodeValue1);
        testSize++;
        list.Insert(2, InsertedNodeValue2);
        testSize++;
        Assert.Equal(testSize, list.Count);
        Assert.Equal(InsertedNodeValue2, list.tail!.Value);
        Assert.Null(list.tail.Next);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test9InsertInMiddlePosition(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue1 = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        list.Add(addedNodeValue1);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        list.Add(addedNodeValue3);
        testSize++;
        dynamic insertedValue = GetValue(type);
        list.Insert(1, insertedValue);
        testSize++;
        Assert.Equal(testSize, list.Count);
        Assert.Equal(addedNodeValue1, list.head!.Value);
        Assert.Equal(insertedValue, list.head.Next!.Value);
        Assert.Equal(addedNodeValue2, list.head.Next.Next!.Value);
        Assert.Equal(addedNodeValue3, list.tail!.Value);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test10InsertIncreasesCount(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic firstNodeValue = GetValue(type);
        dynamic addedNodeValue = GetValue(type);
        dynamic InsertedNodeValue = GetValue(type);
        list.Add(firstNodeValue);
        testSize++;
        list.Add(addedNodeValue);
        testSize++;
        list.Insert(2, InsertedNodeValue);
        testSize++;
        Assert.Equal(testSize, list.Count);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test11tryToRemoveAValueFromAnEmptyList(string type)
    {
        dynamic list = CreateList(type);
        dynamic removeNodeValue = GetValue(type);
        Assert.Null(list.Remove(removeNodeValue));
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test12RemoveHeadValue(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        list.Add(addedNodeValue);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        list.Add(addedNodeValue3);
        testSize++;
        var removedNode = list.Remove(addedNodeValue);
        testSize--;
        Assert.NotNull(removedNode);
        Assert.Equal(addedNodeValue, removedNode.Value);
        Assert.Equal(addedNodeValue2, list.head!.Value);
        Assert.Equal(testSize, list.Count);
        Assert.Equal(addedNodeValue3, list.tail!.Value);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test13RemoveMiddleValue(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        list.Add(addedNodeValue);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        list.Add(addedNodeValue3);
        testSize++;
        var removedNode = list.Remove(addedNodeValue2);
        testSize--;
        Assert.NotNull(removedNode);
        Assert.Equal(addedNodeValue2, removedNode.Value);
        Assert.Equal(testSize, list.Count);
        Assert.Equal(addedNodeValue, list.head!.Value);
        Assert.Equal(addedNodeValue3, list.head.Next!.Value);
        Assert.Equal(addedNodeValue3, list.tail!.Value);
        Assert.Null(list.tail.Next);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test14RemoveTailValue(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        list.Add(addedNodeValue);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        list.Add(addedNodeValue3);
        testSize++;
        var removedNode = list.Remove(addedNodeValue3);
        testSize--;
        Assert.NotNull(removedNode);
        Assert.Equal(addedNodeValue3, removedNode.Value);
        Assert.Equal(testSize, list.Count);
        Assert.Equal(addedNodeValue, list.head!.Value);
        Assert.Equal(addedNodeValue2, list.tail!.Value);
        Assert.Null(list.tail.Next);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test15RemoveANonExistentValueFromAList(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        list.Add(addedNodeValue);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        var removedNode = list.Remove(GetValue(type));
        Assert.Equal(testSize, list.Count);
        Assert.Null(removedNode);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test16RemoveDecreasesCount(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        list.Add(addedNodeValue);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        list.Remove(addedNodeValue2);
        testSize--;
        Assert.Equal(testSize, list.Count);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test17RemoveAtAnInvalidPosition(string type)
    {
        dynamic list = CreateList(type);
        dynamic addedNodeValue = GetValue(type);
        list.Add(addedNodeValue);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
        Assert.Contains("Position out of range", exception.Message);
        Assert.Equal("position", exception.ParamName);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test18RemoveAtALargerPositionThanSize(string type)
    {
        dynamic list = CreateList(type);
        dynamic addedNodeValue = GetValue(type);
        list.Add(addedNodeValue);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(3));
        Assert.Contains("Position out of range", exception.Message);
        Assert.Equal("position", exception.ParamName);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test19RemovedAtFirstPosition(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic firstNodeValue = GetValue(type);
        dynamic secondNodeValue = GetValue(type);
        list.Add(firstNodeValue);
        testSize++;
        list.Add(secondNodeValue);
        testSize++;
        var removedNode = list.RemoveAt(0);
        testSize--;
        Assert.Equal(testSize, list.Count);
        Assert.Equal(secondNodeValue, list.head!.Value);
        Assert.Equal(secondNodeValue, list.tail!.Value);
        Assert.Null(list.head.Next);
        Assert.Equal(firstNodeValue, removedNode.Value);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test20RemovedAtMidleOfList(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        list.Add(addedNodeValue);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        list.Add(addedNodeValue3);
        testSize++;
        var removedNode = list.RemoveAt(1);
        testSize--;
        Assert.Equal(testSize, list.Count);
        Assert.Equal(addedNodeValue2, removedNode.Value);
        Assert.Equal(addedNodeValue3, list.head!.Next!.Value);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test21RemovedAtTailOfList(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        list.Add(addedNodeValue);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        list.Add(addedNodeValue3);
        testSize++;
        var removedNode = list.RemoveAt(2);
        testSize--;
        Assert.Equal(testSize, list.Count);
        Assert.Equal(addedNodeValue3, removedNode.Value);
        Assert.Equal(addedNodeValue2, list.head!.Next!.Value);
        Assert.Equal(addedNodeValue2, list.tail!.Value);
        Assert.Null(list.tail.Next);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test22RemovedAtDecreasesCount(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        list.Add(addedNodeValue);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        list.RemoveAt(1);
        testSize--;
        Assert.Equal(testSize, list.Count);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test23GetAnInvalidPosition(string type)
    {
        dynamic list = CreateList(type);
        dynamic addedNodeValue = GetValue(type);
        list.Add(addedNodeValue);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
        Assert.Contains("Position out of range", exception.Message);
        Assert.Equal("position", exception.ParamName);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test24GetAPositionLargerThanSize(string type)
    {
        dynamic list = CreateList(type);
        dynamic addedNodeValue = GetValue(type);
        list.Add(addedNodeValue);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(1));
        Assert.Contains("Position out of range", exception.Message);
        Assert.Equal("position", exception.ParamName);
        var exception2 = Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(2));
        Assert.Contains("Position out of range", exception2.Message);
        Assert.Equal("position", exception2.ParamName);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test25GetFirstPosition(string type)
    {
        dynamic list = CreateList(type);
        dynamic addedNodeValue = GetValue(type);
        list.Add(addedNodeValue);
        var gotNode = list.Get(0);
        Assert.Equal(list.head, gotNode);
        Assert.Equal(addedNodeValue, gotNode.Value);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test26GetOthersPositions(string type)
    {
        dynamic list = CreateList(type);
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        dynamic gotNodeValue = GetValue(type);
        list.Add(addedNodeValue);
        list.Add(addedNodeValue2);
        list.Add(addedNodeValue3);
        list.Add(gotNodeValue);
        var gotNode = list.Get(3);
        Assert.Equal(gotNodeValue, gotNode.Value);
        Assert.Equal(list.tail, gotNode);
        Assert.Equal(list.tail!.Value, gotNode.Value);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test27FindAValueInAnEmptyList(string type)
    {
        dynamic list = CreateList(type);
        dynamic findNodeValue = GetValue(type);
        var result = list.Find(findNodeValue);
        Assert.Null(result);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test28TryToFindANonExistentValue(string type)
    {
        dynamic list = CreateList(type);
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic findInvalidNodeValue = GetValue(type);
        list.Add(addedNodeValue);
        list.Add(addedNodeValue2);
        var result = list.Find(findInvalidNodeValue);
        Assert.Null(result);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test29FindAnExistentValue(string type)
    {
        dynamic list = CreateList(type);
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        list.Add(addedNodeValue);
        list.Add(addedNodeValue2);
        list.Add(addedNodeValue3);
        var result = list.Find(addedNodeValue2);
        Assert.NotNull(result);
        Assert.Equal(addedNodeValue2, result.Value);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test30IndexOfAnEmptyList(string type)
    {
        dynamic list = CreateList(type);
        var result = list.IndexOf(GetValue(type));
        Assert.Equal(-1, result);
    }


    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test31IndexOfANonExistentValueInList(string type)
    {
        dynamic list = CreateList(type);
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        dynamic nonAddedNodeValue = GetValue(type);
        list.Add(addedNodeValue);
        list.Add(addedNodeValue2);
        list.Add(addedNodeValue3);
        var result = list.IndexOf(nonAddedNodeValue);
        Assert.Equal(-1, result);
    }

    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test32IndexOfAnExistentValueInList(string type)
    {
        dynamic list = CreateList(type);
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        list.Add(addedNodeValue);
        list.Add(addedNodeValue2);
        list.Add(addedNodeValue3);
        int expectedIndex = 2;
        var result = list.IndexOf(addedNodeValue3);
        Assert.Equal(expectedIndex, result);
    }



    [Theory]
    [InlineData("int")]
    [InlineData("string")]
    [InlineData("double")]
    [InlineData("float")]
    [InlineData("object")]
    public void Test33ClearList(string type)
    {
        dynamic list = CreateList(type);
        int testSize = 0;
        dynamic addedNodeValue = GetValue(type);
        dynamic addedNodeValue2 = GetValue(type);
        dynamic addedNodeValue3 = GetValue(type);
        dynamic addedNodeValue4 = GetValue(type);
        list.Add(addedNodeValue);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        list.Add(addedNodeValue3);
        testSize++;
        list.Remove(addedNodeValue2);
        testSize--;
        list.Add(addedNodeValue4);
        testSize++;
        Assert.Equal(testSize, list.Count);
        Assert.False(list.IsEmpty());
        list.Clear();
        Assert.True(list.IsEmpty());
        Assert.Equal(0, list.Count); ;
    }
}