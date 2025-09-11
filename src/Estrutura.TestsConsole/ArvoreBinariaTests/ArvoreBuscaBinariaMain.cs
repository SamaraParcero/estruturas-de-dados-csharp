using System;
using Estrutura.Core.Domain.ArvoreBinaria;

namespace Estrutura.TestsConsole.ArvoreBinariaTests;

class ArvoreBuscaBinariaMain
{
    static void Main(string[] args)
    {
        ArvoreBuscaBinaria arvore = new ArvoreBuscaBinaria();

        arvore.Insert(15);
        arvore.Insert(10);
        arvore.Insert(20);
        arvore.Insert(8);
        arvore.Insert(12);
        arvore.Insert(25);


        Console.WriteLine("Árvore em ordem antes da remoção:");
        arvore.PercorrerEmOrdemArvore();



        arvore.Remove(10);


        Console.WriteLine("Árvore em ordem depois da remoção:");
        arvore.PercorrerEmOrdemArvore();
    }
}
