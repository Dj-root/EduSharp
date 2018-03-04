using System;

namespace EduSharp.Troelsen.Unit8
{
    public class Square:IShape
    {
        public int GetNumberOfSides()
        {
            return 4;
        }

        void IDrawable.Draw()
        {
            Console.WriteLine("Drawing to screen...");
        }

        public void Print()
        {
            Console.WriteLine("Printing...");
        }

        void IPrintable.Draw()
        {
            Console.WriteLine("Drawing to printer...");
        }
    }
}