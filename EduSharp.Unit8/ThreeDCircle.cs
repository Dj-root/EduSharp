using System;

namespace EduSharp.Unit8
{
     class ThreeDCircle:Circle, IDraw3D
    {
        public ThreeDCircle()
        {
        }

        public ThreeDCircle(string name = "NoName") : base(name)
        {
        }

        public void Draw3D()
        {
            Console.WriteLine("Drawing Circle in 3D!");
        }
    }
}