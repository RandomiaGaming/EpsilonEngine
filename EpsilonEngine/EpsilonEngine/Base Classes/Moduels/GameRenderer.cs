using System;
namespace EpsilonEngine
{
    public abstract class GameRenderer
    {
        public readonly GameInterface gameInterface = null;
        public readonly Game game = null;
        public GameRenderer(Game game)
        {
            if (game is null)
            {
                throw new NullReferenceException();
            }
            this.game = game;
            if(game.gameInterface is null)
            {
                throw new NullReferenceException();
            }
            gameInterface = game.gameInterface;
        }
        public abstract Texture Render();
        public virtual void Update()
        {

        }
        public virtual void Initialize()
        {

        }
    }
}
