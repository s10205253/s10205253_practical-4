using System;
using System.Collections.Generic;
using System.Text;

namespace s10205253_practical_4
{
    class SavingsAccount : BankAccount
    {
        public double Rate { get; set; }

        public SavingsAccount() : base() { }
        public SavingsAccount(string no, string name, double b, double r) :base(no, name, b)
        {
            Rate = r;
        }

        public double CalculateInterest()
        {
            double interest = Balance * (Rate / 100);
            return interest;
        }
        public override string ToString()
        {
            return base.ToString() + "\tRate: " + Rate;
        }
    }
}
