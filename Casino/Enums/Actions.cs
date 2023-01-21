using Casino.Attributes;

namespace Casino.Enums
{
    public enum Actions
    {
        [StringValue("Deposit money")]
        DepositMoney = 1,
        [StringValue("Withdraw money")]
        WithdrawMoney = 2,
        [StringValue("Change bet amount")]
        ChangeBetAmount = 3,
        [StringValue("Spin the rotary")]
        Spin = 4,
        [StringValue("Check balance")]
        CheckBalance = 5,
        [StringValue("Change game")]
        ChangeGame = 6,
        [StringValue("Quit")]
        Quit = 7,
        Unknown = 0,
    }
}
