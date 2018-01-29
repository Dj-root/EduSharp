using System;

namespace EduSharp.Unit5
{
    partial class Employee
    {
        // Field data
        private string empName;
        private int empID;
        private float currPay;
        private int empAge;
        private string empSSN;

        // Constructors
        public Employee()
        {
        }

        public Employee(string name, int empID, float currPay)
        : this(name, 0, empID, currPay, null) { }

        public Employee(string name, int age, int id, float pay, string ssn=null)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
            this.Pay = pay;
            this.empSSN=ssn;
        }

        // Properties
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


    }
}