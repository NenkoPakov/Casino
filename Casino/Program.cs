global using static System.Console;

using System.Text;
using Casino;
using Casino.Enums;
using Casino.Games.Interfaces;

namespace Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Actions selectedAction;
            do
            {
                selectedAction = BeginPlay(args);
            } while (selectedAction != Actions.Quit);
        }

        private static Actions BeginPlay(string[] args)
        {
            try
            {
                ICollection<Type> games = GameManager.GetAllSlotGames();

                ISlotGame? choosenGame = GameManager.ChooseGame(args, games);

                var operations = new Dictionary<Actions, Action>()
                {
                    { Actions.DepositMoney,Transaction.Deposit},
                    { Actions.WithdrawMoney,Transaction.Withdraw},
                    { Actions.ChangeBetAmount,Transaction.ChangeBet},
                    { Actions.Spin,choosenGame.Play},
                    { Actions.CheckBalance, Transaction.CheckBalance},
                };

                StringBuilder actionsMenu = GameManager.GetActionsMenu();
                return PlayProcess(choosenGame, operations, actionsMenu);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                return Actions.Unknown;
            }
        }

        private static Actions PlayProcess(ISlotGame choosenGame, Dictionary<Actions, Action> operations, StringBuilder actionsMenu)
        {
            while (true)
            {
                try
                {
                    GameManager.GreetThePlayer(choosenGame, actionsMenu);

                    Actions selectedAction = GameManager.ChooseAction();
                    if (selectedAction == Actions.Quit || selectedAction == Actions.ChangeGame)
                    {
                        WriteLine(GlobalConstants.QUIT);
                        return selectedAction;
                    }

                    if (!operations.ContainsKey(selectedAction))
                    {
                        throw new Exception(GlobalConstants.INVALID_ACTION);
                    }

                    operations[selectedAction]();
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }
    }
}