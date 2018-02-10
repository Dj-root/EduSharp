using System;

namespace EduSharp.Unit8
{
    public class Octagon:IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        public void Draw()
        {
            Console.WriteLine("Drawing the Octagon...");
        }
    }
}