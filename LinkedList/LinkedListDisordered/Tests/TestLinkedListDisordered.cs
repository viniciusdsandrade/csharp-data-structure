using LinkedListDisordered;
using static System.Console;
using static System.Object;

namespace testLinkedListDisordered
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListDisordered<string> linked_name = new LinkedListDisordered<string>();
            WriteLine(linked_name);

            linked_name.Add("Dos");
            linked_name.Add("Santos");

            linked_name.Reverse();
            WriteLine(linked_name);
            linked_name.Reverse();
            WriteLine(linked_name);

            WriteLine("before rotacioning:  " + linked_name);
            linked_name.Rotate(0);
            WriteLine("rotacionating 0:     " + linked_name);
            linked_name.Rotate(1);
            WriteLine("rotacionating 1:     " + linked_name);
            linked_name.Rotate(2);
            WriteLine("rotacionating 2:     " + linked_name);
            linked_name.Rotate(3);
            WriteLine("rotacionating 3:     " + linked_name);
            linked_name.Rotate(4);
            WriteLine("rotacionating 4:     " + linked_name);
            linked_name.Rotate(5);
            WriteLine("rotacionating 5:     " + linked_name);
            linked_name.Rotate(6);
            WriteLine("rotacionating 6:     " + linked_name);

            linked_name.AddFirst("Vinícius");
            linked_name.AddLast("Andrade");
            WriteLine(linked_name);

            linked_name.RemoveFirst();
            WriteLine("removendo first: " + linked_name);
            linked_name.RemoveLast();
            WriteLine("removendo last:  " + linked_name);

            bool containDos = linked_name.Contains("Dos");
            WriteLine("contains Dos:        " + containDos);
            bool containSantos = linked_name.Contains("Santos");
            WriteLine("contains Santos:     " + containSantos);
            bool containVinicius = linked_name.Contains("Vinícius");
            WriteLine("contains Vinícius:   " + containVinicius);
            bool containAndrade = linked_name.Contains("Andrade");
            WriteLine("contains Andrade:    " + containAndrade);

            int size = linked_name.GetSize();
            WriteLine("size:    " + size);

            bool isEmpty = linked_name.IsEmpty();
            WriteLine("isEmpty: " + isEmpty);

            linked_name.clear();
            int sizeAfterClear = linked_name.GetSize();
            WriteLine("size after clear:    " + sizeAfterClear);
            bool isEmptyAfterClear = linked_name.IsEmpty();
            WriteLine("isEmpty after clear: " + isEmptyAfterClear);
            WriteLine("clear:               " + linked_name);


            linked_name.Add("dos");
            linked_name.Add("Santos");
            linked_name.AddFirst("Vinícius");
            linked_name.AddLast("Andrade");

            object primeiro = linked_name.GetFirst();
            WriteLine("primeiro: " + primeiro);

            object ultimo = linked_name.GetLast();
            WriteLine("ultimo:   " + ultimo);

            linked_name.clear();

            LinkedListDisordered<int> numbers = new LinkedListDisordered<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(6);
            numbers.Add(7);
            numbers.Add(8);
            numbers.Add(9);

            WriteLine("numbers before rotate: " + numbers);

            numbers.Rotate(5);
            WriteLine("numbers.rotate(5):     " + numbers);

            numbers.Rotate(3);
            WriteLine("numbers.rotate(3):     " + numbers);

            numbers.Rotate(1);
            WriteLine("numbers.rotate(1):     " + numbers);

            numbers.Rotate(0);
            WriteLine("numbers.rotate(0):     " + numbers);

            numbers.Rotate(9);
            WriteLine("numbers.rotate(9):     " + numbers);

            numbers.Reverse();
            WriteLine("numbers.reverse():     " + numbers);

            for (int i = 0; i < numbers.GetSize(); i++)
            {
                WriteLine($"numbers.Get({i}) = {numbers.Get(i)}");
            }

            for (int i = 1; i < 10; i++)
            {
                WriteLine($"removing: {i}");
                numbers.Remove(i);
                WriteLine(numbers);
            }
        }
    }
}