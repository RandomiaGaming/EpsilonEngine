namespace EpsilonEngine.Drivers.DirectX
{
    public sealed class DirectXGraphicsDriver : GraphicsDriver
    {
        public DirectXGraphicsDriver(GameInterface gameInterface) : base(gameInterface)
        {

        }
        public override void Draw(Texture frame)
        {

        }

        protected override Vector2Int GetViewPortRect()
        {
            return new Vector2Int(1920, 1080);
        }
    }
}