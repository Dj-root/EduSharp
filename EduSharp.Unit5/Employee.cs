using System;

namespace EduSharp.Unit5
{
    public class Employee
    {
        private string empName;
        private int empID;
        private float currPay;

        public Employee()
        {
        }

        public Employee(string empName, int empID, float currPay)
        {
            this.empName = empName;
            this.empID = empID;
            this.currPay = currPay;
        }

        
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                    {
                        Console.WriteLine("Error! Name length exceeds 15 chars!");
                    }
                    else
                    {
                        empName = value;
                    }
            }
        }

        public string GetName()
        {
            return empName;
        }

        //public void SetName(string name)
        //{
        //    if (name.Length > 15)
        //    {
        //        Console.WriteLine("Error! Name length exceeds 15 chars!");
        //    }
        //    else
        //    {
        //        empName = name;
        //    }
        //}
        


        public void GiveBonus(float amount)
        {
            currPay += amount;
        }

        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", empName);
            Console.WriteLine("ID: {0}", empID);
            Console.WriteLine("Pay: {0}",currPay);
        }


    }
}