using System;

namespace EduSharp.Unit6
{
    partial class Employee
    {
		// Inner classes
        public class BenefitPackage
        {
			public enum BenefitPackageLevel 
			{
			    Standard, Gold, Platinum
			}
            public double ComputePayDeduction()
            {
                return 125.0;
            }
        }

        // Field data
        protected string empName;
        protected int empID;
        protected float currPay;
        protected int empAge;
        protected string empSSN;

		protected BenefitPackage empBenefits = new BenefitPackage();

        // Constructors
        public Employee()
        {
        }

        public Employee(string name, int age, int empID, float currPay, string ssn = null)
            : this(name, age, empID, currPay)
        {
            this.empSSN = ssn;
        }

        public Employee(string name, int age, int id, float pay)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
            this.Pay = pay;
        }


    }
}