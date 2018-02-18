namespace EduSharp.Troelsen.Unit6
{
    sealed class PTSalesPerson:SalesPerson
    {
        public PTSalesPerson(string fullName, int age, int EmpID, float currPay, string ssn, int numbOfSales)
            : base(fullName, age, EmpID, currPay, ssn, numbOfSales)
        {
           
        }
    }
}