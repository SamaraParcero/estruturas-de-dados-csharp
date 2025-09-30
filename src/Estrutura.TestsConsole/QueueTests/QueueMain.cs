using System;
using Estrutura.Core.Domain.Queues;

namespace Estrutura.TestsConsole.QueueTests;

class QueueMain
{
    static void Main(string[] args)
    {

        Queuee<int> queue = new Queuee<int>();


        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Console.WriteLine("Actual Queue:");
        queue.ViewQueue();
        Console.WriteLine();
        Console.WriteLine("Removing element...");
        queue.Dequeue();

        Console.WriteLine("Queue after removing:");
        queue.ViewQueue();

        Console.WriteLine();
        queue.Enqueue(40);
        queue.Enqueue(50);
        queue.Enqueue(60);
        queue.Enqueue(70);

        Console.WriteLine("Final queue:");
        queue.ViewQueue();

        queue.Clear();
        queue.ViewQueue();


    }
}
