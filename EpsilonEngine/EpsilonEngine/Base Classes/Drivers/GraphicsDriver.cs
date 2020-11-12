namespace EpsilonEngine
{
    public abstract class GraphicsDriver : GameManager
    {
        public GraphicsDriver(Game game) : base(game)
        {

        }
        public abstract Vector2Int GetViewPortRect();
        public abstract int GetRefreshRate();
        public abstract void Draw(Texture frame);
    }
}