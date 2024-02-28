using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using static System.Console;
using static System.Object;

namespace LinkedList
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

            public X getData()
            {
                return data;
            }

            public void setData(X data)
            {
                this.data = data;
            }

            public Node getNext()
            {
                return next;
            }

            public void setNext(Node next)
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

        public LinkedListDisordered()
        {
            this.head = null;
            this.size = 0;
        }

        public void addFirst(X data)
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

        public void addLast(X data)
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

        public void removeFirst()
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

        public void removeLast()
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

        public void add(X data)
        {
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

        public bool contains(X data)
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

        public int getSize()
        {
            return this.size;
        }

        public bool isEmpty()
        {
            return this.size == 0;
        }

        public void clear()
        {
            head = null;
        }

        public void remove(X data)
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
                this.size--;
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

        public X getFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            return head.data;
        }

        public X getLast()
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

        public X get(int index)
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


        public LinkedListDisordered(LinkedListDisordered<X> other)
        {
            // Implementação da cópia profunda
            if (other.head == null)
            {
                head = null;
                size = 0;
                return;
            }

            Node currentOther = other.head;
            Node currentNew = new Node(other.head.data);
            head = currentNew;

            while (currentOther.next != null)
            {
                currentOther = currentOther.next;
                currentNew.next = new Node(currentOther.data);
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
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            return clone;
        }


        public override bool Equals(Object obj)
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

            while (aux1 != null)
            {
                if (!aux1.Equals(aux2))
                {
                    return false;
                }

                aux1 = aux1.next;
                aux2 = aux2.next;
            }

            return true;
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
            if (this.head == null)
            {
                return "[]";
            }

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