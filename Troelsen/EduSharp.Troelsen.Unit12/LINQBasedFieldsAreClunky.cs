using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Troelsen.Unit12
{
    class LINQBasedFieldsAreClunky
    {
        private static string[] currentVideoGames = { "Morrovind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
        private IEnumerable<string> subset = from g in currentVideoGames where g.Contains(" ") orderby g select g;

        public void PrintGames()
        {
            foreach (var VARIABLE in subset)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
}
