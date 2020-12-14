using System;
namespace EpsilonEngine
{
    public class GameManager
    {
        public readonly GameInterface gameInterface = null;
        public readonly Game game = null;
        public GameManager(Game game)
        {
            if (game is null)
            {
                throw new NullReferenceException();
            }
            this.game = game;
            if (game.gameInterface is null)
            {
                throw new NullReferenceException();
            }
            this.gameInterface = game.gameInterface;
        }
        public virtual void Initialize()
        {

        }
        public virtual void Update()
        {

        }
        public virtual void Cleanup()
        {

        }
    }
}