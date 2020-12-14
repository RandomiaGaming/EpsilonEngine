using System.Collections.Generic;
using System;
namespace EpsilonEngine
{
    public class Game
    {
        protected List<Scene> scenes = new List<Scene>();
        protected List<int> scenesToUnload = new List<int>();
        protected List<Scene> scenesToLoad = new List<Scene>();

        public Vector2Int viewPortRect = new Vector2Int(256, 144);
        public bool requestingToQuit { get; private set; } = false;
        public AssetManager assetManager;

        public readonly GameInterface gameInterface = null;
        public Game(GameInterface gameInterface)
        {
            if (gameInterface is null)
            {
                throw new NullReferenceException();
            }
            this.gameInterface = gameInterface;
            assetManager = new AssetManager(this);
        }
        public virtual void Initialize()
        {
            assetManager.RegisterDecoder(new ImageAssetDecoder());
            assetManager.LoadAllAssets();
        }
        public virtual void Update()
        {
            foreach (Scene scene in scenes)
            {
                scene.Update();
            }

            gameInterface.Draw(Render());

            Cleanup();
        }
        public virtual Texture Render()
        {
            List<Texture> sceneRenders = new List<Texture>();
            foreach (Scene scene in scenes)
            {
                Texture sceneRender = scene.Render();
                if (sceneRender.width == viewPortRect.x && sceneRender.height == viewPortRect.y)
                {
                    sceneRenders.Add(sceneRender);
                }
            }

            if (sceneRenders.Count == 1)
            {
                return sceneRenders[0];
            }
            else if (sceneRenders.Count == 0)
            {
                return null;
            }

            Texture frame = new Texture(256, 144);

            for (int x = 0; x < frame.width; x++)
            {
                for (int y = 0; y < frame.height; y++)
                {
                    Color pixelColor = new Color(255, 255, 255, 0);
                    foreach (Texture sceneRender in sceneRenders)
                    {
                        Color sceneColor = sceneRender.GetPixelUnsafe(x, y);
                        pixelColor = ColorHelper.Mix(pixelColor, sceneColor);
                        if (pixelColor.a == 255)
                        {
                            break;
                        }
                    }
                    frame.SetPixelUnsafe(x, y, pixelColor);
                }
            }

            return frame;
        }
        public virtual void Cleanup()
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

            foreach (Scene scene in scenes)
            {
                scene.Cleanup();
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