using System;
using EduSharp.Unit10;

namespace EduSharp.Troelsen.Unit10
{
    public class CarEvent
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }

        private bool carIsDead;

        public CarEvent() { }

        public CarEvent(string petName, int maxSpeed, int currentSpeed)
        {
            CurrentSpeed = currentSpeed;
            MaxSpeed = maxSpeed;
            PetName = petName;
        }

        public delegate void CarEngineHandler(object sender, CarEventArgs e);

        public CarEngineHandler listOfHandlers;

        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            //            listOfHandlers = methodToCall;
            if (listOfHandlers == null)
            {
                listOfHandlers = methodToCall;
            }
            else
            {
                Delegate.Combine(listOfHandlers, methodToCall);
            }
        }

        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;

        }

        public void Accelerate(int delta)
        {

            //            if (listOfHandlers != null)
            //            {
            //                listOfHandlers("Sorry, this car is dead...");
            //            }

            if (carIsDead)
            {
                Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;
                if (10 == (MaxSpeed - CurrentSpeed) && AboutToBlow != null)
                {
                    AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
                }
                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }



    }
}