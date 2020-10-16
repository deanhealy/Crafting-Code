using CraftingCode.AccountService;
using Moq;
using Xunit;

namespace UnitTests.AccountServiceTests
{
    [Trait("Category", "Unit")]
    public class AccountServiceShould
    {
        [Fact]
        public void deposit_correct_amount_in_bank_account()
        {
            var mockDepositService = new Mock<DepositService>();
            var mockWithdrawService = new Mock<WithdrawService>();
            var mockConsoleService = new Mock<ConsoleService>();
            var mockTransactionService = new Mock<TransactionService>();
            var accountService = new AccountService(mockDepositService.Object, mockWithdrawService.Object, mockConsoleService.Object, mockTransactionService.Object);
            var value = 50;

            accountService.Deposit(value);

            mockDepositService.Verify(x => x.Deposit(value), Times.Once);
        }

        [Fact]
        public void should_save_transaction_from_deposit()
        {
            var value = 50;
            var transaction = new Transaction();
            var mockDepositService = new Mock<DepositService>();
            mockDepositService.Setup(x => x.Deposit(value)).Returns(transaction);
            var mockWithdrawService = new Mock<WithdrawService>();
            var mockConsoleService = new Mock<ConsoleService>();
            var mockTransactionService = new Mock<TransactionService>();
            var accountService = new AccountService(mockDepositService.Object, mockWithdrawService.Object, mockConsoleService.Object, mockTransactionService.Object);

            accountService.Deposit(value);

            mockTransactionService.Verify(x => x.SaveTransaction(transaction), Times.Once);
        }

        [Fact]
        public void withdraw_correct_amount_from_bank_account()
        {
            var mockDepositService = new Mock<DepositService>();
            var mockWithdrawService = new Mock<WithdrawService>();
            var mockConsoleService = new Mock<ConsoleService>();
            var mockTransactionService = new Mock<TransactionService>();
            var accountService = new AccountService(mockDepositService.Object, mockWithdrawService.Object, mockConsoleService.Object, mockTransactionService.Object);
            var value = 50;

            accountService.Withdraw(value);

            mockWithdrawService.Verify(x => x.Withdraw(value), Times.Once);
        }

        [Fact]
        public void should_save_transaction_from_withdraw()
        {
            var value = 50;
            var transaction = new Transaction();
            var mockDepositService = new Mock<DepositService>();
            var mockWithdrawService = new Mock<WithdrawService>();
            mockWithdrawService.Setup(x => x.Withdraw(value)).Returns(transaction);
            var mockConsoleService = new Mock<ConsoleService>();
            var mockTransactionService = new Mock<TransactionService>();
            var accountService = new AccountService(mockDepositService.Object, mockWithdrawService.Object, mockConsoleService.Object, mockTransactionService.Object);

            accountService.Withdraw(value);

            mockTransactionService.Verify(x => x.SaveTransaction(transaction), Times.Once);
        }

        [Fact]
        public void print_transaction_details_to_console()
        {
            var mockDepositService = new Mock<DepositService>();
            var mockWithdrawService = new Mock<WithdrawService>();
            var mockConsoleService = new Mock<ConsoleService>();
            var mockTransactionService = new Mock<TransactionService>();
            var accountService = new AccountService(mockDepositService.Object, mockWithdrawService.Object, mockConsoleService.Object, mockTransactionService.Object);

            accountService.PrintStatement();

            mockConsoleService.Verify(x => x.PrintToConsole(), Times.Once);
        }
    }
}