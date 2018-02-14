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
            myPeople.AddPerson(new Person("Homer", "Simpson",40));
            myPeople.AddPerson(new Person("Marge", "Simpson", 38));
            myPeople.AddPerson(new Person("Lisa", "Simpson", 9));
            myPeople.AddPerson(new Person("Bart", "Simpson", 7));
            myPeople.AddPerson(new Person("Maggie", "Simpson", 2));

            foreach (Person p in myPeople)
            {
                Console.WriteLine(p);
            }

//            ============================================
            UseGenericList();

            Console.WriteLine("\n === Specifyingn Type Params for Gen Members===");
            int[] myInts = {10, 4, 2, 33, 93};

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




            Console.ReadLine();
        }

        static void UseGenericList()
        {
            Console.WriteLine("\n**** Fun with Generics *****\n");

            List<Person> morePeople = new List<Person>();
            morePeople.Add(new Person("Frank", "Black", 50));
            Console.WriteLine(morePeople[0]);

            List<int> moreInts = new List<int>();
            moreInts.Add(10);
            moreInts.Add(2);
            int sum = moreInts[0] + moreInts[1];
            Console.WriteLine(sum);
        }
    }
}
