using System.Reflection;
using System.Text;
using Casino.Attributes;
using Casino.Enums;
using Casino.Exceptions;
using Casino.Extensions;
using Casino.Games.Interfaces;
using Casino.Services;
using Casino.Wrappers;

namespace Casino
{
    public class GameManager
    {
        private readonly IConsole _console;
        private readonly Random _numberGenerator = new Random();
        private readonly TransactionService _transactionService;

        public GameManager(TransactionService transactionService, IConsole console)
        {
            this._transactionService = transactionService;
            this._console = console;
        }

        public Actions BeginPlay(string[] args, TransactionService transactionService)
        {
            try
            {
                ICollection<Type> games = GetAllSlotGames();

                IGame? choosenGame = ChooseGame(args, games);

                Dictionary<Actions, Action> operations = new Dictionary<Actions, Action>()
                {
                    { Actions.DepositMoney,transactionService.Deposit},
                    { Actions.WithdrawMoney,transactionService.Withdraw},
                    { Actions.ChangeBetAmount,transactionService.ChangeBet},
                    { Actions.Spin,choosenGame.Play},
                    { Actions.CheckBalance, transactionService.CheckBalance},
                };

                StringBuilder actionsMenu = GetActionsMenu();
                return PlayProcess(choosenGame, operations, actionsMenu);
            }
            catch (Exception ex)
            {
                this._console.WriteLine(ex.Message);
                return Actions.Unknown;
            }
        }

        private ICollection<Type> GetAllSlotGames()
        {
            ICollection<Type> games = new List<Type>();

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (Attribute.IsDefined(type, typeof(SlotGameAttribute)) && type.IsClass)
                {
                    games.Add(type);
                }
            }

            if (games.Count == 0)
            {
                throw new ArgumentException(GlobalConstants.NOT_FOUND_GAME_MESSAGE);
            }

            return games;
        }

        private IGame ChooseGame(string[] args, ICollection<Type> games)
        {
            this._console.WriteLine(GlobalConstants.CASINO_WELCOME_MESSAGE);
            this._console.WriteLine(GlobalConstants.SELECT_GAME_MESSAGE);
            for (int game = 0; game < games.Count; game++)
            {
                this._console.WriteLine($"{game + 1}. {games.ElementAt(game).Name}");
            }

            int selectedGame;
            bool isValid = int.TryParse(this._console.ReadLine(), out selectedGame);

            if (!isValid)
            {
                throw new InvalidInputException();
            }

            Type choosenGameType = games.ElementAt(selectedGame - 1);

            if (choosenGameType == null)
            {
                throw new InvalidInputException(GlobalConstants.INVALID_GAME, selectedGame);
            }

            int defaultRows = 4;
            int defaultCols = 3;

            int rows = args.Length == 0 ? defaultRows : int.Parse(args[0]);
            int cols = args.Length == 0 ? defaultCols : int.Parse(args[1]);

            IGame? choosenGame = Activator.CreateInstance(choosenGameType, rows, cols, this._numberGenerator, this._transactionService, this._console) as IGame;

            return choosenGame!;
        }

        private StringBuilder GetActionsMenu()
        {
            StringBuilder actionsMenu = new StringBuilder();

            foreach (Actions action in Enum.GetValues<Actions>())
            {
                if (!string.IsNullOrEmpty(action.GetStringValue()))
                {
                    actionsMenu.AppendLine($"{(int)action}. {action.GetStringValue()}");
                }
            }

            return actionsMenu;
        }

        private Actions PlayProcess(IGame choosenGame, Dictionary<Actions, Action> operations, StringBuilder actionsMenu)
        {
            while (true)
            {
                try
                {
                    GreetThePlayer(choosenGame, actionsMenu);

                    Actions selectedAction = ChooseAction();
                    if (selectedAction == Actions.Quit || selectedAction == Actions.ChangeGame)
                    {
                        choosenGame.Quit();
                        return selectedAction;
                    }

                    if (!operations.ContainsKey(selectedAction))
                    {
                        throw new InvalidInputException(GlobalConstants.INVALID_ACTION);
                    }

                    operations[selectedAction]();
                }
                catch (Exception ex)
                {
                    this._console.WriteLine(ex.Message);
                }
            }
        }

        private void GreetThePlayer(IGame choosenGame, StringBuilder actionsMenu)
        {
            this._console.WriteLine($"{GlobalConstants.GAME_WELCOME_MESSAGE} {choosenGame.GetType().Name}");
            this._console.WriteLine(new string('-', 10));
            this._console.WriteLine($"{GlobalConstants.CURRENT_BET_AMOUNT} {_transactionService.Bet}");
            this._console.WriteLine(new string('-', 10));
            this._console.WriteLine(actionsMenu.ToString());
        }

        private Actions ChooseAction()
        {
            string? input = this._console.ReadLine();

            int action;
            bool isValid = int.TryParse(input, out action);

            if (!isValid)
            {
                throw new InvalidInputException();
            }

            bool isDefined = Enum.IsDefined(typeof(Actions), action);

            if (!isDefined)
            {
                throw new InvalidInputException(GlobalConstants.INVALID_ACTION, action);
            }

            return (Actions)action;
        }
    }
}
