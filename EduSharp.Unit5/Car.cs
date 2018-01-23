using System;

namespace EduSharp.Unit5
{
    public class Car
    {
        public string petName;
        public int currSpeed;

        public Car()
        {
            this.petName = "Chuck";
            this.currSpeed = 10;
        }

        public Car(string pn)
        {
            this.petName = pn;
        }

        public Car(string petName, int currSpeed)
        {
            this.petName = petName;
            this.currSpeed = currSpeed;
        }

        public void PrintState()
        {
            Console.WriteLine("{0} is going {1} MPH.", petName, currSpeed);
        }

        public void SpeedUp(int delta)
        {
            currSpeed += delta;
        }
    }
}