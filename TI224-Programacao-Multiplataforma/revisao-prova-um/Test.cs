using System;
using revisao_prova_um;
using static System.Console;

namespace revisao_prova_um
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account();

            account.MakeDeposit(1000.0);

            WriteLine(account);

            TestGetOwner(account);
            TestGetNumber(account);
            TestGetBalance(account);
        }

        static void TestGetOwner(Account account)
        {
            // Testa o método GetOwner
            var owner = account.GetOwner();
            WriteLine("Owner: " + owner);
        }

        static void TestGetNumber(Account account)
        {
            // Testa o método GetNumber
            var number = account.GetNumber();
            WriteLine("Number: " + number);
        }

        static void TestGetBalance(Account account)
        {
            // Testa o método GetBalance
            var balance = account.GetBalance();
            WriteLine("Balance: " + balance);
        }
    }
}