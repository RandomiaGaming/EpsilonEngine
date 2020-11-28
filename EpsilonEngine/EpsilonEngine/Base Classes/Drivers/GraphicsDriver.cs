using System;
namespace EpsilonEngine
{
    public abstract class GraphicsDriver
    {
        public Vector2Int viewPortRect { get { return GetViewPortRect(); } private set { } }
        public readonly GameInterface gameInterface = null;
        public GraphicsDriver(GameInterface gameInterface)
        {
            if(gameInterface is null)
            {
                throw new NullReferenceException();
            }
            this.gameInterface = gameInterface;
        }
        protected abstract Vector2Int GetViewPortRect();
        public abstract void Draw(Texture frame);
        public virtual void Initialize()
        {

        }
        public virtual void Update()
        {

        }
    }
}