using System;
namespace EpsilonEngine
{
    public class GameInterface
    {
        protected GraphicsDriver _GraphicsDriver = null;
        protected InputDriver _InputDriver = null;
        public InputDriver inputDriver
        {
            get
            {
                return _InputDriver;
            }
            set
            {
                if (running)
                {
                    throw new Exception("Cannot change \"inputDriver\" when game is running.");

                }
                else
                {
                    _InputDriver = value;
                }
            }
        }
        public GraphicsDriver graphicsDriver
        {
            get
            {
                return _GraphicsDriver;
            }
            set
            {
                if (running)
                {
                    throw new Exception("Cannot change \"graphicsDriver\" when game is running.");

                }
                else
                {
                    _GraphicsDriver = value;
                }
            }
        }
        protected bool running = false;
        public Game game { get; protected set; } = null;
        public GameInterface()
        {

        }
        public virtual void Run(Game game)
        {
            if (game is null || inputDriver is null || graphicsDriver is null)
            {
                throw new NullReferenceException();
            }
            if(game.gameInterface != this)
            {
                throw new ArgumentException();
            }
            running = true;
            this.game = game;
            inputDriver.Initialize();
            graphicsDriver.Initialize();
            game.Initialize();
            while (!game.requestingToQuit)
            {
                inputDriver.Update();
                game.Update();
            }
            running = false;
        }
    }
}
