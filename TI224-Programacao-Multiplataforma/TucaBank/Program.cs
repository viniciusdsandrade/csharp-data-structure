using static System.Console;
using static System.DateTime;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Teste de depósito
            var account = new BankAccount.BankAccount("12345", "João Silva", 1000);
            account.MakeDeposit(500, Now, "Depósito de salário");
            if (account.Balance != 1500) WriteLine("Teste de depósito falhou!");
            else WriteLine("Teste de depósito passou!");

            // Teste de saque
            account.MakeWithdraw(200, Now, "Saque ATM");
            if (account.Balance != 1300) WriteLine("Teste de saque falhou!");

            else WriteLine("Teste de saque passou!");

            // Teste do histórico da conta
            string expectedHistory = "Depósito de salário: +500\nSaque ATM: -200\n";
            if (account.GetAccountHistory() != expectedHistory) WriteLine("Teste do histórico da conta falhou!");
            else WriteLine("Teste do histórico da conta passou!");

            WriteLine(account.GetAccountHistory());
        }
    }
}