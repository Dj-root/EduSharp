using System;

namespace EduSharp.Unit5
{
    public class Car
    {
        public string PetName { get; set; }
        public int CurrSpeed { get; set; }
        public string Color { get; set; }

        public Car()
        {
            this.PetName = "Chuck";
            this.CurrSpeed = 10;
        }

        public Car(string pn)
        {
            this.PetName = pn;
        }

        public Car(string petName, int currSpeed, string color)
        {
            this.PetName = petName;
            this.CurrSpeed = currSpeed;
            this.Color = color;
        }

//        public void PrintState()
//        {
//            Console.WriteLine("{0} is going {1} MPH.", PetName, CurrSpeed);
//        }

        public void DisplayStats()
        {
            Console.WriteLine("Car name: {0}", PetName);
            Console.WriteLine("Speed: {0}", CurrSpeed);
            Console.WriteLine("Color: {0}", Color);
        }

        public void SpeedUp(int delta)
        {
            CurrSpeed += delta;
        }
    }
}