using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Edusharp.Unit4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Methods *****\n");

            int ans;
            Add(90, 90, out ans);
            Console.WriteLine("90 + 90 = {0}", ans);
            Console.WriteLine();

            int i;
            string str;
            bool b;
            FillTheseValue(out i, out str, out b);
            Console.WriteLine("Int is: {0}", i);
            Console.WriteLine("String is: {0}", str);
            Console.WriteLine("Boolean is: {0}", b);
            Console.WriteLine();

            string str1 = "Flip";
            string str2 = "Flop";
            Console.WriteLine("Before: {0}, {1}", str1, str2);
            SwapStrings(ref str1, ref str2);
            Console.WriteLine("After: {0}, {1}", str1, str2);
            Console.WriteLine();

            // Pass in a comma-delimited list of doubles…
            double average;
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine("Average of data is: {0}", average);
            // …or pass an array of doubles.
            double[] data = { 4.0, 3.2, 5.7 };
            average = CalculateAverage(data);
            Console.WriteLine("Average of data is: {0}", average);
            // Average of 0 is 0!
            Console.WriteLine("Average of data is: {0}", CalculateAverage());
            Console.WriteLine();


            EnterLogData("Oh no! Grid can't find data");
            EnterLogData("Oh no! I can't find the payroll data", "CFO");
            Console.WriteLine();


            DateTime timeStamp = DateTime.Now;
            Console.WriteLine("Current time is: {0}", timeStamp);
            Console.WriteLine();

            ////////////////////////////////////////////////////////////////////////

            Console.WriteLine("***** Fun with Arrays *****");
            SimpleArrays();
            Console.WriteLine();

            RectMultidimensionalArray();
            Console.WriteLine();

            JaggedMultidimensionalArray();
            Console.WriteLine();

            PassAndReceiveArrays();
            Console.WriteLine();



            Console.WriteLine("**** Fun with Enums ****");
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);
            Console.WriteLine("EmpType uses a {0} for storage", Enum.GetUnderlyingType(emp.GetType()));
            Console.WriteLine("EmpType uses a {0} for storage", Enum.GetUnderlyingType(typeof(EmpType)));
            Console.WriteLine("emp is a {0}", emp.ToString());
            Console.WriteLine("{0} = {1}", emp.ToString(), (byte)emp);

            EmpType e2 = EmpType.Contractor;

            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor cc = ConsoleColor.Gray;

            EvaluateEnum(e2);
            EvaluateEnum(day);
            EvaluateEnum(cc);
            Console.WriteLine();

            Console.WriteLine("***** A First Look at Structures *****\n");
            Point myPoint;
            myPoint.X = 349;
            myPoint.Y = 76;
            myPoint.Display();

            myPoint.Increment();
            myPoint.Display();

            Point p2 = new Point(50, 60);
            p2.Display();

            Program.ValueTypeAssigment();
            Console.WriteLine();

            ShapeInfo.ValueTypeContainingRefType();
            Console.WriteLine();

            Console.WriteLine("***** Passing Person object by value *****");
            Person fred = new Person("Fred", 12);
            Console.WriteLine("\nDefore by value call, Person is: ");
            fred.Display();

            fred.SendPersonByValue(fred);
            Console.WriteLine("\nAfter by value call, Person is:");
            fred.Display();

            Console.WriteLine("***** Passing Person object by reference *****");
            Person mel = new Person("Mel", 23);
            Console.WriteLine("Before by ref call, Person is:");
            mel.Display();

            Person.SendAPersonByReference(ref mel);
            Console.WriteLine("After by ref call, Person is:");
            mel.Display();
            Console.WriteLine();

            Console.WriteLine("***** Fun with Nullable Data *****\n");
            DatabaseReader dr = new DatabaseReader();
            int? ii = dr.GetIntFromDatabase();
            if (ii.HasValue)
            {
                Console.WriteLine("Value of 'ii' is: {0}", ii.Value);
            }
            else
            {
                Console.WriteLine("Value of 'ii' is undefined");
            }

            bool? bb = dr.GetBollFromDatabase();
            if (bb != null)
            {
                Console.WriteLine("Value of 'bb' is: {0}", bb.Value);
            }
            else
            {
                Console.WriteLine("Value of 'bb' is undefined");
            }
            Console.WriteLine();

            int myData = dr.GetIntFromDatabase() ?? 100;
            Console.WriteLine("Value of myData: {0}", myData);

            int? moreData = dr.GetIntFromDatabase();
            if (!moreData.HasValue)
            {
                moreData = 100;
            }

            Console.WriteLine("Value of moreData: {0}", moreData);
            Console.WriteLine();

            TesterMethod(null);



            Console.ReadLine();
        }

        static void TesterMethod(string[] args)
        {
            Console.WriteLine($"You sent me {args?.Length ?? 0} arguments.");
        }

        struct Point
        {
            public int X;
            public int Y;

            public Point(int XPos, int YPos)
            {
                X = XPos;
                Y = YPos;
            }

            public void Increment()
            {
                X++;
                Y++;
            }

            public void Decrement()
            {
                X--;
                Y--;
            }

            public void Display()
            {
                Console.WriteLine("X = {0}, Y = {1}", X, Y);
            }
        }

        static void ValueTypeAssigment()
        {
            Console.WriteLine("\nAssigning value types\n");

            Point p1 = new Point(10, 10);
            Point p2 = p1;

            p1.Display();
            p2.Display();

            p1.X = 100;
            Console.WriteLine("\n=> Changed p1.X");
            p1.Display();
            p2.Display();
        }

        enum EmpType
        {
            Manager,
            Grunt,
            Contractor,
            VicePresident
        }

        static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock option instead?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("You have got to be kidding...");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("You already get enough cash...");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("VERY GOOD, Sir!");
                    break;
            }
        }

        static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information about {0}", e.GetType().Name);

            Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()));

            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members", enumData.Length);

            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}", enumData.GetValue(i));
            }

            Console.WriteLine();
        }

        static void Add(int x, int y, out int ans)
        {
            ans = x + y;
        }

        static void FillTheseValue(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string";
            c = true;
        }

        public static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }

        public static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} doubles", values.Length);

            double sum = 0;
            if (values.Length == 0)
            {
                return sum;
            }

            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }

            return (sum / values.Length);
        }

        static void EnterLogData(string message, string owner = "Programmer")
        {
            //            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
            //            Console.WriteLine("Time of Error: {0}", timeStamp);
        }

        static void SimpleArrays()
        {
            Console.WriteLine("=> Simple Array Creation.");
            int[] myInts = new int[3];
            myInts[0] = 100;
            myInts[1] = 200;
            myInts[2] = 300;

            foreach (int i in myInts)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            string[] booksOnDotNet = new string[100];
            Console.WriteLine();
        }

        static void RectMultidimensionalArray()
        {
            Console.WriteLine("=> Rectangular multidimensional array.");
            int[,] myMatrix;
            myMatrix = new int[3, 4];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    myMatrix[i, j] = i * j;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(myMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void JaggedMultidimensionalArray()
        {
            Console.WriteLine("=> Jagged multidimensional array.");
            // A jagged MD array (i.e., an array of arrays).
            // Here we have an array of 5 different arrays.

            int[][] myJagArray = new int[5][];

            for (int i = 0; i < myJagArray.Length; i++)
            {
                myJagArray[i] = new int[i + 7];
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < myJagArray[i].Length; j++)
                {
                    Console.Write(myJagArray[i][j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

        }

        static void PrintArray(int[] myInts)
        {
            for (int i = 0; i < myInts.Length; i++)
            {
                Console.WriteLine("Item {0} is {1}", i, myInts[i]);
            }
        }

        static string[] GetStringArray()
        {
            string[] theStrings = { "Hello", "from", "GetStringArray" };
            return theStrings;
        }

        static void PassAndReceiveArrays()
        {
            Console.WriteLine("=> Arrays as params and return values.");
            // Pass array as parameter.
            int[] ages = { 20, 22, 23, 0 };
            PrintArray(ages);

            string[] strs = GetStringArray();
            foreach (string s in strs)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();
        }
    }
}
