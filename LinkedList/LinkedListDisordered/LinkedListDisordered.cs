using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using static System.Console;
using static System.Object;
using static LinkedListDisordered.ShallowOrDeepCopy;

namespace LinkedListDisordered
{
    public class LinkedListDisordered<X> : ICloneable
    {
        public class Node : ICloneable
        {
            public X data;
            public Node next;

            public Node(X data)
            {
                this.data = data;
                this.next = null;
            }

            public Node(X data, Node next)
            {
                this.data = data;
                this.next = next;
            }

            public X GetData()
            {
                return data;
            }

            public void SetData(X data)
            {
                this.data = data;
            }

            public Node GetNext()
            {
                return next;
            }

            public void SetNext(Node next)
            {
                this.next = next;
            }

            public Node(Node other)
            {
                this.data = other.data;
                this.next = other.next;
            }

            public object Clone()
            {
                Node clone = null;

                try
                {
                    clone = new Node(this);
                }
                catch (Exception)
                {
                    //Exceção nunca vai ser lançada
                }

                return clone;
            }

            public override int GetHashCode()
            {
                int prime = 31;
                int hash = 1;

                hash *= prime + (this.data == null ? 0 : this.data.GetHashCode());
                hash *= prime + (this.next == null ? 0 : this.next.GetHashCode());

                if (hash < 0)
                {
                    hash *= -1;
                }

                return hash;
            }

            public override bool Equals(object? obj)
            {
                if (this == obj)
                {
                    return true;
                }

                if (obj == null)
                {
                    return false;
                }

                if (this.GetType() != obj.GetType())
                {
                    return false;
                }

                Node other = (Node)obj;

                return Equals(this.data, other.data);
            }


            public override string ToString()
            {
                if (this.data != null)
                {
                    return "Node{data=" + this.data + ", next=" + this.next + "}";
                }
                else
                {
                    return "Node{data=" + this.data + ", next=null}";
                }
            }
        }

        private Node head;
        private int size;


        public Node GetHead()
        {
            return head;
        }

        public void SetHead(Node head)
        {
            this.head = head;
        }

        public int GetSize()
        {
            return size;
        }

        public void SetSize(int size)
        {
            this.size = size;
        }

        public LinkedListDisordered()
        {
            this.head = null;
            this.size = 0;
        }

        public void AddFirst(X? data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data cannot be null");
            }

            Node newNode = new Node(data);
            newNode.next = this.head;
            this.head = newNode;
            this.size++;
        }

        public void Add(X data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data cannot be null");
            }

            Node newNode = new Node(data);
            Node aux = this.head;

            if (aux == null)
            {
                head = newNode;
            }
            else
            {
                while (aux.next != null)
                {
                    aux = aux.next;
                }

                aux.next = newNode;
            }

            this.size++;
        }

        public void AddLast(X? data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data cannot be null");
            }

            Node newNode = new Node(data);
            Node aux = this.head;

            if (aux == null)
            {
                head = newNode;
            }
            else
            {
                while (aux.next != null)
                {
                    aux = aux.next;
                }

                aux.next = newNode;
            }

            this.size++;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            Node temp = this.head;
            this.head = this.head.next;
            temp.next = null;

            this.size--;
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            if (this.size == 1)
            {
                this.head = null;
                this.size--;
                return;
            }

            Node current = this.head;
            Node previous = null;

            while (current.next != null)
            {
                previous = current;
                current = current.next;
            }

            previous.next = null;
            this.size--;
        }

        public bool Contains(X? data)
        {
            Node aux = this.head;

            while (aux != null)
            {
                if (aux.data.Equals(data))
                {
                    return true;
                }

                aux = aux.next;
            }

            return false;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void clear()
        {
            head = null;
            size = 0;
        }

        public void Remove(X? data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data cannot be null");
            }

            if (head == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            if (head.data.Equals(data))
            {
                head = head.next;
                size--;
                return;
            }

            Node current = this.head;
            Node previous = null;

            while (current != null && !current.data.Equals(data))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
            {
                throw new InvalidOperationException("The element does not exist in the list");
            }

            previous.next = current.next;
            this.size--;
        }

        public X GetFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            return head.data;
        }

        public X GetLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            Node aux = head;
            while (aux.next != null)
            {
                aux = aux.next;
            }

            return aux.data;
        }

        public X Get(int index)
        {
            if (index < 0 || index >= this.size)
            {
                throw new IndexOutOfRangeException("Index");
            }

            Node aux = head;
            for (int i = 0; i < index; i++)
            {
                aux = aux.next;
            }

            return aux.data;
        }

        public void Reverse()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            Node previous = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            head = previous;
        }

        public void Rotate(int steps)
        {
            if (head == null || steps == 0) return;

            steps = steps % size;

            if (steps < 0)
            {
                steps = size + steps;
            }

            Node current = head;
            for (int i = 0; i < steps - 1; i++)
            {
                current = current.next;
            }

            Node newHead = current.next;
            current.next = null;

            Node temp = newHead;
            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = head;
            head = newHead;
        }

        public LinkedListDisordered(LinkedListDisordered<X>? other)
        {
            // Implementação da cópia profunda
            if (other.head == null)
            {
                head = null;
                size = 0;
                return;
            }

            Node currentOther = other.head;
            Node currentNew = new Node((X)VerifyAndCopy(currentOther.data));
            head = currentNew;

            while (currentOther.next != null)
            {
                currentOther = currentOther.next;
                currentNew.next = new Node((X)VerifyAndCopy(currentOther.data));
                currentNew = currentNew.next;
            }

            size = other.size;
        }

        public object Clone()
        {
            LinkedListDisordered<X> clone = null;
            try
            {
                clone = new LinkedListDisordered<X>(this);
            }
            catch (Exception)
            {
            }

            return clone;
        }


        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            LinkedListDisordered<X> other = (LinkedListDisordered<X>)obj;

            if (this.size != other.size)
            {
                return false;
            }

            Node aux1 = this.head;
            Node aux2 = other.head;

            while (aux1 != null && aux2 != null)
            {
                if (!aux1.data.Equals(aux2.data))
                {
                    return false;
                }

                aux1 = aux1.next;
                aux2 = aux2.next;
            }

            return aux1 == null && aux2 == null;
        }


        public override int GetHashCode()
        {
            int prime = 31;
            int hash = 1;

            Node aux = this.head;
            while (aux != null)
            {
                hash *= prime + (aux == null ? 0 : aux.GetHashCode());
                aux = aux.next;
            }

            if (hash < 0)
            {
                hash *= -1;
            }

            return hash;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            Node aux = this.head;
            while (aux != null)
            {
                sb.Append(aux.data);
                if (aux.next != null)
                {
                    sb.Append(" -> ");
                }

                aux = aux.next;
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}