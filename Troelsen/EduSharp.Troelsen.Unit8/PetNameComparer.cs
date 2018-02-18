using System;
using System.Collections;

namespace EduSharp.Troelsen.Unit8
{
    public class PetNameComparer:IComparer
    {
        public int Compare(object x, object y)
        {

            Car t1 = x as Car;
            Car t2 = y as Car;

            if (t1 != null && t2 != null)
            {
                return String.Compare(t1.PetName, t2.PetName);
            }
            else
            {
                throw new ArgumentException("Parameter is not a Car!");
            }
        }
    }
}