using System;
namespace EpsilonEngine.Internal
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            EpsilonKernal.Initialize(InitializationPacket.Create());
        }
    }
}
