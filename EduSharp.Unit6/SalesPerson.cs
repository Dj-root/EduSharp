namespace EduSharp.Unit6
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
    }
}