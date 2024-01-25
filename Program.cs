using EpsilonEngine;

namespace TestProject
{
    public static class Program
    {
        [System.STAThread()]
        public static int Main()
        {
            TestGame game = new TestGame();
            game.Run();
            return 0;
        }
    }
}