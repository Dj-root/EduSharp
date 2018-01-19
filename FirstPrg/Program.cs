using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EduSharp.Unit3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** My first C# App *****");
            Console.WriteLine("Hello world!");
            Console.WriteLine();

            ShowEnvironmentDetails();
            Console.WriteLine();

            //GetUserData();

            FormatNumericalData();
            Console.WriteLine();

            ParseFromStrings();
            Console.WriteLine();

            UseDatesAndTimes();
            Console.WriteLine();

            StringConcatenation();
            Console.WriteLine();

            FunWithStringBuilder();
            Console.WriteLine();

            StringInterpolation();
            Console.WriteLine();



            Console.ReadLine();
        }

        static void ShowEnvironmentDetails()
        {
            foreach (string drive in Environment.GetLogicalDrives())
            {
                Console.WriteLine("Drive: {0}", drive);
            }
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Version: {0}", Environment.Version);
        }

        private static void GetUserData()
        {
            Console.WriteLine("Please enter your name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Please anter your age: ");
            string userAge = Console.ReadLine();

            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("Hello {0}! You are {1} years old.", userName, userAge);

            Console.ForegroundColor = prevColor;
        }

        private static void FormatNumericalData()
        {
            Console.WriteLine("The value 99999 in various formats: ");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d9}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);
        }

        static void ParseFromStrings()
        {
            Console.WriteLine("=> Data type parsing:");
            bool b = bool.Parse("True");
            Console.WriteLine("Value of b: {0}", b);
            double d = double.Parse("99,884");
            Console.WriteLine("Value of d: {0}", d);
            int i = int.Parse("8");
            Console.WriteLine("Value of i: {0}", i);
            char c = Char.Parse("w");
            Console.WriteLine("Value of c: {0}", c);
            Console.WriteLine();
        }

        static void UseDatesAndTimes()
        {
            Console.WriteLine("=> Dates and Times:");
            DateTime dt = new DateTime(2015, 10, 17);
            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);

            dt = dt.AddMonths(2);
            Console.WriteLine("Dayligth savings: {0}", dt.IsDaylightSavingTime());

            TimeSpan ts = new TimeSpan(4, 30, 0);
            Console.WriteLine(ts);

            Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));
        }

        static void StringConcatenation()
        {
            Console.WriteLine("=> String Copncatenation:");
            string s1 = "Programming the ";
            string s2 = "PsychoDrill (PTP)";
            string s3 = String.Concat(s1, s2);
            Console.WriteLine(s3);
            Console.WriteLine();
        }

        static void FunWithStringBuilder()
        {
            Console.WriteLine("=> Using the StringBuilder:");
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****");
            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", " Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();
        }

        static void StringInterpolation()
        {
            Console.WriteLine("=> String Interpolation:");

            int age = 4;
            string name = "Soren";

            string greeting = string.Format("Hello {0} you are {1} years old.", name, age);
            string greeting2 = $"\a\tHello {name.ToUpper()} you are {age} years old.";

            Console.WriteLine(greeting2.ToString());
        }


    }
}
