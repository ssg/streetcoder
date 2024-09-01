using System;

namespace Class
{
    public class Id(int value)
    {
        public int Value { get; private set; } = value;
    }

    public class Person(int id, string firstName, string lastName, string city)
    {
        public int Id { get; private set; } = id;
        public string FirstName { get; private set; } = firstName;
        public string LastName { get; private set; } = lastName;
        public string City { get; private set; } = city;
    }
}

namespace Struct
{
    public struct Id(int value)
    {
        public int Value { get; private set; } = value;

        private void testMethod()
        {
            var a = new Person(42, "Sedat", "Kapanoglu", "San Francisco");
            var b = a;
            b.City = "Eskisehir";
            Console.WriteLine(a.City);
            Console.WriteLine(b.City);
        }
    }

    public struct Person(int id, string firstName, string lastName, string city)
    {
        public int Id { get; set; } = id;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string City { get; set; } = city;
    }
}