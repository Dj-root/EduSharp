using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Troelsen.Unit12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ Objects ******\n");
            QueryOverStrings();
            QueryOverInts();


            Console.WriteLine("\n***** LINQ Return Values ******\n");
            IEnumerable<string> subset = GetStringSubset();

            foreach (var VARIABLE in subset)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("\n***** Fun with LINQ Over Generic Collections ******\n");

            List<Car> myCars = new List<Car>()
            {
                new Car {PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car {PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car {PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car {PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car {PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };

            GetFastCars(myCars);
            GetFastBMWs(myCars);

            LINQOverArrayList();

            OfTypeAsFilter();


            Console.ReadLine();
        }

        static void OfTypeAsFilter()
        {
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[]{10, 400, 8, false, new Car(), "string data"});

            var myInts = myStuff.OfType<int>();

            Console.WriteLine("\n=== Filtering Using OfType<T> ===");
            foreach (var VARIABLE in myInts)
            {
                Console.WriteLine("Int value: {0}", VARIABLE);
            }
        }

        static void LINQOverArrayList()
        {
            Console.WriteLine("\n***** LINQ over ArrayList *****");
            ArrayList myCars = new ArrayList{
                new Car {PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car {PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car {PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car {PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car {PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };
            var myCarsEnum = myCars.OfType<Car>();

            var fastCars = from c in myCarsEnum where c.Speed > 55 select c;
            foreach (var VARIABLE in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", VARIABLE.PetName);
            }
        }

        static void GetFastBMWs(List<Car> myCars)
        {
            var fastCars = from c in myCars where c.Speed > 90 && c.Make.Contains("BMW") select c;

            Console.WriteLine("=== Get BMW Cars faster than 90 MPH ===");
            foreach (var VARIABLE in fastCars)
            {
                Console.WriteLine("{0} is doing too fast", VARIABLE.PetName);
            }
        }

        static void GetFastCars(List<Car> myCars)
        {
            var fastCars = from c in myCars where c.Speed > 55 select c;
            Console.WriteLine("=== Get Cars faster than 55 MPH ===");
            foreach (var VARIABLE in fastCars)
            {
                Console.WriteLine("{0} is doing too fast", VARIABLE.PetName);
            }
        }

        static IEnumerable<string> GetStringSubset()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            IEnumerable<string> theRedColors = from c in colors where c.Contains("Red") select c;

            return theRedColors;
        }

        static void ImmediateExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            int[] subsetAsIntArray = (from i in numbers where i < 10 select i).ToArray<int>();
            List<int> subsetAsList = (from i in numbers where i < 10 select i).ToList<int>();
        }

        static void QueryOverInts()
        {
            Console.WriteLine("\n=== Work With Ints ===");
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            IEnumerable<int> subset = from i in numbers where i < 10 select i;

            Console.WriteLine("=== Ints Less Than 10 ===");
            foreach (int i in subset)
            {
                Console.WriteLine("Item: {0} < 10", i);
            }

            numbers[0] = 4;

            Console.WriteLine("=== Ints Less Than 10 ===");
            foreach (int j in subset)
            {
                Console.WriteLine("Item: {0} < 10", j);
            }
            ReflectOverQueryResults(subset);

        }

        static void QueryOverStrings()
        {
            string[] currentVideoGames = { "Morrovind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            IEnumerable<string> subset = from g in currentVideoGames where g.Contains(" ") select g;

            Console.WriteLine("=== Games with WhiteSpace ===");
            foreach (string s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }

            ReflectOverQueryResults(subset);
        }

        static void ReflectOverQueryResults(object resultSet)
        {
            Console.WriteLine("=== Info About Query ===");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }
    }
}
