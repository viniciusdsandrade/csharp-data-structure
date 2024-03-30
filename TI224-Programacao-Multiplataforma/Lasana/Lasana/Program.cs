using static System.Console;
using System;

// ReSharper disable All

namespace ProgramacaoMultiplataforma
{
    /*
      Cada um dos operadores booleanos tem uma procedência de operador diferente. Como consequencia,
      eles são aninhados nesta ordem: !(NOT), &&(AND), ^(XOR)  e por ultimo ||(OR).
      Se quiser "escapar" dessas regras, você pode colocar uma expressão booleana entre parênteses, pois
      os parenteses têm uma precedência de operador ainda maior.
     */
    public class Lasana
    {
        public Lasana()
        {
        }

        public static int ExpectedMinutesInOven() => 40;

        public static int RemainingTimeInMinutes(int actualMinutesInOven)
        {
            if (actualMinutesInOven >= ExpectedMinutesInOven())
            {
                return 0;
            }

            return ExpectedMinutesInOven() - actualMinutesInOven;
        }

        public static int PreparationTimeInMinutes(int layers)
            => layers * 2;

        public static int TotalTimeInMinutes(int layers, int actualMinutesInOven)
        {
            if (!isLayerValid(layers))
            {
                throw new ArgumentException("Número de camadas inválido");
            }

            return PreparationTimeInMinutes(layers) + RemainingTimeInMinutes(actualMinutesInOven);
        }

        public static bool IsLasanaReady(int actualMinutesInOven)
            => actualMinutesInOven >= ExpectedMinutesInOven();

        public static bool isLayerValid(int layer) => layer > 0;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            Lembrando que String são objetos imutáveis, ou seja, uma vez que você cria uma string, ela não pode ser alterada.
             */

            string fruta = "banana";
            String fruit = "banana";
            WriteLine(fruta);
            WriteLine(fruit);

            String texto = "Hoje é sexta-feira";
            WriteLine(texto);
            String dia = texto.Substring(7, 11);
            String diaComReplace = texto.Replace("é", "foi");
            WriteLine(dia);
            WriteLine(texto);
            WriteLine(diaComReplace);

            /*
            O método IndexOf() pode ser usado para encontrar o indice da primeira ocorrência de
            string em uma string retornando -1 se o valor espeficiado não for encontrado
             */

            var cotuca = "Eu amo o Cotuca";
            int indice = cotuca.IndexOf("amo");
            WriteLine("Eu amo o Cotuca: " + indice);

            String concat = String.Concat("Aqui estou usando o concat: ", dia, texto, diaComReplace);
            WriteLine(concat);

            Write("Digite o numero de camadas da Lasanha: ");
            var layers = int.Parse(ReadLine());

            Write("Digite o tempo que a lasanha ficou no forno: ");
            var actualMinutesInOven = int.Parse(ReadLine());

            WriteLine("Tempo total: " + Lasana.TotalTimeInMinutes(layers, actualMinutesInOven));
        }
    }
}