using System;

namespace CraftingCode.AccountService
{
    public class DepositService
    {
        public virtual Transaction Deposit(int amount)
        {
            var transaction = new Transaction
            {
                Date = DateTime.Now,
                Amount = amount
            };
            return transaction;
        }
    }
}