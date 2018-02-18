using System;

namespace EduSharp.Troelsen.Unit8
{
    public class Rectangle:IShape
    {
        public int GetNumberOfSides()
        {
            return 4;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing...");
        }

        public void Print()
        {
            Console.WriteLine("Printing...");
        }
    }
}