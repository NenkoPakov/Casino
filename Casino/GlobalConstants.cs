namespace Casino
{
    public static class GlobalConstants
    {
        #region Successful messages
        public const string DEPOSIT_MONEY_SUCCESSFUL = "Deposit successful. Your new balance is:";
        public const string WITHDRAWAL_SUCCESSFUL = "Withdrawal successful. Your new balance is:";
        public const string CHANGE_BET_AMOUNT_SUCCESSFUL = "Bet amount changed to:";
        #endregion

        #region Invalid messages
        public const string INVALID_AMOUNT = "The input must be a positive number";
        public const string INVALID_GAME = "Invalid game!";
        public const string INVALID_ACTION = "Invalid action!";
        public const string INVALID_WITHDRAWAL_AMOUNT = "The withdrawal amount must be within the balance and a positive number!";
        public const string INVALID_BET_AMOUNT = "Invalid bet amount!";
        public const string INVALID_INPUT = "Invalid choice. Please try again.";
        public const string INSUFFICIENT_FUNDS = "Insufficient funds. Your balance is:";
        #endregion

        #region Action messages
        public const string DEPOSIT_MONEY = "Enter the amount to deposit:";
        public const string WITHDRAW_MONEY = "Enter the amount to withdraw:";
        public const string CHANGE_BET_AMOUNT = "Enter the new bet amount:";
        public const string CHECK_BALANCE = "Your current balance is: ";
        public const string QUIT = "Thanks for playing!";
        #endregion

        #region Result messages
        public const string WIN_MESSAGE = "Congratulations! You won this spin. Your current winnings are:";
        public const string TRY_AGAIN_MESSAGE = "Try again";
        #endregion

        #region Info messages
        public const string CURRENT_BET_AMOUNT = "Current bet amount:";
        public const string GAME_WELCOME_MESSAGE = "Welcome to";
        public const string CASINO_WELCOME_MESSAGE = "Welcome to the Casino!";
        public const string SELECT_GAME_MESSAGE = "Please select a game:";
        public const string NOT_FOUND_GAME_MESSAGE = "No games found";
        #endregion

        #region Symbols
        public const char WILDCARD_SYMBOL = '*';
        public const char APPLE_SYMBOL = 'A';
        public const char BANANA_SYMBOL = 'B';
        public const char PINEAPPLE_SYMBOL = 'P';
        public const char SUM_SYMBOL = '+';
        public const char SUBTRACT_SYMBOL = '-';
        #endregion
    }
}
