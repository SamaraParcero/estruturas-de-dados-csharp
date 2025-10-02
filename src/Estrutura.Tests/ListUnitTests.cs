
using Estrutura.Core.Domain.Lists;

namespace Estrutura.Tests;

public class ListUnitTests
{

    [Fact]
    public void Test1ListStartsEmpty()
    {
        Listt<int> list = new Listt<int>();
        Assert.Equal(0, list.Count);
        Assert.True(list.IsEmpty());
    }

    [Fact]
    public void Test2AddIncreasesCount()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        list.Add(3);
        testSize++;
        Assert.Equal(testSize, list.Count);
        list.Add(4);
        testSize++;
        Assert.Equal(testSize, list.Count);
    }

    [Fact]
    public void Test3AddValueInAnEmptyList()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int addedNodeValue = 16;
        list.Add(addedNodeValue);
        testSize++;
        Assert.Equal(testSize, list.Count);
        Assert.False(list.IsEmpty());
        Assert.Equal(addedNodeValue, list.head.Value);
        Assert.Equal(addedNodeValue, list.tail.Value);
    }

    [Fact]
    public void Test4AddTwoValuesInAnEmptyList()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int addedNodeValue = 16;
        int addedNodeValue2 = 13;
        list.Add(addedNodeValue);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        Assert.Equal(testSize, list.Count);
        Assert.False(list.IsEmpty());
        Assert.Equal(addedNodeValue, list.head.Value);
        Assert.Equal(addedNodeValue2, list.head.Next.Value);
        Assert.Equal(addedNodeValue2, list.tail.Value);
        Assert.Null(list.tail.Next);
    }

    [Fact]
    public void Test5InsertInAnInvalidPosition()
    {
        Listt<int> list = new Listt<int>();
        list.Add(15);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(-1, 5));
        Assert.Contains("Position out of range", exception.Message);
        Assert.Equal("position", exception.ParamName);
    }

    [Fact]
    public void Test6InsertInAPositionLargerThanSize()
    {
        Listt<int> list = new Listt<int>();
        list.Add(10);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(3, 3));
        Assert.Contains("Position out of range", exception.Message);
        Assert.Equal("position", exception.ParamName);
    }

    [Fact]
    public void Test7InsertInFirstPosition()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int firstNodeValue = 10;
        int InsertedNodeValue = 5;
        list.Add(firstNodeValue);
        testSize++;
        list.Insert(0, InsertedNodeValue);
        testSize++;
        Assert.Equal(testSize, list.Count);
        Assert.Equal(InsertedNodeValue, list.head.Value);
        Assert.Equal(firstNodeValue, list.head.Next.Value);
        Assert.Equal(firstNodeValue, list.tail.Value);
    }

    [Fact]
    public void Test8InsertInLastPosition()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int firstNodeValue = 10;
        int InsertedNodeValue = 5;
        list.Add(firstNodeValue);
        testSize++;
        list.Add(3);
        testSize++;
        list.Insert(2, InsertedNodeValue);
        testSize++;
        Assert.Equal(testSize, list.Count);
        Assert.Equal(InsertedNodeValue, list.tail.Value);
        Assert.Null(list.tail.Next);
    }

    [Fact]
    public void Test9InsertInMiddlePosition()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int addedNodeValue1 = 10;
        int addedNodeValue2 = 20;
        int addedNodeValue3 = 30;
        list.Add(addedNodeValue1);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        list.Add(addedNodeValue3);
        testSize++;
        int insertedValue = 15;
        list.Insert(1, insertedValue);
        testSize++;
        Assert.Equal(testSize, list.Count);
        Assert.Equal(addedNodeValue1, list.head.Value);
        Assert.Equal(insertedValue, list.head.Next.Value);
        Assert.Equal(addedNodeValue2, list.head.Next.Next.Value);
        Assert.Equal(addedNodeValue3, list.tail.Value);
    }

    [Fact]
    public void Test10InsertIncreasesCount()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int firstNodeValue = 10;
        int InsertedNodeValue = 5;
        list.Add(firstNodeValue);
        testSize++;
        list.Add(3);
        testSize++;
        list.Insert(2, InsertedNodeValue);
        testSize++;
        Assert.Equal(testSize, list.Count);
    }

    [Fact]
    public void Test11tryToRemoveAValueFromAnEmptyList()
    {
        Listt<int> list = new Listt<int>();
        Assert.Null(list.Remove(5));
    }

    [Fact]
    public void Test12RemoveHeadValue()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int addedNodeValue = 4;
        int addedNodeValue2 = 2;
        int addedNodeValue3 = 8;
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
        Assert.Equal(addedNodeValue2, list.head.Value);
        Assert.Equal(testSize, list.Count);
        Assert.Equal(addedNodeValue3, list.tail.Value);
    }

    [Fact]
    public void Test13RemoveMiddleValue()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int addedNodeValue = 4;
        int addedNodeValue2 = 2;
        int addedNodeValue3 = 8;
        list.Add(addedNodeValue);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        list.Add(addedNodeValue3);
        testSize++;
        var removedNode = list.Remove(2);
        testSize--;
        Assert.NotNull(removedNode);
        Assert.Equal(addedNodeValue2, removedNode.Value);
        Assert.Equal(testSize, list.Count);
        Assert.Equal(addedNodeValue, list.head.Value);
        Assert.Equal(addedNodeValue3, list.head.Next.Value);
        Assert.Equal(addedNodeValue3, list.tail.Value);
        Assert.Null(list.tail.Next);
    }

    [Fact]
    public void Test14RemoveTailValue()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int addedNodeValue = 4;
        int addedNodeValue2 = 2;
        int addedNodeValue3 = 8;
        list.Add(addedNodeValue);
        testSize++;
        list.Add(addedNodeValue2);
        testSize++;
        list.Add(addedNodeValue3);
        testSize++;
        var removedNode = list.Remove(8);
        testSize--;
        Assert.NotNull(removedNode);
        Assert.Equal(addedNodeValue3, removedNode.Value);
        Assert.Equal(testSize, list.Count);
        Assert.Equal(addedNodeValue, list.head.Value);
        Assert.Equal(addedNodeValue2, list.tail.Value);
        Assert.Null(list.tail.Next);
    }

    [Fact]
    public void Test15RemoveANonExistentValueFromAList()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        list.Add(10);
        testSize++;
        list.Add(5);
        testSize++;
        var removedNode = list.Remove(8);
        Assert.Equal(testSize, list.Count);
        Assert.Null(removedNode);
    }

    [Fact]
    public void Test16RemoveDecreasesCount()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        list.Add(10);
        testSize++;
        list.Add(5);
        testSize++;
        list.Remove(5);
        testSize--;
        Assert.Equal(testSize, list.Count);
    }

    [Fact]
    public void Test17RemoveAtAnInvalidPosition()
    {
        Listt<int> list = new Listt<int>();
        list.Add(5);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
        Assert.Contains("Position out of range", exception.Message);
        Assert.Equal("position", exception.ParamName);
    }

    [Fact]
    public void Test18RemoveAtALargerPositionThanSize()
    {
        Listt<int> list = new Listt<int>();
        list.Add(5);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(3));
        Assert.Contains("Position out of range", exception.Message);
        Assert.Equal("position", exception.ParamName);
    }


    [Fact]
    public void Test19RemovedAtFirstPosition()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int firstNodeValue = 10;
        int secondNodeValue = 11;
        list.Add(firstNodeValue);
        testSize++;
        list.Add(secondNodeValue);
        testSize++;
        var removedNode = list.RemoveAt(0);
        testSize--;
        Assert.Equal(testSize, list.Count);
        Assert.Equal(secondNodeValue, list.head.Value);
        Assert.Equal(secondNodeValue, list.tail.Value);
        Assert.Null(list.head.Next);
        Assert.Equal(firstNodeValue, removedNode.Value);
    }

    [Fact]
    public void Test20RemovedAtMidleOfList()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int addedNodeValue = 4;
        int addedNodeValue2 = 2;
        int addedNodeValue3 = 8;
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
        Assert.Equal(addedNodeValue3, list.head.Next.Value);
    }

    [Fact]
    public void Test21RemovedAtTailOfList()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int addedNodeValue = 4;
        int addedNodeValue2 = 2;
        int addedNodeValue3 = 8;
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
        Assert.Equal(addedNodeValue2, list.head.Next.Value);
        Assert.Equal(addedNodeValue2, list.tail.Value);
        Assert.Null(list.tail.Next);
    }

    [Fact]
    public void Test22RemovedAtDecreasesCount()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        list.Add(10);
        testSize++;
        list.Add(5);
        testSize++;
        list.RemoveAt(1);
        testSize--;
        Assert.Equal(testSize, list.Count);
    }

    [Fact]
    public void Test23GetAnInvalidPosition()
    {
        Listt<int> list = new Listt<int>();
        list.Add(5);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
        Assert.Contains("Position out of range", exception.Message);
        Assert.Equal("position", exception.ParamName);
    }


    [Fact]
    public void Test24GetAPositionLargerThanSize()
    {
        Listt<int> list = new Listt<int>();
        list.Add(5);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(1));
        Assert.Contains("Position out of range", exception.Message);
        Assert.Equal("position", exception.ParamName);
        var exception2 = Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(2));
        Assert.Contains("Position out of range", exception2.Message);
        Assert.Equal("position", exception2.ParamName);
    }

    [Fact]
    public void Test25GetFirstPosition()
    {
        Listt<int> list = new Listt<int>();
        int addedNodeValue = 5;
        list.Add(addedNodeValue);
        var gotNode = list.Get(0);
        Assert.Equal(list.head, gotNode);
        Assert.Equal(addedNodeValue, gotNode.Value);
    }

    [Fact]
    public void Test26GetOthersPositions()
    {
        Listt<int> list = new Listt<int>();
        int gotNodeValue = 8;
        list.Add(5);
        list.Add(6);
        list.Add(2);
        list.Add(gotNodeValue);
        var gotNode = list.Get(3);
        Assert.Equal(gotNodeValue, gotNode.Value);
        Assert.Equal(list.tail, gotNode);
        Assert.Equal(list.tail.Value, gotNode.Value);
    }

    [Fact]
    public void Test27FindAValueInAnEmptyList()
    {
        Listt<int> list = new Listt<int>();
        var result = list.Find(10);
        Assert.Null(result);

    }

    [Fact]
    public void Test28TryToFindANonExistentValue()
    {
        Listt<int> list = new Listt<int>();
        list.Add(11);
        list.Add(9);
        var result = list.Find(10);
        Assert.Null(result);
    }

    [Fact]
    public void Test29FindAnExistentValue()
    {
        Listt<int> list = new Listt<int>();
        int addedNodeValue = 10;
        list.Add(11);
        list.Add(addedNodeValue);
        list.Add(9);
        var result = list.Find(10);
        Assert.NotNull(result);
        Assert.Equal(addedNodeValue, result.Value);
    }

    [Fact]
    public void Test30IndexOfAnEmptyList()
    {
        Listt<int> list = new Listt<int>();
        var result = list.IndexOf(10);
        Assert.Equal(-1, result);
    }


    [Fact]
    public void Test31IndexOfANonExistentValueInList()
    {
        Listt<int> list = new Listt<int>();
        list.Add(8);
        list.Add(5);
        list.Add(1);
        var result = list.IndexOf(10);
        Assert.Equal(-1, result);
    }

     [Fact]
    public void Test32IndexOfAnExistentValueInList()
    {
        Listt<int> list = new Listt<int>();
        int addedNodeValue = 5;
        int indexOfNode = 1;
        list.Add(8);
        list.Add(addedNodeValue);
        list.Add(1);
        var result = list.IndexOf(addedNodeValue);
        Assert.Equal(indexOfNode, result);
    }



    [Fact]
    public void Test33ClearList()
    {
        Listt<int> list = new Listt<int>();
        int testSize = 0;
        int addedNodeValue = 2;
        int addedNodeValue2 = 3;
        int addedNodeValue3 = 4;
        int addedNodeValue4 = 1;
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