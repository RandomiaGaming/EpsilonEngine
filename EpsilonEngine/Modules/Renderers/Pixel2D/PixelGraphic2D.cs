namespace EpsilonEngine.Modules.Renderers.Pixel2D
{
    public class PixelGraphic2D : Component
    {
        public Texture graphic = null;
        public Vector2Int offset = Vector2Int.Zero;
        public PixelGraphic2D(GameObject gameObject) : base(gameObject)
        {

        }

        public override void Initialize() { }
        public override void Update() { }
    }
}