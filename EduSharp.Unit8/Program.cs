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

//            ===================================================================
            Console.WriteLine("\n***** First Look at Interfaces *****");
            Hexagon hex = new Hexagon();
            Console.WriteLine("Points: {0}", hex.Points);

            Circle c = new Circle("Lisa");
            IPointy itfPt = null;
            try
            {
                itfPt = (IPointy) c;
                Console.WriteLine(itfPt.Points);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            Hexagon hex2 = new Hexagon("Peter");
            IPointy itfPt2 = hex2 as IPointy;

            if (itfPt2 != null)
            {
                Console.WriteLine("Points: {0}", itfPt2.Points);
            }
            else
            {
                Console.WriteLine("OOPS! Not pointy...");
            }

            Shape[] myShapes = {new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("JoJo")};
            for (int i = 0; i < myShapes.Length; i++)
            {
                myShapes[i].Draw();
                if (myShapes[i] is IPointy)
                {
                    Console.WriteLine("-> Points: {0}", ((IPointy) myShapes[i]).Points);
                }
                else
                {
                    Console.WriteLine("-> {0}\'s not pointy!", myShapes[i].PetName);
                }
                Console.WriteLine();
            }
            // ====================================================
            Console.WriteLine("***** Fun with Interfaces *****");
            Shape[] myNewShapes = {new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("JoJo"),};
            for (int i = 0; i < myNewShapes.Length; i++)
            {
                myNewShapes[i].Draw();
                if (myNewShapes[i] is IPointy)
                {
                    Console.WriteLine("-> Points: {0}", ((IPointy)myNewShapes[i]).Points);
                }
                else
                {
                    Console.WriteLine("-> {0}\'s not pointy!", myNewShapes[i].PetName);
                }
                if (myNewShapes[i]is IDraw3D)
                {
                    DrawIn3D((IDraw3D )myNewShapes[i]);
                }
            }

            Console.WriteLine("\nTesting the FindFirstPointyShape method");
            IPointy firstPointItem = FindFirstPointyShape(myNewShapes);
            Console.WriteLine("The item has {0} points", firstPointItem.Points);




            Console.ReadLine();
        }

        private static void CloneMe(ICloneable c)
        {
            object theClone = c.Clone();
            Console.WriteLine("Your clone is a: {0}", theClone.GetType().Name);
        }

        static void DrawIn3D(IDraw3D itf3d)
        {
            Console.WriteLine("-> Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }

        static IPointy FindFirstPointyShape(Shape[] shapes)
        {
            foreach (Shape s in shapes)
            {
                if (s is Shape)
                {
                    return s as IPointy;
                }
            }
            return null;
        }




    }
}
