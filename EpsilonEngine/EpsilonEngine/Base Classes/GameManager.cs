using System;

namespace EpsilonEngine
{
    public abstract class GameManager : Updatable
    {
        public readonly Game game;
        public readonly Machine machine;
        public GameManager(Game game)
        {
            if (game is null)
            {
                throw new NullReferenceException();
            }
            this.game = game;
            if (game.machine is null)
            {
                throw new NullReferenceException();
            }
            machine = game.machine;
        }
    }
}