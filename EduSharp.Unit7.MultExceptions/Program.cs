using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Troelsen.Unit7.MultExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Handling Multiple Exceptions *****\n");
            Car myCar = new Car("Rusty", 90);
            myCar.CrankTunes(true);
            try
            {
                myCar.Accelerate(20);
            }
            catch (CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
//                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                myCar.CrankTunes(false);
            }

            Console.ReadLine();
        }
    }
}
