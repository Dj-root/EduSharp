using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Unit8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** First Look at Interfaces *****");
            string myStr = "Hello";
            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
            System.Data.SqlClient.SqlConnection sqlCnn = new SqlConnection();

            CloneMe(myStr);
            CloneMe(unixOS);
            CloneMe(sqlCnn);



            Console.ReadLine();
        }

        private static void CloneMe(ICloneable c)
        {
            object theClone = c.Clone();
            Console.WriteLine("Your clone is a: {0}", theClone.GetType().Name);
        }
    }
}
