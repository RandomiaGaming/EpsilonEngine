using System;

namespace RG_Engine
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            RG_Engine_Kernal Kernal = new RG_Engine_Kernal();
            Kernal.Run();
            Kernal.Dispose();
        }
    }
}
