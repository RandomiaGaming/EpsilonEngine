using System;
using System.Collections.Generic;

namespace EpsilonEngine.Modules.Pixel2D
{
    public class Pixel2DScene : SceneBase
    {
        public Vector2Int cameraPosition = Vector2Int.Zero;
        private List<Pixel2DGameObject> gameObjects = new List<Pixel2DGameObject>();
        private List<int> gameObjectsToDestroy = new List<int>();
        private List<Pixel2DGameObject> gameObjectsToInstantiate = new List<Pixel2DGameObject>();
        public Pixel2DScene(GameBase game) : base(game)
        {

        }
        public override Texture Render()
        {
            Texture frame = new Texture(256, 144, new Color(255, 255, 155, 255));

            foreach (Pixel2DGameObject pixel2DGameObject in gameObjects)
            {
                if (pixel2DGameObject.texture is not null)
                {
                    TextureHelper.Blitz(pixel2DGameObject.texture, frame, new Vector2Int(pixel2DGameObject.position.x - cameraPosition.x, pixel2DGameObject.position.y - cameraPosition.y));
                }
            }

            return frame;
        }
        public override void Update()
        {
            foreach (Pixel2DGameObject pixel2DGameObject in gameObjects)
            {
                pixel2DGameObject.Update();
            }
        }
        public override void Cleanup()
        {
            if (gameObjectsToDestroy is null)
            {
                gameObjectsToDestroy = new List<int>();
            }
            gameObjectsToDestroy.Sort();
            foreach (int gameObjectID in gameObjectsToDestroy)
            {
                gameObjects.RemoveAt(gameObjectID);
            }
            gameObjectsToDestroy = new List<int>();

            foreach (Pixel2DGameObject gameObjectToLoad in gameObjectsToInstantiate)
            {
                gameObjects.Add(gameObjectToLoad);
            }
            foreach (Pixel2DGameObject gameObjectToLoad in gameObjectsToInstantiate)
            {
                gameObjectToLoad.Initialize();
            }
            gameObjectsToInstantiate = new List<Pixel2DGameObject>();

            foreach (Pixel2DGameObject gameObject in gameObjects)
            {
                gameObject.Cleanup();
            }
        }

        #region GameObject Management Methods
        public Pixel2DGameObject GetGameObject(int index)
        {
            if (gameObjects is null)
            {
                gameObjects = new List<Pixel2DGameObject>();
                return null;
            }
            if (index < 0 || index >= gameObjects.Count)
            {
                throw new ArgumentException();
            }
            return gameObjects[index];
        }
        public List<Pixel2DGameObject> GetGameObjects()
        {
            return new List<Pixel2DGameObject>(gameObjects);
        }
        public int GetGameObjectCount()
        {
            if (gameObjects is null)
            {
                gameObjects = new List<Pixel2DGameObject>();
                return 0;
            }
            return gameObjects.Count;
        }
        public void DestroyGameObject(int index)
        {
            if (gameObjects is null)
            {
                gameObjects = new List<Pixel2DGameObject>();
                return;
            }
            if (index < 0 || index >= gameObjects.Count)
            {
                throw new ArgumentException();
            }
            if (gameObjectsToDestroy is null)
            {
                gameObjectsToDestroy = new List<int>();
            }
            gameObjectsToDestroy.Add(index);
        }
        public void DestroyGameObject(Pixel2DGameObject target)
        {
            if (gameObjects is null)
            {
                gameObjects = new List<Pixel2DGameObject>();
                return;
            }
            if (target is null)
            {
                throw new NullReferenceException();
            }
            if (gameObjectsToDestroy is null)
            {
                gameObjectsToDestroy = new List<int>();
            }
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] == target)
                {
                    gameObjectsToDestroy.Add(i);
                }
            }
        }
        public void InstantiateGameObject(Pixel2DGameObject newGameObject)
        {
            if (gameObjectsToInstantiate is null)
            {
                gameObjectsToInstantiate = new List<Pixel2DGameObject>();
            }
            if (newGameObject is null)
            {
                throw new NullReferenceException();
            }
            gameObjectsToInstantiate.Add(newGameObject);
        }
        #endregion
    }
}
