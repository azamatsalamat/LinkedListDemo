namespace LinkedListDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var people = new CustomLinkedList<string>();
            people.AddLast("Tom"); 
            people.AddFirst("Bob"); 

            if (people.First != null) people.AddAfter(people.First, "Mike");
            people.AddBefore(people.Last, "Sam");

            // Bob Mike Sam Tom
            foreach (var person in people) Console.WriteLine(person);

            var cars = new CustomLinkedList<string>();
            var car = people.Find("Tom");
            Console.WriteLine();
            Console.WriteLine("Tom is here: " + car?.Value);
            Console.WriteLine();
            foreach (var c in cars) Console.WriteLine(c);

            people.RemoveFirst();
            people.Remove("Sam");
            foreach (var person in people) Console.WriteLine(person);

            Console.WriteLine();
            people.Clear();
            foreach (var person in people) Console.WriteLine(person);
        }
    }
}