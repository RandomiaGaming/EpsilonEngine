using System.Collections.Generic;
using System;
namespace EpsilonEngine
{
    public class Game
    {
        public List<string> ConsoleOutputBuffer = new List<string>();
        public List<string> ConsoleInputBuffer = new List<string>();

        public List<Scene> scenes = new List<Scene>();
        public AssetManager assetManager = null;
        public GameRenderer renderer = null;
        public bool requestingToQuit = false;

        public GameInterface gameInterface = null;
        public Game(GameInterface gameInterface)
        {
            if(gameInterface is null)
            {
                throw new NullReferenceException();
            }
            this.gameInterface = gameInterface;
        }
        public virtual void Update()
        {
            foreach (Scene scene in scenes)
            {
                scene.Update();
            }

            gameInterface.graphicsDriver.Draw(renderer.Render());
        }
        public virtual void Initialize()
        {
            assetManager.LoadAssets();

            foreach (Scene scene in scenes)
            {
                scene.Initialize();
            }
        }
    }
}