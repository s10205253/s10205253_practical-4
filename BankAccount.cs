using System;
using System.Collections.Generic;
using System.Text;

namespace s10205253_practical_4
{
    class BankAccount
    {
        public string AccNo { get; set; }
        public string AccName { get; set; }
        public double Balance { get; set; }

        public BankAccount() { }
        public BankAccount(string no, string name, double b)
        {
            AccNo = no;
            AccName = name;
            Balance = b;
        }

        public void Deposit(double amt)
        {
            Balance += amt;
        }
        public bool Withdraw(double amt)
        {
            if (Balance >= amt)
            {
                Balance -= amt;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "AccNo: " + AccNo + "\tAccName: " + AccName + "\tBalance: "
                + Balance;
        }
    }
}
