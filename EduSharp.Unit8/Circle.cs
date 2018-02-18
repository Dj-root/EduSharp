using System;

namespace EduSharp.Troelsen.Unit8
{
     class Circle:Shape
    {
        public Circle()
        {
        }
        public Circle(string name = "NoName") : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Circle", PetName);
        }
    }
}