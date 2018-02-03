using System;

namespace EduSharp.Unit6
{
     class ThreeDCircle:Circle
    {
        public new string PetName { get; set; }

        public new void Draw()
        {
            Console.WriteLine("Drawing 3D Circle");
        }
    }
}