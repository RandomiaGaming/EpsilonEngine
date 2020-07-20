using System;
namespace EpsilonEngine
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Epsilon_Engine_Kernal Kernal = new Epsilon_Engine_Kernal();
            Kernal.Run();
            Kernal.Dispose();
        }
    }
}
