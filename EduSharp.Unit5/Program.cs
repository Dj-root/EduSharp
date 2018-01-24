using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Unit5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Class Types *****\n");

            Car myCar = new Car();
            myCar.petName = "Henry";
            myCar.currSpeed = 10;

            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }
            Console.WriteLine();


            Car chuck = new Car();
            chuck.PrintState();

            Car mary = new Car("Mary");
            mary.PrintState();

            Car daisy = new Car("Daisy", 75);
            daisy.PrintState();
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
            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());
            SavingsAccount s2 = new SavingsAccount(100);
            SavingsAccount.SetInterestRate(0.08);
            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());

            SavingsAccount s3 = new SavingsAccount(10000.75);
            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());
            Console.WriteLine();


            Console.WriteLine("***** Fun with Static Classes *****\n");
            TimeUtilClass.PrintDate();
            TimeUtilClass.PrintTime();
            Console.WriteLine();




            Console.ReadLine();
        }
    }
}
