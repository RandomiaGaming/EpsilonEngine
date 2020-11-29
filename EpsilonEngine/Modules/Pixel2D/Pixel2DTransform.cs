namespace EpsilonEngine.Modules.Pixel2D
{
    public sealed class Pixel2DTransform : Component
    {
        public Vector2Int position = Vector2Int.Zero;
        public Pixel2DTransform(GameObject gameObject) : base(gameObject)
        {

        }
        public Pixel2DTransform(GameObject gameObject, Vector2Int position) : base(gameObject)
        {
            this.position = position;
        }
    }
}
