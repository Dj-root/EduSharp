using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Troelsen.Unit12
{
    class VeryComplexQueryExpression
    {
        public static void QueryStringWithRawDelegates()
        {
            Console.WriteLine("***** Using Raw Delegated *****");

            string[] currentVideoGames = { "Morrovind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            Func<string, bool> searchFilter = new Func<string, bool>(Filter);
            Func<string, string> itemToProcess = new Func<string, string>(ProcessItem);

            var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);
            foreach (var game in subset)
            {
                Console.WriteLine("Item: {0}", game);
            }

            Console.WriteLine();
        }

        public static bool Filter(string game)
        {
            return game.Contains(" ");
        }

        public static string ProcessItem(string game)
        {
            return game;
        }
    }
}
