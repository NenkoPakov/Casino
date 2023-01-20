using System.Runtime.Serialization;

namespace Casino
{
    public sealed class GlobalConstants
    {
        internal const string DEPOSIT_MONEY = "Enter the amount to deposit:";
        internal const string DEPOSIT_MONEY_SUCCESSFUL = "Deposit successful. Your new balance is: ";
        internal const string WITHDRAW_MONEY = "Enter the amount to withdraw:";
        internal const string CHANGE_BET_AMOUNT = "Enter the new bet amount:";
        internal const string INVALID_INPUT = "Invalid choice. Please try again.";
        internal const string CHECK_BALANCE = "Your current balance is: ";
        internal const string QUIT = "Thanks for playing!";
        internal const string INSUFFICIENT_FUNDS = "Insufficient funds. Your balance is: ";
        internal const string WITHDRAWAL_SUCCESSFUL = "Withdrawal successful. Your new balance is: ";
        internal const string CHANGE_BET_AMOUNT_SUCCESSFUL = "Bet amount changed to: ";
        internal const string WIN_MESSAGE = "Congratulations! You won this spin. Your current winnings are: ";
        internal const string TRY_AGAIN_MESSAGE = "Try again";
        internal const string INVALID_AMOUNT = "The input must be a positive number";
        internal const string INVALID_GAME = "Invalid game!";
        internal const string INVALID_ACTION = "Invalid action!";
    }
}
