using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Casino.Attributes;
using Casino.Enums;
using Casino.Extensions;
using Casino.Games.Interfaces;

namespace Casino
{
    public static class GameManager
    {
        internal static Actions ChooseAction()
        {
            string? input = ReadLine();

            int choice;
            bool isValid = int.TryParse(input, out choice);
            var isDefined = Enum.IsDefined(typeof(Actions), choice);
            if (!isValid || !isDefined)
            {
                throw new Exception(GlobalConstants.INVALID_ACTION);
            }

            return (Actions)choice;
        }

        internal static void GreetThePlayer(ISlotGame choosenGame, StringBuilder actionsMenu)
        {
            WriteLine($"{GlobalConstants.GAME_WELCOME_MESSAGE} {choosenGame.GetType().Name}");
            WriteLine(new string('-', 10));
            WriteLine($"{GlobalConstants.CURRENT_BET_AMOUNT} {Transaction.Bet}");
            WriteLine(new string('-', 10));
            WriteLine(actionsMenu);
        }

        internal static StringBuilder GetActionsMenu()
        {
            var actionsMenu = new StringBuilder();

            foreach (var action in Enum.GetValues<Actions>())
            {
                if (!string.IsNullOrEmpty(action.GetStringValue()))
                {
                    actionsMenu.AppendLine($"{(int)action}. {action.GetStringValue()}");
                }
            }

            return actionsMenu;
        }

        internal static ISlotGame ChooseGame(string[] args, ICollection<Type> games)
        {
            WriteLine(GlobalConstants.CASINO_WELCOME_MESSAGE);
            WriteLine(GlobalConstants.SELECT_GAME_MESSAGE);
            for (int game = 0; game < games.Count; game++)
            {
                WriteLine($"{game + 1}. {games.ElementAt(game).Name}");
            }

            int selectedGame;
            var isValid = int.TryParse(ReadLine(), out selectedGame);

            if (!isValid)
            {
                throw new Exception(GlobalConstants.INVALID_INPUT);
            }

            var choosenGameType = games.ElementAt(selectedGame - 1);

            if (choosenGameType == null)
            {
                throw new Exception(GlobalConstants.INVALID_GAME);
            }

            ISlotGame? choosenGame = Activator.CreateInstance(choosenGameType, args.Length > 0 ? args : new object[] { 4, 3 }) as ISlotGame;

            return choosenGame!;
        }

        internal static ICollection<Type> GetAllSlotGames()
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
                throw new Exception(GlobalConstants.NOT_FOUND_GAME_MESSAGE);
            }

            return games;
        }
    }
}
