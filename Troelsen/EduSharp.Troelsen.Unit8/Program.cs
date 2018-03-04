using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Troelsen.Unit8
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
                itfPt = (IPointy)c;
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

            Shape[] myShapes = { new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("JoJo") };
            for (int i = 0; i < myShapes.Length; i++)
            {
                myShapes[i].Draw();
                if (myShapes[i] is IPointy)
                {
                    Console.WriteLine("-> Points: {0}", ((IPointy)myShapes[i]).Points);
                }
                else
                {
                    Console.WriteLine("-> {0}\'s not pointy!", myShapes[i].PetName);
                }
                Console.WriteLine();
            }
            // ====================================================
            Console.WriteLine("***** Fun with Interfaces *****");
            Shape[] myNewShapes = { new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("JoJo"), };
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
                if (myNewShapes[i] is IDraw3D)
                {
                    DrawIn3D((IDraw3D)myNewShapes[i]);
                }
            }

            Console.WriteLine("\nTesting the FindFirstPointyShape method");
            IPointy firstPointItem = FindFirstPointyShape(myNewShapes);
            Console.WriteLine("The item has {0} points. Item type is {1}", firstPointItem.Points, firstPointItem.GetType());

            //==========================================================
            Console.WriteLine("\n***** Fun with Interface Name Clashes *****");
            Octagon oct = new Octagon();

            IDrawToForm itfForm = (IDrawToForm)oct;
            itfForm.Draw();

            //            IDrawToPrinter itfPrinter = (IDrawToPrinter) oct;
            //            itfPrinter.Draw();

            ((IDrawToPrinter)oct).Draw();

            //            IDrawToMemory itfMemory = (IDrawToMemory) oct;
            //            itfMemory.Draw();

            if (oct is IDrawToMemory)
            {
                ((IDrawToMemory)oct).Draw();
            }



            Console.WriteLine("\n***** Simple Interface Hierarchy *****");
            BitmapImage myBitmap = new BitmapImage();
            myBitmap.Draw();
            myBitmap.DrawInBoundingBox(10, 10, 100, 150);
            myBitmap.DrawUpsideDown();

            IAdvancedDraw iAdvDraw = myBitmap as IAdvancedDraw;
            if (iAdvDraw != null)
            {
                iAdvDraw.DrawUpsideDown();
            }

            // ==========================================
            Console.WriteLine("\n***** Fun with IEnumerable / IEnumerator *****\n");
            Garage carLot = new Garage();
            foreach (Car cc in carLot)
            {
                Console.WriteLine("{0} is going {1} MPH", cc.PetName, cc.CurrentSpeed);
            }

            Console.WriteLine("\n***** Fun with the Yield keyword *****\n");
            foreach (Car cc in carLot)
            {
                Console.WriteLine("{0} is going {1} MPH", cc.PetName, cc.CurrentSpeed);
            }
            Console.WriteLine("\nPrinting in Reverse order\n");

            foreach (Car cc in carLot.GetTheCars(true))
            {
                Console.WriteLine("{0} is going {1} MPH", cc.PetName, cc.CurrentSpeed);
            }

            // ===============================================
            Console.WriteLine("\n***** Fun with Object Clonning *****\n");
            Point p1 = new Point(50, 50);
            Point p2 = p1;
            p2.X = 0;

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Point p3 = new Point(100, 100, "Jane");
            Point p4 = (Point)p3.Clone();

            Console.WriteLine("\nBefore Modification:");
            Console.WriteLine("p3: {0}", p3);
            Console.WriteLine("p4: {0}", p4);

            p4.desc.PetName = "My new Point";
            p4.X = 9;

            Console.WriteLine("\nChanged p4.desc.petName and p4.X");
            Console.WriteLine("After Modification:");
            Console.WriteLine("p3: {0}", p3);
            Console.WriteLine("p4: {0}", p4);


            // ===============================================
            Console.WriteLine("\n***** Fun with Object Sorting *****\n");

            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("Rusty", 80, 1);
            myAutos[1] = new Car("Mary", 40,234);
            myAutos[2] = new Car("Viper", 40, 34);
            myAutos[3] = new Car("Mel", 40,4);
            myAutos[4] = new Car("Chucky",40,5);

            Console.WriteLine("Here is unordered set of cars:");
            foreach (Car cc in myAutos)
            {
                Console.WriteLine("{0} \t{1}", cc.CarID, cc.PetName);
            }

            Array.Sort(myAutos);
            Console.WriteLine();

            Console.WriteLine("Here is ordered set of cars:");
            foreach (Car cc in myAutos)
            {
                Console.WriteLine("{0} \t{1}", cc.CarID, cc.PetName);
            }

            Array.Sort(myAutos, Car.SortByPetName);
            Console.WriteLine("\nOrdering by PetName:");
            foreach (Car cc in myAutos)
            {
                Console.WriteLine("{0} \t{1}", cc.CarID, cc.PetName);
            }





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
