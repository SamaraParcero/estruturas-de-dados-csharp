namespace Estrutura.Core.Domain;

public class Fila
{


    public int[] Fileira { get; set; }
    public int Inicio { get; set; }
    public int Fim { get; set; }
    public int Tamanho { get; set; }
    public int Capacidade { get; set; }

    public Fila()
    {

    }


    public Fila(int capacidade)
    {
        Capacidade = capacidade;
        Fileira = new int[Capacidade];
        Inicio = 0;
        Fim = 0;
        Tamanho = 0;
    }


    public void Queue(int num)
    {
        if (Tamanho == Capacidade)
        {
            throw new InvalidOperationException("Fila cheia");
        }
        else
        {
            Fileira[Fim] = num;
            Fim = (Fim + 1) % Capacidade;
            Tamanho++;
            Console.WriteLine("Enfileirado: " + num);
        }
    }



    public void Dequeue()
    {
        if (Tamanho == 0)
        {
            throw new InvalidOperationException("Fila vazia");
        }
        else
        {
            int dequeued = Fileira[Inicio];
            Inicio = (Inicio + 1) % Capacidade;
            Tamanho--;

            Console.WriteLine("Removido: " + dequeued);

        }
    }

    public int[] VerQueue()
    {
        if (Tamanho == 0)
        {
            throw new InvalidOperationException("Fila vazia");
        }

        var resultado = new int[Tamanho];
        for (int i = 0; i < Tamanho; i++)
        {
            int index = (Inicio + i) % Capacidade;
            resultado[i] = Fileira[index];
            Console.WriteLine(Fileira[index]);
        }

        return resultado;
    }



}