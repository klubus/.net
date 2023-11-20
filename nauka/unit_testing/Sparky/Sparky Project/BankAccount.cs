namespace Sparky_Project
{
    public class BankAccount
    {
        public int balance { get; set; }
        private ILogBook _logBook;
        public BankAccount(ILogBook logBook)
        {
            _logBook = logBook;
            balance = 0;
        }

        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit invoked.");
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;
            var temp = _logBook.LogSeverity;
            balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= balance)
            {
                _logBook.LogToDb("Withdrawal amount: " + amount.ToString());
                balance -= amount;
                return _logBook.LogBalanceAfterWithdrawal(balance);
            }
            return _logBook.LogBalanceAfterWithdrawal(balance - amount);
        }

        public int GetBalance()
        {
            return balance;
        }
    }
}
