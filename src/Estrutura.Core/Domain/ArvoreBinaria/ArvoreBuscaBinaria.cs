using System.ComponentModel.Design.Serialization;

namespace Estrutura.Core.Domain.ArvoreBinaria;

public class ArvoreBuscaBinaria
{
    public No? Raiz;

    public ArvoreBuscaBinaria()
    {
        Raiz = null;

    }


    public void Insert(int valor)
    {
        No no = new No(valor);

        if (Raiz == null)
        {
            Raiz = no;
            Console.WriteLine("Nó raiz adicionado");
        }
        else
        {
            InsertRecursivo(Raiz, no);
        }
    }

    private void InsertRecursivo(No atual, No no)
    {
        if (no.Valor < atual.Valor)
        {
            if (atual.Esquerda == null)
            {
                atual.Esquerda = no;
                Console.WriteLine("Adicionado " + no.Valor + " na esquerda de " + atual.Valor);
            }
            else
            {
                InsertRecursivo(atual.Esquerda, no);
            }
        }
        else if (no.Valor > atual.Valor)
        {
            if (atual.Direita == null)
            {
                atual.Direita = no;
                Console.WriteLine("Adicionado " + no.Valor + " na direita de " + atual.Valor);
            }
            else
            {
                InsertRecursivo(atual.Direita, no);
            }
        }
        else
        {
            Console.WriteLine("Valor " + no.Valor + " já adicionado na árvore");
        }
    }

    public void PercorrerEmOrdemArvore()
    {
        PercorrerEmOrdemArvoreRecursivo(Raiz);
    }

    private void PercorrerEmOrdemArvoreRecursivo(No no)
    {
        if (no != null)
        {
            PercorrerEmOrdemArvoreRecursivo(no.Esquerda);
            Console.WriteLine(no.Valor + " ");
            PercorrerEmOrdemArvoreRecursivo(no.Direita);
        }
    }

    public void Remove(int valor)
    {
        Raiz = RemoveRecursivo(Raiz, valor);
    }


    private No? RemoveRecursivo(No? noAtual, int valor)
    {
        if (noAtual == null)
        {
            return null;
        }

        if (valor < noAtual.Valor)
        {
            noAtual.Esquerda = RemoveRecursivo(noAtual.Esquerda, valor);
        }
        else if (valor > noAtual.Valor)
        {
            noAtual.Direita = RemoveRecursivo(noAtual.Direita, valor);
        }
        else if (valor == noAtual.Valor)
        {

            if (noAtual.Esquerda == null && noAtual.Direita == null)
            {
                return null;
            }
            else if (noAtual.Esquerda == null)
            {
                return noAtual.Direita;
            }
            else if (noAtual.Direita == null)
            {
                return noAtual.Esquerda;
            }
            else
            {
                No sucessor = EncontrarMenorNo(noAtual.Direita); 
                noAtual.Valor = sucessor.Valor;
                noAtual.Direita = RemoveRecursivo(noAtual.Direita, sucessor.Valor);
            }
        }
        return noAtual;
    }

    private No EncontrarMenorNo(No no)
    {
        while (no.Esquerda != null)
        {
            no = no.Esquerda;
        }
        return no;
    }







}