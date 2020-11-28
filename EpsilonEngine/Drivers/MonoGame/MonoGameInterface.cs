namespace EpsilonEngine.Drivers.MonoGame
{
    public class MonoGameInterface : GameInterface
    {
        public readonly MonogameInterfaceGame mgig = null;
        public MonoGameInterface()
        {
            mgig = new MonogameInterfaceGame(this);
        }
        public override void Run()
        {
            base.Initialize();
            mgig.Run();
        }
    }
}
