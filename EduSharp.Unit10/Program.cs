using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Unit10
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Delegate Example *****\n");

            BinaryOp b = new BinaryOp(SimpleMath.Add);
            Console.WriteLine("10 + 10 is {0}", b(10,10));


            Console.ReadLine();
        }
    }
}
