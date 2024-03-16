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
            var capacity1 = 2;
            Write("Teste 1: ");
            WriteLine(LastTimeToCatchBus(buses1, passengers1, capacity1));

            // Teste 2
            int[] buses2 = [20, 30, 10];
            int[] passengers2 = [19, 13, 26, 4, 25, 11, 21];
            var capacity2 = 2;
            Write("Teste 2: ");
            WriteLine(LastTimeToCatchBus(buses2, passengers2, capacity2));

            // Teste 3
            int[] buses3 = [25, 15, 30, 20];
            int[] passengers3 = [10, 5, 7, 28, 19, 12];
            var capacity3 = 3;
            Write("Teste 3: ");
            WriteLine(LastTimeToCatchBus(buses3, passengers3, capacity3));

            // Teste 4
            int[] buses4 = [40, 50, 30];
            int[] passengers4 = [37, 28, 44, 32, 49, 51, 45, 38];
            var capacity4 = 3;
            Write("Teste 4: ");
            WriteLine(LastTimeToCatchBus(buses4, passengers4, capacity4));
        }

        private static int LastTimeToCatchBus(int[] buses, int[] passengers, int capacity)
        {
            Sort(passengers); // Ordena os passageiros por ordem de chegada;
            Sort(buses); // Ordena os ônibus por ordem de partida;

            // Se a capacidade for menor que 0, ou não houver ônibus ou passageiros, retorna -1.
            if (capacity < 0 || buses.Length < 1 || passengers.Length < 1)
                return -1;


            // Se o primeiro passageiro chegar depois do último ônibus, ele perde o ônibus.
            if (passengers[0] > buses[buses.Length - 1])
                return buses
                    [buses.Length - 1];

            var answer = -1;
            var i = 0;
            var j = 0;

            // Enquanto houver ônibus
            while (i < buses.Length)
            {
                var arrived = 0;

                //enquanto a capacidade de um ônibus não for atingida,
                //houver passageiros e
                //o passageiro chegar antes ou no horário do ônibus
                while (arrived < capacity && j < passengers.Length && passengers[j] <= buses[i])
                {
                    if (j > 0 && passengers[j] != passengers[j - 1] + 1)
                    {
                        answer = passengers[j] - 1;
                    }

                    j++;
                    arrived++;


                    if (arrived < capacity && j > i && passengers[j - 1] == buses[i])
                    {
                        answer = buses[i];
                    }
                }

                i++;
            }

            return answer == -1 ? buses[buses.Length - 1] : answer;
        }
    }
}