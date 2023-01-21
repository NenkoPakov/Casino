namespace Casino
{
    public class Transaction
    {
        public static decimal Balance;
        public static decimal Bet = 0.1m;

        public static void Deposit()
        {
            WriteLine(GlobalConstants.DEPOSIT_MONEY);
            decimal deposit;
            var isValid = decimal.TryParse(ReadLine(), out deposit);

            if (!isValid || deposit <= 0)
            {
                throw new Exception(GlobalConstants.INVALID_AMOUNT);
            }

            Balance += deposit;
            WriteLine($"{GlobalConstants.DEPOSIT_MONEY_SUCCESSFUL} {Balance}");
        }

        public static void Withdraw()
        {
            WriteLine(GlobalConstants.WITHDRAW_MONEY);
            decimal withdraw;
            bool isValid = decimal.TryParse(ReadLine(), out withdraw);

            if (!isValid || withdraw < Balance)
            {
                throw new Exception(GlobalConstants.INVALID_WITHDRAWAL_AMOUNT);
            }

            if (withdraw > Balance)
            {
                WriteLine($"{GlobalConstants.INSUFFICIENT_FUNDS} {Balance}");
            }
            else
            {
                Balance -= withdraw;
                WriteLine($"{GlobalConstants.WITHDRAWAL_SUCCESSFUL} {Balance}");
            }
        }

        public static void ChangeBet()
        {
            WriteLine(GlobalConstants.CHANGE_BET_AMOUNT);

            bool isValid = decimal.TryParse(ReadLine(), out Bet);

            if (!isValid || Bet <= 0)
            {
                throw new Exception(GlobalConstants.INVALID_BET_AMOUNT);
            }

            WriteLine($"{GlobalConstants.CHANGE_BET_AMOUNT_SUCCESSFUL} {Bet}");
        }
        public static void CheckBalance()
        {
            WriteLine($"{GlobalConstants.CHECK_BALANCE} {Balance}");
        }
    }
}
