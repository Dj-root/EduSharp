using System;

namespace EduSharp.Unit7.MultExceptions
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