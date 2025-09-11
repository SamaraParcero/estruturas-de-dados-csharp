namespace Estrutura.Core.Domain.ArvoreBinaria;

public class No
{
    public int Valor;
    public No Esquerda;
    public No Direita;

    public No(int valor)
    {
        Valor = valor;
        Esquerda = null;
        Direita = null;
    }
}
