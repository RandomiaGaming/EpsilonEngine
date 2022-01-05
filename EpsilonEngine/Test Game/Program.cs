using System;
using EpsilonEngine;
namespace TestGame
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Game testGame = new Game("EpsilonEngine Test Game");
            Scene mainScene = new Scene(testGame);
            GameObject testGameObject = new GameObject(mainScene);
            GameInterface monoGameInterface = new GameInterface(testGame);
            testGame.SetMonoGameInterface(monoGameInterface);
            testGame.Run();
        }
    }
}