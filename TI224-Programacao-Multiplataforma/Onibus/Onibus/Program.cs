using static System.Console;
using static System.Array;

namespace Onibus
{
    /*
    Uma empresa de transporte rodoviário coletivo possui
    n ônibus para atenderm passageiros que viajam de Campinas para São Paulo.

    Os passageiros esperam pelo ônibus em uma fila.
    É possível embarcar em um ônibus que parte em x minutos se você chegar em y minutos,
    tal que y ≤ x, e o ônibus não esteja lotado.

    Os passageiros embarcam no ônibus por ordem de chegada.

    Escreva um programa que receba como parâmetro de entrada um arranjo
    de inteiros buses − em que cada elemento de buses representa o horário de
    partida do i-ésimo ônibus − um arranjo de inteiros passengers − em que
    cada elemento de passengers representa o horário de chegada do k-ésimo
    passageiro − e um número inteiro capacity − que representa a lotação
    máxima de passageiros para cada ônibus − e devolva o último horário que
    você pode chegar para pegar um ônibus. Você não pode chegar no mesmo
    horário que outro passageiro.

    Exemplos
       Entrada                                      Saída
       buses = {10, 20}                             16
       passengers = {2, 17, 18, 19}
       capacity = 2

       Entrada                                          Saída
       buses = {20, 30, 10}                             20
       passengers = {19, 13, 26, 4, 25, 11, 21}
       capacity = 2
     */

    public class Program
    {
        public static void Main()
        {
            // Teste 1
            int[] buses1 = [10, 20];
            int[] passengers1 = [2, 17, 18, 19];
            const int capacity1 = 2;
            Write("Teste 1: ");
            WriteLine(LatestTimeCatchTheBus(buses1, passengers1, capacity1));

            // Teste 2
            int[] buses2 = [20, 30, 10];
            int[] passengers2 = [19, 13, 26, 4, 25, 11, 21];
            const int capacity2 = 2;
            Write("Teste 2: ");
            WriteLine(LatestTimeCatchTheBus(buses2, passengers2, capacity2));

            // Teste 3
            int[] buses3 = [25, 15, 30, 20];
            int[] passengers3 = [10, 5, 7, 28, 19, 12];
            const int capacity3 = 3;
            Write("Teste 3: ");
            WriteLine(LatestTimeCatchTheBus(buses3, passengers3, capacity3));

            // Teste 4
            int[] buses4 = [40, 50, 30];
            int[] passengers4 = [37, 28, 44, 32, 49, 51, 45, 38];
            const int capacity4 = 3;
            Write("Teste 4: ");
            WriteLine(LatestTimeCatchTheBus(buses4, passengers4, capacity4));


            // Teste 5
            int[] buses5 = [3];
            int[] passengers5 = [2, 3];
            const int capacity5 = 2;

            Write("Teste 5: ");
            WriteLine(LatestTimeCatchTheBus(buses5, passengers5, capacity5));
        }

        public static int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
        {
            var passenger = -1;
            var bus = 0;
            var currCap = 0;

            Sort(buses);
            Sort(passengers);

            while (bus < buses.Length)
            {
                currCap = 0;
                while (currCap < capacity && passenger < (passengers.Length - 1) &&
                       passengers[passenger + 1] <= buses[bus])
                {
                    currCap++;
                    passenger++;
                }

                bus++;
            }

            if (currCap < capacity && (passenger < 0 || buses[buses.Length - 1] != passengers[passenger]))
                return buses[buses.Length - 1];

            while (passenger > 0 && (passengers[passenger] - 1) == passengers[passenger - 1])
                passenger--;

            return passengers[passenger] - 1;
        }
    }
}