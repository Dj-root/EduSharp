using System;
using System.Collections;

namespace EduSharp.Unit9
{
    public class Car : IComparable<Car>
    {
        public const int MaxSpeed = 100;
        public int CarID { get; set; }

        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";

        private bool carIsDead;

//        private Radio theMusicBox = new Radio();



        public Car()
        {
        }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public Car(string name, int speed, int id)
        {
            CurrentSpeed = speed;
            PetName = name;
            CarID = id;
        }

//        public void CrankTunes(bool state)
//        {
//            theMusicBox.TurnOn(state);
//        }

        public void Accelerate(int delta)
        {
            if (delta < 0)
            {
                throw new ArgumentOutOfRangeException("delta", "Speed must be greated than zero!");
            }

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

        
        int IComparable<Car>.CompareTo(Car obj)
        {
//            Car temp = obj as Car;
//            if (temp != null)
//            {
//                return this.CarID.CompareTo(temp.CarID);

                if (this.CarID > obj.CarID)
                {
                    return 1;
                }

                if (this.CarID < obj.CarID)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
//            }
//            else
//            {
//                throw new ArgumentException("Parameter is not a Car!");
//            }
        }

//        public static IComparer SortByPetName
//        {
//            get { return (IComparer) new PetNameComparer(); }
//        }
    }
}