using System.Text;
using Casino.Games.Interfaces;
using Casino.Models;

namespace Casino.Games.SlotGames
{
    public abstract class SlotGameBase : Game, ISlotGame
    {
        private int _rows;
        private int _cols;
        private SlotItem[] items;
        private Dictionary<char, int> auxiliary;
        private char[,] _slot;
        private Random _random;
        private decimal _winnings;

        public SlotGameBase(int rows, int cols, SlotItem[] items)
        {
            _rows = rows;
            _cols = cols;
            this.items = items;

            _slot = new char[rows, cols];

            auxiliary = new Dictionary<char, int>();
            var threshold = 0;
            foreach (var item in items)
            {
                var symbol = item.Symbol;
                threshold += item.Probability;

                auxiliary.Add(symbol, threshold);
            }

            _random = new Random();
        }

        public override void Play()
        {
            if (Transaction.Bet > Transaction.Balance)
            {
                WriteLine($"{GlobalConstants.INSUFFICIENT_FUNDS} {Transaction.Balance}");
            }
            else
            {
                Transaction.Balance -= Transaction.Bet;
                SpinSlot();
                PrintResult();
                CheckForWinnings();
            }
        }

        public void PrintResult()
        {
            var slotGameResult = new StringBuilder();

            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    slotGameResult.Append(_slot[row, col]);
                }

                slotGameResult.AppendLine();
            }

            WriteLine(slotGameResult.ToString());
        }

        public void CheckForWinnings()
        {
            decimal currentWinnings = 0;
            for (int row = 0; row < _rows; row++)
            {
                var rowItems = Enumerable.Range(0, _cols)
                .Select(col => _slot[row, col])
                .ToArray();

                var wildCardsCount = rowItems.Count(x => x == GlobalConstants.WILDCARD_SYMBOL);
                var distinctSymbols = rowItems.Distinct().Where(i => i != GlobalConstants.WILDCARD_SYMBOL);
                var distinctSymbolsCount = distinctSymbols.Count();

                if (distinctSymbolsCount == 1)
                {
                    var symbol = distinctSymbols.FirstOrDefault();
                    var coef = items.FirstOrDefault(i => i.Symbol == symbol)!.Coefficient;
                    currentWinnings += (_cols - wildCardsCount) * coef * Transaction.Bet;
                }
            }

            if (currentWinnings > 0)
            {
                Transaction.Balance += currentWinnings;
                _winnings += currentWinnings;

                WriteLine($"{GlobalConstants.WIN_MESSAGE} {currentWinnings}");
            }
            else
            {
                WriteLine(GlobalConstants.TRY_AGAIN_MESSAGE);
            }

            WriteLine($"{GlobalConstants.CHECK_BALANCE} {Transaction.Balance}");
        }

        public void SpinSlot()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    var currentNumber = _random.Next(1, 101);

                    foreach (var (symbol, threshold) in auxiliary)
                    {
                        if (currentNumber < threshold)
                        {
                            _slot[row, col] = symbol;
                            break;
                        }
                    }
                }
            }
        }
    }
}
