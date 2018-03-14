using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EduSharp.Troelsen.Unit19
{
    class Program
    {
        public delegate int BinaryOp(int x, int y);

        static void Main(string[] args)
        {
            Console.WriteLine("***** Sync Delegate Review *****");

            Console.WriteLine("Main() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);
            BinaryOp b = new BinaryOp(Add);
            int answer = b(10, 10);

            Console.WriteLine("Doing more work in Main()!");
            Console.WriteLine("10 + 10 is {0}", answer);



            Console.WriteLine("***** Sync Delegate Review *****");
            Console.WriteLine("Main() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);
            b = new BinaryOp(Add);
            IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);

            Console.WriteLine("Doing more work in Main()!");
            answer = b.EndInvoke(iftAR);
            Console.WriteLine("10 + 10 is {0}", answer);





            Console.ReadLine();
        }



        static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }

        static void ExtractExecutingThread()
        {
            Thread currThread = Thread.CurrentThread;
        }
    }
}
