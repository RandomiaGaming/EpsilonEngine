using System;

namespace EpsilonEngine
{
    public abstract class GameManager
    {
        public readonly Game game;
        public GameManager(Game game)
        {
            if (game is null)
            {
                throw new NullReferenceException();
            }
            this.game = game;
        }
        public virtual void Initialize()
        {

        }
        public virtual void Update()
        {

        }
    }
}