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
            WriteLine(GlobalConstants.DEPOSIT_MONEY_SUCCESSFUL + Balance);
        }

        public static void Withdraw()
        {
            WriteLine(GlobalConstants.WITHDRAW_MONEY);
            decimal withdraw = decimal.Parse(ReadLine());
            if (withdraw > Balance)
            {
                WriteLine(GlobalConstants.INSUFFICIENT_FUNDS + Balance);
            }
            else
            {
                Balance -= withdraw;
                WriteLine(GlobalConstants.WITHDRAWAL_SUCCESSFUL + Balance);
            }
        }

        public static void ChangeBet()
        {
            WriteLine(GlobalConstants.CHANGE_BET_AMOUNT);
            Bet = decimal.Parse(ReadLine());
            WriteLine(GlobalConstants.CHANGE_BET_AMOUNT_SUCCESSFUL + Bet);
        }
        public static void CheckBalance()
        {
            WriteLine(GlobalConstants.CHECK_BALANCE + Balance);
        }
    }
}
