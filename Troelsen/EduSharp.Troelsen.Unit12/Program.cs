using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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


            Console.WriteLine("\n***** Fun with Query Expressions ******");
            ProductInfo[] itemsInStock = new[]
            {
                new ProductInfo {Name = "Mac's Coffee", Description = "Coffee with TEETH", NumberInStock = 24},
                new ProductInfo {Name = "Milk Maid Milk", Description = "Milk cow's love", NumberInStock = 100},
                new ProductInfo {Name = "Pure Silk Tofe", Description = "Bland as Possible", NumberInStock = 120},
                new ProductInfo {Name = "Cruchy Pops", Description = "Cheezy, peppery goodness", NumberInStock = 2},
                new ProductInfo
                {
                    Name = "RipOff Water",
                    Description = "From the tap to your wallet",
                    NumberInStock = 100
                },
                new ProductInfo
                {
                    Name = "Classic Valpo Pizza",
                    Description = "Everyone loves pizza!",
                    NumberInStock = 73
                }
            };

            SelectEverything(itemsInStock);
            ListProductNames(itemsInStock);
            GetOverstock(itemsInStock);
            GetNamesAndDescriptions(itemsInStock);

            Console.WriteLine("=== Projection data ===");
            Array objs = GetProjectedSubset(itemsInStock);
            foreach (object o in objs)
            {
                Console.WriteLine(o);
            }

            GetCountFromQuery();
            ReverseEverything(itemsInStock);
            AlphabetizeProductNames(itemsInStock);

            DisplayDiff();
            AggregateOps();

            QueryStringWithOperators();
            QueryStringsWithEnumerableAndLambdas();
            QueryStringsWithAnonymousMethods();

            VeryComplexQueryExpression.QueryStringWithRawDelegates();

            Console.ReadLine();
        }



        static void QueryStringsWithAnonymousMethods()
        {
            Console.WriteLine("\n***** Using Anonymous Methods *****");

            string[] currentVideoGames = { "Morrovind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            Func<string, bool> searchFilter = delegate(string game) { return game.Contains(" ");};
            Func<string, string> itemToProcess = delegate(string s) { return s; };


            var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);
            foreach (var game in subset)
            {
                Console.WriteLine("Item: {0}", game);
            }

            Console.WriteLine();
        }

        static void QueryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine("\n***** Using Enumerable / Lambda Expressions *****");

            string[] currentVideoGames = { "Morrovind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            var subset = currentVideoGames.Where(game => game.Contains(" ")).OrderBy(game => game).Select(game => game);
            foreach (var game in subset)
            {
                Console.WriteLine("Item: {0}",game);
            }

            Console.WriteLine();
        }

        static void QueryStringWithOperators()
        {
            Console.WriteLine("\n***** Using Query Operators *****");
            string[] currentVideoGames = { "Morrovind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            var subset = from game in currentVideoGames where game.Contains(" ") orderby game select game;

            foreach (string s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }
        }

        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };
            Console.WriteLine("=== Aggregate Operands ===");
            Console.WriteLine("Max temp: {0}",
                (from t in winterTemps select t).Max());

            Console.WriteLine("Min temp: {0}",
                (from t in winterTemps select t).Min());

            Console.WriteLine("Average temp: {0}",
                (from t in winterTemps select t).Average());

            Console.WriteLine("Sum of all temps: {0}",
                (from t in winterTemps select t).Sum());
        }

        static void DisplayDiff()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            Console.WriteLine("\n=== Different variations of connections ===");
            Console.WriteLine("Difference:");

            var carDiff = (from c in myCars select c).Except(from c2 in yourCars select c2);
            Console.WriteLine("Here is what you don't have, but I do:");
            foreach (string s in carDiff)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nCommon items:");
            var carUnion = (from c in myCars select c).Union(from c2 in yourCars select c2);
            Console.WriteLine("Here is everything:");
            foreach (string s in carUnion)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nConcatenation:");
            var carConcat = (from c in myCars select c).Concat(from c in yourCars select c);
            foreach (string s in carConcat.Distinct())
            {
                Console.WriteLine(s);
            }
        }

        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            Console.WriteLine("\nAll products in alphabet order:");
            var allProducts = from p in products orderby p.Name select p;

            foreach (var prod in allProducts)
            {
                Console.WriteLine(prod.ToString());
            }
        }

        static void ReverseEverything(ProductInfo[] products)
        {
            Console.WriteLine("\nAll products in reverse:");
            var allProducts = from p in products select p;

            foreach (var prod in allProducts.Reverse())
            {
                Console.WriteLine(prod.ToString());
            }
        }

        static void GetCountFromQuery()
        {
            string[] currentVideoGames = { "Morrovind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            int numb = (from g in currentVideoGames where g.Length > 6 select g).Count();

            Console.WriteLine("=== Counts... ===");
            Console.WriteLine("{0} items honor the LINQ query", numb);
        }

        static Array GetProjectedSubset(ProductInfo[] products)
        {
            var nameDesc = from p in products select new { p.Name, p.Description };
            return nameDesc.ToArray();
        }

        static void GetNamesAndDescriptions(ProductInfo[] products)
        {
            Console.WriteLine("\nNames and Descriptions:");
            var nameDesc = from p in products select new { p.Name, p.Description };

            foreach (var item in nameDesc)
            {
                Console.WriteLine(item.ToString());
            }
        }


        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("\nThe overstock items:");
            var overstock = from p in products where p.NumberInStock > 25 select p;

            foreach (var p in overstock)
            {
                Console.WriteLine(p.ToString());
            }
        }

        static void ListProductNames(ProductInfo[] products)
        {
            Console.WriteLine("\nOnly product names:");
            var names = from p in products select p.Name;

            foreach (var n in names)
            {
                Console.WriteLine("Name: {0}", n);
            }
        }

        static void SelectEverything(ProductInfo[] products)
        {
            Console.WriteLine("\nAll product details:");
            var allProducts = from p in products select p;

            foreach (var prod in allProducts)
            {
                Console.WriteLine(prod.ToString());
            }
        }

        static void OfTypeAsFilter()
        {
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });

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
