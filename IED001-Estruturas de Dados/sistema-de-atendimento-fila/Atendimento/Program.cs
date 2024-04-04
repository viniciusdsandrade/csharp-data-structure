/*
 Crie um sistema de senha de atendimento. 
 O sistema deve considerar: 

A) Atendimento normal (Inserir um novo elemento, quando ocorrer atendimento, remoção do elemento na fila); 
B) Atendimento prioritário (uma identificação no atendimento para diferenciar do atendimento normal) 

Uma sugestão de menu: 

1-Gerar nova senha 
2-Efetuar atendimento 
3-Gerar atendimento prioritário 
4-Efetuar atendimento prioritário 
5-Exibir a fila atualmente 
6-Limpar a Fila 
7-Sair

Criar, preferencialmente, no windows forms. Caso tenham alguma dificuldade, pode entregar via "console".
Trabalho para ser realizado em dupla ou individual.

O que entregar: O código fonte e um "print" da tela de resultado do menu.
*/

using System;
using System.Collections.Generic;
using static System.Console;
using static System.Convert;

namespace Atendimento
{
    public class Program
    {
        private static Queue<string> filaNormal = new();
        private static Queue<string> filaPrioritaria = new();
        private static int senha = 0;

        public static void Main(string[] args)
        {
            int opcao;
            do
            {
                WriteLine("\n1-Gerar atendimento");
                WriteLine("2-Gerar atendimento prioritário");
                WriteLine("3-Efetuar atendimento");
                WriteLine("4-Efetuar atendimento prioritário");
                WriteLine("5-Exibir a fila atualmente");
                WriteLine("6-Limpar a Fila");
                WriteLine("7-Sair");
                Write("Escolha uma opção: ");
                opcao = ToInt32(ReadLine());

                switch (opcao)
                {
                    case 1:
                        GerarNovaSenha();
                        break;
                    case 2:
                        GerarAtendimentoPrioritario();
                        break;
                    case 3:
                        EfetuarAtendimento();
                        break;
                    case 4:
                        EfetuarAtendimentoPrioritario();
                        break;
                    case 5:
                        ExibirFila();
                        break;
                    case 6:
                        LimparFila();
                        break;
                    case 7:
                        WriteLine("Saindo...");
                        break;
                    default:
                        WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 7);
        }
        private static void GerarNovaSenha()
        {
            senha++;
            filaNormal.Enqueue("N" + senha);
            WriteLine("Senha gerada: N" + senha);
        }

        private static void EfetuarAtendimento()
        {
            if (filaNormal.Count > 0)
            {
                WriteLine("Atendimento: " + filaNormal.Dequeue());
            }
            else
            {
                WriteLine("Nenhum atendimento normal na fila.");
            }
        }

        private static void GerarAtendimentoPrioritario()
        {
            senha++;
            filaPrioritaria.Enqueue("P" + senha);
            WriteLine("Senha gerada: P" + senha);
        }

        private static void EfetuarAtendimentoPrioritario()
        {
            if (filaPrioritaria.Count > 0)
            {
                WriteLine("Atendimento: " + filaPrioritaria.Dequeue());
            }
            else if (filaNormal.Count > 0)
            {
                WriteLine("Atendimento: " + filaNormal.Dequeue());
            }
            else
            {
                WriteLine("Nenhum atendimento disponível.");
            }
        }

        private static void ExibirFila()
        {
            Write("\nFila Normal: [");
            Write(string.Join(", ", filaNormal));
            WriteLine("]");

            Write("\nFila Prioritária: [");
            Write(string.Join(", ", filaPrioritaria));
            WriteLine("]");
        }

        private static void LimparFila()
        {
            filaNormal.Clear();
            filaPrioritaria.Clear();
            WriteLine("Filas limpas.");
        }
    }
}
