namespace EpsilonEngine
{
    public enum Platform { Windows, Mac, Linux, Unknown }
    public class GameInitializationPacket
    {
        public Platform platform = Platform.Unknown;
        public string[] args = new string[0];
    }
}