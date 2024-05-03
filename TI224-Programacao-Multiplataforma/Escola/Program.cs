using Escola;
using static System.Console;

namespace Escola
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Person p1 = new("Vinícius dos Santos Andrade", "Rua Orlando de Oliveira, 375");
            WriteLine(p1);

            Student s1 = new("Vinícius dos Santos Andrade", "Rua Orlando de Oliveira, 375");
            WriteLine(s1);

            HourlyTeacher ht1 = new("Vinícius dos Santos Andrade", "Rua Orlando de Oliveira, 375", 50.0, 40);
            WriteLine(ht1);

            SalaryTeacher st1 = new("Vinícius dos Santos Andrade", "Rua Orlando de Oliveira, 375", 2000.0);
            WriteLine(st1);

            WriteLine(p1.Equals(s1));
            WriteLine(p1.Equals(ht1));
            WriteLine(p1.Equals(st1));
        }
    }
}