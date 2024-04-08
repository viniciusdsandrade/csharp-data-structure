using System.Text;

namespace Programa
{
    class Program
    {
        /*
            1 - Seguindo a lógica para a conversão de base decimal para binário,implemente em C#
            
            2 - Uma pessoa endinheirada tem 7 marcas de veículos de luxo em sua garagem, a saber:
            Mercedes Benz; Jaguar; Rolls Royce ; BMW; Aston Martin; Lamborghini;
            Você deve criar um vetor que irá armazenar estes veículos na ordem que foram passados e em seguida apresentar os
            veículos em ordem alfabética(ordenação)

            3 - Em uma aplicação Console Application crie uma matriz de 4 linhas e 5 colunas . Preencha a (solicitando ao usuário os
            dados) e exiba seus valores

            4 - Em um terminal rodoviário existe uma tabela de destinos com os ônibus que chegam e saem do terminal. Esta tabela
            segue o conceito First In First Out. A tabela pode ser vista abaixo
            Crie uma aplicação (Console Application 

                • exiba esta fila;
                • conte quantos ônibus estão no terminal (fila cheia);
                • depois que o primeiro ônibus sair do terminal exiba qual é o seguinte.

            5 - Estudamos em C# o algoritmo de ordenação QuickSort (Dividir para Conquistar). É sabido que existem vários outros
            algoritmos que permitem a ordenação de um vetor; neste sentido, qual a principal diferença entre o QuickSort e o
            BubbleSort

            R: 
            QuickSort:
                O QuickSort é um algoritmo de ordenação por divisão e conquista. Ele divide o vetor em duas partes com base em um elemento pivô, 
                de modo que os elementos à esquerda do pivô são menores que o pivô e os elementos à direita do pivô são maiores que o pivô.
                Em seguida, ele ordena as duas partes do vetor de forma recursiva até que o vetor esteja completamente ordenado.
                A complexidade de tempo média do QuickSort é O(nlogn), tornando-o eficiente para grandes conjuntos de dados.

            BubbleSort:
                O BubbleSort é um algoritmo de ordenação simples que compara repetidamente pares adjacentes de elementos e os troca se estiverem na ordem errada.
                Este processo é repetido até que não sejam necessárias mais trocas, o que indica que o vetor está ordenado.
                A complexidade de tempo do BubbleSort é O(n2), o que o torna menos eficiente para grandes conjuntos de dados.

            Portanto, a principal diferença entre eles é que o QuickSort é geralmente mais rápido e eficiente para grandes conjuntos de dados, 
            enquanto o BubbleSort é mais simples, mas menos eficiente. Além disso, o QuickSort é um algoritmo de divisão e conquista, 
            enquanto o BubbleSort é um algoritmo de comparação simples.
         */
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Converter decimal para binário");
                Console.WriteLine("2. Converter binário para decimal");
                Console.WriteLine("3. Ordenar marcas de veículos de luxo");
                Console.WriteLine("4. Preencher e exibir matriz 4 x 5");
                Console.WriteLine("5. Operações de terminal rodoviário");
                Console.WriteLine("6. Sair");
                Console.Write("Opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite um número decimal: ");
                        int numero = int.Parse(Console.ReadLine());
                        string binario = DecimalParaBinarioString(numero);
                        Console.WriteLine($"Binário: {binario}");
                        break;
                    case 2:
                        Console.Write("Digite um número binário: ");
                        string binario2 = Console.ReadLine();
                        int numero2 = BinarioParaDecimal(binario2);
                        Console.WriteLine($"Decimal: {numero2}");
                        break;
                    case 3:
                        string[] marcasVeiculos = { "Mercedes Benz", "Jaguar", "Rolls Royce", "BMW", "Aston Martin", "Lamborghini" };
                        Console.WriteLine("Marcas de veículos de luxo em ordem original:");
                        ImprimirArray(marcasVeiculos);

                        Array.Sort(marcasVeiculos);
                        Console.WriteLine("\nMarcas de veículos de luxo em ordem alfabética:");
                        ImprimirArray(marcasVeiculos);
                        break;
                    case 4:
                        int[,] matriz = new int[4, 5];
                        PreencherMatriz(matriz);
                        Console.WriteLine("\nMatriz preenchida:");
                        ExibirMatriz(matriz);
                        break;
                    case 5:
                        OperacoesTerminalRodoviario();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        public static string DecimalParaBinarioString(int numero)
        {
            if (numero == 0) return "0";     

            Pilha<int> pilha = new(32); 

            while (numero > 0)
            {
                int resto = numero % 2;
                pilha.Push(resto);
                numero = numero / 2;
            }

            string resultado = "";

            while (!pilha.IsEmpty())
                resultado += pilha.Pop().ToString();

            return resultado;
        }

        public static int BinarioParaDecimal(string binario)
        {
            if(binario == null) return 0;

            if(binario.Length == 0)
                throw new ArgumentException("O binário não pode ser vazio.");

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                    throw new ArgumentException("O binário deve conter apenas 0s e 1s.");
            }

            int numero = 0;
            int potencia = 0;

            for (int i = binario.Length - 1; i >= 0; i--)
            {
                int digito = int.Parse(binario[i].ToString());
                numero += digito * (int)Math.Pow(2, potencia);
                potencia++;
            }

            return numero;
        }

        public static void ImprimirArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public static void PreencherMatriz(int[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"Digite o valor para a posição [{i},{j}]: ");
                    matriz[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public static void ExibirMatriz(int[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j]);
                    if (j != matriz.GetLength(1) - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(" ]");
            }
        }

        public static void OperacoesTerminalRodoviario()
        {
            Queue<string> terminalRodoviario = new Queue<string>();
            terminalRodoviario.Enqueue("Ônibus 1");
            terminalRodoviario.Enqueue("Ônibus 2");
            terminalRodoviario.Enqueue("Ônibus 3");

            Console.WriteLine("\nÔnibus no terminal rodoviário:");
            foreach (var onibus in terminalRodoviario)
                Console.WriteLine(onibus);

            Console.WriteLine($"\nTotal de ônibus no terminal: {terminalRodoviario.Count}");

            Console.WriteLine("\nPróximo ônibus a sair:");
            Console.WriteLine(terminalRodoviario.Dequeue());
        }
    }

    public class Pilha<X> : ICloneable
    {
        private readonly X[] elemento;
        private int tamanho;
        private readonly int capacidade;

        public Pilha()
        {
            elemento = new X[100];
            capacidade = 100;
            tamanho = 0;
        }

        public Pilha(int capacidade)
        {
            if (capacidade <= 0) 
                throw new ArgumentException("Capacidade inválida. A capacidade deve ser maior que zero.");
            
            this.elemento = new X[capacidade];
            this.capacidade = capacidade;
            this.tamanho = 0;
        }

        public int GetCapacidade() => capacidade;
        public int GetTamanho() => tamanho;

        public X[] GetArray() => elemento;

        public void Push(X item)
        {
            if (IsFull())
                throw new InvalidOperationException("A pilha está cheia. Não é possível adicionar mais elementos.");

            elemento[tamanho] = item;
            tamanho++;
        }

        public X Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("A pilha está vazia. Não é possível fazer pop.");

            X item = elemento[tamanho - 1];
            tamanho--;
            return item;
        }

        public X Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("A pilha está vazia. Não há nenhum elemento no topo.");

            return elemento[tamanho - 1];
        }

        public int Count => elemento.Length;

        public X PeekLast() => elemento[tamanho - 1];

        public int Search(X item)
        {
            for (int i = 0; i < tamanho; i++)
            {
                if (elemento[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < tamanho; i++)
            {
                if (elemento[i].Equals(item))
                    return true;
            }

            return false;
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < tamanho; i++)
            {
                if (elemento[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public int LastIndexOf(X item)
        {
            for (int i = tamanho - 1; i >= 0; i--)
            {
                if (elemento[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public int FirstIndexOf(X item)
        {
            for (int i = 0; i < tamanho; i++)
            {
                if (elemento[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public bool IsEmpty() => tamanho == 0;

        public bool IsFull() => tamanho == capacidade;

        public int Size() => tamanho;

        public void Clear()
        {
            while (!IsEmpty())
                Pop();

            tamanho = 0;
        }

        public X[] ToArray()
        {
            X[] novoArray = new X[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                novoArray[i] = elemento[i];
            }

            return novoArray;
        }

        public string ToArrayString()
        {
            if (IsEmpty())
                return "[]";

            StringBuilder sb = new();
            sb.Append('[');

            for (int i = 0; i < tamanho - 1; i++)
            {
                sb.Append(elemento[i]);
                sb.Append(", ");
            }

            sb.Append(elemento[tamanho - 1]);
            sb.Append(']');

            return sb.ToString();
        }

        public List<X> ToList()
        {
            List<X> lista = [];

            for (int i = 0; i < tamanho; i++)
                lista.Add(elemento[i]);

            return lista;
        }

        public Pilha(Pilha<X> modelo)
        {
            if(modelo == null) throw new ArgumentException("Modelo não pode ser nulo.");

            this.capacidade = modelo.capacidade;
            this.elemento = new X[capacidade];

            for (int i = 0; i < modelo.tamanho; i++)
                this.elemento[i] = modelo.elemento[i];

            this.tamanho = modelo.tamanho;
        }

        public object Clone()
        {
            Pilha<X>? clone = null;
            try {
                clone = new Pilha<X>(this);
            }
            catch (Exception) {
             // Ignorar exceção
            }
            return clone;
        }

        public override bool Equals(object? obj)
        {
            if(this == obj) return true;
            if (obj == null) return false;
            if(this.GetType() != obj.GetType()) return false;

            Pilha<X> other = (Pilha<X>)obj;

            if (tamanho != other.tamanho) return false;
            if (capacidade != other.capacidade) return false;

            for (int i = 0; i < tamanho; i++)
            {
                if (!elemento[i].Equals(other.elemento[i]))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 1;

            hash *= prime + tamanho;
            hash *= prime + capacidade;

            for (int i = 0; i < tamanho; i++)
                hash *= prime + elemento[i].GetHashCode();
            

            if (hash < 0) hash = -hash;

            return hash;
        }

        public override string ToString()
        {
            if (IsEmpty()) return "[]";
            else return "[" + Peek().ToString() + "]";
        }      
    }
}
 