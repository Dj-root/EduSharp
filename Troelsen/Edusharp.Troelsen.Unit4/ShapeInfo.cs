using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edusharp.Troelsen.Unit4
{
    public class ShapeInfo
    {
        public string infoString;

        public ShapeInfo(string info)
        {
            infoString = info;
        }

        struct Rectangle
        {
            public ShapeInfo RectInfo;
            public int rectTop, rectLeft, rectBottom, rectRight;

            public Rectangle(string info, int top, int left, int bottom, int right)
            {
                RectInfo = new ShapeInfo(info);
                rectTop = top;
                rectBottom = bottom;
                rectLeft = left;
                rectRight = right;
            }

            public void Display()
            {
                Console.WriteLine("String = {0}, Top = {1}, Bottom = {2}, Left = {3}, Right = {4}",
                    RectInfo.infoString, rectTop, rectBottom, rectLeft, rectRight);
            }
        }

        public static void ValueTypeContainingRefType()
        {
            Console.WriteLine("=> Creating r1");
            Rectangle r1 = new Rectangle("First Rect", 10, 10, 50, 50);

            Console.WriteLine("=> Assigning r2 to r1");
            Rectangle r2 = r1;

            Console.WriteLine("=> Changing value of r2");
            r2.RectInfo.infoString = "This in new info!";
            r2.rectBottom = 4444;

            r1.Display();
            r2.Display();
        }


    }
}
