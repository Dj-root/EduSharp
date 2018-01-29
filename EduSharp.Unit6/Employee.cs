using System;

namespace EduSharp.Unit6
{
    partial class Employee
    {

        // Properties
        public BenefitPackage Benefits
        {
            get { return empBenefits;}
            set { empBenefits = value; }
        }

        public int Age
        {
            get { return empAge; }
            set { empAge = value; }
        }

        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error! name length exceeds 15 chars!");
                }
                else
                {
                    empName = value;
                }
            }
        }

        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }

        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }

        public string GetName()
        {
            return empName;
        }

        public string SocialSecurityNumber
        {
            get { return empSSN; }
        }

        // Methods
        public void GiveBonus(float amount)
        {
            Pay += amount;
        }

        public void DisplayStats()
        {
            Console.WriteLine("name: {0}", Name);
            Console.WriteLine("id: {0}", ID);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Pay: {0}", Pay);
        }

        public double GetBenefitCost()
        {
            return empBenefits.ComputePayDeduction();
        }

    }
}