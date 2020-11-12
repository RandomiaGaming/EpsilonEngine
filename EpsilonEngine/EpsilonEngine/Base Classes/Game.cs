using System.Collections.Generic;
using System;
namespace EpsilonEngine
{
    public class Game
    {
        public List<string> ConsoleOutputBuffer = new List<string>();
        public List<string> ConsoleInputBuffer = new List<string>();

        public Random globalRandom = new Random();

        public List<GameObject> gameObjects = new List<GameObject>();
        public List<GameManager> gameManagers = new List<GameManager>();

        public AssetManager assetManager = null;
        public InputDriver inputDriver = null;
        public GraphicsDriver graphicsDriver = null;
        public Renderer renderer = null;

        public bool requestingToQuit = false;

        private bool test = false;

        public virtual void Update()
        {
            while(ConsoleInputBuffer.Count > 0)
            {
                if(ConsoleInputBuffer[0] == "Quit")
                {
                    requestingToQuit = true;
                }
                else if (ConsoleInputBuffer[0] == "No Render")
                {
                    test = !test;
                }
                else
                {
                    ConsoleOutputBuffer.Add($"\"{ConsoleInputBuffer[0]}\" is not a valid command.");
                }
                ConsoleInputBuffer.RemoveAt(0);
            }

            assetManager.Update();
            inputDriver.Update();
            graphicsDriver.Update();

            foreach (GameManager g in gameManagers.ToArray())
            {
                g.Update();
            }

            foreach (GameObject g in gameObjects.ToArray())
            {
                g.Update();
            }

            Texture frame = new Texture(256, 144, Color.Black);

            if (!test)
            {
                frame = renderer.Render();
            }

            graphicsDriver.Draw(frame);
        }
        public virtual void Initialize()
        {
            assetManager.Initialize();
            assetManager.LoadAssets();
            inputDriver.Initialize();

            foreach (GameManager g in gameManagers.ToArray())
            {
                g.Initialize();
            }

            foreach (GameObject g in gameObjects.ToArray())
            {
                g.Initialize();
            }

            graphicsDriver.Initialize();
        }
    }
}