
using CraftingCode.AccountService;
using Moq;
using Xunit;

namespace AcceptanceTests
{
    [Trait("Category", "Acceptance")]
    public class AccountServiceShould
    {
        [Fact]
        public void update_bank_account_and_send_data()
        {
            var accountService = new AccountService();
            var mockConsole = new Mock<ConsoleService>();

            accountService.Deposit(50);
            accountService.Withdraw(25);
            accountService.Deposit(50);

            accountService.PrintStatement();
            mockConsole.Verify(x => x.PrintToConsole(), Times.Once);

        }
    }
}
