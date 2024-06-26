﻿// ReSharper disable once RedundantUsingDirective

using static System.Console;
using System.Diagnostics;
using Shopping;
using static System.Math;


namespace lista_1_cotuca
{
    internal static class Program
    {
        /*
         * Exercício 1
         * Qual o retorno deste programa para funcao([83, 41, 5, 1, 59, 97], 2)?
         */
        private static int[] Funcao(int[] A, int i)
        {
            A[1] = 17;
            A[i / 2] = 9;
            A[2 * i - 1] = 95;
            A[i - 1] = A[5] / 2;
            A[3] = A[i];
            A[i + 1] = A[i] + A[i - 1];
            A[A[2] - 2] = 78;
            A[A[i] - 1] = A[1] * A[i] / 5;
            A[A[2] % 2 + 2] = A[i + 6 / 2] - A[i - 1 * 2];

            return A;
        }


        /*
           Exercício 2
           Qual o retorno deste programa para funcao(81)?
        */
        private static int Funcao2(int n)
        {
            int p = 1, r = n;
            while (p + 1 < r)
            {
                var q = (p + r) / 2;
                if (Pow(q, 2) <= n)
                    p = q;
                else
                    r = q;
            }

            return p;
        }


        /*
          Exercício 3
          O programa abaixo recebe um arranjo A de n números inteiros e o rearranja
          de modo que seus elementos, ao final, estejam ordenados de forma decrescente.
          Contudo, este programa possui alguns erros de lógica. Encontre-os e corrija-os.
         */
        private static int[] Ordena(int[] A)
        {
            int i, j, chave;
            for (i = 1; i < A.Length; i++)
            {
                chave = A[i];
                j = i - 1;
                while (j >= 0 && A[j] < chave)
                {
                    A[j + 1] = A[j];
                    j--;
                }

                A[j + 1] = chave;
            }

            return A;
        }


        /*
         Exercício 4
         Observe o programa abaixo e responda:
          (a) Qual é o resultado da impressão da linha 30?
          (b) busca1 é “melhor” do que busca2? Justifique sua resposta.
         */
        private static int Busca1(int[] A, int k)
        {
            for (var i = 0; i < A.Length; i++)
                if (A[i] == k) return i;

            return -1;
        }

        private static int Busca2(int[] A, int k)
        {
            int inicio = 0, fim = A.Length - 1;
            while (inicio <= fim)
            {
                var meio = (inicio + fim) / 2;
                if (A[meio] == k) return meio;
                if (A[meio] < k) inicio = meio + 1;
                else fim = meio - 1;
            }

            return -1;
        }


        /*
            Exercício 5
            Escreva um programa em C# que embaralhe um arranjo A de n inteiros.
        */
        private static int[] Shuffle(int[] A)
        {
            Random random = new();
            for (var i = 0; i < A.Length; i++)
            {
                var j = random.Next(i, A.Length);
                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
            }

            return A;
        }


        /*
            Exercício 6
            Escreva um programa em C# que encontre dois elementos de um arranjo A de n
            inteiros, distintos entre si, que somados seja igual a um determinado inteiro k.
        */
        private static (int, int)[] EncontrarDoisElementosSomaK(int[] arr, int k)
        {
            List<(int, int)> pares = [];
            HashSet<int> set = [];

            foreach (var num in arr)
            {
                var complemento = k - num;
                if (set.Contains(complemento))
                    pares.Add((num, complemento));
                set.Add(num);
            }

            return pares.ToArray();
        }


        /*
            Exercício 7
            Escreva um programa em C# que remova os elementos duplicados de um arranjo
            A de n cadeias de caracteres.
        */
        private static string[] RemoveDuplicados(string[] A)
        {
            HashSet<string> set = [];
            foreach (var t in A)
                set.Add(t);
            return set.ToArray();
        }

        /*
            Exercício 8
            Escreva um programa em C# que organize um arranjo A de n inteiros de modo
            que todos os inteiros negativos apareçam antes de todos os inteiros positivos.
        */
        private static int[] OrdemCrescente(int[] A)
        {
            for (var i = 0; i < A.Length; i++)
            {
                for (var j = i + 1; j < A.Length; j++)
                {
                    if (A[i] > A[j])
                    {
                        int temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;
                    }
                }
            }

            return A;
        }


        /*
            Exercício 9
            Escreva um programa em C# que obtenha o elemento majoritário de um arranjo
            A de n inteiros. Um elemento majoritário é um elemento que aparece mais de
            n/2 vezes.
        */
        private static int ElementoMajoritario(int[] A)
        {
            int count = 0, candidate = 0;
            foreach (var t in A)
            {
                if (count == 0)
                {
                    candidate = t;
                    count = 1;
                }
                else if (t == candidate)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            // Verifica se o candidato é realmente o elemento majoritário
            count = A.Count(t => t == candidate);

            if (count > A.Length / 2) return candidate;
            else return -1;
        }


        /*
            Exercício 10
            Escreva um programa em C# que encontre um elemento específico em um arranjo
            A de n inteiros usando a busca por interpolação.
         */
        private static int BuscaInterpolacao(int[] A, int k)
        {
            int inicio = 0, fim = A.Length - 1;
            while (inicio <= fim && k >= A[inicio] && k <= A[fim])
            {
                var posicao = inicio + (int)((double)(fim - inicio) / (A[fim] - A[inicio]) * (k - A[inicio]));
                if (A[posicao] == k) return posicao;

                if (A[posicao] < k) inicio = posicao + 1;
                else fim = posicao - 1;
            }

            return -1;
        }


        private static void PrintarArray(string[] array)
        {
            Write("[");
            for (var i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1) Write(array[i]);
                else Write(array[i] + ", ");
            }

            Write("]");
            WriteLine();
        }


        private static void Main()
        {
            /*
              Exercício 7
              Escreva um programa em C# que remova os elementos duplicados de um arranjo
              A de n cadeias de caracteres.
            */

            string[] s = ["bcd", "abd", "bcd", "fgh"];
            WriteLine("Arranjo original: ");
            PrintarArray(s);
            var res = RemoveDuplicados(s);
            WriteLine("Arranjo sem duplicados: ");
            PrintarArray(res);

            /*
               Exercício 1
               Qual o retorno deste programa para funcao([83, 41, 5, 1, 59, 97], 2)?
             */
            int[] a = [83, 41, 5, 1, 59, 97];
            ImprimirArray(a);
            const int i = 2;
            var result = Funcao(a, i);
            ImprimirArray(result);
            WriteLine();


            /*
               Exercício 2
               Qual o retorno deste programa para funcao(81)?
            */
            const int n = 81;
            WriteLine("O resultado da função para " + n + " é: " + Funcao2(n));
            WriteLine();


            /*
              Exercício 3
              O programa abaixo recebe um arranjo A de n números inteiros e o rearranja
              de modo que seus elementos, ao final, estejam ordenados de forma decrescente.
              Contudo, este programa possui alguns erros de lógica. Encontre-os e corrija-os.
             */
            WriteLine("Exercício 3");
            int[] b = [83, 41, 5, 1, 59, 97];
            ImprimirArray(b);
            var result2 = Ordena(b);
            ImprimirArray(result2);
            WriteLine();


            /*
              Exercício 4
              Observe o programa abaixo e responda:
              (a) Qual é o resultado da impressão da linha 30?
              (b) busca1 é “melhor” do que busca2? Justifique sua resposta.
             */
            int[] tamanhos =
            [
                100, 1_000, 10_000,
                100_000, 1_000_000,
                10_000_000, 100_000_000
            ];
            Random random = new();

            foreach (int tamanhoArray in tamanhos)
            {
                int valorBusca = random.Next(tamanhoArray); // Valor a ser buscado no array
                int[] array = new int[tamanhoArray];

                // Preencher o array com números de 0 até tamanhoArray - 1
                for (int f = 0; f < tamanhoArray; f++)
                    array[f] = f;

                Stopwatch stopwatch = new();

                // Medir o tempo de execução da Busca1
                stopwatch.Start();
                int indice1 = Busca1(array, valorBusca);
                stopwatch.Stop();
                WriteLine($"Tamanho do Array: {tamanhoArray}");
                WriteLine($"Busca1: Índice encontrado = {indice1}, Ticks = {stopwatch.Elapsed}");
                stopwatch.Reset();

                // Medir o tempo de execução da Busca2
                Array.Sort(array); // Ordenar o array para utilizar a busca binária
                stopwatch.Start();
                int indice2 = Busca2(array, valorBusca);
                stopwatch.Stop();
                WriteLine($"Busca2: Índice encontrado = {indice2}, Ticks = {stopwatch.Elapsed}");
                WriteLine();
            }

            WriteLine();


            /*
            Exercício 5
            Escreva um programa em C# que embaralhe um arranjo A de n inteiros.
            */
            int[] vector = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            ImprimirArray(vector);
            int[] shuffled = Shuffle(vector);
            ImprimirArray(shuffled);
            WriteLine();


            /*
            Exercício 6
            Escreva um programa em C# que encontre dois elementos de um arranjo A de n
            inteiros, distintos entre si, que somados seja igual a um determinado inteiro k.
            */
            int[] arr = [1, 4, 45, 6, 10, -8, -1];
            int k = 5;
            WriteLine("Arranjo: ");
            ImprimirArray(arr);
            var pares = EncontrarDoisElementosSomaK(arr, k);
            WriteLine("Pares que somam " + k + ": ");
            foreach (var par in pares)
                WriteLine(par);

            WriteLine();


            /*
            Exercício 8
            Escreva um programa em C# que organize um arranjo A de n inteiros de modo
            que todos os inteiros negativos apareçam antes de todos os inteiros positivos.
            */
            int[] Arrange = [1, -2, 3, -4, 5, -6, 7, -8, 9, -10];

            WriteLine("Arranjo original: ");
            ImprimirArray(Arrange);

            int[] re = OrdemCrescente(Arrange);

            WriteLine("Arranjo organizado: ");
            ImprimirArray(re);
            WriteLine();


            /*
            Exercício 9
            Escreva um programa em C# que obtenha o elemento majoritário de um arranjo
            A de n inteiros. Um elemento majoritário é um elemento que aparece mais de
            n/2 vezes.
            */
            int[] majoritario = [2, 2, 1, 1, 1, 2, 2, 1, 2, 1, 1, 2];
            ImprimirArray(majoritario);
            WriteLine("Elemento majoritário: " + ElementoMajoritario(majoritario));
            WriteLine();


            /*
            Exercício 10
            Escreva um programa em C# que encontre um elemento específico em um arranjo
            A de n inteiros usando a busca por interpolação.
            */
            WriteLine();
            int[] arrayInterpolacao = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            int valorInterpolacao = 5;
            WriteLine("Índice do valor " + valorInterpolacao + ": " +
                      BuscaInterpolacao(arrayInterpolacao, valorInterpolacao));
            WriteLine();


            /*
             * Exercício 11
             */
            Employee employee = new(1, "Vinícius", "Andrade", 1000);
            WriteLine(employee);

            WriteLine("Salário Anual:               " + employee.GetAnnualSalary());
            WriteLine("Salário mensal após aumento: " + employee.RaiseSalary(10));
            WriteLine("Salário Anual:               " + employee.GetAnnualSalary());
            WriteLine();


            /*
             * Exercício 13
             */
            Author author = new("Vinícius", "vinicius_andrade2010@hotmail.com", 'm');
            WriteLine(author);

            Book book = new("C# 9 and .NET 5", author, 100, 10);
            WriteLine(book);
            WriteLine();


            /*
             * Exercício 14
             */
            MovablePoint point = new(1, 2, 3);
            WriteLine(point);

            point.MoveUp();
            WriteLine(point);

            point.MoveDown();
            WriteLine(point);

            point.MoveLeft();
            WriteLine(point);

            point.MoveRight();
            WriteLine(point);

            MovableRectangle rectangle = new(1, 2, 3, 4, 5);
            WriteLine(rectangle);

            rectangle.MoveUp();
            WriteLine(rectangle);

            rectangle.MoveDown();
            WriteLine(rectangle);

            rectangle.MoveLeft();
            WriteLine(rectangle);

            rectangle.MoveRight();
            WriteLine(rectangle);
            WriteLine();


            /*
             * Exercício 15
             */
            Product iphone = new(1, "iPhone 12", 1000);
            Product galaxy = new(2, "Galaxy S21", 900);
            Product pixel = new(3, "Pixel 5", 800);

            Customer customer = new(1, "Vinícius", 10);
            Invoice invoice = new(1, customer);

            invoice.AddProduct(iphone, 2);
            invoice.AddProduct(galaxy, 1);
            invoice.AddProduct(pixel, 3);

            WriteLine("Total: " + invoice.GetTotal());
            WriteLine();

            WriteLine(invoice);
        }

        public static void ImprimirArray(int[] array)
        {
            Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Write(array[i].ToString());
                }
                else
                {
                    Write(array[i] + ", ");
                }
            }

            Write("]");
            WriteLine();
        }
    }
}