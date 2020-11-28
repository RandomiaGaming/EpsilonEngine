using System;
namespace EpsilonEngine.Drivers.MonoGame
{
    public sealed class MonoGameGraphicsDriver : GraphicsDriver
    {
        private readonly MonoGameInterface monoGameInterface = null;
        public Texture frameBuffer = null;
        public MonoGameGraphicsDriver(GameInterface gameInterface) : base(gameInterface)
        {
            if(gameInterface is null)
            {
                throw new NullReferenceException();
            }
            if (!gameInterface.GetType().IsAssignableFrom(typeof(MonoGameInterface)))
            {
                throw new ArgumentException();
            }
            monoGameInterface = (MonoGameInterface)gameInterface;
        }
        public override void Draw(Texture frame)
        {
            frameBuffer = frame;
        }

        protected override Vector2Int GetViewPortRect()
        {
            return new Vector2Int(monoGameInterface.mgig.GraphicsDevice.Viewport.Width, monoGameInterface.mgig.GraphicsDevice.Viewport.Height);
        }

        public override void Initialize()
        {

        }
    }
}
