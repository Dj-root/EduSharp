using System;

namespace EduSharp.Troelsen.Unit6
{
     class SalesPerson:Employee
    {
        public int SalesNumber { get; set; }

        public SalesPerson(){}
        public SalesPerson(string fullName, int age, int EmpID, float currPay, string ssn, int numbOfSales)
            : base(fullName, age, EmpID, currPay, ssn)
        {
            SalesNumber = numbOfSales;
        }

        public override sealed void GiveBonus(float amount)
        {
//            base.GiveBonus(amount);
            int salesBonus = 0;
            if (SalesNumber>=0 && SalesNumber<=100)
            {
                salesBonus = 10;
            }
            else
            {
                if (SalesNumber >=101 && SalesNumber <=200)
                {
                    salesBonus = 15;
                }
                else
                {
                    salesBonus = 20;
                }
            }
            base.GiveBonus(amount*salesBonus);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Number of sales: {0}",SalesNumber);
        }
    }
}