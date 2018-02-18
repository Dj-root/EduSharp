using System;

namespace Edusharp.Troelsen.Unit4
{
    public class Person
    {
        public string personName;
        public int personAge;

        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }

        public Person(){}

        public void Display()
        {
            Console.WriteLine("Name: {0}, Age: {1}", personName, personAge);
        }

        public void SendPersonByValue(Person p)
        {
            p.personAge = 99;
            p = new Person("Nikki", 99);
        }

        public static void SendAPersonByReference(ref Person p)
        {
            p.personAge = 555;
            p = new Person("Nikki", 999);
        }
    }
}