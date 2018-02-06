using System;

namespace EduSharp.Unit8
{
    public class Hexagon: Shape, IPointy
    {
        public Hexagon(string name = "NoName") : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }

        public byte Points
        {
            get { return 6; }
        }
    }
}