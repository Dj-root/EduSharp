using System;

namespace EduSharp.Unit8
{
    public class Hexagon: Shape, IPointy, IDraw3D
    {
        public Hexagon(string name = "NoName") : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }

        public void Draw3D()
        {
            Console.WriteLine("Drawing Hexagon in 3D");
        }

        public byte Points
        {
            get { return 6; }
        }
    }
}