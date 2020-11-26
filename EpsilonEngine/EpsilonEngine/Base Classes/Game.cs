using System.Collections.Generic;
using System;
namespace EpsilonEngine
{
    public class Game
    {
        public GameInterface gInterface = null;

        public List<string> ConsoleOutputBuffer = new List<string>();
        public List<string> ConsoleInputBuffer = new List<string>();

        public Random globalRandom = new Random();

        public List<Scene> scenes = new List<Scene>();
        public List<GameManager> gameManagers = new List<GameManager>();

        public AssetManager assetManager = null;

        public bool requestingToQuit = false;

        public Game(GameInterface gInterface)
        {
            if(gInterface == null)
            {
                throw new NullReferenceException();
            }
            this.gInterface = gInterface;
        }
        public virtual void Update()
        {
            assetManager.Update();
            gInterface.Update();

            foreach (GameManager g in gameManagers.ToArray())
            {
                g.Update();
            }

            foreach (Scene scene in scenes)
            {
                scene.Update();
            }

            Texture frame = frame = scenes[0].renderer.Render();
            gInterface.graphicsDriver.Draw(frame);
        }
        public virtual void Initialize()
        {
            assetManager.Initialize();
            assetManager.LoadAssets();

            foreach (GameManager g in gameManagers.ToArray())
            {
                g.Initialize();
            }

            foreach (Scene scene in scenes)
            {
                scene.Initialize();
            }

            gInterface.Initialize();
        }
    }
}