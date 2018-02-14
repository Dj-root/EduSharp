using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Unit9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Custom Person Collection *****\n");
            PersonCollection myPeople = new PersonCollection();
            myPeople.AddPerson(new Person("Homer", "Simpson", 40));
            myPeople.AddPerson(new Person("Marge", "Simpson", 38));
            myPeople.AddPerson(new Person("Lisa", "Simpson", 9));
            myPeople.AddPerson(new Person("Bart", "Simpson", 7));
            myPeople.AddPerson(new Person("Maggie", "Simpson", 2));

            foreach (Person p in myPeople)
            {
                Console.WriteLine(p);
            }

            //            ============================================


            Console.WriteLine("\n === Specifyingn Type Params for Gen Members===");
            int[] myInts = { 10, 4, 2, 33, 93 };

            Array.Sort(myInts);
            foreach (int i in myInts)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            List<Point> myListOfPoints = new List<Point>
            {
                new Point{X = 2, Y = 2},
                new Point{X=3, Y=3},
                new Point(PointColor.LigthBlue){X = 4, Y=4}
            };

            foreach (var pt in myListOfPoints)
            {
                Console.WriteLine(pt);
            }


            List<Rectangle> myListORects = new List<Rectangle>
            {
                new Rectangle{TopLeft = new Point{X=10, Y=10}, BottomRight = new Point {X=200, Y=200}},
                new Rectangle{TopLeft = new Point{X=2, Y=2}, BottomRight = new Point {X=100, Y=100}},
                new Rectangle{TopLeft = new Point{X=5, Y=5}, BottomRight = new Point {X=90, Y=57}},
            };

            foreach (var r in myListORects)
            {
                Console.WriteLine(r);
                //                r.DisplayStats();
            }

            UseGenericList();
            UseGenericStack();
            UseGenericQueue();
            UseSortedSet();
            UseDictionary();



            Console.ReadLine();
        }

        static void UseGenericList()
        {
            Console.WriteLine("\n**** Fun with Generics *****\n");

            Console.WriteLine("Ints:");
            List<int> moreInts = new List<int>();
            moreInts.Add(10);
            moreInts.Add(2);
            int sum = moreInts[0] + moreInts[1];
            Console.WriteLine(sum);

            Console.WriteLine("Persons:");
            List<Person> morePeople = new List<Person>();
            morePeople.Add(new Person("Frank", "Black", 50));
            Console.WriteLine(morePeople[0]);

            Console.WriteLine("\nList<People>");
            List<Person> people = new List<Person>
            {
                new Person{FirstName = "Homer", LastName = "Simpson", Age = 47},
                new Person{FirstName = "Marge", LastName = "Simpson", Age = 45},
                new Person{FirstName = "Lisa", LastName = "Simpson", Age = 9},
                new Person{FirstName = "Bart", LastName = "Simpson", Age = 8}
            };

            Console.WriteLine("Items in list: {0}", people.Count);

            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("\n->Inserting new person");
            people.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            Console.WriteLine("Items in list: {0}", people.Count);

            Person[] arrayOfPersons = people.ToArray();

            for (int i = 0; i < arrayOfPersons.Length; i++)
            {
                Console.WriteLine("First Name: {0}", arrayOfPersons[i].FirstName);
            }
        }

        static void UseGenericStack()
        {
            Console.WriteLine("\n**** Fun with Generic Stack *****\n");
            Stack<Person> stackOfPeople = new Stack<Person>();
            stackOfPeople.Push(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            stackOfPeople.Push(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            stackOfPeople.Push(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            Console.WriteLine("First person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            Console.WriteLine("\nFirst person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            Console.WriteLine("\nFirst person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());

            try
            {
                Console.WriteLine("\nFirst person is: {0}", stackOfPeople.Peek());
                Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\nError! {0}", ex.Message);
                //                throw;
            }
        }

        static void GetCoffee(Person p)
        {
            Console.WriteLine("{0} got coffee!", p.FirstName);
        }

        static void UseGenericQueue()
        {
            Console.WriteLine("\n**** Fun with Generic Stack *****\n");

            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleQ.Enqueue(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleQ.Enqueue(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            Console.WriteLine("{0} is first in line!", peopleQ.Peek());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());

            try
            {
                GetCoffee(peopleQ.Dequeue());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\nError! {0}", ex.Message);
                //                throw;
            }
        }

        static void UseSortedSet()
        {
            Console.WriteLine("\n**** Fun with Generic Sorted Set *****\n");

            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person{FirstName = "Homer", LastName = "Simpson", Age = 47},
                new Person{FirstName = "Marge", LastName = "Simpson", Age = 45},
                new Person{FirstName = "Lisa", LastName = "Simpson", Age = 9},
                new Person{FirstName = "Bart", LastName = "Simpson", Age = 8}
            };

            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();

            setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setOfPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });

            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();
        }

        static void UseDictionary()
        {
            Console.WriteLine("\n**** Fun with Generic Dictionaries *****\n");

            Dictionary<string, Person> peopleA = new Dictionary<string, Person>();
            peopleA.Add("Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleA.Add("Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleA.Add("Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            Person homer = peopleA["Homer"];
            Console.WriteLine(homer);

            Dictionary<string, Person> peopleB = new Dictionary<string, Person>()
            {
                {"Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 } },
                {"Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 } },
                {"Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 } }
            };

            Person lisa = peopleB["Lisa"];
            Console.WriteLine(lisa);

            Dictionary<string, Person> peopleC = new Dictionary<string, Person>()
            {
                ["Homer"] = new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
                ["Marge"] = new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
                ["Lisa"] = new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 }
            };

            Person marge = peopleC["Marge"];
            Console.WriteLine(marge);
        }
    }
}
