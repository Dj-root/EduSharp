namespace EduSharp.Unit6
{
     class Manager:Employee
    {
        public int StockOptions { get; set; }

        public Manager(string fullName, int age, int EmpID, float currPay, string ssn, int numberOfOpts)
        :base( fullName,  age,  EmpID,  currPay,  ssn)
        {
            StockOptions = numberOfOpts;
        }
    }
}