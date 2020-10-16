using CraftingCode.AccountService;
using Xunit;

namespace UnitTests.AccountServiceTests
{
    [Trait("Category", "Unit")]
    public class DepositServiceShould
    {
        [Fact]
        public void deposit_correct_amount_in_bank_account()
        {
            var depositService = new DepositService();
            var value = 50;

            depositService.Deposit(value);

        }
    }
}