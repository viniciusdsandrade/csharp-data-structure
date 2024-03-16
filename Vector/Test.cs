using System.Text;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1 - Faça um programa que leia um vetor com quinze posições para números inteiros.
             * Depois da leitura, divida todos os seus elementos pelo maior valor do vetor.
             * Mostre o vetor após os cálculos.
             *
             * 2 - Faça um programa que receba 10 números inteiros digitados pelo usuário.
             * Crie um segundo vetor que irá calcular o dobro do valor de cada posição digitada.
             * Em seguida exiba os dois valores
             */

            var inteiros = new Vector<int>(15);


            for (int i = 0; i < inteiros.array.Length; i++)
            {
                Console.Write($"inteiro[{i}]: ");
                inteiros.array[i] = int.Parse(Console.ReadLine());
            }

            //Como eu faço para acessar a primeira posição do vetor e pegar o maior valor?
            var maior = inteiros.array[0];

            for (int i = 0; i < inteiros.array.Length; i++)
            {
                if (inteiros.array[i] > maior)
                {
                    maior = inteiros.array[i];
                }
            }

            Console.WriteLine($"Maior valor: {maior}");

            var valorDividido = new float[inteiros.GetSize()];
            for (var i = 0; i < inteiros.array.Length; i++)
            {
                valorDividido[i] = inteiros.Get(i);
                valorDividido[i] /= maior;
            }

            void ImprimirValores(float[] vetor)
            {
                Console.Write("[");
                for (var i = 0; i < vetor.Length; i++)
                {
                    if (i < vetor.Length - 1)
                    {
                        Console.Write("{0:F1}, ",
                            vetor[i]); // Se não for o último elemento, imprima com uma vírgula e um espaço depois
                    }

                    else
                    {
                        Console.Write("{0:F1}",
                            vetor[i]); // Se for o último elemento, imprima sem a vírgula e o espaço depois
                    }
                }

                Console.WriteLine("]");
            }

            Console.WriteLine("Inteiro " + inteiros);
            ImprimirValores(valorDividido);

            var inteiros2 = new Vector<int>(10);

            for (var i = 0; i < inteiros2.array.Length; i++)
            {
                Console.Write($"inteiro2[{i}]: ");
                inteiros2.array[i] = int.Parse(Console.ReadLine());
            }

            var dobreInteiros2 = new Vector<int>(inteiros2);

            for (var i = 0; i < dobreInteiros2.array.Length; i++)
            {
                dobreInteiros2.array[i] = inteiros2.Get(i) * 2;
            }

            Console.WriteLine("Inteiros2       : " + inteiros2);
            Console.WriteLine("Inteiros2 Dobro : " + dobreInteiros2);
        }
    }
}