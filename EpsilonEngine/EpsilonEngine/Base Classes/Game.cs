using System.Collections.Generic;
using System;
namespace EpsilonEngine
{
    public class Game
    {
        protected List<Scene> scenes = new List<Scene>();
        protected List<int> scenesToUnload = new List<int>();
        protected List<Scene> scenesToLoad = new List<Scene>();

        public AssetManager assetManager = null;
        public GameRenderer renderer = null;
        public bool requestingToQuit { get; protected set; } = false;

        public readonly GameInterface gameInterface = null;
        public Game(GameInterface gameInterface)
        {
            if (gameInterface is null)
            {
                throw new NullReferenceException();
            }
            this.gameInterface = gameInterface;
        }

        public virtual void Update()
        {
            CullScenes();

            foreach (Scene scene in scenes)
            {
                scene.Update();
            }

            gameInterface.graphicsDriver.Draw(renderer.Render());
        }
        public virtual void Initialize()
        {
            assetManager.LoadAssets();
        }
        public virtual void CullScenes()
        {
            if (scenesToUnload is null)
            {
                scenesToUnload = new List<int>();
            }
            scenesToUnload.Sort();
            foreach (int sceneID in scenesToUnload)
            {
                scenes.RemoveAt(sceneID);
            }
            scenesToUnload = new List<int>();

            foreach (Scene sceneToLoad in scenesToLoad)
            {
                scenes.Add(sceneToLoad);
            }
            foreach (Scene sceneToLoad in scenesToLoad)
            {
                sceneToLoad.Initialize();
            }
            scenesToLoad = new List<Scene>();

            foreach(Scene scene in scenes)
            {
                scene.CullGameObjects();
            }
        }

        public virtual void Quit()
        {
            requestingToQuit = true;
        }

        #region Scene Management Methods
        public virtual Scene GetScene(int index)
        {
            if (scenes is null)
            {
                scenes = new List<Scene>();
                return null;
            }
            if (index < 0 || index >= scenes.Count)
            {
                throw new ArgumentException();
            }
            return scenes[index];
        }
        public virtual List<Scene> GetScenes()
        {
            return new List<Scene>(scenes);
        }
        public virtual int GetSceneCount()
        {
            if (scenes is null)
            {
                scenes = new List<Scene>();
                return 0;
            }
            return scenes.Count;
        }
        public virtual void UnloadScene(int index)
        {
            if (scenes is null)
            {
                scenes = new List<Scene>();
                return;
            }
            if (index < 0 || index >= scenes.Count)
            {
                throw new ArgumentException();
            }
            if (scenesToUnload is null)
            {
                scenesToUnload = new List<int>();
            }
            scenesToUnload.Add(index);
        }
        public virtual void UnloadScene(Scene target)
        {
            if (scenes is null)
            {
                scenes = new List<Scene>();
                return;
            }
            if (target is null)
            {
                throw new NullReferenceException();
            }
            if (scenesToUnload is null)
            {
                scenesToUnload = new List<int>();
            }
            for (int i = 0; i < scenes.Count; i++)
            {
                if (scenes[i] == target)
                {
                    scenesToUnload.Add(i);
                }
            }
        }
        public virtual void LoadScene(Scene newScene)
        {
            if (scenesToLoad is null)
            {
                scenesToLoad = new List<Scene>();
            }
            if (newScene is null)
            {
                throw new NullReferenceException();
            }
            scenesToLoad.Add(newScene);
        }
        #endregion
    }
}