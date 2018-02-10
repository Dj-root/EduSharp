using System;

namespace EduSharp.Unit8
{
    public class BitmapImage:IAdvancedDraw
    {
        public void DrawInBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine("Drawing in a box...");
        }

        public void DrawUpsideDown()
        {
            Console.WriteLine("Drawing upside down!");
        }

        public void Draw()
        {
            Console.WriteLine("Drawing...");
        }
    }
}