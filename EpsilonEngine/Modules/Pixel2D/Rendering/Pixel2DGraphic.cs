namespace EpsilonEngine.Modules.Pixel2D
{
    public class Pixel2DGraphic : Component
    {
        public Texture graphic = null;
        public Vector2Int offset = Vector2Int.Zero;
        public Pixel2DGraphic(GameObject gameObject) : base(gameObject)
        {

        }
    }
}