using Casino.Exceptions;

namespace Casino.Services
{
    public class TransactionService : ITransactionService
    {
        public decimal Balance { get; private set; }
        public decimal Bet { get; private set; } = 0.1m;

        public void Deposit()
        {
            WriteLine(GlobalConstants.DEPOSIT_MONEY);
            decimal deposit;
            bool isValid = decimal.TryParse(ReadLine(), out deposit);

            if (!isValid)
            {
                throw new InvalidAmountException();
            }

            if (deposit <= 0)
            {
                throw new InvalidAmountException(deposit);
            }

            this.Balance += deposit;
            WriteLine($"{GlobalConstants.DEPOSIT_MONEY_SUCCESSFUL} {this.Balance}");
        }

        public void Withdraw()
        {
            WriteLine(GlobalConstants.WITHDRAW_MONEY);
            decimal withdraw;
            bool isValid = decimal.TryParse(ReadLine(), out withdraw);

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
                WriteLine($"{GlobalConstants.WITHDRAWAL_SUCCESSFUL} {this.Balance}");
            }
        }

        public void ChangeBet()
        {
            WriteLine(GlobalConstants.CHANGE_BET_AMOUNT);

            decimal newBet;
            bool isValid = decimal.TryParse(ReadLine(), out newBet);

            if (!isValid)
            {
                throw new InvalidAmountException(GlobalConstants.INVALID_BET_AMOUNT);
            }

            if (newBet <= 0)
            {
                throw new InvalidAmountException(GlobalConstants.INVALID_BET_AMOUNT, newBet);
            }

            Bet = newBet;

            WriteLine($"{GlobalConstants.CHANGE_BET_AMOUNT_SUCCESSFUL} {this.Bet}");
        }

        public void CheckBalance()
        {
            WriteLine($"{GlobalConstants.CHECK_BALANCE} {this.Balance}");
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
