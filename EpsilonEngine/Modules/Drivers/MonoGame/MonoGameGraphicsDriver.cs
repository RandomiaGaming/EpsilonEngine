using System;
namespace EpsilonEngine.Modules.Drivers.MonoGame
{
    public class MonoGameGraphicsDriver : GraphicsDriver
    {
        private MonogameInterfaceGame MGWInterfaceGame = null;
        public MonoGameGraphicsDriver(Machine machine) : base(machine)
        {

        }
        public override void Draw(Texture frame)
        {
            MGWInterfaceGame.frameBuffer = frame;
        }

        public override int GetRefreshRate()
        {
            return 60;
        }

        public override Vector2Int GetViewPortRect()
        {
            return new Vector2Int(MGWInterfaceGame.GraphicsDevice.Viewport.Width, MGWInterfaceGame.GraphicsDevice.Viewport.Height);
        }

        public override void Initialize()
        {
            MonogameInterfaceGame MGWIG = MonogameInterfaceGame.GetFromEpsilonGame(null);
            if (MGWIG != null)
            {
                MGWInterfaceGame = MGWIG;
            }
            else
            {
                MGWInterfaceGame = new MonogameInterfaceGame(null);
            }
            MGWInterfaceGame.Run();
        }

        public override void Update() { }
    }
}
