using System;
using System.Collections.ObjectModel;

namespace EduSharp.Troelsen.Unit9
{
    public class ObservCollection
    {
        public static void ObsCollectionDemo()
        {
            Console.WriteLine("\n**** Fun with ObservableCollection *****\n");
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person {FirstName = "Peter", LastName = "Murphy", Age = 52},
                new Person {FirstName = "Kevin", LastName = "Key", Age = 48}
            };

            people.CollectionChanged += people_CollectionChanged;

            people.Add(new Person { FirstName = "Mark", LastName = "Scolfield", Age = 43 });
            people.RemoveAt(2);
            people.Insert(1, new Person { FirstName = "Ian", LastName = "Brown", Age = 15 });
            people.Move(0, 2);
        }

        static void people_CollectionChanged(object sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Action for event: {0}", e.Action);

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:");
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }

                Console.WriteLine();
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Here are the NEW items:");
                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }

                Console.WriteLine();
            }
            
        }


    }
}