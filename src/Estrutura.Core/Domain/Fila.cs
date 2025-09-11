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
            Console.WriteLine("A fila estás cheia");
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
            Console.WriteLine("A fila está vazia");
        }
        else
        {
            int dequeued = Fileira[Inicio];
            Inicio = (Inicio + 1) % Capacidade;
            Tamanho--;

            Console.WriteLine("Removido: " + dequeued);

        }
    }

    public void VerQueue()
    {
        if (Tamanho == 0)
        {
            Console.WriteLine("A fila está vazia");
            return;
        }

        for (int i = 0; i < Tamanho; i++)
        {
            int index = (Inicio + i) % Capacidade;
            Console.WriteLine(Fileira[index]);
        }
    }
    
    

}