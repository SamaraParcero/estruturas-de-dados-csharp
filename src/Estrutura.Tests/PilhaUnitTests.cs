using Estrutura.Core.Domain;

namespace Estrutura.Tests;

public class PilhaUnitTests
{

    [Fact]
    public void Test1DeckSetCapacity()
    {
        int capacidade = 3;

        Pilha pilha = new Pilha(capacidade);

        Assert.Equal(capacidade, pilha.Capacidade);

    }


    [Fact]
    public void Test2PushIncreaseTop()
    {
        Pilha pilha = new Pilha(3);
        Assert.Equal(-1, pilha.Topo);
        int top = pilha.Topo;
        pilha.Push(2);
        int pushedTop = pilha.Topo;
        Assert.Equal(top + 1, pushedTop);
    }

    [Fact]
    public void Test3PushIncreaseSize()
    {
        Pilha pilha = new Pilha(4);
        var tamanho = pilha.Tamanho;
        pilha.Push(5);
        Assert.Equal(tamanho + 1, pilha.Tamanho);
    }


    [Fact]
    public void Test4PushRightNumber()
    {
        Pilha pilha = new Pilha(4);
        int numero = 2;
        pilha.Push(numero);
        Assert.Equal(numero, pilha.Pilhas[pilha.Topo]);
    }


    [Fact]
    public void Test5FullDeck()
    {
        Pilha pilha = new Pilha(4);
        pilha.Push(2);
        pilha.Push(5);
        pilha.Push(1);
        pilha.Push(6);

        Assert.Equal(pilha.Capacidade, pilha.Tamanho);
        Assert.Throws<InvalidOperationException>(() => pilha.Push(9));

    }



    [Fact]
    public void Test6PopDecreaseTop()
    {
        Pilha pilha = new Pilha(4);
        pilha.Push(4);
        pilha.Push(5);
        int top = pilha.Topo;
        pilha.Pop();
        int topPoped = pilha.Topo;
        Assert.NotEqual(top, topPoped);
    }

    [Fact]
    public void Test7DeckDecreaseSize()
    {
        Pilha pilha = new Pilha(4);
        pilha.Push(3);
        pilha.Push(4);
        var tamanho = pilha.Tamanho;
        pilha.Pop();
        Assert.Equal(tamanho - 1, pilha.Tamanho);
    }


    [Fact]
    public void Test8PopRightNumber()
    {
        Pilha pilha = new Pilha(3);
        pilha.Push(2);
        pilha.Push(4);
        var top = pilha.Topo;
        pilha.Pop();
        Assert.NotEqual(pilha.Pilhas[top], pilha.Pilhas[pilha.Topo]);
    }


    [Fact]
    public void Test9EmptyDeck()
    {
        Pilha pilha = new Pilha(4);
        Assert.Equal(0, pilha.Tamanho);
        Assert.Throws<InvalidOperationException>(() => pilha.Pop());
    }


    [Fact]
    public void Test10VerTop()
    {
        Pilha pilha = new Pilha(3);
        pilha.Push(4);
        int top = pilha.Pilhas[pilha.Topo];
        Assert.Equal(pilha.VerTop(), top);
    }


    [Fact]
    public void VerDeck()
    {
        
        Pilha pilha = new Pilha(5); 
        int posicao1 = 5;
        int posicao2 = 8;
        int posicao3 = 10;

        pilha.Push(posicao1);
        pilha.Push(posicao2);
        pilha.Push(posicao3);

        var resultado = pilha.VerDeck();

    
        Assert.Equal(new int[] { posicao1, posicao2, posicao3 }, resultado);
    }
}
