global using static System.Console;

using System.Reflection;
using Casino;
using Casino.Attributes;
using Casino.Enums;
using Casino.Games.Interfaces;

class Program
{
    static void Main(string[] args)
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


        WriteLine("Welcome to the Casino!");
        WriteLine("Please select a game:");
        for (int game = 0; game < games.Count; game++)
        {
            WriteLine($"{game + 1}. {games.ElementAt(game).Name}");
        }

        int selectedGame;
        var isValid = int.TryParse(ReadLine(), out selectedGame);

        if (!isValid || selectedGame <= 0 || selectedGame > games.Count)
        {
            throw new Exception(GlobalConstants.INVALID_GAME);
        }

        ISlotGame choosenGame = (ISlotGame)Activator.CreateInstance(games.ElementAt(selectedGame - 1), new object[] { 4, 3 });


        var operations = new Dictionary<Actions, Action>()
            {
                { Actions.DepositMoney,Transaction.Deposit},
                { Actions.WithdrawMoney,Transaction.Withdraw},
                { Actions.ChangeBetAmount,Transaction.ChangeBet},
                { Actions.Spin,choosenGame.Play},
                { Actions.CheckBalance, Transaction.CheckBalance},
                { Actions.Quit, choosenGame.Quit},
            };

        while (true)
        {
            WriteLine($"Welcome to {choosenGame.GetType().Name}");
            WriteLine(new string('-', 10));
            WriteLine($"Current bet amount: {Transaction.Bet}");
            WriteLine(new string('-', 10));

            foreach (var action in Enum.GetValues<Actions>())
            {
                WriteLine(action.GetStringValue());
            }

            WriteLine("1. Deposit money");
            WriteLine("2. Withdraw money");
            WriteLine("3. Change bet amount");
            WriteLine("4. Spin the rotary");
            WriteLine("5. Check balance");
            WriteLine("6. Quit");

            try
            {
                string? choice = ReadLine();

                Actions selectedAction;
                isValid = Enum.TryParse(choice, out selectedAction);

                if (!isValid)
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