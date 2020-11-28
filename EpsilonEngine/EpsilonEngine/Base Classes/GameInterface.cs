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
        public virtual void Run()
        {
            Initialize();
            while (!game.requestingToQuit)
            {
                Tick();
            }
        }
        public virtual void Initialize()
        {
            inputDriver.Initialize();
            graphicsDriver.Initialize();
            game.Initialize();
        }
        public virtual void Tick()
        {
            inputDriver.Update();
            game.Update();
        }
    }
}
