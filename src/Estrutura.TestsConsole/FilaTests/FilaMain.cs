using System;
using Estrutura.Core.Domain;

namespace Estrutura.TestsConsole.FilaTests;
class FilaMain
{
    static void Main(string[] args)
    {

        Fila fila = new Fila(5);


        fila.Queue(10);
        fila.Queue(20);
        fila.Queue(30);

        Console.WriteLine("Fila atual:");
        fila.VerQueue();

        Console.WriteLine("Removendo um elemento...");
        fila.Dequeue();

        Console.WriteLine("Fila após remoção:");
        fila.VerQueue();


        fila.Queue(40);
        fila.Queue(50);
        fila.Queue(60);
        fila.Queue(70);

        Console.WriteLine("Fila final:");
        fila.VerQueue();

    }
}
