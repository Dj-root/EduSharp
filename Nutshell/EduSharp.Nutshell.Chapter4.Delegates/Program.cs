using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Nutshell.Chapter4.Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Testing invoking methods to delegate *****");
            int[] values = {1, 2, 3};
            Util.Transform(values, Square);
            foreach (int i in values)
            {
                Console.Write(i + " ");
            }

            HardWorkDemo();
            InstanceVsStatic();
            DelegateVsInterface();




            Console.ReadLine();
        }

        static int Square(int x) => x * x;

        static void DelegateVsInterface() 
        {
            Console.WriteLine("\n***** Delegates VS Interfaces *****");

            int[] values = { 1, 2, 3 };
            Util.TransformAll(values, new Squarer());
            foreach (int i in values)
            {
                Console.WriteLine(i);
            }
        }


        static void InstanceVsStatic()
        {
            Console.WriteLine("\n***** Instance VS Static Delegates *****");

            X x = new X();
            ProgressReporter p = x.InstanceProgress;
            p(99);
            Console.WriteLine(p.Target);
            Console.WriteLine(p.Method);
        }

        static void WriteProgressToConsole(int percentComplete) => Console.WriteLine(percentComplete);

        static void WriteProgressToFile(int percentComplete) =>
            System.IO.File.WriteAllText("progress.txt", percentComplete.ToString());

        static void HardWorkDemo()
        {
            Console.WriteLine("***** Multicast Delegate *****");

            ProgressReporter p = WriteProgressToConsole;
            p += WriteProgressToFile;
            Util.HardWork(p);
        }

    }
}
