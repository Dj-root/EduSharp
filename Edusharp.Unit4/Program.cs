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

    }
}
