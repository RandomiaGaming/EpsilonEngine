namespace EpsilonEngine
{
    public abstract class Renderer : GameManager
    {
        public Renderer(Game game) : base(game)
        {

        }
        public abstract Texture Render();
    }
}
