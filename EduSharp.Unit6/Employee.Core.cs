using System;

namespace EduSharp.Unit6
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

        public Employee(string name, int age, int id, float pay, string ssn = null)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
            this.Pay = pay;
            this.empSSN = ssn;
        }


    }
}