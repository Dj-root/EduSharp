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


           
            Console.ReadLine();
        }
    }
}
