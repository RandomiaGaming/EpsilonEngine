using System;
namespace EpsilonEngine
{
    public abstract class GameBase
    {
        public bool requestingToQuit { get; private set; } = false;

        public readonly GameInterfaceBase gameInterface = null;
        public GameBase(GameInterfaceBase gameInterface)
        {
            if(gameInterface is null)
            {
                throw new NullReferenceException();
            }
            this.gameInterface = gameInterface;
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
        public void Quit()
        {
            requestingToQuit = true;
        }
    }
}