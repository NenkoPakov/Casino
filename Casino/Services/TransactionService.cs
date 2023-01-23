using Casino.Exceptions;
using Casino.Wrappers;

namespace Casino.Services
{
    public class TransactionService : ITransactionService
    {
        public decimal Balance { get; private set; }
        public decimal Bet { get; private set; } = 0.1m;
        private readonly IConsole _console;

        public TransactionService(IConsole console)
        {
            this._console = console;
        }

        public void Deposit()
        {
            this._console.WriteLine(GlobalConstants.DEPOSIT_MONEY);
            decimal deposit;
            bool isValid = decimal.TryParse(this._console.ReadLine(), out deposit);

            if (!isValid)
            {
                throw new InvalidAmountException();
            }

            if (deposit <= 0)
            {
                throw new InvalidAmountException(deposit);
            }

            this.Balance += deposit;
            this._console.WriteLine($"{GlobalConstants.DEPOSIT_MONEY_SUCCESSFUL} {this.Balance}");
        }

        public void Withdraw()
        {
            this._console.WriteLine(GlobalConstants.WITHDRAW_MONEY);
            decimal withdraw;
            bool isValid = decimal.TryParse(this._console.ReadLine(), out withdraw);

            if (!isValid)
            {
                throw new InvalidAmountException(GlobalConstants.INVALID_WITHDRAWAL_AMOUNT);
            }

            if (withdraw <= 0)
            {
                throw new InvalidAmountException(GlobalConstants.INVALID_WITHDRAWAL_AMOUNT, withdraw);
            }

            if (withdraw > this.Balance)
            {
                throw new InvalidAmountException(GlobalConstants.INSUFFICIENT_FUNDS, this.Balance);
            }
            else
            {
                this.Balance -= withdraw;
                this._console.WriteLine($"{GlobalConstants.WITHDRAWAL_SUCCESSFUL} {this.Balance}");
            }
        }

        public void ChangeBet()
        {
            this._console.WriteLine(GlobalConstants.CHANGE_BET_AMOUNT);

            decimal newBet;
            bool isValid = decimal.TryParse(this._console.ReadLine(), out newBet);

            if (!isValid)
            {
                throw new InvalidAmountException(GlobalConstants.INVALID_BET_AMOUNT);
            }

            if (newBet <= 0)
            {
                throw new InvalidAmountException(GlobalConstants.INVALID_BET_AMOUNT, newBet);
            }

            Bet = newBet;

            this._console.WriteLine($"{GlobalConstants.CHANGE_BET_AMOUNT_SUCCESSFUL} {this.Bet}");
        }

        public void CheckBalance()
        {
            this._console.WriteLine($"{GlobalConstants.CHECK_BALANCE} {this.Balance}");
        }

        public void ReduceBalanceByBetAmount()
        {
            this.Balance -= this.Bet;
        }

        public void AddWinnings(decimal winnings)
        {
            this.Balance += winnings;
        }
    }
}
