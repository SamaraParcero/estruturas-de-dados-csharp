using System;
using Estrutura.Core.Domain.Stacks;

namespace Estrutura.TestsConsole.StackTests;
class StackMain
{
    static void Main(string[] args)
    {

        Stackk<int> stack = new Stackk<int>();
        
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine("Peek of Stack: " + stack.Peek());

        stack.Pop();

        stack.Push(40);
        stack.Push(50);
        stack.Push(60);
        stack.Push(70);
    

        stack.Pop();
        stack.Pop();
        stack.Pop();
        stack.Pop();
        stack.Pop();
        stack.Pop();

        stack.Clear();
      

    }
}
