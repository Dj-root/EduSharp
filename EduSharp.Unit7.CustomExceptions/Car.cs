using System;

namespace EduSharp.Troelsen.Unit7.CustomExceptions
{
    public class Car
    {
        public const int MaxSpeed = 100;

        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";

        private bool carIsDead;

        private Radio theMusicBox = new Radio();

        public Car()
        {
        }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public void CrankTunes(bool state)
        {
            theMusicBox.TurnOn(state);
        }

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                Console.WriteLine("{0} is out of order...", PetName);
            }
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed >= MaxSpeed)
                {
                    //                    Console.WriteLine("{0} has overheated!", PetName);
                    //                    CurrentSpeed = 0;
                    //                    carIsDead = true;
                    CarIsDeadException ex = new CarIsDeadException(string.Format("{0} has overheated!", PetName), "You have a lead foot", DateTime.Now);
                    ex.HelpLink = "http://www.google.com";
                    throw ex;
                }
                else
                {
                    Console.WriteLine("=> Current speed = {0}", CurrentSpeed);
                }
            }
        }
    }
}