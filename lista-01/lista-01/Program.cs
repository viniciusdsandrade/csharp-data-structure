using static System.Console;

namespace lista01
{
    /*
       1 – Desenvolva uma calculadora, onde será necessário entrar com a operação, primeiro e segundo valor,
       exiba o resultado na tela. OBS.: Desenhe a calculadora com as suas funções. Exemplo:
       ***************************
       CALCULADORA
       1 - Somar
       2 - Subtrair
       3 - Multiplicar
       4 - Dividir
       5 - Sair
       ****************************
     */
    public static class Exercise01
    {
        public static void Run()
        {
            WriteLine("Digite a operação que deseja realizar:");
            WriteLine("1 - Somar");
            WriteLine("2 - Subtrair");
            WriteLine("3 - Multiplicar");
            WriteLine("4 - Dividir");
            WriteLine("5 - Sair");

            int option;
            int.TryParse(ReadLine(), out option);

            if (option == 5)
            {
                WriteLine("Saindo...");
                return;
            }

            WriteLine("Digite o primeiro valor:");
            double value1 = double.Parse(ReadLine());

            WriteLine("Digite o segundo valor:");
            double value2 = double.Parse(ReadLine());

            switch (option)
            {
                case 1:
                    WriteLine($"Resultado: {value1 + value2}");
                    break;
                case 2:
                    WriteLine($"Resultado: {value1 - value2}");
                    break;
                case 3:
                    WriteLine($"Resultado: {value1 * value2}");
                    break;
                case 4:
                    if (value2 == 0)
                    {
                        WriteLine("Não é possível dividir por zero.");
                        break;
                    }

                    WriteLine($"Resultado: {value1 / value2}");
                    break;
                default:
                    WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    /*
      2 – Desenvolva um algoritmo que solicite a entrada da idade de um determinado usuário,
      se for menor que 18 anos exiba na cor vermelha “Sem permissão”,
      caso seja maior ou igual a 18 anos exiba na cor verde “Permissão concedida”.
     */
    public static class Exercise02
    {
        public static void Run()
        {
            WriteLine("Digite a sua idade:");
            int age = int.Parse(ReadLine());

            if (age < 18)
            {
                ForegroundColor = System.ConsoleColor.Red;
                WriteLine("Sem permissão");
            }
            else
            {
                ForegroundColor = System.ConsoleColor.Green;
                WriteLine("Permissão concedida");
            }
        }
    }

    /*
      3 – Desenvolva uma função que receba por parâmetro o um nome,
      e retorne a frase “Olá meu nome é: {nome recebido}”.
     */
    static class Exercise03
    {
        public static void Run()
        {
            WriteLine("Digite o seu nome:");
            string name = ReadLine();
            WriteLine($"Olá meu nome é: {name}");
        }
    }

    /*
      4 – Faça um programa que leia os valores correspondentes aos três lados a, b e c de um triângulo.
      O programa então determina se o triângulo é
        isósceles,
        escaleno ou
        equilátero,
      informando isto para o usuário, e em seguida imprime a área A do triângulo utilizando a fórmula de Heron:
     */
    static class Exercise04
    {
        public static void Run()
        {
            WriteLine("Digite o valor do lado a:");
            double a = double.Parse(ReadLine());

            WriteLine("Digite o valor do lado b:");
            double b = double.Parse(ReadLine());

            WriteLine("Digite o valor do lado c:");
            double c = double.Parse(ReadLine());

            //Preciso verificar se o triângulo existe
            if (a + b < c || a + c < b || b + c < a)
            {
                WriteLine("Triângulo inexistente");
                return;
            }


            if (a == b && b == c)
            {
                WriteLine("Triângulo equilátero");
            }
            else if (a == b || b == c || a == c)
            {
                WriteLine("Triângulo isósceles");
            }
            else
            {
                WriteLine("Triângulo escaleno");
            }

            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            WriteLine($"Área do triângulo: {area}");
        }
    }

    /*
      5 – Desenvolva um algoritmo que calcule o reajuste salarial.
      Se o salário for abaixo de 1.700 o ajuste é de R$300.00, se maior de R$ 200.00.
      Para finalizar, exiba o novo salário na tela.
     */
    static class Exercise05
    {
        public static void Run()
        {
            WriteLine("Digite seu salário: ");
            double salario = double.Parse(ReadLine());

            if (salario < 1700)
            {
                salario = salario + 300;
            }
            else
            {
                salario = salario + 200;
            }

            WriteLine($"Novo salário: {salario}");
        }
    }

    public static class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Lista 01 de exercícios.");
            WriteLine("Escolha o exercício que deseja executar");
            WriteLine("1 - Exercício 01");
            WriteLine("2 - Exercício 02");
            WriteLine("3 - Exercício 03");
            WriteLine("4 - Exercício 04");
            WriteLine("5 - Exercício 05");
            WriteLine("6 - Sair");

            int option;
            int.TryParse(ReadLine(), out option);

            switch (option)
            {
                case 1:
                    Exercise01.Run();
                    break;
                case 2:
                    Exercise02.Run();
                    break;
                case 3:
                    Exercise03.Run();
                    break;
                case 4:
                    Exercise04.Run();
                    break;
                case 5:
                    Exercise05.Run();
                    break;
                case 6:
                    WriteLine("Saindo...");
                    break;
                default:
                    WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}