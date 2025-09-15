namespace Estrutura.Core.Domain;

public class Pilha
{


    public int[] Pilhas { get; set; }
    public int Base { get; set; }
    public int Topo { get; set; }
    public int Tamanho { get; set; }
    public int Capacidade { get; set; }

    public Pilha()
    {

    }


    public Pilha(int capacidade)
    {
        Capacidade = capacidade;
        Pilhas = new int[Capacidade];
        Base = 0;
        Topo = -1;
        Tamanho = 0;
    }

    public void Push(int num)
    {
        if (Tamanho == Capacidade)
        {
            throw new InvalidOperationException("A Pilha está cheia!");
        }
        else
        {
            Topo++;
            Pilhas[Topo] = num;
            Tamanho++;
        }

    }

    public void Pop()
    {
        if (Tamanho == 0)
        {
            throw new InvalidOperationException("A Pilha está vazia");
        }
        else
        {
            int poped = Pilhas[Topo];
            Topo--;
            Tamanho--;
            Console.WriteLine("Item removido:" + poped);
        }

    }

    public int VerTop()
    {
        var top = Pilhas[Topo];
        Console.WriteLine("Topo da pilha:" + top);
        return top;
    }

    public int[] VerDeck()
    {
        var resultado = new int[Tamanho];
        for (int i = 0; i < Tamanho; i++)
        {
            resultado[i] = Pilhas[i];
            Console.WriteLine(Pilhas[i]);
        }
        return resultado;
    }




}