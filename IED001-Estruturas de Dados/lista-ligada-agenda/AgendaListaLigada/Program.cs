using System.Text;
using System.Text.RegularExpressions;
using static System.Console;


namespace Program
{
    public class Contato
    {
        private string nome;
        private string telefone;

        public Contato()
        {
            this.nome = "";
            this.telefone = "";
        }

        public Contato(string nome, string telefone)
        {
            this.nome = nome;
            this.telefone = telefone;
        }

        public string GetNome() => nome;
        public string GetTelefone() => telefone;

        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido");

            this.nome = nome;
        }

        public void SetTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                throw new ArgumentException("Telefone inválido");

            this.telefone = telefone;
        }
    }

    public static class Program
    {
        /*
         * Desenvolva uma programa para agendar o nome e telefone de seus amigos.
         * Considere o nome e o telefone como sendo String. Utilize as propriedades da lista encadeada para
         * adicionar os nomes considerando ordem alfabética.
         */

        private static string NormalizeNome(string nome)
        {
            string s = nome.Normalize(NormalizationForm.FormD);
            return Regex.Replace(s, @"\p{M}", "").ToLower();
        }

        public static void Adicionar(LinkedList<Contato> agenda)
        {
            WriteLine("Digite o nome: ");
            string nome = ReadLine();

            WriteLine("Digite o telefone: ");
            string telefone = ReadLine();

            Contato contato = new Contato(nome, telefone);

            // Agora a gente quer colocar esse contato na LinkedList em ordem Alfabética com base no Nome
            // Se a lista estiver vazia, a gente adiciona o contato

            if (agenda.Count == 0)
            {
                agenda.AddLast(contato);
            }
            else
            {
                // Se a lista não estiver vazia, a gente precisa percorrer a lista para encontrar a posição correta
                LinkedListNode<Contato> atual = agenda.First;

                while (atual != null)
                {
                    if (string.Compare(contato.GetNome(), atual.Value.GetNome()) < 0)
                    {
                        WriteLine("Contato Inserido com sucesso");
                        agenda.AddBefore(atual, contato);
                        return;
                    }

                    atual = atual.Next;
                }

                agenda.AddLast(contato);
            }
        }

        public static void Listar(LinkedList<Contato> agenda)
        {
            foreach (Contato contato in agenda)
                WriteLine($"Nome: {contato.GetNome()} - Telefone: {contato.GetTelefone()}");
        }

        // Normaliza nome retirando Acentos e Variações de maiusculo e minusculo



        public static void Main()
        {
            LinkedList<Contato> agendaContatos = [];

            do
            {
                WriteLine("1 - Adicionar");
                WriteLine("2 - Listar");
                WriteLine("5 - Sair");
                WriteLine("Digite a opção desejada: ");
                int opcao = int.Parse(ReadLine());

                switch (opcao)
                {
                    case 1:
                        Adicionar(agendaContatos);
                        break;
                
                    case 2:
                        Listar(agendaContatos);
                        break;
                    default:
                        WriteLine("Opção inválida");
                        break;
                }
            } while (true);
        }
    }
}