namespace EpsilonEngine
{
    public sealed class RenderInstruction
    {
        public Texture texture  = new Texture(1, 1);
        public Point position = Point.Zero;
        public RenderInstruction(Texture texture, Point position)
        {
            this.texture = texture;
            this.position = position;
        }
    }
}
