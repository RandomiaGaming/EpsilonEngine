namespace EpsilonEngine.Drivers.MonoGame
{
    public class MonoGameGraphicsDriver : GraphicsDriver
    {
        private MonogameInterfaceGame MGWInterfaceGame = null;
        public MonoGameGraphicsDriver(GameInterface gInterface) : base(gInterface)
        {

        }
        public override void Draw(Texture frame)
        {
            MGWInterfaceGame.frameBuffer = frame;
        }

        public override Vector2Int GetViewPortRect()
        {
            return new Vector2Int(MGWInterfaceGame.GraphicsDevice.Viewport.Width, MGWInterfaceGame.GraphicsDevice.Viewport.Height);
        }

        public override void Initialize()
        {
            MonogameInterfaceGame MGWIG = MonogameInterfaceGame.GetFromgInterface(gInterface);
            if (MGWIG != null)
            {
                MGWInterfaceGame = MGWIG;
            }
            else
            {
                MGWInterfaceGame = new MonogameInterfaceGame(gInterface);
            }
            MGWInterfaceGame.Run();
        }
    }
}
