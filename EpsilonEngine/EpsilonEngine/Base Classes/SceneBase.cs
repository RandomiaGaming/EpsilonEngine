using System;
namespace EpsilonEngine
{
    public abstract class SceneBase
    {
        public readonly GameInterfaceBase gameInterface = null;
        public readonly GameBase game = null;
        public SceneBase(GameBase game)
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
            gameInterface = game.gameInterface;
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
        public abstract Texture Render();
    }
}
