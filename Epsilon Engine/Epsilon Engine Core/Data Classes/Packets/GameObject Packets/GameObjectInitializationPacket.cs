namespace EpsilonEngine
{
    public class GameObjectInitializationPacket
    {
        public Scene parent = null;
        public Platform platform = Platform.Unknown;
        public string[] args = new string[0];
    }
}