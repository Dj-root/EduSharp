﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Troelsen.Unit5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Class Types *****\n");

            Car myCar = new Car();
            myCar.PetName = "Henry";
            myCar.CurrSpeed = 10;

            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.DisplayStats();
            }
            Console.WriteLine();


            Car chuck = new Car();
            chuck.DisplayStats();

            Car mary = new Car("Mary");
            mary.DisplayStats();

            Car daisy = new Car();
            daisy.PetName = "Daisy";
            daisy.CurrSpeed = 55;
            daisy.Color = "Red";
            Console.WriteLine("Your car is named {0}? That's odd...", daisy.PetName);
            daisy.DisplayStats();
            Console.WriteLine();

            Garage g = new Garage();
            g.MyAuto = daisy;
            Console.WriteLine("Number of Cars in garage: {0}", g.NumberOfCars);
            Console.WriteLine("Your car named: {0}", g.MyAuto.PetName);
            Console.WriteLine();


            Motorcycle mc = new Motorcycle();
            mc.PopAHweely();

            Motorcycle c = new Motorcycle(5);
            c.SetDriverName("Tiny");
            c.PopAHweely();
            Console.WriteLine("Rider's name is {0}", c.driverName);
            Console.WriteLine();


            Console.WriteLine("***** Fun with Static Data *****\n");
            SavingsAccount s1 = new SavingsAccount(50);
            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.InterestRate);
            SavingsAccount s2 = new SavingsAccount(100);
            SavingsAccount.InterestRate=(0.08);
            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.InterestRate);

            SavingsAccount s3 = new SavingsAccount(10000.75);
            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.InterestRate);
            Console.WriteLine();


            Console.WriteLine("***** Fun with Static Classes *****\n");
            TimeUtilClass.PrintDate();
            TimeUtilClass.PrintTime();
            Console.WriteLine();

            //////////////////////////////////////////////////////////////////////////

            Console.WriteLine("***** Fun with Encapsulation *****\n");
            Employee emp = new Employee("Marvin", 456, 30000);
            emp.GiveBonus(1000);
            emp.DisplayStats();
            emp.Name="Marv";
            Console.WriteLine("Employee is named: {0}",emp.GetName());

            Employee emp2 = new Employee();
            emp2.Name="Xena the warrior princess";
            Console.WriteLine();

            Employee joe = new Employee("Joe",30,458, 100000);
            joe.DisplayStats();
            Console.WriteLine();
            joe.Age++;
            joe.DisplayStats();
            Console.WriteLine();

            Console.WriteLine("***** Fun with Object Init Syntax *****\n");
            Point firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;
            firstPoint.DisplayStats();

            Point anotherPoint = new Point(20,20);
            anotherPoint.DisplayStats();

            Point finalPoint = new Point{X=30, Y=30};
            finalPoint.DisplayStats();

            Point goldPoint = new Point(PointColor.Gold){X=90, Y=20};
            goldPoint.DisplayStats();
            Console.WriteLine();

            Rectangle myRect = new Rectangle()
            {
                TopLeft = new Point {X = 10, Y = 10},
                BottomRight = new Point {X = 200, Y = 200}
            };





            Console.ReadLine();
        }
    }
}
