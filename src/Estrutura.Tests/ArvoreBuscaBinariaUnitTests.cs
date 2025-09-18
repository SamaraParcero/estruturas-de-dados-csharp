using Estrutura.Core.Domain;
using Estrutura.Core.Domain.ArvoreBinaria;

namespace Estrutura.Tests;

public class ArvoreBuscaBinariaUnitTests
{
    [Fact]
    public void Test1InsertDuplicateNodeValue()
    {
        ArvoreBuscaBinaria arvore = new ArvoreBuscaBinaria();
        var node1 = arvore.Insert(10);
        arvore.Insert(10);
        var result = arvore.PercorrerEmOrdemArvore();
        Assert.Single(result);
        Assert.Equal(node1.Valor, result[0]);
    }

    [Fact]
    public void Test2InsertRootNode()
    {
        ArvoreBuscaBinaria arvore = new ArvoreBuscaBinaria();
        var nos = arvore.PercorrerEmOrdemArvore();
        Assert.Empty(nos);
        var insertNodeValue = 10;
        arvore.Insert(insertNodeValue);

        Assert.NotNull(arvore.Raiz);
        Assert.Equal(insertNodeValue, arvore.Raiz.Valor);
    }



    [Fact]
    public void Test3InsertNodeRightAndLeft()
    {
        ArvoreBuscaBinaria arvore = new ArvoreBuscaBinaria();
        var nodeValue1 = arvore.Insert(10);
        var nodeValue2 = arvore.Insert(5);
        var nodeValue3 = arvore.Insert(15);

        Assert.Equal(nodeValue1.Valor, arvore.Raiz.Valor);
        Assert.Equal(nodeValue2.Valor, arvore.Raiz.Esquerda.Valor);
        Assert.Equal(nodeValue3.Valor, arvore.Raiz.Direita.Valor);
    }

    [Fact]
    public void Test4RemoveNonExistentNode()
    {
        ArvoreBuscaBinaria arvore = new ArvoreBuscaBinaria();
        var node2 = arvore.Insert(10);
        var node1 =arvore.Insert(5);
        var node3 =arvore.Insert(15);

        arvore.Remove(12); 
        List<int> list = new List<int> { node1.Valor, node2.Valor, node3.Valor};
        var result = arvore.PercorrerEmOrdemArvore();
        Assert.Equal(list, result);
    }

    [Fact]
    public void Test5RemoveRootNode()
    {
        ArvoreBuscaBinaria arvore = new ArvoreBuscaBinaria();
        var rootNode = arvore.Insert(10);


        arvore.Remove(rootNode.Valor);

        Assert.Null(arvore.Raiz);
    }

    [Fact]
    public void Test6RemoveNodeLeaf()
    {
        ArvoreBuscaBinaria arvore = new ArvoreBuscaBinaria();
        arvore.Insert(10);
        arvore.Insert(5);

        arvore.Remove(5);

        Assert.Null(arvore.Raiz.Esquerda);
    }

    [Fact]
    public void Test7RemoveNodeWithOneSon()
    {
        var arvore = new ArvoreBuscaBinaria();
        arvore.Insert(10);
        arvore.Insert(5);
        var nodeValue1 = arvore.Insert(3);

        arvore.Remove(5);

        Assert.Equal(nodeValue1.Valor, arvore.Raiz.Esquerda.Valor);
    }

    [Fact]
    public void Test8RemoveNodeWithBothSons()
    {
        var arvore = new ArvoreBuscaBinaria();
        var node2 = arvore.Insert(10);
        var node1 = arvore.Insert(5);
        arvore.Insert(15);
        var node3 = arvore.Insert(12);
        var node4 = arvore.Insert(18);


        arvore.Remove(15);


        var list = new List<int> { node1.Valor, node2.Valor, node3.Valor, node4.Valor };
        var result = arvore.PercorrerEmOrdemArvore();

        Assert.Equal(list, result);
    }

    [Fact]
    public void Test9TraverseInOrderEmptyTree()
    {
        ArvoreBuscaBinaria arvore = new ArvoreBuscaBinaria();
        var result = arvore.PercorrerEmOrdemArvore();
        Assert.Empty(result);
    }

    [Fact]
    public void Test10TraverseInOrderTree()
    {
        ArvoreBuscaBinaria arvore = new ArvoreBuscaBinaria();
        var node2 = arvore.Insert(10);
        var node1 = arvore.Insert(5);
        var node4 = arvore.Insert(15);
        var node3 = arvore.Insert(12);

        List<int> list = new List<int> { node1.Valor, node2.Valor, node3.Valor, node4.Valor };
        var result = arvore.PercorrerEmOrdemArvore();

        Assert.Equal(list, result);
    }

}