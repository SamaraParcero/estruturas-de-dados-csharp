using System;
using Estrutura.Core.Domain;

namespace Estrutura.TestsConsole.PilhaTests;
class PilhaMain
{
    static void Main(string[] args)
    {

        Pilha pilha = new Pilha(5);


        pilha.Push(10);
        pilha.Push(20);
        pilha.Push(30);

        Console.WriteLine("Elementos na pilha após 3 Push:");
        pilha.VerDeck();
        pilha.VerTop();


        pilha.Pop();

        Console.WriteLine("Elementos na pilha após 1 Pop:");
        pilha.VerDeck();


        pilha.Push(40);
        pilha.Push(50);
        pilha.Push(60);
        pilha.Push(70);
        Console.WriteLine("Elementos na pilha após mais Push:");
        pilha.VerDeck();


        pilha.Pop();
        pilha.Pop();
        pilha.Pop();
        pilha.Pop();
        pilha.Pop();
        pilha.Pop();


    }
}
