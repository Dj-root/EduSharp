using System;

namespace EduSharp.Troelsen.Unit5
{
    public class SavingsAccount
    {
        public double currBalance;
        private static double currInterestRate;

        public SavingsAccount(double balance)
        {
            currInterestRate = 0.04;
            currBalance = balance;
        }

         static SavingsAccount()
        {
            Console.WriteLine("In static ctor");
            currInterestRate = 0.04;
        }

        public static double InterestRate
        {
            get { return currInterestRate;}
            set { currInterestRate = value; }
        }
//
//        public static void SetInterestRate(double newRate)
//        {
//            currInterestRate = newRate;
//        }
//
//        public static double GetInterestRate()
//        {
//            return currInterestRate;
//        }

    }
}