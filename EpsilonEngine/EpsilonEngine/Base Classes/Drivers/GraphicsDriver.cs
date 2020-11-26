using System;
namespace EpsilonEngine
{
    public abstract class GraphicsDriver
    {
        public readonly GameInterface gInterface;
        public GraphicsDriver(GameInterface gInterface)
        {
            if(gInterface is null)
            {
                throw new NullReferenceException();
            }
            this.gInterface = gInterface;
        }
        public virtual Vector2Int GetViewPortRect()
        {
            throw new NotSupportedException();
        }
        public virtual void Draw(Texture frame)
        {
            throw new NotSupportedException();
        }
        public virtual void Initialize()
        {

        }
    }
}