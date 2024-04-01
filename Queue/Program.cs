using DataStructure;
using System;
using static System.Console;

namespace Program
{
    static class Program
    {
        static void Main(string[] args)
        {
           DataStructure.Queue<int> queue = new();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            WriteLine(queue);
            WriteLine(queue.Dequeue());
            WriteLine(queue.Dequeue());
            WriteLine(queue.Dequeue());
            WriteLine(queue);
        }
    }
}
