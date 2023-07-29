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

            Console.WriteLine(people.Count);
            // Bob Mike Sam Tom
            foreach (var person in people) Console.WriteLine(person);
            Console.WriteLine();

            var cars = new CustomLinkedList<string>();
            var car = cars.Find("Tom");
            Console.WriteLine("Is Tom in cars? " + (car != null));
            Console.WriteLine();

            people.RemoveFirst();
            people.Remove("Sam");

            Console.WriteLine(people.Count);
            // Mike Tom
            foreach (var person in people) Console.WriteLine(person);
            Console.WriteLine();

            people.Clear();
            Console.WriteLine(people.Count);
            foreach (var person in people) Console.WriteLine(person);
        }
    }
}