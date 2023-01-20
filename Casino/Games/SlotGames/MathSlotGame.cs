using Casino.Attributes;
using Casino.Models;

namespace Casino.Games.SlotGames
{
    [SlotGame]
    public class MathSlotGame : SlotGameBase
    {
        private static SlotItem[] slotItems = new SlotItem[]
            {
                new SlotItem('+',0.4m,45),
                new SlotItem('-',0.6m,35),
                new SlotItem('*',0m,20),
            };

        public MathSlotGame(int rows, int cols)
            : base(rows, cols, slotItems)
        {
        }
    }
}
