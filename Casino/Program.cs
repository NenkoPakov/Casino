global using static System.Console;

using System.Text;
using Casino.Enums;
using Casino.Exceptions;
using Casino.Games.Interfaces;
using Casino.Services;

namespace Casino
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            TransactionService transactionService = new TransactionService();
            GameManager gameManager = new GameManager(transactionService);
            Actions selectedAction;
            do
            {
                selectedAction = gameManager.BeginPlay(args, transactionService);
            } while (selectedAction != Actions.Quit);
        }
    }
}