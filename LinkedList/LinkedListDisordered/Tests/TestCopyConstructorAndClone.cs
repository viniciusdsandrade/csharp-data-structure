using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using LinkedList;
using static System.Console;
using static System.Object;


namespace TestCopyConstructorAndClone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criando uma lista encadeada desordenada para teste
            LinkedListDisordered<int> list1 = new LinkedListDisordered<int>();
            list1.add(1);
            list1.add(2);
            list1.add(3);

            // Testando o método Clone
            LinkedListDisordered<int> clonedList = (LinkedListDisordered<int>)list1.Clone();

            // Adicionando mais um elemento à lista original para verificar se a cópia é independente
            list1.add(4);

            // Imprimindo os elementos das listas original e clonada para verificar a cópia
            WriteLine("Original List: " + list1);


            WriteLine("Cloned List: " + clonedList);


            ReadLine();
        }
    }
}