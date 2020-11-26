using System;
namespace EpsilonEngine
{
    public class GameInterface
    {
        public Game game = null;
        public InputDriver inputDriver = null;
        public GraphicsDriver graphicsDriver = null;

        public GameInterface()
        {

        }

        public virtual void Initialize()
        {
            inputDriver.Initialize();
            graphicsDriver.Initialize();
        }

        public virtual void Update()
        {
            inputDriver.Update();
        }
    }
}
