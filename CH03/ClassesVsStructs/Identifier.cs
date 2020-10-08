using System;

namespace Class
{
    public class Id
    {
        public int Value { get; private set; }

        public Id(int value)
        {
            this.Value = value;
        }
    }

    public class Person
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string City { get; private set; }

        public Person(int id, string firstName, string lastName,
          string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            City = city;
        }
    }
}

namespace Struct
{
    public struct Id
    {
        public int Value { get; private set; }

        public Id(int value)
        {
            this.Value = value;
        }

        private void testMethod()
        {
            var a = new Person(42, "Sedat", "Kapanoglu", "San Francisco");
            var b = a;
            b.City = "Eskisehir";
            Console.WriteLine(a.City);
            Console.WriteLine(b.City);
        }
    }

    public struct Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public Person(int id, string firstName, string lastName,
          string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            City = city;
        }
    }
}