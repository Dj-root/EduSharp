using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Unit6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Basic Inheritance *****\n");
            Car myCar = new Car(80);

            myCar.Speed = 50;
            Console.WriteLine("My car is going {0} MPH", myCar.Speed);

            MiniVan myVan = new MiniVan();
            myVan.Speed = 10;
            Console.WriteLine("My van is going {0} MPH\n", myVan.Speed);


            Console.WriteLine("***** The Employee Class Hierarchy *****\n");
            SalesPerson fred = new SalesPerson();
            fred.Age = 31;
            fred.Name = "Fred";
            fred.SalesNumber = 50;

            //Employee
            Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-22-2332", 9000);
            double cost = chucky.GetBenefitCost();
            chucky.GiveBonus(300);
            chucky.DisplayStats();
            Console.WriteLine();

            SalesPerson fran = new SalesPerson("Fran", 43, 93, 3000, "932-23-4356", 31);
            fran.GiveBonus(200);
            fran.DisplayStats();
            Console.WriteLine();

            Employee.BenefitPackage.BenefitPackageLevel myBenefitLevel =
                Employee.BenefitPackage.BenefitPackageLevel.Platinum;
            Console.WriteLine();


            Console.WriteLine("***** Fun with Polymorphism *****\n");

            Hexagon hex = new Hexagon("Beth");
            hex.Draw();

            Circle cir = new Circle("Cindy");
            cir.Draw();
            Console.WriteLine();

            Shape[] myShapes =
                {new Hexagon(), new Circle(), new Hexagon("Mick"), new Circle("Beth"), new Hexagon("Linda")};
            foreach (Shape s in myShapes)
            {
                s.Draw();
            }

            ThreeDCircle o = new ThreeDCircle();
            o.Draw();
            ((Circle)o).Draw();
            Console.WriteLine();

            CastingExamples();
            Console.WriteLine();

            object[] things = new object[4];
            things[0] = new Hexagon();
            things[1] = false;
            things[2] = new Manager("MoonUnit Zappa", 2, 3001, 20000, "101-11-1234", 1);
            things[3] = "Last thing";

            Console.WriteLine("Using \"AS\" keyword");
            foreach (object item in things)
            {
                Hexagon h = item as Hexagon;
                if (h == null)
                {
                    Console.WriteLine("Item \"{0}\" is not hexagon", item);
                }
                else
                {
                    h.Draw();
                }
            }

            Console.WriteLine();


            Console.WriteLine("***** Fun with System.Object *****\n");
            Person p1 = new Person("Homer", "Simpson", 50);
            Person p2 = new Person("Homer", "Simpson", 50);

            Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            Console.WriteLine("p2.ToString() = {0}", p2.ToString());


            //            Console.WriteLine("ToString: {0}", p1.ToString());
            //            Console.WriteLine("Hash code: {0}",p1.GetHashCode());
            //            Console.WriteLine("Type: {0}", p1.GetType());

            //            Person p2 = p1;
            //            object o1 = p2;
            //            if (o1.Equals(p1)&&p2.Equals(o1))
            //            {
            //                Console.WriteLine("Same instance!");
            //            }

            Console.WriteLine("p1 = p2?: {0}", p1.Equals(p2));
            Console.WriteLine("Same hash codes: {0}", p1.GetHashCode() == p2.GetHashCode());

            p2.Age = 45;
            Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            Console.WriteLine("p2.ToString() = {0}", p2.ToString());
            Console.WriteLine("p1 = p2?: {0}", p1.Equals(p2));
            Console.WriteLine("Same hash codes: {0}", p1.GetHashCode() == p2.GetHashCode());
            Console.WriteLine();

            StaticMemberOfObject();
            Console.ReadLine();
        }
        //        Other methods

        static void CastingExamples()
        {
            object frank = new Manager("Frank Zappa", 9, 3000, 40000, "111-22-3334", 5);
            Employee moonUnit = new Manager("MoonUnit Zappa", 2, 3001, 20000, "101-11-1234", 1);
            SalesPerson jill = new PTSalesPerson("Jill", 843, 3002, 100000, "111-12-3456", 90);

            GivePromotion(moonUnit);
            GivePromotion(jill);
            GivePromotion((Manager)frank);
        }

        static void GivePromotion(Employee emp)
        {
            Console.WriteLine("{0} was promoted!", emp.Name);
            if (emp is SalesPerson)
            {
                Console.WriteLine("{0} made {1} sale(s)!", emp.Name, ((SalesPerson)emp).SalesNumber);
                Console.WriteLine();
            }

            if (emp is Manager)
            {
                Console.WriteLine("{0} had {1} stock options...", emp.Name, ((Manager)emp).StockOptions);
                Console.WriteLine();
            }
        }

        static void StaticMemberOfObject()
        {
            Person p3 = new Person("Sally", "Jones", 4);
            Person p4 = new Person("Sally", "Jones", 4);
            Console.WriteLine("P3 and P4 have same state: {0}", object.Equals(p3, p4));
            Console.WriteLine("P3 and P4 are pointing to same object: {0}", object.ReferenceEquals(p3, p4));
        }
    }
}
