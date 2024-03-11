using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using LinkedListDisordered;
using static System.Console;
using static System.Object;


namespace TestCopyConstructorAndClone
{
    class Program
    {
        static void main(string[] args)
        {
            LinkedListDisordered<int> emptyList = new LinkedListDisordered<int>();
            LinkedListDisordered<int> emptyListCopyConstructor
                = new LinkedListDisordered<int>(emptyList);
            LinkedListDisordered<int> emptyListClone = (LinkedListDisordered<int>)emptyList.Clone();

            WriteLine("Empty list:");
            WriteLine("Original:         " + emptyList);
            WriteLine("Copy constructor: " + emptyListCopyConstructor);
            WriteLine("Clone:            " + emptyListClone);
            WriteLine();

            LinkedListDisordered<List<LinkedListDisordered<int>>> listlist =
                new LinkedListDisordered<List<LinkedListDisordered<int>>>();

            LinkedListDisordered<LinkedListDisordered<List<int>>> listlistlist =
                new LinkedListDisordered<LinkedListDisordered<List<int>>>();

            LinkedListDisordered<int> list = new LinkedListDisordered<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            List<int> list2 = new List<int>();
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);

            List<LinkedListDisordered<int>> list3 = new List<LinkedListDisordered<int>>();
            list3.Add(list);
            list3.Add(list);
            list3.Add(list);

            LinkedListDisordered<List<int>> list4 = new LinkedListDisordered<List<int>>();
            list4.Add(list2);
            list4.Add(list2);
            list4.Add(list2);

            listlist.Add(list3);
            listlist.Add(list3);
            listlist.Add(list3);

            listlistlist.Add(list4);
            listlistlist.Add(list4);
            listlistlist.Add(list4);

            WriteLine(list);
            WriteLine(list2);
            WriteLine(list3);
            WriteLine(list4);
            WriteLine(listlist);
            WriteLine(listlistlist);

            LinkedListDisordered<List<LinkedListDisordered<int>>> listlistCopyConstructor
                = new LinkedListDisordered<List<LinkedListDisordered<int>>>(listlist);

            LinkedListDisordered<List<LinkedListDisordered<int>>> listlistClone =
                (LinkedListDisordered<List<LinkedListDisordered<int>>>)listlist.Clone();

            LinkedListDisordered<LinkedListDisordered<List<int>>> listlistlistCopyConstructor
                = new LinkedListDisordered<LinkedListDisordered<List<int>>>(listlistlist);

            LinkedListDisordered<LinkedListDisordered<List<int>>> listlistlistClone =
                (LinkedListDisordered<LinkedListDisordered<List<int>>>)listlistlist.Clone();



            WriteLine("listlist.hashCode():                 " + listlist.GetHashCode());
            WriteLine("listlistCopyConstructor.hashCode():  " + listlistCopyConstructor.GetHashCode());
            WriteLine("listlistClone.hashCode():            " + listlistClone.GetHashCode());
            WriteLine();
            WriteLine("listlistlist.hashCode():                 " + listlistlist.GetHashCode());
            WriteLine("listlistlistCopyConstructor.hashCode()   " + listlistlistCopyConstructor.GetHashCode());
            WriteLine("listlistlistClone.hashCode()             " + listlistlistClone.GetHashCode());
            WriteLine();

            listlist.AddLast(list3);
            listlistlist.AddLast(list4);

            WriteLine("listlist.hashCode():                 " + listlist.GetHashCode());
            WriteLine("listlistCopyConstructor.hashCode():  " + listlistCopyConstructor.GetHashCode());
            WriteLine("listlistClone.hashCode():            " + listlistClone.GetHashCode());
            WriteLine();
            WriteLine("listlistlist.hashCode():                 " + listlistlist.GetHashCode());
            WriteLine("listlistlistCopyConstructor.hashCode()   " + listlistlistCopyConstructor.GetHashCode());
            WriteLine("listlistlistClone.hashCode()             " + listlistlistClone.GetHashCode());
        }
    }
}