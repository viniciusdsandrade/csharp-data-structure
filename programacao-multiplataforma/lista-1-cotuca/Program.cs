using System.Diagnostics;
using static System.Console;
using static System.Math;


namespace Program
{
    static class Program
    {
        /*
         * Exercício 1
         * Qual o retorno deste programa para funcao([83, 41, 5, 1, 59, 97], 2)?
         */
        public static int[] Funcao(int[] A, int i)
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
        public static int Funcao2(int n)
        {
            int p = 1, r = n;
            while (p + 1 < r)
            {
                int q = (p + r) / 2;
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
        public static int[] Ordena(int[] A)
        {
            int i, j, chave;
            for (i = 1; i < A.Length; i++)
            {
                chave = A[i];
                j = i - 1;
                while (j >= 0 && A[j] > chave)
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
          ( a ) Qual é o resultado da impressão da linha 30?
          ( b ) busca1 é “melhor” do que busca2? Justifique sua resposta.
         */
        public static int Busca1(int[] A, int k)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == k)
                {
                    return i;
                }
            }
            return -1;
        }

        private static int Busca2(int[] A, int k)
        {
            int inicio = 0, fim = A.Length - 1;
            while (inicio <= fim)
            {
                int meio = (inicio + fim) / 2;
                if (A[meio] == k)
                {
                    return meio;
                }
                else if (A[meio] < k)
                {
                    inicio = meio + 1;
                }
                else
                {
                    fim = meio - 1;
                }
            }

            return -1;
        }
        /*
            Exercício 5
            Escreva um programa em C# que embaralhe um arranjo A de n inteiros.
        */

        public static int[] Shuffle(int[] A)
        {
            Random random = new();
            for (int i = 0; i < A.Length; i++)
            {
                int j = random.Next(i, A.Length);
                (A[j], A[i]) = (A[i], A[j]);
            }
            return A;
        }
        /*
            Exercício 6
            Escreva um programa em C# que encontre dois elementos de um arranjo A de n
            inteiros, distintos entre si, que somados seja igual a um determinado inteiro k.
        */

        public static int[] EncontrarElementos(int[] A, int k)
        {
            int[] resultado = new int[2];
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (A[i] + A[j] == k)
                    {
                        resultado[0] = A[i];
                        resultado[1] = A[j];
                        return resultado;
                    }
                }
            }
            return resultado;
        }

        /*
            Exercício 7
            Escreva um programa em C# que remova os elementos duplicados de um arranjo
            A de n cadeias de caracteres.
        */

        public static string[] RemoveDuplicados(string[] A)
        {
            List<string> lista = [];
            foreach (string elemento in A)
            {
                if (!lista.Contains(elemento))
                {
                    lista.Add(elemento);
                }
            }
            return [.. lista];
        }

        /*
            Exercício 8
            Escreva um programa em C# que organize um arranjo A de n inteiros de modo
            que todos os inteiros negativos apareçam antes de todos os inteiros positivos.
        */

        public static int[] Organiza(int[] A)
        {
            int i = 0, j = A.Length - 1;
            while (i < j)
            {
                if (A[i] < 0)
                {
                    i++;
                }
                else if (A[j] >= 0)
                {
                    j--;
                }
                else
                {
                    (A[j], A[i]) = (A[i], A[j]);
                    i++;
                    j--;
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

        public static int ElementoMajoritario(int[] A)
        {
            Dictionary<int, int> dicionario = [];
            foreach (int elemento in A)
            {
                if (dicionario.TryGetValue(elemento, out int value))
                {
                    dicionario[elemento] = ++value;
                }
                else
                {
                    dicionario[elemento] = 1;
                }
            }
            foreach (KeyValuePair<int, int> par in dicionario)
            {
                if (par.Value > A.Length / 2)
                {
                    return par.Key;
                }
            }
            return -1;
        }

        /*
            Exercício 10
            Escreva um programa em C# que encontre um elemento específico em um arranjo
            A de n inteiros usando a busca por interpolação.
         */

        public static int BuscaInterpolacao(int[] A, int k)
        {
            int inicio = 0, fim = A.Length - 1;
            while (inicio <= fim && k >= A[inicio] && k <= A[fim])
            {
                int posicao = inicio + (int)((double)(fim - inicio) / (A[fim] - A[inicio]) * (k - A[inicio]));
                if (A[posicao] == k)
                {
                    return posicao;
                }
                if (A[posicao] < k)
                {
                    inicio = posicao + 1;
                }
                else
                {
                    fim = posicao - 1;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int[] A = [83, 41, 5, 1, 59, 97];
            int i = 2;
            int[] result = Funcao(A, i);
            ImprimirArray(result);

            WriteLine(Funcao2(25));
            WriteLine(Funcao2(49));
            WriteLine(Funcao2(64));
            WriteLine(Funcao2(81));
            WriteLine(Funcao2(100));


            int[] B = [83, 41, 5, 1, 59, 97];
            int[] result2 = Ordena(B);
            ImprimirArray(result2);


            int[] C = [1, 3, 5, 7, 9, 11, 13, 15, 17, 19];
            int valor2, valor1;
            Stopwatch stopwatch = new();

            // Teste para Busca1
            stopwatch.Start();
            valor1 = Busca1(C, 13);
            stopwatch.Stop();
            long tempoBusca1 = stopwatch.ElapsedTicks;
            int ciclosBusca1 = ContarCiclos(C, 13);

            // Teste para Busca2
            stopwatch.Reset();
            stopwatch.Start();
            valor2 = Busca2(C, 13);
            stopwatch.Stop();
            long tempoBusca2 = stopwatch.ElapsedTicks;
            int ciclosBusca2 = ContarCiclos(C, 13);

            WriteLine("Resultado Busca1: " + valor1 + ", Tempo: " + tempoBusca1 + " ticks, Ciclos: " + ciclosBusca1);
            WriteLine("Resultado Busca2: " + valor2 + ", Tempo: " + tempoBusca2 + " ticks, Ciclos: " + ciclosBusca2);
        }

        private static int ContarCiclos(int[] A, int k)
        {
            int ciclos = 0;
            for (int i = 0; i < A.Length; i++)
            {
                ciclos++;
                if (A[i] == k)
                {
                    return ciclos;
                }
            }
            return ciclos;
        }

        public static void ImprimirArray(int[] array)
        {
            Write("[ ");
            foreach (int elemento in array)
            {
                Write(elemento + " ");
            }
            Write("]");
            WriteLine();
        }
    }
}
