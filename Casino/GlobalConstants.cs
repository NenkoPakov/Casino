using System.Runtime.Serialization;

namespace Casino
{
    public sealed class GlobalConstants
    {
        #region Successful messages
        internal const string DEPOSIT_MONEY_SUCCESSFUL = "Deposit successful. Your new balance is:";
        internal const string WITHDRAWAL_SUCCESSFUL = "Withdrawal successful. Your new balance is:";
        internal const string CHANGE_BET_AMOUNT_SUCCESSFUL = "Bet amount changed to:";
        #endregion

        #region Invalid messages
        internal const string INVALID_AMOUNT = "The input must be a positive number";
        internal const string INVALID_GAME = "Invalid game!";
        internal const string INVALID_ACTION = "Invalid action!";
        internal const string INVALID_WITHDRAWAL_AMOUNT = "The withdrawal amount must be within the balance and a positive number!";
        internal const string INVALID_BET_AMOUNT = "Invalid bet amount!";
        internal const string INVALID_INPUT = "Invalid choice. Please try again.";
        internal const string INSUFFICIENT_FUNDS = "Insufficient funds. Your balance is:";
        #endregion

        #region Action messages
        internal const string DEPOSIT_MONEY = "Enter the amount to deposit:";
        internal const string WITHDRAW_MONEY = "Enter the amount to withdraw:";
        internal const string CHANGE_BET_AMOUNT = "Enter the new bet amount:";
        internal const string CHECK_BALANCE = "Your current balance is: ";
        internal const string QUIT = "Thanks for playing!";
        #endregion

        #region Result messages
        internal const string WIN_MESSAGE = "Congratulations! You won this spin. Your current winnings are:";
        internal const string TRY_AGAIN_MESSAGE = "Try again";
        #endregion

        #region Info messages
        internal const string CURRENT_BET_AMOUNT = "Current bet amount:";
        internal const string GAME_WELCOME_MESSAGE = "Welcome to";
        internal const string CASINO_WELCOME_MESSAGE = "Welcome to the Casino!";
        internal const string SELECT_GAME_MESSAGE = "Please select a game:";
        internal const string NOT_FOUND_GAME_MESSAGE = "No game found";
        #endregion

        #region Symbols
        internal const char WILDCARD_SYMBOL = '*';
        internal const char APPLE_SYMBOL = 'A';
        internal const char BANANA_SYMBOL = 'B';
        internal const char PINEAPPLE_SYMBOL = 'P';
        internal const char SUM_SYMBOL = '+';
        internal const char SUBTRACT_SYMBOL = '-';
        #endregion
    }
}
