using System;

namespace EduSharp.Troelsen.Unit8
{
    public class Triangle:Shape,IPointy
    {
        public Triangle(string name = "NoName") : base(name)
        {
        }


        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Triangle", PetName);
        }


        public byte Points
        {
            get {return 3;}
        }
    }
}