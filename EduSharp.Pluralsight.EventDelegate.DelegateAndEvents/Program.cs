using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Pluralsight.EventDelegate.DelegateAndEvents
{
    public delegate int BizRulesDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lambdas *****\n");

            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;


            var data = new ProcessData();
            data.Process(2,3, addDel);
            data.Process(2, 3, multiplyDel);



            Console.WriteLine("\n***** Fun with Delegates *****\n");
            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            //del1 += del2 + del3;

            //int finalHours =  del1(10, WorkType.GoToMeetings);
            //Console.WriteLine(finalHours);

            var worker = new Worker();
            //            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            //            worker.WorkCompleted+= new EventHandler(Worker_WorkCompleted);


            //            worker.WorkPerformed += Worker_WorkPerformed;
            worker.WorkPerformed += (s, e) => Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);

            //            worker.WorkCompleted += Worker_WorkCompleted;
            worker.WorkCompleted += (s, e) => Console.WriteLine("Worker is done");

            //            worker.WorkCompleted -= Worker_WorkCompleted;
            worker.DoWork(8, WorkType.GenerateReports);


            Console.Read();

        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
        }

        //        static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //        {
        //            Console.WriteLine("Hours worked: "+e.Hours + " " + e.WorkType);
        //        }

        static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Worker is done");
        }

        //static int WorkPerformed1(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed1 called {0}", hours);
        //    return hours + 1;
        //}

        //static int WorkPerformed2(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed2 called {0}", hours);
        //    return hours + 2;
        //}

        //static int WorkPerformed3(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed3 called {0}", hours);
        //    return hours + 3;
        //}

        //static void DoWork(WorkPerformedHandler del)
        //{
        //    del(5, WorkType.GoToMeetings);
        //}
    }


    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
