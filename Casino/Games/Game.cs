using Casino.Games.Interfaces;

namespace Casino
{
    public abstract class Game : IGame
    {
        public abstract void Play();

        public void Quit()
        {
            WriteLine(GlobalConstants.QUIT);
            Environment.Exit(0);
        }
    }
}
