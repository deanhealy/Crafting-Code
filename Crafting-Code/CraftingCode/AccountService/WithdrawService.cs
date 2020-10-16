using System;

namespace CraftingCode.AccountService
{
    public class WithdrawService
    {
        public virtual Transaction Withdraw(int amount)
        {
            var transaction = new Transaction
            {
                Date = DateTime.Now,
                Amount = amount * -1
            };
            return transaction;
        }
    }
}