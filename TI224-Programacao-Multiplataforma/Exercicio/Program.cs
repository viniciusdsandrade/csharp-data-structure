using System;
using System.Collections.Generic;
using System.Security.Principal;
using static System.Console;
using static System.Array;

namespace Program
{
    /*
    1 - Utilizando o trecho de código abaixo, que trata da função do bubble Sort utilizado em C, 
    implemente este método em C# para realizar a ordenação de um vetor de 15 números inteiros 
    (não utilizar Array Sort)

    2  - Faça um programa que insira 5 nomes em um vetor Depois da inserção, realize a ordenação em C#

    3 - Elabore um programa que preencha um vetor com 18 posições, ordene e mostre
    a) o maior elemento do vetor e sua respectiva posição
    b) o menor elemento do vetor e sua respectiva posição

    4 - Criar uma matriz para receber 16 valores inteiros(4 x 4). 
    Depois, criar uma segunda matriz que irá construir a transposta da primeira. 
    Exibir as 2 matrizes no final.
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            int choice;
            do
            {
                WriteLine("Escolha o exercício que deseja executar:");
                WriteLine("1 - Bubble Sort");
                WriteLine("2 - Ordenação de nomes");
                WriteLine("3 - Vetor com 18 posições");
                WriteLine("4 - Matriz transposta");
                WriteLine("0 - Sair");

                choice = int.Parse(ReadLine());

                switch (choice)
                {
                    case 1:
                        ExecutarBubbleSort();
                        break;
                    case 2:
                        ExecutarOrdenacaoNomes();
                        break;
                    case 3:
                        ExecutarVetor18Posicoes();
                        break;
                    case 4:
                        ExecutarMatrizTransposta();
                        break;
                    case 0:
                        WriteLine("Saindo...");
                        break;
                    default:
                        WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (choice != 0);
        }

        public static void ExecutarBubbleSort()
        {
            const int quantidadeNumeros = 15;
            int[] vetor = new int[quantidadeNumeros];

            WriteLine("Insira 15 números inteiros:");
            PreencherVetor(vetor);

            BubbleSort(vetor);

            WriteLine("Números ordenados:");
            ImprimirVetor(vetor);
        }

        public static void ExecutarVetor18Posicoes()
        {
            const int quantidadeNumeros = 18;
            int[] vetor18 = new int[quantidadeNumeros];

            WriteLine("Insira 18 números inteiros:");
            PreencherVetor(vetor18);

            BubbleSort(vetor18);

            WriteLine($"Maior elemento: {vetor18[vetor18.Length - 1]}, Posição: {IndexOf(vetor18, vetor18[vetor18.Length - 1])}");
            WriteLine($"Menor elemento: {vetor18[0]}, Posição: {IndexOf(vetor18, vetor18[0])}");
        }

        public static void ExecutarMatrizTransposta()
        {
            int[,] matriz = new int[4, 4];
            WriteLine("Insira 16 números inteiros para a matriz 4x4:");
            PreencherMatriz(matriz);

            int[,] transposta = CalcularTransposta(matriz);

            WriteLine("Matriz original:");
            ExibirMatriz(matriz);

            WriteLine("Matriz transposta:");
            ExibirMatriz(transposta);
        }

        public static void ExecutarOrdenacaoNomes()
        {
            string[] nomes = new string[5];
            for (int i = 0; i < 5; i++)
            {
                Write($"Insira o {i + 1}º nome: ");
                nomes[i] = ReadLine();
            }
            BubbleSort(nomes);

            WriteLine("Nomes ordenados:");
            ImprimirVetor(nomes);
        }

        public static void PreencherVetor(int[] vetor)
        {
            for (int i = 0; i < vetor.Length; i++)
            {
                Write($"Número {i + 1}: ");
                vetor[i] = int.Parse(ReadLine());
            }
        }

        public static void PreencherMatriz(int[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Write($"Número {i + 1},{j + 1}: ");
                    matriz[i, j] = int.Parse(ReadLine());
                }
            }
        }

        public static int[,] CalcularTransposta(int[,] matriz)
        {
            int[,] transposta = new int[matriz.GetLength(1), matriz.GetLength(0)];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    transposta[j, i] = matriz[i, j];
                }
            }
            return transposta;
        }

        public static void ExibirMatriz(int[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                Write("  [ ");
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (j != matriz.GetLength(1) - 1)
                        Write(matriz[i, j] + ", ");
                    else
                        Write(matriz[i, j]);
                }
                Write(" ]");
                WriteLine();
            }
        }

        public static void ImprimirVetor(string[] vetor)
        {
            Write("[");
            foreach (string nome in vetor)
            {
                if (nome != vetor[vetor.Length - 1])
                    Write(nome + ", ");
                else
                    Write(nome);
            }
            WriteLine("]");
        }

        public static void ImprimirVetor(int[] vetor)
        {
            Write("[");
            foreach (int numero in vetor)
            {
                if (numero != vetor[vetor.Length - 1])
                    Write(numero + ", ");
                else
                    Write(numero);
            }   
            WriteLine("]");
        }

        public static void BubbleSort(int[] vetor)
        {
            int temp;
            for (int write = 0; write < vetor.Length; write++)
            {
                for (int sort = 0; sort < vetor.Length - 1; sort++)
                {
                    if (vetor[sort] > vetor[sort + 1])
                    {
                        temp = vetor[sort + 1];
                        vetor[sort + 1] = vetor[sort];
                        vetor[sort] = temp;
                    }
                }
            }
        }

        public static void BubbleSort(string[] vetor)
        {
            string temp;
            for (int write = 0; write < vetor.Length; write++)
            {
                for (int sort = 0; sort < vetor.Length - 1; sort++)
                {
                    if (vetor[sort].CompareTo(vetor[sort + 1]) > 0)
                    {
                        temp = vetor[sort + 1];
                        vetor[sort + 1] = vetor[sort];
                        vetor[sort] = temp;
                    }
                }
            }
        }
    }
}