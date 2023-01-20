using Casino.Attributes;
using Casino.Models;

namespace Casino.Games.SlotGames
{
    [SlotGame]
    public class FruitSlotGame : SlotGameBase
    {
        private static SlotItem[] slotItems = new SlotItem[]
            {
                new SlotItem('A',0.4m,45),
                new SlotItem('B',0.6m,35),
                new SlotItem('P',0.8m,15),
                new SlotItem('*',0m,5),
            };

        public FruitSlotGame(int rows, int cols)
            : base(rows, cols, slotItems)
        {
        }

    }
}
