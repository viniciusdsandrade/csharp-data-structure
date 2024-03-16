int a = 2100000000;
int b = 2100000000;
long c = (long)a + b;
long d = a + (long)b;

float e = 51000000000000000000000000000000000000f;
float f = 51000000000000000000000000000000000000f;
double g = (double)e + f *
    1000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000.0;

Console.WriteLine("{0} + {1} = {2}", a, b, c);
Console.WriteLine("{0} + {1} = {2}", a, b, d);
Console.WriteLine($"{a} + {b} = {c}");
Console.WriteLine($"{e} + {f} = {g}");
Console.WriteLine("{0} + {1} = {2}", e, f, g);

/*
 * tupla = Uma tupla é uma estrutura de dados que organiza os dados,
 * mantendo dois ou mais campoas de qualquer tipo,
 * Normalmente uma tupla é criada colocando-se duas ou mais expressões separadas por vírgula
 * ,dentro de um conjunto de parenteses.
 */

// Criando uma tupla de números inteiros
var numeros = (1, 2, 3, 4, 5);

// Acessando os elementos da tupla
Console.WriteLine($"Primeiro número: {numeros.Item1}");
Console.WriteLine($"Segundo número: {numeros.Item2}");
Console.WriteLine($"Terceiro número: {numeros.Item3}");
Console.WriteLine($"Quarto número: {numeros.Item4}");
Console.WriteLine($"Quinto número: {numeros.Item5}");

var vertices = (a, b, c);

(bool, int) GetSameOrBigger(int a, int b)
{
    return (a == b, a > b ? a : b);
}

var result = GetSameOrBigger(10, 3);
Console.WriteLine(result);

var result2 = GetSameOrBigger(20, 10);
Console.WriteLine(result2);

int Add((int, int) numbers)
{
    return numbers.Item1 + numbers.Item2;
}

Console.WriteLine(Add((10, 20)));

(bool sucess, string menssage) result_1 = (true, "Operação realizada com sucesso");

bool mySucess = result_1.sucess;
string myMessage = result_1.menssage;
Console.WriteLine($"{mySucess}, {myMessage}");

var result_2 = (sucess: true, menssage: "Operação realizada com sucesso");
Console.WriteLine(result_2);

Console.Write("Digite o número do mês (1-12): ");
int mesDoAno = Convert.ToInt32(Console.ReadLine());

string nomeDoMes;

switch (mesDoAno)
{
    case 1:
        nomeDoMes = "Janeiro";
        break;
    case 2:
        nomeDoMes = "Fevereiro";
        break;
    case 3:
        nomeDoMes = "Março";
        break;
    case 4:
        nomeDoMes = "Abril";
        break;
    case 5:
        nomeDoMes = "Maio";
        break;
    case 6:
        nomeDoMes = "Junho";
        break;
    case 7:
        nomeDoMes = "Julho";
        break;
    case 8:
        nomeDoMes = "Agosto";
        break;
    case 9:
        nomeDoMes = "Setembro";
        break;
    case 10:
        nomeDoMes = "Outubro";
        break;
    case 11:
        nomeDoMes = "Novembro";
        break;
    case 12:
        nomeDoMes = "Dezembro";
        break;
    default:
        nomeDoMes = "Mês inválido";
        break;
}

Console.WriteLine("O mês correspondente é: " + nomeDoMes);

int counter = 0;
while (counter < 10)
{
    Console.WriteLine($"Contador: {counter}");
    counter++;
}

Console.WriteLine();
counter = 0;
do
{
    Console.WriteLine($"Contador: {counter}");
    counter++;
} while (counter < 10);

Console.WriteLine();
counter = 0;
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Contador: {counter}");
}

Console.WriteLine();
int[] array2 = [1, 2, 3, 4, 5];
Console.WriteLine(array2);


Console.WriteLine();
int[,] array3 =
{
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};

Console.WriteLine(array3);
Console.WriteLine();
int[,] array4 = null;
for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        array4[i, j] = i;
    }
}


Console.WriteLine();

List<int> list = [1, 2, 3, 4];
List<int> list_1 = new List<int>
{
    1, 2, 3, 4
};

Console.WriteLine(list);
Console.WriteLine(list_1);

List<string> names = ["Vinícius", "Dos", "Santos", "Andrade"];
Console.WriteLine(names);

foreach (var name in names)
{
    Console.WriteLine($"{name}");
    Console.WriteLine($"{names.Count}");
}