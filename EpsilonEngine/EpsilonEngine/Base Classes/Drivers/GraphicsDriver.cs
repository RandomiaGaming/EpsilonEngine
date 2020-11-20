using System;
namespace EpsilonEngine
{
    public abstract class GraphicsDriver : Updatable
    {
        public readonly Machine machine;
        public GraphicsDriver(Machine machine)
        {
            if(machine is null)
            {
                throw new NullReferenceException();
            }
            this.machine = machine;
        }
        public abstract Vector2Int GetViewPortRect();
        public abstract int GetRefreshRate();
        public abstract void Draw(Texture frame);
    }
}