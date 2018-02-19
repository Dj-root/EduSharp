using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Troelsen.Unit10
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Delegate Example *****\n");

            BinaryOp b = new BinaryOp(SimpleMath.Add);
            Console.WriteLine("10 + 10 is {0}", b(10,10));

//            CompilerError Error
//            BinaryOp b2=new BinaryOp(SimpleMath.SquareNumber);

            DisplayDelegateInfo(b);

//            SimpleMath m = new SimpleMath();
//            BinaryOp b2 = new BinaryOp(m.Add);


            Console.WriteLine("***** Delegate as event enablers*****\n");

            Car c1 = new Car("SlugBug",100,10);
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }




            Console.ReadLine();
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************");
        }


        static void DisplayDelegateInfo(Delegate delObj)
        {
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}",d.Target);
            }
        }
    }
}
