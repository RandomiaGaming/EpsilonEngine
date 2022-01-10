using System;
using EpsilonEngine;
namespace TestGame
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            GameInterface gameInterface = new GameInterface();
            TestGame testGame = new TestGame(gameInterface);
            gameInterface.Run();
        }
    }
}