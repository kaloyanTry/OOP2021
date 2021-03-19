using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class BankAccount
    {
        private decimal amount;

        public BankAccount(decimal amount)
        {
            Amount = amount;
        }
        public decimal Amount 
        { 
            get => amount; 
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("No negatives.");
                }
                amount = value;
            } 
        }
    }
}
