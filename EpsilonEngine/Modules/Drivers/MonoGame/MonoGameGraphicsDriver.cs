using System;
namespace EpsilonEngine.Modules.Drivers.MonoGame
{
    public class MonoGameGraphicsDriver : GraphicsDriver
    {
        private MonogameInterfaceGame MGWInterfaceGame = null;
        public MonoGameGraphicsDriver(Game game) : base(game)
        {

        }
        public override void Draw(Texture frame)
        {
            MGWInterfaceGame.frameBuffer = frame;
        }

        public override int GetRefreshRate()
        {
            throw new NotImplementedException();
        }

        public override Vector2Int GetViewPortRect()
        {
            return new Vector2Int(MGWInterfaceGame.GraphicsDevice.Viewport.Width, MGWInterfaceGame.GraphicsDevice.Viewport.Height);
        }

        public override void Initialize()
        {
            MonogameInterfaceGame MGWIG = MonogameInterfaceGame.GetFromEpsilonGame(game);
            if (MGWIG != null)
            {
                MGWInterfaceGame = MGWIG;
            }
            else
            {
                MGWInterfaceGame = new MonogameInterfaceGame(game);
            }
            MGWInterfaceGame.Run();
        }
    }
}
