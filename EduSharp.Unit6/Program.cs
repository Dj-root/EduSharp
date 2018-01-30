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

            SalesPerson fran = new SalesPerson("Fran", 43,93, 3000, "932-23-4356",31);
            fran.GiveBonus(200);
            fran.DisplayStats();
            Console.WriteLine();

            Employee.BenefitPackage.BenefitPackageLevel myBenefitLevel =
                Employee.BenefitPackage.BenefitPackageLevel.Platinum;


            Console.ReadLine();
        }
    }
}
