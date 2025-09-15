using Estrutura.Core.Domain;

namespace Estrutura.Tests;

public class FilaUnitTests
{

    [Fact]
    public void Test1QueueSetCapacity()
    {
        int capacidade = 3;

        Fila fila = new Fila(capacidade);

        Assert.Equal(capacidade, fila.Capacidade);

    }


    [Fact]
    public void Test2QueueSetFinal()
    {
        Fila fila = new Fila(3);
        int fim = fila.Fim;
        fila.Queue(2);
        int fimQueued = fila.Fim;
        Assert.Equal((fim + 1) % fila.Capacidade, fimQueued);
    }

    [Fact]
    public void Test3QueueIncreaseSize()
    {
        Fila fila = new Fila(3);
        var tamanho = fila.Tamanho;
        fila.Queue(2);
        Assert.Equal(fila.Tamanho, tamanho + 1);
    }


    [Fact]
    public void Test4QueueRightNumber()
    {
        Fila fila = new Fila(3);
        int numero = 2;
        var fim = fila.Fim;
        fila.Queue(numero);
        Assert.Equal(numero, fila.Fileira[fim]);
    }


    [Fact]
    public void Test5FullQueue()
    {
        Fila fila = new Fila(4);

        fila.Queue(3);
        fila.Queue(4);
        fila.Queue(5);
        fila.Queue(2);

        Assert.Equal(fila.Capacidade, fila.Tamanho);
        Assert.Throws<InvalidOperationException>(() => fila.Queue(10));

    }



    [Fact]
    public void Test6DequeueSetStart()
    {
        Fila fila = new Fila(4);
        fila.Queue(2);
        fila.Queue(4);
        int inicio = fila.Inicio;
        fila.Dequeue();
        int inicioDequeued = fila.Inicio;
        Assert.Equal((inicio + 1) % fila.Capacidade, inicioDequeued);
    }

    [Fact]
    public void Test7DequeueDecreaseSize()
    {
        Fila fila = new Fila(3);
        fila.Queue(2);
        fila.Queue(4);
        var tamanho = fila.Tamanho;
        fila.Dequeue();
        Assert.Equal(fila.Tamanho, tamanho - 1);
    }


    [Fact]
    public void Test8DequeueRightNumber()
    {
        Fila fila = new Fila(3);
        fila.Queue(2);
        fila.Queue(4);
        var inicio = fila.Inicio;
        fila.Dequeue();
        var inicioDequeued = fila.Inicio;
        Assert.NotEqual(inicio, inicioDequeued);
    }


    [Fact]
    public void Test9EmptyQueue()
    {
        Fila fila = new Fila(4);
        Assert.Equal(0, fila.Tamanho);
        Assert.Throws<InvalidOperationException>(() => fila.Dequeue());
    }


    [Fact]
    public void Test10VerQueueEmptyQueue()
    {
        Fila fila = new Fila(4);
        Assert.Equal(0, fila.Tamanho);
        Assert.Throws<InvalidOperationException>(() => fila.VerQueue());
    }

    [Fact]
    public void Test11VerQueue()
    {
        Fila fila = new Fila(4);
        int posicao1 = 5;
        int posicao2 = 8;
        int posicao3 = 10;
        fila.Queue(posicao1);
        fila.Queue(posicao2);
        fila.Queue(posicao3);

        var resultado = fila.VerQueue();

        Assert.Equal(new int[] { posicao1, posicao2, posicao3 }, resultado);
    }

}
