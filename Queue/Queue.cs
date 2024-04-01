using System;
using System.Text;

namespace DataStructure
{
    public class Queue<X>
    {
        private X[] data;
        private int size;
        private int capacity;

        public Queue()
        {      
            size = 0;
            capacity = 100;
            data = new X[capacity];
        }

        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new InvalidOperationException("Capacity must be greater than 0");
            }

            size = 0;
            this.capacity = capacity;
            data = new X[capacity];
        }

        public void Enqueue(X item)
        {
            if (size == capacity)
            {
                throw new InvalidOperationException("Queue is full");
            }

            data[size] = item;
            size++;
        }

        public X Dequeue()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            X item = data[0];
            for (int i = 0; i < size - 1; i++)
            {
                data[i] = data[i + 1];
            }
            size--;
            return item;
        }


        public X Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return data[0];
        }

        public void Clear()
        {
            for (int i = 0; i < size; i++)
            {
                data[i] = default(X);
            }
            size = 0;
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == capacity;
        }

        public int FreeSpace()
        {
            return capacity - size;
        }







        public override string ToString()
        {
            StringBuilder result = new('[');
            for (int i = 0; i < size; i++)
            {
                if (i > 0)
                {
                    result.Append(", ");
                }
                result.Append(data[i]);
            }
            result.Append(']');
            return result.ToString();
        }
    }
}
