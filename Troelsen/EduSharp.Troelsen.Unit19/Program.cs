using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace EduSharp.Troelsen.Unit19
{
    class Program
    {
        public delegate int BinaryOp(int x, int y);

        private static bool isDone = false;
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            //Sample1();
            //Sample2();
            //Sample3();
            //SampleAdder();
            //SampleBgFg();
            //SampleTimer();
            SampleThreadPool();



            Console.WriteLine("___ Finished ___");
            Console.ReadLine();
        }


        static void SampleThreadPool()
        {
            Console.WriteLine("***** Fun with the CLR Thread Pool *****\n");

            Console.WriteLine("Main thread started. ThreadID = {0}",Thread.CurrentThread.ManagedThreadId);

            Printer p = new Printer();
            WaitCallback workItem = new WaitCallback(PrintTheNumbers);

            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }

            Console.WriteLine("All task queued");
        }

        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer) state;
            task.PrintNumbers();
        }

        static void SampleTimer()
        {
            Console.WriteLine("***** Working With Timer Type *****\n");

            TimerCallback timeCB = new TimerCallback(PrintTime);

            Timer t = new Timer(timeCB, null,0,100);

            Console.WriteLine("Hit key to terminate...");
            Console.ReadLine();
        }


        static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0}", DateTime.Now.ToLongTimeString());
        }


        static void SampleBgFg()
        {
            Console.WriteLine("***** Backgroud Thread *****\n");
            Printer p = new Printer();

            Thread bgroundThread = new Thread(new ThreadStart(p.PrintNumbers));

            bgroundThread.IsBackground = true;
            bgroundThread.Start();


            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i]= new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }

            foreach (Thread t in threads)
            {
                t.Start();
            }
        }

        static void SampleAdder()
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);

            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Adder));
            t.Start(ap);

            waitHandle.WaitOne();
            Console.WriteLine("Other thread is done!");

            //Thread.Sleep(5);
        }

        static void Sample3()
        {
            Console.WriteLine("***** The Amazing Thread App *****");
            Console.Write("Do you want [1] or [2] threads? ");
            string threadCount = Console.ReadLine();

            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            Console.WriteLine("-> {0} is executing Main()", Thread.CurrentThread.Name);


            Printer p = new Printer();


            switch (threadCount)
            {
                case "2":
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;
                case "1":
                    p.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("I don't know what you want... you get 1 thread.");
                    goto case "1";
            }
            //MessageBox.Show("I'm busy!", "Work on main thread...");
        }

        static void Sample2()
        {
            Console.WriteLine("***** Primary Thread Stats *****");

            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";

            Console.WriteLine("Name of Current AppDomain: {0}", Thread.GetDomain().FriendlyName);
            Console.WriteLine("ID of current Context: {0}", Thread.CurrentContext.ContextID);

            Console.WriteLine("Thread Name: {0}", primaryThread.Name);
            Console.WriteLine("Has thread started?: {0}", primaryThread.IsAlive);
            Console.WriteLine("Priority Level: {0}", primaryThread.Priority);
            Console.WriteLine("Thread State: {0}", primaryThread.ThreadState);

        }

        static void AddComlete(IAsyncResult itfAR)
        {
            Console.WriteLine("AddComlete() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete");

            AsyncResult ar = (AsyncResult)itfAR;
            BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10 + 10 is {0}", b.EndInvoke(itfAR));

            string msg = (string)itfAR.AsyncState;
            Console.WriteLine(msg);

            isDone = true;
        }

        static void Adder(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of thread in Adder() {0}", Thread.CurrentThread.ManagedThreadId);

                AddParams ap = (AddParams)data;
                Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);
                waitHandle.Set();
            }
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

        static void Sample1()
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
            IAsyncResult itfAR = b.BeginInvoke(10, 10, null, null);

            Console.WriteLine("Doing more work in Main()!");
            answer = b.EndInvoke(itfAR);
            Console.WriteLine("10 + 10 is {0}", answer);


            Console.WriteLine("\n***** AsyncCallbackDelegate Example *****");
            Console.WriteLine("Main() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);
            b = new BinaryOp(Add);
            itfAR = b.BeginInvoke(10, 10, new AsyncCallback(AddComlete), "Main() thanks for adding these numbers.");

            while (!isDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Working...");
            }

        }
    }
}
