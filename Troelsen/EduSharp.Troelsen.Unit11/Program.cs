using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Troelsen.Unit11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Indexers *****\n");

            PersonCollection myPeople = new PersonCollection();

            myPeople[0] = new Person("Homer", "Simpson", 40);
            myPeople[1] = new Person("Marge", "Simpson", 38);
            myPeople[2] = new Person("Lisa", "Simpson", 9);
            myPeople[3] = new Person("Bart", "Simpson", 7);
            myPeople[4] = new Person("Maggie", "Simpson", 2);

            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Person number: {0}", i);
                Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
                Console.WriteLine("Age: {0}", myPeople[i].Age);
                Console.WriteLine();
            }

            Console.WriteLine("\n=== Using UseGenericListOfPeople() method ===\n");
            UseGenericListOfPeople();


            Console.WriteLine("\n=== Text Indexers ===\n");
            PersonCollection myTextPeople = new PersonCollection();
            myTextPeople["Homer"] = new Person("Homer", "Simpson", 40);
            myTextPeople["Marge"] = new Person("Marge", "Simpson", 38);

            Person homer = myTextPeople["Homer"];
            Console.WriteLine(homer.ToString());


            Console.WriteLine("\n=== Using MultiIdexerWithDataTable() method ===\n");
            MultiIdexerWithDataTable();


            Console.WriteLine("\n***** Fun with Overloaded Operators *****\n");
            Point ptOne = new Point(100, 100);
            Point ptTwo = new Point(40, 40);
            Console.WriteLine("ptOne = {0}", ptOne);
            Console.WriteLine("ptTwo = {0}", ptTwo);

            Console.WriteLine("ptOne + ptTwo: {0} ", ptOne + ptTwo);
            Console.WriteLine("ptOne - ptTwo: {0} ", ptOne - ptTwo);

            Point biggerPoint = ptOne + 10;
            Console.WriteLine("ptOne + 10 = {0}", biggerPoint);
            Console.WriteLine("10 + biggerPoint = {0}", 10 + biggerPoint);

            Point ptThree = new Point(90,5);
            Console.WriteLine("ptThree = {0}", ptThree);
            Console.WriteLine("ptThree += ptTwo: {0}", ptThree+ptTwo);

            Point ptFour = new Point(0,500);
            Console.WriteLine("ptFour = {0}", ptFour);
            Console.WriteLine("ptFour -= ptThree: {0}", ptFour-ptThree);

            Point ptFive = new Point(1,1);
            Console.WriteLine("++ptFive = {0}", ++ptFive);
            Console.WriteLine("--ptFive = {0}", --ptFive);

            Point ptSix = new Point(20,20);
            Console.WriteLine("ptSix++ = {0}", ptSix++);
            Console.WriteLine("ptSix-- = {0}", ptSix--);

            Console.WriteLine("ptOne == ptTwo : {0}", ptOne==ptTwo);
            Console.WriteLine("ptOne != ptTwo : {0}", ptOne != ptTwo);

            Console.WriteLine("ptOne < ptTwo : {0}", ptOne < ptTwo);
            Console.WriteLine("ptOne > ptTwo : {0}", ptOne > ptTwo);


            Console.WriteLine("***** Fun with Conversions *****\n");
            Rectangle r = new Rectangle(15,4);
            Console.WriteLine(r.ToString());
            r.Draw();

            Square s = (Square) r;
            Console.WriteLine(s.ToString());
            s.Draw();


            Console.WriteLine("=== Explicit cast ===\n");
            Square sq2 = (Square) 90;
            Console.WriteLine("sq2 = {0}",sq2);
            
            int side = (int) sq2;
            Console.WriteLine("Side lenght of sq2 = {0}",side);


            Console.WriteLine("=== Implicit cast ===\n");
            Square s3 = new Square();
            s3.Lenght = 7;
            Rectangle rect2 = s3;
            Console.WriteLine("rect2 = {0}",rect2);

            Square s4 = new Square();
            s4.Lenght = 3;
            Rectangle rect3 = (Rectangle) s4;

            Console.WriteLine("rect3 = {0}",rect3);


            Console.WriteLine("***** Fun with Extension Methods *****\n");
            int myInt = 123456789;
            myInt.DisplayDefiningAssembly();

            System.Data.DataSet d = new DataSet();
            d.DisplayDefiningAssembly();

            System.Media.SoundPlayer sp = new SoundPlayer();
            sp.DisplayDefiningAssembly();

            Console.WriteLine("Value of myInt: {0}", myInt);
            Console.WriteLine("Reversed digits of myInt: {0}", myInt.ReverseDigits());


            Console.WriteLine("\n***** Fun with Anonymous Types *****\n");
            var myCar = new {Color = "Bright Pink", Make="Saab", CurrentSpeed=55};

            Console.WriteLine("My car is a {0} {1}.", myCar.Color, myCar.Make);
            BuildAnonType("BMW", "Black", 90);

            ReflectOverAnonymousType(myCar);

            Console.ReadLine();
        }


        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString() == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());
        }

        static void BuildAnonType(string make, string color, int currSp)
        {
            var car = new {Make = make, Color = color, Speed = currSp};
            Console.WriteLine("You have a {0} {1} going {2} MPH", car.Color, car.Make, car.Speed);

            Console.WriteLine("ToString() == {0}", car.ToString());
        }

        static void MultiIdexerWithDataTable()
        {
            DataTable myTable = new DataTable();
            myTable.Columns.Add(new DataColumn("FirstName"));
            myTable.Columns.Add(new DataColumn("LastName"));
            myTable.Columns.Add(new DataColumn("Age"));

            myTable.Rows.Add("Mel", "Appleby", 60);

            Console.WriteLine("First Name: {0}", myTable.Rows[0][0]);
            Console.WriteLine("Last Name: {0}", myTable.Rows[0][1]);
            Console.WriteLine("Age: {0}", myTable.Rows[0][2]);
        }

        static void UseGenericListOfPeople()
        {
            List<Person> myPeople = new List<Person>();
            myPeople.Add(new Person("Lisa", "Simpson", 9));
            myPeople.Add(new Person("Bart", "Simpson", 7));

            Console.WriteLine("Before change [0] item:");
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Person number: {0}", i);
                Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
                Console.WriteLine("Age: {0}", myPeople[i].Age);
                Console.WriteLine();
            }

            myPeople[0] = new Person("Maggie", "Simpson", 2);

            Console.WriteLine("Item [0] changed:");
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Person number: {0}", i);
                Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
                Console.WriteLine("Age: {0}", myPeople[i].Age);
                Console.WriteLine();
            }
        }
    }
}
