using System;

namespace EduSharp.Troelsen.Unit5
{
    public class Motorcycle
    {
        private int driverIntensity;
        public string driverName;

        public Motorcycle()
        {
            Console.WriteLine("In default constructor");
        }

        public Motorcycle(int intensity) : this(intensity, "")
        {
            Console.WriteLine("In ctor taking an int");
        }

        public Motorcycle(string name) : this(0, name)
        {
            Console.WriteLine("In ctor taking a string");
        }

        public Motorcycle(int intensity, string name)
        {
            Console.WriteLine("In master ctor");
            if (intensity > 10)
            {
                intensity = 10;
            }

            driverIntensity = intensity;
            driverName = name;
        }

        //{
        //    driverIntensity = intensity;
        //}

        public void SetDriverName(string name)
        {
            this.driverName = name;
        }

        public void PopAHweely()
        {
            Console.WriteLine("Yeeeeeeeeeee Haaaaaeeeeewww!");
        }
    }
}