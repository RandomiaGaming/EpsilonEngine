using System;
using EpsilonEngine.Projects.TestProj;
namespace Epsilon
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            EpsilonGame game = new EpsilonGame();
            game.Initialize();
        }
    }
}