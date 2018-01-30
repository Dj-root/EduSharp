using System;

namespace EduSharp.Unit6
{
     class Hexagon:Shape
    {
        public Hexagon(string name = "NoName") : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }
    }
}