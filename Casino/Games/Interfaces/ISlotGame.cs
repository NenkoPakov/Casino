namespace Casino.Games.Interfaces
{
    public interface ISlotGame: IGame
    {
        public void PrintResult();
        public void CheckForWinnings();
        public void SpinSlot();
    }
}
