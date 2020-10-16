namespace CraftingCode.AccountService
{
    public class AccountService
    {
        private readonly DepositService _depositService;
        private readonly WithdrawService _withdrawService;
        private readonly ConsoleService _consoleService;
        private readonly TransactionService _transactionService;

        public AccountService(DepositService depositService, WithdrawService withdrawService, ConsoleService consoleService, TransactionService transactionService)
        {
            _depositService = depositService;
            _withdrawService = withdrawService;
            _consoleService = consoleService;
            _transactionService = transactionService;
        }

        public void Deposit(int amount)
        {
            var transaction = _depositService.Deposit(amount);
            _transactionService.SaveTransaction(transaction);
        }

        public void Withdraw(int amount)
        {
            var transaction = _withdrawService.Withdraw(amount);
            _transactionService.SaveTransaction(transaction);
        }

        public void PrintStatement()
        {
            _consoleService.PrintToConsole();
        }
    }
}
