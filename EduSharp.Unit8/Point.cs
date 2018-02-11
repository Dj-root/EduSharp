using System;

namespace EduSharp.Unit8
{
    public class Point: ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointDescription desc = new PointDescription();

        public Point(int x, int y, string petName)
        {
            X = x;
            Y = y;
            desc.PetName = petName;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point() { }

        public override string ToString()
        {
            return String.Format("X = {0}; Y = {1}, Name = {2};\nID = {3}", 
                X, Y, desc.PetName, desc.PointID);
        }

        public object Clone()
        {
//            return new Point(this.X, this.Y);
//            return this.MemberwiseClone();

            Point newPoint = (Point) this.MemberwiseClone();

            PointDescription currentDesc = new PointDescription();
            currentDesc.PetName = this.desc.PetName;
            newPoint.desc = currentDesc;
            return newPoint;
        }
    }
}