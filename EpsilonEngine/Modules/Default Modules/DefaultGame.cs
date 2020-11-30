using System.Collections.Generic;
using System;
namespace EpsilonEngine
{
    public class DefaultGame : GameBase
    {
        protected List<SceneBase> scenes = new List<SceneBase>();
        protected List<int> scenesToUnload = new List<int>();
        protected List<SceneBase> scenesToLoad = new List<SceneBase>();

        public Vector2Int viewPortRect = new Vector2Int(256, 144);
        public DefaultGame(GameInterfaceBase gameInterface) : base(gameInterface)
        {

        }

        public override void Update()
        {
            foreach (SceneBase scene in scenes)
            {
                scene.Update();
            }

            gameInterface.Draw(Render());

            Cleanup();
        }
        private Texture Render()
        {
            List<Texture> sceneRenders = new List<Texture>();
            foreach (SceneBase scene in scenes)
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
                return new Texture(256, 144, new Color(255, 255, 255, 0));
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
        public override void Cleanup()
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

            foreach (SceneBase sceneToLoad in scenesToLoad)
            {
                scenes.Add(sceneToLoad);
            }
            foreach (SceneBase sceneToLoad in scenesToLoad)
            {
                sceneToLoad.Initialize();
            }
            scenesToLoad = new List<SceneBase>();

            foreach (SceneBase scene in scenes)
            {
                scene.Cleanup();
            }
        }
        #region Scene Management Methods
        public virtual SceneBase GetScene(int index)
        {
            if (scenes is null)
            {
                scenes = new List<SceneBase>();
                return null;
            }
            if (index < 0 || index >= scenes.Count)
            {
                throw new ArgumentException();
            }
            return scenes[index];
        }
        public virtual List<SceneBase> GetScenes()
        {
            return new List<SceneBase>(scenes);
        }
        public virtual int GetSceneCount()
        {
            if (scenes is null)
            {
                scenes = new List<SceneBase>();
                return 0;
            }
            return scenes.Count;
        }
        public virtual void UnloadScene(int index)
        {
            if (scenes is null)
            {
                scenes = new List<SceneBase>();
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
        public virtual void UnloadScene(SceneBase target)
        {
            if (scenes is null)
            {
                scenes = new List<SceneBase>();
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
        public virtual void LoadScene(SceneBase newScene)
        {
            if (scenesToLoad is null)
            {
                scenesToLoad = new List<SceneBase>();
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