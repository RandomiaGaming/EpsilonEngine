using System;
namespace EpsilonEngine.Modules.MonoGame
{
    public class MonoGameInterface : GameInterface
    {
        public readonly MonogameInterfaceGame mgig = null;
        public MonoGameInterface()
        {
            mgig = new MonogameInterfaceGame(this);
        }
        public override void Run(Game game)
        {
            if (game is null || inputDriver is null || graphicsDriver is null)
            {
                throw new NullReferenceException();
            }
            if (game.gameInterface != this)
            {
                throw new ArgumentException();
            }
            running = true;
            this.game = game;
            inputDriver.Initialize();
            graphicsDriver.Initialize();
            game.Initialize();
            mgig.Run();
            running = false;
        }
        public virtual void MonoGameUpdateCallBack()
        {
            inputDriver.Update();
            game.Update();
        }
    }
}
