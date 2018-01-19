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
            

            EnterLogData("Oh no! Grid can't find data");
            EnterLogData("Oh no! I can't find the payroll data", "CFO");
            Console.WriteLine();





            Console.ReadLine();
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
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }




    }
}
