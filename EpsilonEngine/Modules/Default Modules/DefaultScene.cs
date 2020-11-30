using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public sealed class DefaultScene : SceneBase
    {
        private List<GameObjectBase> gameObjects = new List<GameObjectBase>();
        private List<int> gameObjectsToDestroy = new List<int>();
        private List<GameObjectBase> gameObjectsToInstantiate = new List<GameObjectBase>();

        public DefaultScene(GameBase game) : base(game)
        {

        }
        public override Texture Render()
        {
            return null;
        }
        public override void Update()
        {
            foreach (GameObjectBase go in gameObjects)
            {
                go.Update();
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

            foreach (GameObjectBase gameObjectToLoad in gameObjectsToInstantiate)
            {
                gameObjects.Add(gameObjectToLoad);
            }
            foreach (GameObjectBase gameObjectToLoad in gameObjectsToInstantiate)
            {
                gameObjectToLoad.Initialize();
            }
            gameObjectsToInstantiate = new List<GameObjectBase>();

            foreach (GameObjectBase gameObject in gameObjects)
            {
                gameObject.Cleanup();
            }
        }

        #region GameObject Management Methods
        public GameObjectBase GetGameObject(int index)
        {
            if (gameObjects is null)
            {
                gameObjects = new List<GameObjectBase>();
                return null;
            }
            if (index < 0 || index >= gameObjects.Count)
            {
                throw new ArgumentException();
            }
            return gameObjects[index];
        }
        public List<GameObjectBase> GetGameObjects()
        {
            return new List<GameObjectBase>(gameObjects);
        }
        public int GetGameObjectCount()
        {
            if (gameObjects is null)
            {
                gameObjects = new List<GameObjectBase>();
                return 0;
            }
            return gameObjects.Count;
        }
        public void DestroyGameObject(int index)
        {
            if (gameObjects is null)
            {
                gameObjects = new List<GameObjectBase>();
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
        public void DestroyGameObject(GameObjectBase target)
        {
            if (gameObjects is null)
            {
                gameObjects = new List<GameObjectBase>();
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
        public void InstantiateGameObject(GameObjectBase newGameObject)
        {
            if (gameObjectsToInstantiate is null)
            {
                gameObjectsToInstantiate = new List<GameObjectBase>();
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
