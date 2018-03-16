using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EduSharp.Troelsen.Unit19
{
    class Printer
    {
        private object threadLock = new object();

        public void PrintNumbers()
        {
            lock (threadLock)
            {
                Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

                Console.Write("Your numbers:");
                for (int i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(100 * r.Next(5));
                    Console.Write("{0}, ", i);
                }

                Console.WriteLine();
            }
        }
    }
}
