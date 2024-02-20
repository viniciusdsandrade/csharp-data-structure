using System;
using System.Collections.Generic;


namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(1);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Console.WriteLine("Queue elements:");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            PrintQueueElements(queue);

            Console.WriteLine("Dequeue: " + queue.Dequeue());
            Console.WriteLine("Dequeue: " + queue.Dequeue());
            Console.WriteLine("Dequeue: " + queue.Dequeue());

            Console.WriteLine("Queue elements:");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }

        static void PrintQueueElements(Queue<int> queue)
        {
            Console.Write("[");
            foreach (var item in queue)
            {
                if(item.Equals(queue.Last()))
                {
                    Console.Write(item);
                }
                else
                {
                    Console.Write(item + ", ");
                }
            }
            Console.WriteLine("]");
        }

    }
}
