using System;

namespace EduSharp.Troelsen.Unit6
{
     class Manager:Employee
    {
        public int StockOptions { get; set; }

        public Manager(string fullName, int age, int EmpID, float currPay, string ssn, int numberOfOpts)
        :base( fullName,  age,  EmpID,  currPay,  ssn)
        {
            StockOptions = numberOfOpts;
        }

        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random r = new Random();
            StockOptions += r.Next(500);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Number of Stock Options: {0}", StockOptions);
        }
    }
}