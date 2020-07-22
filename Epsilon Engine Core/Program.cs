using System;
using System.Diagnostics;
namespace Epsilon_Engine.Internal
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Epsilon_Engine_Kernal.Consume_Thread();
        }
    }
}
