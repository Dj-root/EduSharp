using System;

namespace EduSharp.Unit7.CustomExceptions
{
    public class Radio
    {
        public void TurnOn(bool on)
        {
            if (on)
            {
                Console.WriteLine("Jamming...");
            }
            else
            {
                Console.WriteLine("Quiet time...");
            }
        }
    }
}